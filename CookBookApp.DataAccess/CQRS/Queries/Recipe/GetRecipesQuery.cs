using CookBookApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries
{
    public class GetRecipesQuery : QueryBase<List<Entities.Recipe>>
    {
        public override Task<List<Entities.Recipe>> Execute(CookBookAppContext context)
        {
            return context.Recipes
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Product)
                .Include(x => x.FoodTypes)
                    .ThenInclude(x => x.FoodType)
                .ToListAsync();
        }
    }
}
