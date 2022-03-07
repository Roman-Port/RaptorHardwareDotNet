using RaptorHardwareDotNet.Exceptions;
using RaptorHardwareDotNet.Internal.Helper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RaptorHardwareDotNet.Internal
{
    unsafe class RaptorCustomProperty : RaptorNativeSubObject, IRaptorHwCustomProperty
    {
        public RaptorCustomProperty(RaptorDevice device, IntPtr handle) : base(device, handle)
        {
            flags = (PropertyFlags)raptorhw_customprop_get_flags(GetHandle());
        }

        private PropertyFlags flags;

        public string Name
        {
            get
            {
                byte[] buffer = new byte[128];
                int len;
                fixed (byte* ptr = buffer)
                    len = raptorhw_customprop_get_name(GetHandle(), ptr, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, len);
            }
        }

        public bool IsWritable => HasFlag(PropertyFlags.WRITABLE);

        public RaptorHwCustomPropertyType ValueType
        {
            get
            {
                if (HasFlag(PropertyFlags.BOOL))
                    return RaptorHwCustomPropertyType.Bool;
                if (HasFlag(PropertyFlags.INT))
                    return RaptorHwCustomPropertyType.Int;
                if (HasFlag(PropertyFlags.STRING))
                    return RaptorHwCustomPropertyType.String;
                throw new Exception("Invalid or unsupported property type.");
            }
        }

        public object Value
        {
            get
            {
                switch (ValueType)
                {
                    case RaptorHwCustomPropertyType.Bool: return ValueBool;
                    case RaptorHwCustomPropertyType.Int: return ValueInt;
                    case RaptorHwCustomPropertyType.String: return ValueString;
                    default: throw new Exception("Unexpected state.");
                }
            }
            set
            {
                switch (ValueType)
                {
                    case RaptorHwCustomPropertyType.Bool: ValueBool = (bool)value; break;
                    case RaptorHwCustomPropertyType.Int: ValueInt = (int)value; break;
                    case RaptorHwCustomPropertyType.String: ValueString = (string)value; break;
                    default: throw new Exception("Unexpected state.");
                }
            }
        }

        public string ValueString
        {
            get
            {
                EnsureMatchesType(PropertyFlags.STRING);
                byte[] buffer = new byte[512];
                int result;
                IntPtr len;
                fixed (byte* ptr = buffer)
                    result = raptorhw_customprop_read_string(GetHandle(), ptr, (IntPtr)buffer.Length, &len);
                if (result != 1)
                    throw new CustomPropertyReadErrorException();
                return Encoding.ASCII.GetString(buffer, 0, (int)len);
            }
            set
            {
                EnsureMatchesType(PropertyFlags.STRING);
                EnsureWritable();
                IntPtr ptr = Marshal.StringToHGlobalAnsi(value);
                try
                {
                    if (raptorhw_customprop_write_string(GetHandle(), (byte*)ptr, (IntPtr)(value.Length)) != 1)
                        throw new CustomPropertyWriteErrorException();
                } finally
                {
                    Marshal.FreeHGlobal(ptr);
                }

            }
        }

        public int ValueInt
        {
            get
            {
                EnsureMatchesType(PropertyFlags.INT);
                int value;
                if (raptorhw_customprop_read_int(GetHandle(), &value) != 1)
                    throw new CustomPropertyReadErrorException();
                return value;
            }
            set
            {
                EnsureMatchesType(PropertyFlags.INT);
                EnsureWritable();
                if (raptorhw_customprop_write_int(GetHandle(), value) != 1)
                    throw new CustomPropertyWriteErrorException();
            }
        }

        public bool ValueBool
        {
            get => ValueInt != 0;
            set => ValueInt = value ? 1 : 0;
        }

        protected override void DisposeInternal()
        {
            //Not called directly, ignore...
        }

        private void EnsureMatchesType(PropertyFlags flag)
        {
            if (!HasFlag(flag))
                throw new CustomPropertyTypeMismatchException();
        }

        private void EnsureWritable()
        {
            if (!HasFlag(PropertyFlags.WRITABLE))
                throw new CustomPropertyReadOnlyException();
        }

        private bool HasFlag(PropertyFlags flag)
        {
            return (flags & flag) == flag;
        }

        enum PropertyFlags
        {
            WRITABLE = (1 << 0),
            STRING = (1 << 1),
            INT = (1 << 2),
            BOOL = (1 << 3)
        }

        /* NATIVE METHODS */

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_customprop_get_name(IntPtr handle, byte* buffer, int bufferLen);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_customprop_get_flags(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_customprop_read_string(IntPtr handle, byte* result, IntPtr resultLen, IntPtr* resultWritten);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_customprop_write_string(IntPtr handle, byte* input, IntPtr len);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_customprop_read_int(IntPtr handle, int* result);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_customprop_write_int(IntPtr handle, int value);
    }
}
