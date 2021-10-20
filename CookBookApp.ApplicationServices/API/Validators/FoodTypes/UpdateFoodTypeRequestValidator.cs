using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using FluentValidation;

namespace CookBookApp.ApplicationServices.API.Validators.FoodTypes
{
    public class UpdateFoodTypeRequestValidator : AbstractValidator<UpdateFoodTypeRequest>
    {
        public UpdateFoodTypeRequestValidator()
        {
            this.RuleFor(x => x.FoodTypeName).MaximumLength(20);
        }
    }
}
