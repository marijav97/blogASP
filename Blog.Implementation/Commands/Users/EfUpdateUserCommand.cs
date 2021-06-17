using Blog.Application.Commands.Users;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Users;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Commands.Users
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly BlogContext _context;
        private readonly UpdateUserValidator _validator;

        public EfUpdateUserCommand(BlogContext context, UpdateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Update Users";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var findUser = _context.Users.Find(request.Id);
            if (findUser == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }
            var user = _context.Users.Include(x => x.UserUseCases).Where(x => x.Id == request.Id).First();

            foreach (var id in user.UserUseCases)
            {
                _context.Remove(id);
            }

            foreach (var idUc in request.UserUseCases)
            {
                _context.UserUseCases.Add(new UserUseCase
                {
                    UseCaseId = idUc,
                    UserId = request.Id
                });
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Username = request.Username;
            user.Email = request.Email;
            user.Password = request.Password;
            _context.SaveChanges();
        }
    }
}
