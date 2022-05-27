using System;
using System.Collections.Generic;
using System.Text;
using ChedzaApp.api.Data.Exceptions;

namespace ChedzaApp.api.Data.Exceptions
{
    public class ChedzaRetryLimitExceededException: ChedzaException
    {
        public ChedzaRetryLimitExceededException()
        {

        }
        public ChedzaRetryLimitExceededException(string message) :base(message) 
        {
            
        }
        public ChedzaRetryLimitExceededException(string message, Exception innerException) : base(message, innerException)
        { 

        }

    }
}