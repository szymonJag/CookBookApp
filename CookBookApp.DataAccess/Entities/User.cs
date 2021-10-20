using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
