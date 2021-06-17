using Blog.Application;
using Blog.Application.Commands.Posts;
using Blog.Application.Commands.Requests;
using Blog.Application.DataTransfer.Requests;
using Blog.Application.Queries.Posts;
using Blog.Application.Searches;
using Blog.DataAccess;
using Blog.Domain;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogContext _context;
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
        public PostsController(BlogContext context, UseCaseExecutor executor, IApplicationActor actor)
        {
            _context = context;
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearch search, [FromServices] IGetPostsQuery query)
        {
            //var postsFaker = new Faker<Post>();
            //var catIds = _context.Categories.Select(x => x.Id).ToList();
            //var userIds = _context.Users.Select(x => x.Id).ToList();

            //postsFaker.RuleFor(x => x.Title, f => f.Lorem.Sentence());
            //postsFaker.RuleFor(x => x.Description, f => f.Lorem.Paragraph());
            //postsFaker.RuleFor(x => x.CreatedAt, f => f.Date.Recent());
            //postsFaker.RuleFor(x => x.CategoryId, f => f.PickRandom(catIds));
            //postsFaker.RuleFor(x => x.UserId, f => f.PickRandom(userIds));

            //var posts = postsFaker.Generate(40);
            //_context.Posts.AddRange(posts);
            //_context.SaveChanges();

            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOnePostQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<PostsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePostRequest request, [FromServices] ICreatePostCommand command)
        {
            request.UserId = _actor.Id;
            _executor.ExecuteCommand(command, request);

            return StatusCode(201);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostRequest request, [FromServices] IUpdatePostCommand command)
        {
            request.Id = id;
            _executor.ExecuteCommand(command, request);
            return NoContent();
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
        [HttpPost]
        [Route("vote")]
        public IActionResult Vote([FromBody] AddVoteRequest request, [FromServices] IAddVoteCommand command)
        {
            request.UserId = _actor.Id;
            _executor.ExecuteCommand(command, request);

            return StatusCode(201);
        }
    }
}
