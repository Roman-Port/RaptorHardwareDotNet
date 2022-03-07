using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class CustomPropertyReadOnlyException : Exception
    {
        public CustomPropertyReadOnlyException() : base("This property is read-only and does not support writing.")
        {

        }
    }
}
