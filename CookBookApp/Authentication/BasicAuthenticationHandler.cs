using CookBookApp.ApplicationServices.Components.PasswordHasher;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CookBookApp.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor,
            IPasswordHasher passwordHasher) : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();

            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            DataAccess.Entities.User user = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                
                var query = new GetUserByNameQuery()
                {
                    UserName = username
                };

                user = await this.queryExecutor.Execute(query);

                var hashedPassword = this.passwordHasher.HashPassword(password, user.Salt).Result;
                var isPasswordConfirmed = this.passwordHasher.IsPasswordConfirmed(user.HashedPassword, hashedPassword).Result;

                if(user==null || !isPasswordConfirmed)
                {
                    return AuthenticateResult.Fail("Invalid authorization header");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("invalid authorization header");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.UserRole.Name)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}