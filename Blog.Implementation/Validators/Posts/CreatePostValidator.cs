using Blog.Application.DataTransfer.Requests;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators.Posts
{
    public class CreatePostValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostValidator(BlogContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .Must(catId => context.Categories.Any(p => p.Id == catId))
                .WithMessage("Category must be valid");

             RuleFor(x => x.UserId)
               .NotEmpty();
        }
    }
}
