using CookBookApp.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services.UserService
{
    public interface IUserService
    {
        Task ChangeUserPermission(User user);
        Task DeleteUser(User user);
        Task<List<User>> GetAllUsers();
        Task Register(RegisterUser user);
    }
}