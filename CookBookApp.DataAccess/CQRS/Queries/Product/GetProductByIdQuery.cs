using CookBookApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries
{
    public class GetProductByIdQuery : QueryBase<Entities.Product>
    {
        public int Id { get; set; }
        public override async Task<Entities.Product> Execute(CookBookAppContext context)
        {
            var product = await context.Product
                .Include(x => x.ProductType)
                .FirstOrDefaultAsync(x => x.Id == Id);

            return product;
        }
    }
}
