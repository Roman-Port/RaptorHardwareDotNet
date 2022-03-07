using RaptorHardwareDotNet.Exceptions;
using RaptorHardwareDotNet.Internal.Helper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RaptorHardwareDotNet.Internal
{
    unsafe class RaptorGainGroup : RaptorNativeSubObject, IRaptorHwGainGroup
    {
        internal RaptorGainGroup(RaptorDevice device, IntPtr handle) : base(device, handle)
        {
            //Preallocate settings
            settings = new RaptorGainSetting[raptorhw_gain_group_get_option_count(GetHandle())];
            for (int i = 0; i < settings.Length; i++)
                settings[i] = new RaptorGainSetting(this, raptorhw_gain_group_get_option(GetHandle(), i));
        }

        private RaptorGainSetting[] settings;

        public string Name
        {
            get
            {
                byte[] buffer = new byte[128];
                int len;
                fixed (byte* ptr = buffer)
                    len = raptorhw_gain_group_get_name(GetHandle(), ptr, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, len);
            }
        }

        public IRaptorHwGainSetting[] Settings => settings;

        public void Select()
        {
            if (raptorhw_gain_group_select(GetHandle()) != 1)
                throw new SelectGainGroupException();
        }

        protected override void DisposeInternal()
        {
            //Not called directly, do nothing
        }

        /* NATIVE METHODS */

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_group_get_name(IntPtr handle, byte* buffer, int bufferLen);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_group_get_option_count(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern IntPtr raptorhw_gain_group_get_option(IntPtr handle, int index);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_gain_group_select(IntPtr handle);
    }
}
