using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Recipes
{
    public class GetRecipeByIdRequest : RequestBase, IRequest<GetRecipeByIdResponse>
    {
        public int RecipeId { get; set; }
    }
}
