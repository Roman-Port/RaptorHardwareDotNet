using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public unsafe delegate void IRaptorHwDevice_OnSamplesReceived(IRaptorHwDevice device, RaptorHwComplex* samples, int count);

    public interface IRaptorHwDevice : IDisposable
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
        /// Gets the minimum estimated tunable frequency the device supports.
        /// </summary>
        long MinFrequency { get; }

        /// <summary>
        /// Gets the maximum estimated tunable frequency the device supports.
        /// </summary>
        long MaxFrequency { get; }

        /// <summary>
        /// Gets or sets the center frequency of the device.
        /// </summary>
        long CenterFrequency { get; set; }

        /// <summary>
        /// Gets or sets the bias T option of the device, if available.
        /// </summary>
        bool EnableBiasT { get; set; }

        /// <summary>
        /// Gets or sets the direct sampling option of the device, if available.
        /// </summary>
        bool EnableDirectSampling { get; set; }

        /// <summary>
        /// Gets the supported samplerates of the device.
        /// </summary>
        int[] SupportedSamplerates { get; }

        /// <summary>
        /// Gets or sets the current sample rate of the device.
        /// </summary>
        int SampleRate { get; set; }

        /// <summary>
        /// Get the gain groups for the device.
        /// </summary>
        IRaptorHwGainGroup[] GainGroups { get; }

        /// <summary>
        /// Custom properties associated with this device.
        /// </summary>
        IRaptorHwCustomProperty[] CustomProperties { get; }

        /// <summary>
        /// Starts streaming samples from the device.
        /// </summary>
        void StartRx();

        /// <summary>
        /// Stops streaming samples from the device.
        /// </summary>
        void StopRx();

        /// <summary>
        /// Event fired when samples are received. Call StartRx() to begin raising this event.
        /// </summary>
        event IRaptorHwDevice_OnSamplesReceived OnSamplesReceived;
    }
}
