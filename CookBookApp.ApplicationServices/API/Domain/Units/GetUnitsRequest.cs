using MediatR;

namespace CookBookApp.ApplicationServices.API.Domain
{
    public class GetUnitsRequest : RequestBase, IRequest<GetUnitsResponse>
    {
    }
}
