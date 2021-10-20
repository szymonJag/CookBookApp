using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class Ingredient : EntityBase
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        [Range(0, 9999)]
        public double Value { get; set; }

        public Recipe Recipe { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }

        
    }
}
