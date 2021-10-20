using CookBookApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands
{
    public class AddProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(CookBookAppContext context)
        {
            await context.Product.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
