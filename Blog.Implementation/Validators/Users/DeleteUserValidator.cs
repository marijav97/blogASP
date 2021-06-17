using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Validators.Users
{
    public class DeleteUserValidator : AbstractValidator<int>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x)
                .NotEmpty();


        }
    }
}
