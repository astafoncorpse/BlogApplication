
using BlogApplication.Contracts.Models.Tegs;
using FluentValidation;

namespace BlogApplication.Contracts.Validation.TegValidators
{
    public class AddTegRequestValidator : AbstractValidator<TegRequest>
    {
        public AddTegRequestValidator()
        {
            RuleFor(x => x.Value).NotEmpty().MaximumLength(100);
        }
    }
}
