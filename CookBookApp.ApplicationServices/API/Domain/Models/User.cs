namespace CookBookApp.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
    }
}
