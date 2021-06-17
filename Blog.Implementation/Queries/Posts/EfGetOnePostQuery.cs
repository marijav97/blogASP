using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Application.Queries.Posts;
using Blog.DataAccess;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries.Posts
{
    public class EfGetOnePostQuery : IGetOnePostQuery
    {
        private readonly BlogContext _context;
        private ICollection<GetCommentsForOnePostDto> MainComms { get; set; } = new List<GetCommentsForOnePostDto>();

        public EfGetOnePostQuery(BlogContext context)
        {
            _context = context;
        }
        public int Id => 18;

        public string Name => "Get One Post";

        public OnePostDto Execute(int search)
        {
            var post = _context.Posts.Find(search);

            if (post == null)
            {
                throw new EntityNotFoundException(search, typeof(Post));
            }

            var postQuery = _context.Posts
                .Include(u => u.User)
                .Include(c => c.Category)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .Include(x => x.Votes)
                .ThenInclude(x => x.User)
                .Where(x => x.Id == search)
                .FirstOrDefault();

            var result = new OnePostDto
            {
                Title = postQuery.Title,
                Description = postQuery.Description,
                CreatedAt = postQuery.CreatedAt,
                CategoryId = postQuery.CategoryId,
                UserId = postQuery.UserId
            };

            foreach (var r in result.Comments)
            {
                if (r.ParentId == 0)
                {
                    MainComms.Add(r);
                }
            }
            result.Comments = MainComms;

            return result;
        }
    }

}

