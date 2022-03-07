using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SetFrequencyErrorException : Exception
    {
        internal SetFrequencyErrorException() : base("Failed to set device center frequency.")
        {

        }
    }
}
