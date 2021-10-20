using CookBookApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.Users
{
    public class DeleteUserCommand : CommandBase<Entities.User, Entities.User>
    {
        public override async Task<User> Execute(CookBookAppContext context)
        {
            context.Users.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
