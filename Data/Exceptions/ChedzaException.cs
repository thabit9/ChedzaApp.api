using System;
using System.Collections.Generic;
using System.Text;

namespace ChedzaApp.api.Data.Exceptions
{
    public class ChedzaException : Exception
    {
        public ChedzaException()
        { 
        }
        public ChedzaException(string message) : base(message)
        { 
        }
        public ChedzaException(string message, Exception innerException) : base(message, innerException)
        { 
        }

    }
}