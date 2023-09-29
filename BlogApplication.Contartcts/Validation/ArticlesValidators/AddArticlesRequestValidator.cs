﻿
using BlogApplication.Contracts.Models.Articles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Validation.ArticlesValidators
{
    public class AddArticlesRequestValidator : AbstractValidator<ArticlesReqest>
    {
        public AddArticlesRequestValidator()
        {
            RuleFor(x => x.ArticleContext).NotEmpty();
            RuleFor(x => x.ArticlesName).NotEmpty().MaximumLength(50);
        }
    }
}
