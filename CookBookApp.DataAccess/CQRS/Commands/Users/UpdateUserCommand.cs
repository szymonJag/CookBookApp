using CookBookApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.Users
{
    public class UpdateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(CookBookAppContext context)
        {
            context.Users.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
