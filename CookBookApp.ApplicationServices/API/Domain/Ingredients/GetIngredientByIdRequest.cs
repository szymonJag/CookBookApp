using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Ingredients
{
    public class GetIngredientByIdRequest : RequestBase, IRequest<GetIngredientByIdResponse>
    {
        public int IngredientId { get; set; }
    }
}
