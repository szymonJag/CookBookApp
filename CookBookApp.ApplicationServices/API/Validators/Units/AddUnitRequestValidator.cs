using CookBookApp.ApplicationServices.API.Domain.Units;
using FluentValidation;

namespace CookBookApp.ApplicationServices.API.Validators.Units
{
    public class AddUnitRequestValidator : AbstractValidator<AddUnitRequest>
    {
        public AddUnitRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(30).NotEmpty();
        }
    }
}
