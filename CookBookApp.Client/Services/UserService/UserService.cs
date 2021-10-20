using CookBookApp.Client.Models;
using CookBookApp.Client.Services.HttpService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpService httpService;
        private readonly string apiUrl = "https://cobook.azurewebsites.net/api";

        public UserService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task Register(RegisterUser user)
        {
            await httpService.Post<RegisterUser>($"{apiUrl}/Users", new { user.Username, user.Password });
        }

        public async Task DeleteUser(User user)
        {
            await httpService.Delete<User>($"{apiUrl}/Users/{user.Id}");
        }

        public async Task ChangeUserPermission(User user)
        {
            await httpService.Put<User>($"{apiUrl}/Users/changeRole/{user.Id}", new { user.Id });
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await httpService.Get<List<User>>($"{apiUrl}/Users");
        }

    }
}
