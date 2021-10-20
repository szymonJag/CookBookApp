using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Ingredient
{
    public class GetIngredientsQuery : QueryBase<List<Entities.Ingredient>>
    {
        public override Task<List<Entities.Ingredient>> Execute(CookBookAppContext context)
        {
            return context.Ingredient
                .Include(x=>x.Product)
                .Include(x=>x.Unit)
                .ToListAsync();
        }
    }
}
