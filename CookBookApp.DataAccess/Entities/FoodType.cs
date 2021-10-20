using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class FoodType : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
