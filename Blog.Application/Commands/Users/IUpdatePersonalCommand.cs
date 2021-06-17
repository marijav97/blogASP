using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.Users
{
    public interface IUpdateUserPersonalCommand : ICommand<UserDto>
    {

    }

}
