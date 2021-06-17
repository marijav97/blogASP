using Blog.Application.Commands.Users;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Commands.Users
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly BlogContext _context;
        private readonly CreateUserValidator _validator;
        public EfCreateUserCommand(BlogContext context, CreateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "Add New User";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
               
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            int Id = user.Id;
            foreach(var c in request.UserUseCases)
            {
                _context.UserUseCases.Add(new UserUseCase
                {
                    UserId = Id,
                    UseCaseId = c
                });
            }
            _context.SaveChanges();
        }
    }
}
