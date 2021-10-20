using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Users;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.ApplicationServices.Components.PasswordHasher;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Users;
using CookBookApp.DataAccess.CQRS.Queries.UserRole;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.User
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            //id zwyklego usera
            var userRoleId = 2;
            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            var salt = this.passwordHasher.GenerateSalt().Result;
            var hashedPassword = this.passwordHasher.HashPassword(request.Password, salt).Result;

            var getUserRoleQuery = new GetUserRolesByIdQuery()
            {
                Id = userRoleId
            };

            user.Salt = salt;
            user.HashedPassword = hashedPassword;
            user.UserRoleId = userRoleId;
            user.UserRole = this.queryExecutor.Execute(getUserRoleQuery).Result;

            var addUserCommand = new AddUserCommand()
            {
                Parameter = user
            };
            var addedUser = this.commandExecutor.Execute(addUserCommand).Result;

            if (addedUser == null)
            {
                return new AddUserResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.ValidationError)
                };
            }

            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(addedUser)
            };
        }
    }
}
