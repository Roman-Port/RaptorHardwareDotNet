using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Exceptions
{
    public class SampleRateInvalidException : Exception
    {
        public SampleRateInvalidException(int[] supported) : base($"The specified sample rate is not supported by this device. The sample rate must be one of: {FormatSupportedRates(supported)}")
        {

        }

        private static string FormatSupportedRates(int[] supported)
        {
            string result = "";
            for (int i = 0; i < supported.Length; i++)
            {
                result += supported[i];
                if (i != supported.Length - 1)
                    result += ", ";
            }
            return result;
        }
    }
}
