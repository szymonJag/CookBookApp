using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.FoodType
{
    public class GetFoodTypesQuery : QueryBase<List<Entities.FoodType>>
    {
        public override async Task<List<Entities.FoodType>> Execute(CookBookAppContext context)
        {
            return await context.FoodTypes.ToListAsync();
        }
    }
}
