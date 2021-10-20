using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.UserRole
{
    public class GetUserRolesByIdQuery : QueryBase<Entities.UserRole>
    {
        public int Id { get; set; }
        public override async Task<Entities.UserRole> Execute(CookBookAppContext context)
        {
            return await context.Roles.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
