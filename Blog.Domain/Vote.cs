using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Vote : Entity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public VoteStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }


    }

    public enum VoteStatus
    {
        Null,
        Liked,
        Disliked
    }
}
