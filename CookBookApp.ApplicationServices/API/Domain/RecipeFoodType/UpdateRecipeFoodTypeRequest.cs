using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.RecipeFoodType
{
    public class UpdateRecipeFoodTypeRequest : RequestBase, IRequest<UpdateRecipeFoodTypeResponse>
    {
        public int RecipeFoodTypeId { get; set; }
        public int RecipeId { get; set; }
        public int FoodTypeId { get; set; }
    }
}
