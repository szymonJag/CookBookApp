using CookBookApp.Client.Models;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        User User { get; }

        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}