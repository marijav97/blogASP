using Blog.Application.DataTransfer;
using Blog.Application.DataTransfer.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.Posts
{
    public interface ICreatePostCommand : ICommand<CreatePostRequest>
    {
    }
}
