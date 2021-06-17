using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class GetVotesForOnePost
    {
        public int Id { get; set; }
        public VoteStatus Status { get; set; }
        public UserDto User { get; set; }
    }
}
