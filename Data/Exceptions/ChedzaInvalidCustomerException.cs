using System;
using System.Collections.Generic;
using System.Text;
using ChedzaApp.api.Data.Exceptions;

namespace ChedzaApp.api.Data.Exceptions
{
    public class ChedzaInvalidCustomerException: ChedzaException
    {
        public ChedzaInvalidCustomerException()
        {

        }
        public ChedzaInvalidCustomerException(string message) :base(message) 
        {

        }
        public ChedzaInvalidCustomerException(string message, Exception innerException) : base(message, innerException)
        { 
            
        }

    }
}