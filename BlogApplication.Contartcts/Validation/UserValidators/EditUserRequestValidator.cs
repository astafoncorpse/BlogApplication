
using BlogApplication.Contracts.Models.Uesrs;
using FluentValidation;

namespace BlogApplication.Contracts.Validation.UserValidators
{
    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserRequestValidator()
        {
            RuleFor(x => x.NewFirstName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.NewLastName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.NewEmail).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.NewPassword).NotEmpty().MaximumLength(50);
            RuleFor(x => x.NewLogin).NotEmpty().MaximumLength(50);
        }
    }
}
