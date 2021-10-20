using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.Unit
{
    public class AddUnitCommand : CommandBase<Entities.Unit, Entities.Unit>
    {
        public override async Task<Entities.Unit> Execute(CookBookAppContext context)
        {
            context.Unit.Add(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
