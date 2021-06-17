using Blog.Application.Commands.Comments;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.Comments
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly BlogContext _context;
        private readonly DeleteCommentValidator _validator;

        public EfDeleteCommentCommand(BlogContext context, DeleteCommentValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Delete Comment";


        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var comment = _context.Comments.Find(request);
            if (comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }

            _context.Comments.Remove(comment);


            _context.SaveChanges();
        }
    }
}
