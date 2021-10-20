using CookBookApp.Client.Helpers;
using CookBookApp.Client.Models;
using CookBookApp.Client.Services.HttpService;
using CookBookApp.Client.Services.LocalStorageService;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CookBookApp.Client.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpService httpService;
        private readonly NavigationManager navigationManager;
        private readonly ILocalStorageService localStorageService;
        private readonly HttpClient httpClient;
        public User User { get; private set; } = null;
        public AuthenticationService(IHttpService httpService, NavigationManager navigationManager, ILocalStorageService localStorageService, HttpClient httpClient)
        {
            this.httpService = httpService;
            this.navigationManager = navigationManager;
            this.localStorageService = localStorageService;
            this.httpClient = httpClient;
        }

        public async Task Initialize()
        {
            User = await localStorageService.GetItem<User>("user");
        }

        public async Task Login(string username, string password)
        {
            User = await this.httpService.Post<User>("api/Users/authenticate", new { username, password });
            User.AuthData = $"{username}:{password}".EncodeBase64();
            await localStorageService.SetItem("user", User);
        }
        public async Task Logout()
        {
            User = null;
            await localStorageService.RemoveItem("user");
            navigationManager.NavigateTo("/");
        }

    }
}
