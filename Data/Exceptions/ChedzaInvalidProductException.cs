using System;
using System.Collections.Generic;
using System.Text;
using ChedzaApp.api.Data.Exceptions;

namespace ChedzaApp.api.Data.Exceptions
{
    public class ChedzaInvalidProductException: ChedzaException
    {
        public ChedzaInvalidProductException()
        {

        }
        public ChedzaInvalidProductException(string message) :base(message) 
        {
            
        }
        public ChedzaInvalidProductException(string message, Exception innerException) : base(message, innerException)
        { 

        }

    }
}