using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class GetCommentsForOnePostDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int ParentId { get; set; }
        public UserDto User { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<GetCommentsForOnePostDto> Childs { get; set; } = new List<GetCommentsForOnePostDto>();


    }
}