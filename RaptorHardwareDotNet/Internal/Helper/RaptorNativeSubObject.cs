using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Internal.Helper
{
    abstract class RaptorNativeSubObject : RaptorNativeObject
    {
        public RaptorNativeSubObject(RaptorNativeObject holder, IntPtr handle) : base(handle)
        {
            this.holder = holder;
        }

        private RaptorNativeObject holder;

        public override void EnsureHandleValid()
        {
            holder.EnsureHandleValid();
            base.EnsureHandleValid();
        }
    }
}
