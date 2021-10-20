using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.UserRoles
{
    public class AddUserRolesRequest : RequestBase, IRequest<AddUserRolesResponse>
    {
        public string Name { get; set; }
    }
}
