using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public enum RaptorHwDeviceCapabilities
    {
        BIAS_T = (1 << 0),
        OFFSET_TUNING = (1 << 1),
        DIRECT_SAMPLING = (1 << 2)
    }
}
