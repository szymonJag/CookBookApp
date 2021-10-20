using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.Ingredient
{
    public class DeleteIngredientCommand : CommandBase<Entities.Ingredient, Entities.Ingredient>
    {
        public override async Task<Entities.Ingredient> Execute(CookBookAppContext context)
        {
            context.Ingredient.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
