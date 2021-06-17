using Blog.Application.Commands.Categories;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validators.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Commands.Categories
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly UpdateCategoryValidator _validator;

        public EfUpdateCategoryCommand(BlogContext context, UpdateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Update  Category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = _context.Categories.Find(request.Id);
            if (category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            category.Name = request.Name;

            _context.SaveChanges();

        }
    }
}
