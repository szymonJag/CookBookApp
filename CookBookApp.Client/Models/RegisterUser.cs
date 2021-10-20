using System.ComponentModel.DataAnnotations;

namespace CookBookApp.Client.Models
{
    public class RegisterUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
