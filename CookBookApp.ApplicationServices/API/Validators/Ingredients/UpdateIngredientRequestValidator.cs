using CookBookApp.ApplicationServices.API.Domain.Ingredients;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Validators.Ingredients
{
    public class UpdateIngredientRequestValidator : AbstractValidator<UpdateIngredientRequest>
    {
        public UpdateIngredientRequestValidator()
        {
            this.RuleFor(x => x.ProductId).IsInEnum();
            this.RuleFor(x => x.RecipeId).IsInEnum();
            this.RuleFor(x => x.UnitId).IsInEnum();
        }
    }
}
