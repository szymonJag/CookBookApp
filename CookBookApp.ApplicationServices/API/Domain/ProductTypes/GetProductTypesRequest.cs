using MediatR;

namespace CookBookApp.ApplicationServices.API.Domain.ProductTypes
{
    public class GetProductTypesRequest : RequestBase, IRequest<GetProductTypesResponse>
    {
    }
}
