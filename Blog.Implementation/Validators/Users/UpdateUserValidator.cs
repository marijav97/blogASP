using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator(BlogContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-z0-9]*")
                .WithMessage("Username must contain Numbers and Letters")
                .Must((request, username) => !context.Users.Any(p => p.Username == request.Username && p.Id != request.Id))
                .WithMessage("Username is already taken");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must((request, Email) => !context.Users.Any(x => x.Email == request.Email && x.Id != request.Id))
                .WithMessage("Email is already taken");

            //RuleFor(x => x.ProfilePhoto)
            // .NotEmpty();

            RuleFor(x => x.UserUseCases)
                .NotEmpty();
        }
    }
}
