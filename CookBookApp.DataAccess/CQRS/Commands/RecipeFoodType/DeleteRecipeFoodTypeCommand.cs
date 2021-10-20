using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.RecipeFoodType
{
    public class DeleteRecipeFoodTypeCommand : CommandBase<Entities.RecipeFoodType, Entities.RecipeFoodType>
    {
        public override async Task<Entities.RecipeFoodType> Execute(CookBookAppContext context)
        {
            context.RecipeFoodTypes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
