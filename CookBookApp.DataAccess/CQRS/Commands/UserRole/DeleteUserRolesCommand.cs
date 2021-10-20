using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Commands.UserRole
{
    public class DeleteUserRolesCommand : CommandBase<Entities.UserRole, Entities.UserRole>
    {
        public override async Task<Entities.UserRole> Execute(CookBookAppContext context)
        {
            context.Roles.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
