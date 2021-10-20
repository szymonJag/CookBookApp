using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class UserRole : EntityBase
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
