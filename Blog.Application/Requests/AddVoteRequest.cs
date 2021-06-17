using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.Requests
{
    public class AddVoteRequest
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public VoteStatus Status { get; set; }
    }
}
