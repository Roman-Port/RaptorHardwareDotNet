using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SetCapabilityException : Exception
    {
        internal SetCapabilityException(IRaptorHwDevice device, RaptorHwDeviceCapabilities capability, string errorMessage) :
            base(DeviceCapabilitySupported(device, capability) ? errorMessage : "This device does not support this feature.")
        {

        }

        private static bool DeviceCapabilitySupported(IRaptorHwDevice device, RaptorHwDeviceCapabilities capability)
        {
            return (device.Capabilities & capability) == capability;
        }
    }
}
