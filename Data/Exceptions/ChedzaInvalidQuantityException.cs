using System;
using System.Collections.Generic;
using System.Text;
using ChedzaApp.api.Data.Exceptions;

namespace ChedzaApp.api.Data.Exceptions
{
    public class ChedzaInvalidQuantityException: ChedzaException
    {
        public ChedzaInvalidQuantityException()
        {

        }
        public ChedzaInvalidQuantityException(string message) :base(message) 
        {
            
        }
        public ChedzaInvalidQuantityException(string message, Exception innerException) : base(message, innerException)
        { 

        }

    }
}