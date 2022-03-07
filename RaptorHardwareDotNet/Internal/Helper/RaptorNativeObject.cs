using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet.Internal.Helper
{
    abstract class RaptorNativeObject : IDisposable
    {
        public RaptorNativeObject(IntPtr handle)
        {
            this.handle = handle;
        }

        private IntPtr handle;

        protected abstract void DisposeInternal();

        public virtual void EnsureHandleValid()
        {
            if (handle == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
        }

        protected IntPtr GetHandle()
        {
            EnsureHandleValid();
            return handle;
        }

        public void Dispose()
        {
            //Call disposal method
            DisposeInternal();

            //Invalidate handle
            handle = IntPtr.Zero;
        }
    }
}
