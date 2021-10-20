using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Ingredients
{
    public class AddIngredientRequest : RequestBase, IRequest<AddIngredientResponse>
    {
        public int UnitId { get; set; }
        public int RecipeId { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
    }
}
