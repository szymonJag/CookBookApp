using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Users
{
    public class AddUserRequest : RequestBase, IRequest<AddUserResponse>
    {
        new public string UserName { get; set; }
        public string Password { get; set; }
    }
}
