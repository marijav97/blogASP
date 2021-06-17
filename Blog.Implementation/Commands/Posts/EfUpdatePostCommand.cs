using Blog.Application;
using Blog.Application.Commands.Posts;
using Blog.Application.Commands.Requests;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Posts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Commands.Posts
{
    public class EfUpdatePostCommand : IUpdatePostCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        private readonly UpdatePostValidator _validator;
        public EfUpdatePostCommand(BlogContext context,IApplicationActor actor, UpdatePostValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 16;

        public string Name => "Update Post";

        public void Execute(UpdatePostRequest request)
        {
            _validator.ValidateAndThrow(request);

            var findPost = _context.Posts.Find(request.Id);

            if (findPost == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Post));
            }

            if (_actor.Id != findPost.UserId)
            {
                throw new ForbiddenAccessException(_actor, this.Name);
            }

            var post = _context.Posts.Include(x => x.User).Include(x => x.Category).Where(x => x.Id == request.Id).FirstOrDefault();

            post.Title = request.Title;
            post.Description = request.Description;
            post.CategoryId = request.CategoryId;

            _context.SaveChanges();
        }
    }
}
