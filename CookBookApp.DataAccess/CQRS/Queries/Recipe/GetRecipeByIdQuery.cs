using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Recipe
{
    public class GetRecipeByIdQuery : QueryBase<Entities.Recipe>
    {
        public int RecipeId { get; set; }
        public override async Task<Entities.Recipe> Execute(CookBookAppContext context)
        {
            return await context.Recipes
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Product)
                .Include(x => x.FoodTypes)
                    .ThenInclude(x => x.FoodType)
                .FirstOrDefaultAsync(x => x.Id == RecipeId);
        }
    }
}
