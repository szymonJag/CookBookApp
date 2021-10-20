using MediatR;

namespace CookBookApp.ApplicationServices.API.Domain.Users
{
    public class GetUserByIdRequest : RequestBase, IRequest<GetUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}
