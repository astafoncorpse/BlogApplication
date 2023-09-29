﻿
using BlogApplication.Contracts.Models.Articles;
using FluentValidation;

namespace BlogApplication.Contracts.Validation.ArticlesValidators
{
    public class EditArticlesRequestValidator : AbstractValidator<EditArticleRequest>
    {
        public EditArticlesRequestValidator()
        {
            RuleFor(x => x.NewArticleContext).NotEmpty();
            RuleFor(x => x.NewArticleName).NotEmpty().MaximumLength(50);
        }
    }
}
