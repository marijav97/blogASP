using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class CommentDto
    {
        public string CommentText { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
    }
}
