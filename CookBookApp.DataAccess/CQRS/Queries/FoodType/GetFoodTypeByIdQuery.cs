using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.FoodType
{
    public class GetFoodTypeByIdQuery : QueryBase<Entities.FoodType>
    {
        public int FoodTypeId { get; set; }
        public override async Task<Entities.FoodType> Execute(CookBookAppContext context)
        {
            return await context.FoodTypes.FirstOrDefaultAsync(x => x.Id == FoodTypeId);
        }
    }
}
