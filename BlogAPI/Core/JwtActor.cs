using Blog.Application;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Core
{
        public class JwtActor : IApplicationActor
        {
            public int Id { get; set; }

            public string Identity { get; set; }

            public IEnumerable<int> AllowedUseCases { get; set; }
        }
}
