using CookBookApp.ApplicationServices.API.Domain.Users;
using FluentValidation;

namespace CookBookApp.ApplicationServices.API.Validators.User
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            this.RuleFor(x => x.UserName).MaximumLength(30).NotEmpty();
            this.RuleFor(x => x.Password).MinimumLength(6).MaximumLength(20).NotEmpty();
        }
    }
}
