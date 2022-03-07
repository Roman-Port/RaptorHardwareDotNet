using RaptorHardwareDotNet.Exceptions;
using RaptorHardwareDotNet.Internal.Helper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RaptorHardwareDotNet.Internal
{
    unsafe class RaptorGainSetting : RaptorNativeSubObject, IRaptorHwGainSetting
    {
        internal RaptorGainSetting(RaptorGainGroup group, IntPtr handle) : base(group, handle)
        {
            //Preallocate options
            options = new GainOption[raptorhw_gain_item_get_option_count(GetHandle())];
            for (int i = 0; i < options.Length; i++)
                options[i] = new GainOption(this, i);
        }

        private GainOption[] options;

        public string Name
        {
            get
            {
                byte[] buffer = new byte[128];
                int len;
                fixed (byte* ptr = buffer)
                    len = raptorhw_gain_item_get_name(GetHandle(), ptr, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, len);
            }
        }

        public RaptorHwGainSettingUnits Units => (RaptorHwGainSettingUnits)raptorhw_gain_item_get_units(GetHandle());
        public bool AgcSupported => raptorhw_gain_item_get_agc_supported(GetHandle()) == 1;
        public bool AgcEnabled
        {
            get => raptorhw_gain_item_get_agc(GetHandle()) == 1;
            set
            {
                if (raptorhw_gain_item_set_agc(GetHandle(), value ? 1 : 0) != 1)
                    throw new SetGainAgcException();
            }
        }

        public IRaptorHwGainValue[] Values => options;

        public IRaptorHwGainValue CurrentValue
        {
            get => options[raptorhw_gain_item_get_value(GetHandle())];
            set
            {
                //Get the index from the item
                if (value is GainOption option)
                {
                    if (raptorhw_gain_item_set_value(GetHandle(), option.Index) != 1)
                        throw new SetGainValueException();
                } else
                {
                    throw new ArgumentException();
                }
            }
        }

        protected override void DisposeInternal()
        {
            //Not called directly, do nothing
        }

        /* OPTION */

        class GainOption : IRaptorHwGainValue
        {
            public GainOption(RaptorGainSetting setting, int index)
            {
                this.setting = setting;
                this.index = index;
            }

            private RaptorGainSetting setting;
            private int index;

            public float Label => raptorhw_gain_item_get_option_label(setting.GetHandle(), index);
            public int Index => index;
        }

        /* NATIVE METHODS */

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_get_name(IntPtr handle, byte* buffer, int bufferSize);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_get_units(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_get_agc_supported(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_get_agc(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_set_agc(IntPtr handle, int value);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_get_option_count(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern float raptorhw_gain_item_get_option_label(IntPtr handle, int index);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_get_value(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_item_set_value(IntPtr handle, int index);
    }
}
