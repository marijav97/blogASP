using Blog.Application.Commands.Posts;
using Blog.Application.DataTransfer.Requests;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.Posts
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private readonly BlogContext _context;
        private readonly CreatePostValidator _validator;
        public EfCreatePostCommand(BlogContext context, CreatePostValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 15;

        public string Name => "Create New Post";

        public void Execute(CreatePostRequest request)
        {
            _validator.ValidateAndThrow(request);

            var post = new Post
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                UserId = request.UserId,
                CreatedAt=DateTime.Now
            };

            _context.Posts.Add(post);

            _context.SaveChanges();
        }
    }
}
