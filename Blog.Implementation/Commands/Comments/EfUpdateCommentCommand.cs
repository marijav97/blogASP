using Blog.Application;
using Blog.Application.Commands.Comments;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Commands.Comments
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly BlogContext _context;
        private readonly UpdateCommentValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateCommentCommand(BlogContext context, UpdateCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public string Name => "Update Comment";

        public int Id => 12;

        public void Execute(UpdateCommentDto request)
        {
            _validator.ValidateAndThrow(request);

            var comment = _context.Comments.Find(request.Id);
            if (comment == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Comment));
            }

            if (_actor.Id != comment.UserId)
            {
                throw new ForbiddenAccessException(_actor, this.Name);
            }

            var commentQuery = _context.Comments.Where(x => x.Id == request.Id).FirstOrDefault();

            commentQuery.CommentText = request.CommentText;
            _context.SaveChanges();
        }
    }
}
