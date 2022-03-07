using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class CreateDeviceInstanceException : Exception
    {
        internal CreateDeviceInstanceException() : base("Failed to create device instance.")
        {

        }
    }
}
