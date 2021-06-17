using Blog.Application.Commands.Requests;
using Blog.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Validators.Posts
{
    public class AddVoteValidator : AbstractValidator<AddVoteRequest>
    {
        public AddVoteValidator()
        {

            RuleFor(x => x.PostId).NotEmpty();

            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.Status)
                .Must(y => Enum.IsDefined(typeof(VoteStatus), y))
                .WithMessage("Not valid status");
        }
    }
}
