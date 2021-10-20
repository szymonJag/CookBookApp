using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.ProductType
{
    public class GetProductTypesQuery : QueryBase<List<Entities.ProductType>>
    {
        public override Task<List<Entities.ProductType>> Execute(CookBookAppContext context)
        {
            return context.ProductTypes.ToListAsync();
        }
    }
}
