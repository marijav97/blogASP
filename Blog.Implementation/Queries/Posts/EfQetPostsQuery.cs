using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Queries.Posts;
using Blog.Application.Searches;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries.Posts
{
    public class EfGetPostsQuery : IGetPostsQuery
    {
        private readonly BlogContext _context;
        public EfGetPostsQuery(BlogContext context)
        {
            _context = context;
        }
        public int Id => 14;

        public string Name => "Search Posts";

        public PagedResponse<PostDto> Execute(PostSearch search)
        {
            var query = _context.Posts.OrderByDescending(x => x.Id).Include(u => u.User).Include(c => c.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()));
                query = query.Where(x => x.Description.ToLower().Contains(search.Keyword.ToLower()));
            }

            if (search.CategoryIds.Any())
            {
                query = query.Where(x => search.CategoryIds.Contains(x.CategoryId));
            }
             
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<PostDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList()
            };
            return response;
        }
    }
}
