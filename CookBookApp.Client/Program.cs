using CookBookApp.Client.Services.AuthenticationService;
using CookBookApp.Client.Services.HttpService;
using CookBookApp.Client.Services.LocalStorageService;
using CookBookApp.Client.Services.ProductService;
using CookBookApp.Client.Services.UserService;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CookBookApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped(x =>
            {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);
                return new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();

            var authenticationSerivce = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationSerivce.Initialize();

            await host.RunAsync();


        }
    }
}
