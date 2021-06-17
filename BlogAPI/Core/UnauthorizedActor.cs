using Blog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Core
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Annonymus";

        public IEnumerable<int> AllowedUseCases => new List<int> {3,10,14,18};
    }
}
