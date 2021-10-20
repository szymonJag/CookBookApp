using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.User
{
    public class GetUserByNameQuery : QueryBase<Entities.User>
    {
        public string UserName { get; set; }
        public override async Task<Entities.User> Execute(CookBookAppContext context)
        {
            return await context.Users
                .Include(x => x.UserRole)
                .FirstOrDefaultAsync(x => x.Username.ToLower() == UserName.ToLower());
        }
    }
}
