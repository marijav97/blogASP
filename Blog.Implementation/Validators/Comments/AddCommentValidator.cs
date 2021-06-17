using Blog.Application.DataTransfer;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators.Comments
{
    public class AddCommentValidator : AbstractValidator<CommentDto>
    {
        public AddCommentValidator(BlogContext context)
        {
            RuleFor(x => x.CommentText).NotEmpty();

            RuleFor(x => x.PostId)
                .NotEmpty()
                .Must(postId => context.Posts.Any(p => p.Id == postId))
                .WithMessage("Post must exists.");


            RuleFor(x => x.ParentId)
                .Must(commID => context.Comments.Any(c => c.Id == commID))
                .When(request => request.ParentId != null)
                .WithMessage("Parent comment must exists.");
        }
    }
}
