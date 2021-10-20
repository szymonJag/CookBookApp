using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.Recipe
{
    public class UpdateRecipeCommand : CommandBase<Entities.Recipe, Entities.Recipe>
    {
        public override async Task<Entities.Recipe> Execute(CookBookAppContext context)
        {
            context.Recipes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
