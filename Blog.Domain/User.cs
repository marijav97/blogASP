using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
