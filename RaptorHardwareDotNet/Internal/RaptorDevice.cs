using RaptorHardwareDotNet.Exceptions;
using RaptorHardwareDotNet.Internal.Helper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RaptorHardwareDotNet.Internal
{
    unsafe class RaptorDevice : RaptorNativeObject, IRaptorHwDevice
    {
        internal RaptorDevice(IntPtr handle) : base(handle)
        {
            //Create GCHandle on this so we can get a reference to it later
            gc = GCHandle.Alloc(this);

            //Preallocate gain groups
            gains = new RaptorGainGroup[raptorhw_instance_get_gain_group_count(GetHandle())];
            for (int i = 0; i < gains.Length; i++)
                gains[i] = new RaptorGainGroup(this, raptorhw_instance_get_gain_group_at(GetHandle(), i));

            //Preallocate properties
            properties = new RaptorCustomProperty[raptorhw_instance_get_custom_property_count(GetHandle())];
            for (int i = 0; i < properties.Length; i++)
                properties[i] = new RaptorCustomProperty(this, raptorhw_instance_get_custom_property_at(GetHandle(), i));

            //Request samplerates
            samplerates = new int[raptorhw_instance_get_supported_samplerates(GetHandle(), (int*)0, 0)];
            fixed (int* ptr = samplerates)
                raptorhw_instance_get_supported_samplerates(GetHandle(), ptr, samplerates.Length);
        }

        private GCHandle gc;
        private RaptorGainGroup[] gains;
        private RaptorCustomProperty[] properties;
        private int[] samplerates;

        public string Name
        {
            get
            {
                byte[] buffer = new byte[128];
                int len;
                fixed (byte* ptr = buffer)
                    len = raptorhw_instance_get_name(GetHandle(), ptr, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, len);
            }
        }

        public string Serial
        {
            get
            {
                byte[] buffer = new byte[128];
                int len;
                fixed (byte* ptr = buffer)
                    len = raptorhw_instance_get_serial(GetHandle(), ptr, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, len);
            }
        }

        public RaptorHwDeviceCapabilities Capabilities => (RaptorHwDeviceCapabilities)raptorhw_instance_get_capabilities(GetHandle());
        public long MinFrequency => raptorhw_instance_get_min_freq(GetHandle());
        public long MaxFrequency => raptorhw_instance_get_max_freq(GetHandle());

        public long CenterFrequency
        {
            get => raptorhw_instance_get_freq(GetHandle());
            set {
                if (raptorhw_instance_set_freq(GetHandle(), value) != 1)
                    throw new SetFrequencyErrorException();
            }
        }

        public bool EnableBiasT
        {
            get => raptorhw_instance_get_bias_t(GetHandle()) == 1;
            set
            {
                if (raptorhw_instance_set_bias_t(GetHandle(), value ? 1 : 0) != 1)
                    throw new SetBiasTException(this);
            }
        }

        public bool EnableDirectSampling
        {
            get => raptorhw_instance_get_direct_sampling(GetHandle()) == 1;
            set
            {
                if (raptorhw_instance_set_direct_sampling(GetHandle(), value ? 1 : 0) != 1)
                    throw new SetDirectSamplingException(this);
            }
        }

        public int[] SupportedSamplerates => samplerates;

        public int SampleRate
        {
            get => raptorhw_instance_get_samplerate(GetHandle());
            set
            {
                //Find samplerate index
                for (int i = 0; i < samplerates.Length; i++)
                {
                    if (samplerates[i] == value)
                    {
                        if (raptorhw_instance_set_samplerate(GetHandle(), i) != 1)
                            throw new SetSampleRateException();
                        return;
                    }
                }

                //Raise error
                throw new SampleRateInvalidException(samplerates);
            }
        }

        public IRaptorHwGainGroup[] GainGroups => gains;

        public IRaptorHwCustomProperty[] CustomProperties => properties;

        public event IRaptorHwDevice_OnSamplesReceived OnSamplesReceived;

        public void StartRx()
        {
            if (raptorhw_instance_start_rx(GetHandle(), streamingCallbackDelegate, (IntPtr)gc) != 1)
                throw new StartRxException();
        }

        public void StopRx()
        {
            raptorhw_instance_stop_rx(GetHandle());
        }

        protected override void DisposeInternal()
        {
            //Dispose of the object
            raptorhw_instance_close(GetHandle());
        }

        /* INTERNAL */

        private static readonly raptorhw_instance_streaming_cb streamingCallbackDelegate = InternalStreamingCallback;

        private static void InternalStreamingCallback(IntPtr device, IntPtr ctx, RaptorHwComplex* samples, int sampleCount)
        {
            RaptorDevice target = (RaptorDevice)GCHandle.FromIntPtr(ctx).Target;
            target.OnSamplesReceived?.Invoke(target, samples, sampleCount);
        }

        /* NATIVE METHODS */

        private delegate void raptorhw_instance_streaming_cb(IntPtr device, IntPtr ctx, RaptorHwComplex* samples, int sampleCount);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_name(IntPtr device, byte* buffer, int bufferLen);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_serial(IntPtr device, byte* buffer, int bufferLen);
        
        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_capabilities(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern long raptorhw_instance_get_min_freq(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern long raptorhw_instance_get_max_freq(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern long raptorhw_instance_get_freq(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_set_freq(IntPtr device, long freq);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_bias_t(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_set_bias_t(IntPtr device, int value);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_offset_tuning(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_set_offset_tuning(IntPtr device, int value);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_direct_sampling(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_set_direct_sampling(IntPtr device, int value);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_supported_samplerates(IntPtr device, int* values, int count);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_samplerate(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_set_samplerate(IntPtr device, int rate);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_gain_group_count(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern IntPtr raptorhw_instance_get_gain_group_at(IntPtr device, int index);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_get_custom_property_count(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern IntPtr raptorhw_instance_get_custom_property_at(IntPtr device, int index);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_instance_start_rx(IntPtr device, raptorhw_instance_streaming_cb callback, IntPtr ctx);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern void raptorhw_instance_stop_rx(IntPtr device);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern void raptorhw_instance_close(IntPtr device);
    }
}
