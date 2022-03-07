using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class CustomPropertyWriteErrorException : Exception
    {
        public CustomPropertyWriteErrorException() : base("There was an unknown internal error writing to this property.")
        {

        }
    }
}
