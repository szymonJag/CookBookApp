using CookBookApp.ApplicationServices.API.Domain.Recipes;
using FluentValidation;

namespace CookBookApp.ApplicationServices.API.Validators.Recipes
{
    public class UpdateRecipeRequestValidator : AbstractValidator<UpdateRecipeRequest>
    {
        public UpdateRecipeRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(100);
            this.RuleFor(x => x.Description).MaximumLength(2000);
        }
    }
}
