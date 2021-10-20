using MediatR;

namespace CookBookApp.ApplicationServices.API.Domain
{
    public class GetProductsRequest : RequestBase, IRequest<GetProductsResponse>
    {
        public string Name { get; set; }
    }
}
