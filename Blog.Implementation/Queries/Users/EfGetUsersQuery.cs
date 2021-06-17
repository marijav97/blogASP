using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Queries.Users;
using Blog.Application.Searches;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries.Users
{
    public class EfGetUsersQuery : IGetUsersSearchQuery
    {
        public readonly BlogContext _context;
        public EfGetUsersQuery(BlogContext context)
        {
            _context = context;
        }
        public int Id => 8;

        public string Name => "Search Users";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.OrderByDescending(x => x.Id).AsQueryable();
            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Email) || !string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }


            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                   LastName = x.LastName,
                    Username = x.Username,
                    Email=x.Email,
                    Password=x.Password
                }).ToList()
            };
            return response;

        }
    }

}
