using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.User
{
    public class GetUserByIdQuery : QueryBase<Entities.User>
    {
        public int UserId { get; set; }
        public async override Task<Entities.User> Execute(CookBookAppContext context)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == UserId);
        }
    }
}
