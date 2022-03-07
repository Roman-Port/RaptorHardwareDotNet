using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class CustomPropertyTypeMismatchException : Exception
    {
        public CustomPropertyTypeMismatchException() : base("This type is unsupported by this property.")
        {

        }
    }
}
