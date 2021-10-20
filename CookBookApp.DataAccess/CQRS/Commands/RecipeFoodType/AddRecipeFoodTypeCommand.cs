using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.RecipeFoodType
{
    public class AddRecipeFoodTypeCommand : CommandBase<Entities.RecipeFoodType, Entities.RecipeFoodType>
    {
        public override async Task<Entities.RecipeFoodType> Execute(CookBookAppContext context)
        {
            var foodTypesList = await context.RecipeFoodTypes.Where(x => x.RecipeId == this.Parameter.RecipeId).Select(x => x.FoodTypeId).ToListAsync();

            if (foodTypesList.Contains(Parameter.FoodTypeId))
            {
                return this.Parameter;
            }

            await context.RecipeFoodTypes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
