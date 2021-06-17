using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    class OneUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<int> UserUseCase { get; set; } = new List<int>();
        //public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
    }
}
