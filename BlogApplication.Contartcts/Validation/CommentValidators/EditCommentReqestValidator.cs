
using BlogApplication.Contracts.Models.Comments;
using FluentValidation;

namespace BlogApplication.Contracts.Validation.CommentValidators
{
    public class EditCommentReqestValidator : AbstractValidator<EditCommentReqest>
    {
        public EditCommentReqestValidator()
        {
            RuleFor(x => x.NewContent).NotEmpty();
        }
    }
}
