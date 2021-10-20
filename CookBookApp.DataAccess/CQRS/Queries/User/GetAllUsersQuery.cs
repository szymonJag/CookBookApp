using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.User
{
    public class GetAllUsersQuery : QueryBase<List<Entities.User>>
    {
        public override async Task<List<Entities.User>> Execute(CookBookAppContext context)
        {
            return await context.Users
                .Include(x => x.UserRole)
                .OrderBy(x => x.UserRole)
                .ToListAsync();
        }
    }
}
