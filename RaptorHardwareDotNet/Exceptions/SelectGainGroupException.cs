using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SelectGainGroupException : Exception
    {
        internal SelectGainGroupException() : base("Failed to select the gain group.")
        {

        }
    }
}
