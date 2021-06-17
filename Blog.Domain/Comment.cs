using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Comment : Entity
    {
        public string CommentText { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> Childs { get; set; }


    }
}
