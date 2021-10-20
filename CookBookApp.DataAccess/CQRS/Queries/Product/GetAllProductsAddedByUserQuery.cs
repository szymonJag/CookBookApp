using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Product
{
    public class GetAllProductsAddedByUserQuery : QueryBase<List<Entities.Product>>
    {
        public string Username { get; set; }
        public async override Task<List<Entities.Product>> Execute(CookBookAppContext context)
        {
            return await context.Product.Where(x => x.Author == Username).ToListAsync();
        }
    }
}
