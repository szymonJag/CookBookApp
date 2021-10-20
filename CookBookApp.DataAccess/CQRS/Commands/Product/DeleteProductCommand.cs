using CookBookApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands
{
    public class DeleteProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(CookBookAppContext context)
        {
            context.Product.Remove(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
