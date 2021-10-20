using CookBookApp.ApplicationServices.API.Domain.RecipeFoodType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Validators.RecipeFoodType
{
    public class UpdateRecipeFoodTypeRequestValidator : AbstractValidator<UpdateRecipeFoodTypeRequest>
    {
        public UpdateRecipeFoodTypeRequestValidator()
        {
            this.RuleFor(x => x.RecipeId).IsInEnum();
            this.RuleFor(x => x.FoodTypeId).IsInEnum();
        }
    }
}
