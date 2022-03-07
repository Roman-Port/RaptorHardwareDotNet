using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SetGainAgcException : Exception
    {
        public SetGainAgcException() : base("Failed to set gain AGC.")
        {

        }
    }
}
