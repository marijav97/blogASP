using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators.Categories
{
    public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public UpdateCategoryValidator(BlogContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .Must((request, n) => !context.Categories.Any(c => c.Name == request.Name && c.Id != request.Id))
                .WithMessage("Category must be unique");

        }
    }
}
