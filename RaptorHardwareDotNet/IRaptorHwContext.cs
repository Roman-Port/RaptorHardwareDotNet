using RaptorHardwareDotNet.Internal;
using RaptorHardwareDotNet.Internal.Helper;
using System;
using System.Runtime.InteropServices;

namespace RaptorHardwareDotNet
{
    public interface IRaptorHwContext : IDisposable
    {
        string[] ActiveModules { get; }
        IRaptorHwCandidateList Search();
    }
}
