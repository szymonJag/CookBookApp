using System.Collections.Generic;

namespace CookBookApp.ApplicationServices.API.Domain.Models
{
    public class Recipe 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeFoodType> FoodTypes { get; set; }
        public string Author { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
    }
}
