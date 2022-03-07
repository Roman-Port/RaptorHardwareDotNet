using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RaptorHardwareDotNet
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RaptorHwComplex
    {
        public float real;
        public float imag;
    }
}
