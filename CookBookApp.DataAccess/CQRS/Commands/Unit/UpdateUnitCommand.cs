using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.Unit
{
    public class UpdateUnitCommand : CommandBase<Entities.Unit, Entities.Unit>
    {
        public override async Task<Entities.Unit> Execute(CookBookAppContext context)
        {
            context.Unit.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
