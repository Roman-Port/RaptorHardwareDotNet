using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class StartRxException : Exception
    {
        internal StartRxException() : base("Failed to start reciving samples.")
        {

        }
    }
}
