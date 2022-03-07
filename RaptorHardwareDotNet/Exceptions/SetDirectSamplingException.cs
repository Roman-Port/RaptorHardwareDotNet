using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SetDirectSamplingException : SetCapabilityException
    {
        internal SetDirectSamplingException(IRaptorHwDevice device) : base(device, RaptorHwDeviceCapabilities.DIRECT_SAMPLING, "Failed to toggle Bias T.")
        {

        }
    }
}
