using CookBookApp.Client.Models;
using CookBookApp.Client.Services.LocalStorageService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services.HttpService
{
    public class HttpService : IHttpService
    {
        private HttpClient httpClient;
        private NavigationManager navigationManager;
        private ILocalStorageService localStorageService;

        public HttpService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
            this.localStorageService = localStorageService;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }

        public Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            var jsonSerializer = JsonSerializer.Serialize(value);
            request.Content = new StringContent(jsonSerializer, Encoding.UTF8, "application/json");
            return SendRequest<T>(request);
        }

        public Task<T> Put<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return SendRequest<T>(request);
        }

        public Task<T> Delete<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            return SendRequest<T>(request);
        }
        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            var user = await this.localStorageService.GetItem<User>("user");
            var isApiUrl = request.RequestUri.IsAbsoluteUri;

            if (user != null && isApiUrl)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", user.AuthData);
            }

            using var response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                navigationManager.NavigateTo("logout");
                return default;
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var result = await response.Content.ReadFromJsonAsync<Response<T>>();
            return result.Data;
        }
    }
}
