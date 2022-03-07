using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public interface IRaptorHwCandidateList : IReadOnlyList<IRaptorHwCandidate>, IDisposable
    {
    }
}
