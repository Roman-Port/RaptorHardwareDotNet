using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SetGainValueException : Exception
    {
        internal SetGainValueException() : base("Failed to set gain value.")
        {

        }
    }
}
