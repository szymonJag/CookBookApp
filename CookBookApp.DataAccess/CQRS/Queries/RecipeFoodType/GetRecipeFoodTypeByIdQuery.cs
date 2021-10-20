using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.RecipeFoodType
{
    public class GetRecipeFoodTypeByIdQuery : QueryBase<Entities.RecipeFoodType>
    {
        public int RecipeFoodTypeId { get; set; }
        public override async Task<Entities.RecipeFoodType> Execute(CookBookAppContext context)
        {
            return await context.RecipeFoodTypes
                .Include(x=>x.FoodType)
                .Include(x=>x.Recipe)
                .FirstOrDefaultAsync(x => x.Id == RecipeFoodTypeId);
        }
    }
}
