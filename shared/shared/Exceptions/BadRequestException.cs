using System;

namespace SimpleAuthServer.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message){}
    }
}
