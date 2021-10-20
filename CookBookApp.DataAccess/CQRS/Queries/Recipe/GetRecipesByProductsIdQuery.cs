using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Recipe
{
    public class GetRecipesByProductsIdQuery : QueryBase<List<Entities.Recipe>>
    {
        public List<int> ProductsId { get; set; }
        public override async Task<List<Entities.Recipe>> Execute(CookBookAppContext context)
        {
            var dict = new Dictionary<Entities.Recipe, int>();

            var listOfProducts = context.Product
                .Where(x => ProductsId.Contains(x.Id))
                .ToListAsync()
                .Result;

            var listOfRecipes = context.Recipes
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Product)
                .Include(x => x.FoodTypes)
                    .ThenInclude(x => x.FoodType)
                .ToListAsync().Result;

            foreach(var recipe in listOfRecipes)
            {
                var listOfProductsFromRecipe = recipe.Ingredients.Select(x => x.Product).ToList();
                var countOfMatchingProducts = listOfProductsFromRecipe.Where(x => listOfProducts.Contains(x)).Count();
                
                if (countOfMatchingProducts > 0) 
                    dict.Add(recipe, countOfMatchingProducts);
            }
            var recipeListWithMatchingProducts = dict.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            return await Task.FromResult(recipeListWithMatchingProducts);
        }
    }
}
