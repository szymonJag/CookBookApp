using CookBookApp.ApplicationServices.API.Domain;
using FluentValidation;

namespace CookBookApp.ApplicationServices.API.Validators.Product
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            this.RuleFor(x => x.Kcal).GreaterThan(0).NotEmpty();
            this.RuleFor(x => x.Name).Length(1, 30).NotEmpty();
        }
    }
}
