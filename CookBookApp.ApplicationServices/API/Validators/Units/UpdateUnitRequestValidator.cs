using CookBookApp.ApplicationServices.API.Domain.Units;
using FluentValidation;

namespace CookBookApp.ApplicationServices.API.Validators.Units
{
    public class UpdateUnitRequestValidator : AbstractValidator<UpdateUnitRequest>
    {
        public UpdateUnitRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(30);
        }
    }
}
