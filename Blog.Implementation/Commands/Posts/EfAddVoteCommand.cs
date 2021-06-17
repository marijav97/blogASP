using Blog.Application;
using Blog.Application.Commands.Posts;
using Blog.Application.Commands.Requests;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Commands.Posts
{
    public class EfAddVoteCommand : IAddVoteCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;
        private readonly AddVoteValidator _validator;
        public EfAddVoteCommand(BlogContext context, IApplicationActor actor, AddVoteValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Add Vote";

        public void Execute(AddVoteRequest request)
        {
            _validator.ValidateAndThrow(request);

            var findVote = _context.Votes.Where(x => x.PostId == request.PostId && x.UserId == request.UserId).FirstOrDefault();

            if (findVote == null)
            {
                var newVote = new Vote
                {
                    PostId=request.PostId,
                    Status=request.Status,
                    UserId=request.UserId
                };
                _context.Votes.Add(newVote);
                _context.SaveChanges();
            }
            else
            {
                findVote.Status = request.Status;
                _context.SaveChanges();
            }
        }
    }
}
