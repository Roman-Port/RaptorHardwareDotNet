using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public interface IRaptorHwGainGroup
    {
        /// <summary>
        /// The display name of the gain group.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets each setting in the gain group.
        /// </summary>
        IRaptorHwGainSetting[] Settings { get; }

        /// <summary>
        /// Chooses this group as the selected group.
        /// </summary>
        void Select();
    }
}
