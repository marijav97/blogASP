using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.Categories
{
    public interface ICreateCategoryCommand : ICommand<CategoryDto>
    {
    }
}
