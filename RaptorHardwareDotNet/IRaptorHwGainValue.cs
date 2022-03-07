using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public interface IRaptorHwGainValue
    {
        /// <summary>
        /// The label for the value
        /// </summary>
        float Label { get; }
    }
}
