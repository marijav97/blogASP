using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
        
    }
}
