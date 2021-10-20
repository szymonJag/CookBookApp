using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.Recipe
{
    public class DeleteRecipeCommand : CommandBase<Entities.Recipe, Entities.Recipe>
    {
        public override async Task<Entities.Recipe> Execute(CookBookAppContext context)
        {
            context.Recipes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
