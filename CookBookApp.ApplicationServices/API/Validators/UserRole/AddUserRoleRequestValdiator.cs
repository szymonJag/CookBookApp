using CookBookApp.ApplicationServices.API.Domain.UserRoles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Validators.UserRole
{
    public class AddUserRoleRequestValdiator : AbstractValidator<AddUserRolesRequest>
    {
        public AddUserRoleRequestValdiator()
        {
            this.RuleFor(x => x.Name).MaximumLength(10).NotEmpty();
        }
    }
}
