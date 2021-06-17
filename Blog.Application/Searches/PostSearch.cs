using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class PostSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
    }
}
