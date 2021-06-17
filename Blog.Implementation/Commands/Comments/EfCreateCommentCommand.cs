using Blog.Application;
using Blog.Application.Commands.Comments;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.Comments
{
    public class EfCreateCommentCommand : ICreateComment
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        private readonly AddCommentValidator _validator;
        public EfCreateCommentCommand(BlogContext context, IApplicationActor actor, AddCommentValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 11;

        public string Name => "Add Comment";

        public void Execute(CommentDto request)
        {
            _validator.ValidateAndThrow(request);
            request.UserId = _actor.Id;

            var comment = new Comment
            {
                CommentText=request.CommentText,
                PostId=request.PostId,
                UserId=request.UserId
            };

            _context.Add(comment);
            _context.SaveChanges();
        }
    }
}
