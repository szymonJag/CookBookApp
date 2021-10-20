using CookBookApp.ApplicationServices.API.Domain.Recipes;
using FluentValidation;

namespace CookBookApp.ApplicationServices.API.Validators.Recipes
{
    public class AddRecipeRequestValidator : AbstractValidator<AddRecipeRequest>
    {
        public AddRecipeRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(100).NotEmpty();
            this.RuleFor(x => x.Description).MaximumLength(2000).NotEmpty();
        }
    }
}
