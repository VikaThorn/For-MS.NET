using FluentValidation;
using LostPropertyOffice.BL.Users.Entity;

namespace LostPropertyOffice.Service.Controllers
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage("Role is required");

            RuleFor(x => x.Login)
                .NotEmpty()
                .Matches(@"[\w_]+")
                .WithMessage("Login is required");

            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required");

            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.EmailAddress))
                .WithMessage("Email must be a valid email address");

            RuleFor(x => x.Position)
                .NotEmpty()
                .WithMessage("Position is required");
        }
    }
}