using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Recipe
{
    public class GetUnacceptedRecipesQuery : QueryBase<List<Entities.Recipe>>
    {
        public override async Task<List<Entities.Recipe>> Execute(CookBookAppContext context)
        {
            return await context.Recipes
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Product)
                .Include(x => x.FoodTypes)
                    .ThenInclude(x => x.FoodType)
                .Where(x => !x.IsAcceptedByAdmin).ToListAsync();
        }
    }
}
