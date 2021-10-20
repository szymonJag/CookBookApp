using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Recipe
{
    public class GetRecipeByNameQuery : QueryBase<Entities.Recipe>
    {
        public string RecipeName { get; set; }
        public override Task<Entities.Recipe> Execute(CookBookAppContext context)
        {
            return context.Recipes
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Product)
                .Include(x => x.FoodTypes)
                    .ThenInclude(x => x.FoodType)
                .FirstOrDefaultAsync(x => x.Name.ToLower().Contains(RecipeName.ToLower()));
        }
    }
}
