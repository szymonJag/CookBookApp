using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.FoodType
{
    public class AddFoodTypeCommand : CommandBase<Entities.FoodType, Entities.FoodType>
    {
        public override async Task<Entities.FoodType> Execute(CookBookAppContext context)
        {
            await context.FoodTypes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
