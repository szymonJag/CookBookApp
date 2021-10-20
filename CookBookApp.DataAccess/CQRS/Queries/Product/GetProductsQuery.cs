using CookBookApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries
{
    public class GetProductsQuery : QueryBase<List<Entities.Product>>
    {
        public string Name { get; set; }
        public override Task<List<Entities.Product>> Execute(CookBookAppContext context)
        {
            var productsList = context.Product
                .Include(x => x.ProductType)
                .ToListAsync();

            if (this.Name!=null)
            {
                productsList = context.Product
                    .Where(x => x.Name.Contains(this.Name))
                    .ToListAsync();
            }

            return productsList;
        }
    }
}
