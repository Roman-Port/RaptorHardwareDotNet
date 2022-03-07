using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class CustomPropertyReadErrorException : Exception
    {
        public CustomPropertyReadErrorException() : base("There was an unknown internal error reading from this property.")
        {

        }
    }
}
