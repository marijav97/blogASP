using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class OnePostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoryDto Category { get; set; }
        public UserDto User { get; set; }
        public ICollection<GetCommentsForOnePostDto> Comments { get; set; } = new List<GetCommentsForOnePostDto>();
        public ICollection<GetVotesForOnePost> Votes { get; set; } = new List<GetVotesForOnePost>();
    }
}
