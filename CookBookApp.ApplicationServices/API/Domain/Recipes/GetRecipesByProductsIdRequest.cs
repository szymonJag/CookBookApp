using MediatR;
using System.Collections.Generic;

namespace CookBookApp.ApplicationServices.API.Domain.Recipes
{
    public class GetRecipesByProductsIdRequest : RequestBase, IRequest<GetRecipesByProductsIdResponse>
    {
        public List<int> ProductsId { get; set; }
    }
}
