using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public interface IRaptorHwGainSetting
    {
        /// <summary>
        /// Gets the name of the gain setting.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The units of the labels for each option.
        /// </summary>
        RaptorHwGainSettingUnits Units { get; }

        /// <summary>
        /// Gets if AGC is supported.
        /// </summary>
        bool AgcSupported { get; }

        /// <summary>
        /// Gets or sets if AGC is enabled.
        /// </summary>
        bool AgcEnabled { get; set; }

        /// <summary>
        /// Available values to be set.
        /// </summary>
        IRaptorHwGainValue[] Values { get; }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        IRaptorHwGainValue CurrentValue { get; set; }
    }
}
