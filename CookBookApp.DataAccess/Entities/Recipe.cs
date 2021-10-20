using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class Recipe : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public string Author { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
        //public int UserId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeFoodType> FoodTypes { get; set; }
    }
}
