using MediatR;

namespace CookBookApp.ApplicationServices.API.Domain.Users
{
    public class ChangeUserRoleRequest : RequestBase, IRequest<ChangeUserRoleResponse>
    {
        public int UserId { get; set; }
    }
}
