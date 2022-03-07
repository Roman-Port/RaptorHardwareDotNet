using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public interface IRaptorHwCandidate
    {
        /// <summary>
        /// Gets the display name of the device.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the serial number of the device.
        /// </summary>
        string Serial { get; }

        /// <summary>
        /// Gets bit flags indiciating the capabilities of the device.
        /// </summary>
        RaptorHwDeviceCapabilities Capabilities { get; }

        /// <summary>
        /// Opens the device for reading samples.
        /// </summary>
        /// <returns></returns>
        IRaptorHwDevice Open();
    }
}
