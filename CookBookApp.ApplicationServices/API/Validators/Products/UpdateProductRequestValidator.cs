using CookBookApp.ApplicationServices.API.Domain.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Validators.Product
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            this.RuleFor(x => x.Kcal).InclusiveBetween(0, 1000);
            this.RuleFor(x => x.Name).MaximumLength(20);
        }
    }
}
