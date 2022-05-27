using System;
using System.Collections.Generic;
using System.Text;
using ChedzaApp.api.Data.Exceptions;

namespace ChedzaApp.api.Data.Exceptions
{
    public class ChedzaConcurrencyException : ChedzaException
    {
        public ChedzaConcurrencyException()
        { 
        }
        public ChedzaConcurrencyException(string message) : base(message) 
        { 
        }
        public ChedzaConcurrencyException(string message, Exception innerException) : base(message, innerException)
        { 
        }

    }
}