using CookBookApp.DataAccess.Entities;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands
{
    public class UpdateProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(CookBookAppContext context)
        {
            context.Product.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
