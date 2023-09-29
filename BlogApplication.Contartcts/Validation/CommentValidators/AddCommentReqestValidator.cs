
using BlogApplication.Contracts.Models.Comments;
using FluentValidation;

namespace BlogApplication.Contracts.Validation.CommentValidators
{
    public class AddCommentReqestValidator : AbstractValidator<CommentRequest>
    {
        public AddCommentReqestValidator()
        {
            RuleFor(x => x.CommentContext).NotEmpty();
        }
    }
}
