using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SetSampleRateException : Exception
    {
        internal SetSampleRateException() : base("Failed to set device sampling rate.")
        {

        }
    }
}
