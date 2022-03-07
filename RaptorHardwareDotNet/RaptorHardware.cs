using RaptorHardwareDotNet.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public static class RaptorHardware
    {
        public static IRaptorHwContext CreateContext()
        {
            return new RaptorContext();
        }
    }
}
