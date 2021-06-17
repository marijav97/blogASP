using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
    }
}
