using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.UserRoles
{
    public class DeleteUserRolesRequest : RequestBase, IRequest<DeleteUserRolesResponse>
    {
        public int UserRoleId { get; set; }
    }
}
