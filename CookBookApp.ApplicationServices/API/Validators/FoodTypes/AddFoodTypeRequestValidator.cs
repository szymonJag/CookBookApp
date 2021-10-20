using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Validators.FoodTypes
{
    public class AddFoodTypeRequestValidator : AbstractValidator<AddFoodTypeRequest>
    {
        public AddFoodTypeRequestValidator()
        {
            this.RuleFor(x => x.FoodTypeName).MaximumLength(20).NotEmpty();
        }
    }
}
