using Blog.Application.Commands.Posts;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.Posts
{
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private readonly BlogContext _context;
        private readonly DeletePostValidator _validator;
        public EfDeletePostCommand(BlogContext context, DeletePostValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 17;

        public string Name => "Delete Post";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var post = _context.Posts.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(Post));
            }


            _context.Posts.Remove(post);

            _context.SaveChanges();
        }
    }
}
