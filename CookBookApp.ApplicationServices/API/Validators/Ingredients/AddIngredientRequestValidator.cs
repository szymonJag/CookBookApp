using CookBookApp.ApplicationServices.API.Domain.Ingredients;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Validators.Ingredients
{
    public class AddIngredientRequestValidator : AbstractValidator<AddIngredientRequest>
    {
        public AddIngredientRequestValidator()
        {
            this.RuleFor(x => x.ProductId).NotEmpty().IsInEnum();
            this.RuleFor(x => x.UnitId).NotEmpty().IsInEnum();
            this.RuleFor(x => x.RecipeId).NotEmpty().IsInEnum();
        }
    }
}
