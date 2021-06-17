using Blog.Application.Commands.Users;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.Users
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly BlogContext _context;
        private readonly DeleteUserValidator _validator;
        public EfDeleteUserCommand(BlogContext context, DeleteUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 7;

        public string Name => "Delete User";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var user = _context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
