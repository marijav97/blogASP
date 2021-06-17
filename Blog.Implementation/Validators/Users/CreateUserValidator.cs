using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(BlogContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[a-zA-Z]{2,}")
                .WithMessage("FirstName must contain Letters");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?")
                .WithMessage("LastName must contain  Letters");
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-z0-9]*")
                .WithMessage("Username must contain Numbers and Letters")
                .Must(x => !context.Users.Any(user => user.Username == x))
                .WithMessage("Username is already taken");


            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches("[A-z0-9]*")
                .WithMessage("Password must contain Numbers and Letters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(u => !context.Users.Any(x => x.Email == u))
                .WithMessage("Email is already taken");

            RuleFor(x => x.UserUseCases)
                .NotEmpty();
        }
    }
}
