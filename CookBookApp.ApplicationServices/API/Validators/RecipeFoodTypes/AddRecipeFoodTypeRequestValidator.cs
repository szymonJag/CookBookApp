using CookBookApp.ApplicationServices.API.Domain.RecipeFoodType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Validators.RecipeFoodType
{
    public class AddRecipeFoodTypeRequestValidator : AbstractValidator<AddRecipeFoodTypeRequest>
    {
        public AddRecipeFoodTypeRequestValidator()
        {
            this.RuleFor(x => x.RecipeId).IsInEnum().NotEmpty();
            this.RuleFor(x => x.FoodTypeId).IsInEnum().NotEmpty();
        }
    }
}
