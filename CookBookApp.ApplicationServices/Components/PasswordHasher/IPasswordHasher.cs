using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.Components.PasswordHasher
{
    public interface IPasswordHasher
    {
        Task<string> GenerateSalt();
        Task<string> HashPassword(string password, string salt);
        Task<bool> IsPasswordConfirmed(string firstPassword, string secondPassword);
    }
}