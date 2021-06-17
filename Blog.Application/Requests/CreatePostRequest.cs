using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer.Requests
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
