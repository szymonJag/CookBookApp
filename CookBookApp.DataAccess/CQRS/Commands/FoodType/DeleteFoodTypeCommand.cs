using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.FoodType
{
    public class DeleteFoodTypeCommand : CommandBase<Entities.FoodType, Entities.FoodType>
    {
        public override async Task<Entities.FoodType> Execute(CookBookAppContext context)
        {
            context.FoodTypes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
