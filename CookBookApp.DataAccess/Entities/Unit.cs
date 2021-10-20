using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class Unit : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
