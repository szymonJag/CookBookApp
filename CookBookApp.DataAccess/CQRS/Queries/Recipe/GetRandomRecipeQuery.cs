using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Recipe
{
    public class GetRandomRecipeQuery : QueryBase<Entities.Recipe>
    {
        public override async Task<Entities.Recipe> Execute(CookBookAppContext context)
        {
            var numberOfRecipes = context.Recipes.Count();
            var rand = new Random();
            var skip = (int)(rand.NextDouble() * numberOfRecipes);

            return await context.Recipes
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Product)
                .Include(x => x.FoodTypes)
                    .ThenInclude(x => x.FoodType)
                .OrderBy(x => x.Id).Skip(skip).Take(1).FirstOrDefaultAsync();
        }
    }
}
