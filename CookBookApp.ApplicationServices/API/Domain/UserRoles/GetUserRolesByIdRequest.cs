using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.UserRoles
{
    public class GetUserRolesByIdRequest : RequestBase, IRequest<GetUserRolesByIdResponse>
    {
        public int Id { get; set; }
    }
}
