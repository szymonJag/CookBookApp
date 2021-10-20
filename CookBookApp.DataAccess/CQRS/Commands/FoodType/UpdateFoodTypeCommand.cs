using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.FoodType
{
    public class UpdateFoodTypeCommand : CommandBase<Entities.FoodType, Entities.FoodType>
    {
        public override async Task<Entities.FoodType> Execute(CookBookAppContext context)
        {
            context.FoodTypes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
