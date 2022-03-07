using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SetBiasTException : SetCapabilityException
    {
        internal SetBiasTException(IRaptorHwDevice device) : base(device, RaptorHwDeviceCapabilities.BIAS_T, "Failed to toggle Bias T.")
        {

        }
    }
}
