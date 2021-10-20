using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class RecipeFoodType : EntityBase
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int FoodTypeId { get; set; }
        public Recipe Recipe { get; set; }
        public FoodType FoodType { get; set; }
    }
}
