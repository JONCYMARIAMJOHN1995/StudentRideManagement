using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.CustomMiddlewares
{
    public class Exceptions : Exception
    {
        public Exceptions(string message) : base(message)
        {

        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }

    public class NoContentException : Exception
    {
        public NoContentException(string message) : base(message)
        {

        }
    }

    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message) : base(message)
        {

        }
    }
}
