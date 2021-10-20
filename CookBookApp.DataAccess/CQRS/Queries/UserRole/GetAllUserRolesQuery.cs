using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.UserRole
{
    public class GetAllUserRolesQuery : QueryBase<List<Entities.UserRole>>
    {
        public override async Task<List<Entities.UserRole>> Execute(CookBookAppContext context)
        {
            return await context.Roles.ToListAsync();
        }
    }
}
