using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException(IApplicationActor actor, string UseCaseName) :
            base($"Actor with identity: {actor.Identity} and id: {actor.Id} has tryed to access Use Case: {UseCaseName}")
        {
        }
    }
}
