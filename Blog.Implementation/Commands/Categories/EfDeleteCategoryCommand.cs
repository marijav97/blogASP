using Blog.Application.Commands.Categories;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands.Categories
{
    public class EfGetCayegoriesCommand : IDeleteCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly DeleteCategoryValidator _validator;
        public EfGetCayegoriesCommand(BlogContext context, DeleteCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 2;

        public string Name => "Deleting category";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var category = _context.Categories.Find(request);
            if (category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
