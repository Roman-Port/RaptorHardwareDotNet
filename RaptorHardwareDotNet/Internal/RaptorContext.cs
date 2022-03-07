using RaptorHardwareDotNet.Exceptions;
using RaptorHardwareDotNet.Internal.Helper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RaptorHardwareDotNet.Internal
{
    unsafe class RaptorContext : RaptorNativeObject, IRaptorHwContext
    {
        public RaptorContext() : base(raptorhw_context_create())
        {
        }

        public string[] ActiveModules
        {
            get
            {
                //Allocate string array
                string[] result = new string[raptorhw_context_get_module_count(GetHandle())];

                //Create a buffer to hold the name of each and copy
                byte[] buf = new byte[256];
                fixed (byte* ptr = buf)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        int len = raptorhw_context_get_module_info(GetHandle(), i, ptr, buf.Length);
                        result[i] = Encoding.ASCII.GetString(buf, 0, len);
                    }
                }

                return result;
            }
        }

        public IRaptorHwCandidateList Search()
        {
            return new CandidateList(this);
        }

        protected override void DisposeInternal()
        {
            raptorhw_context_destroy(GetHandle());
        }

        /* CANDIDATES */

        class CandidateList : List<IRaptorHwCandidate>, IRaptorHwCandidateList
        {
            public CandidateList(RaptorContext context)
            {
                this.context = context;

                //Request
                candidates = raptorhw_context_search(context.GetHandle());

                //Add each
                for (int i = 0; candidates[i] != IntPtr.Zero; i++)
                    Add(new CandidateEntry(this, candidates[i]));
            }

            private RaptorContext context;
            private bool disposed;
            private IntPtr* candidates;

            public void Dispose()
            {
                //Set flag
                disposed = true;

                //Dispose
                raptorhw_context_search_destroy(context.GetHandle(), candidates);
            }

            class CandidateEntry : RaptorNativeObject, IRaptorHwCandidate
            {
                public CandidateEntry(CandidateList list, IntPtr handle) : base(handle)
                {
                    this.list = list;
                }

                private CandidateList list;

                public string Name
                {
                    get
                    {
                        byte[] buffer = new byte[128];
                        int len;
                        fixed (byte* ptr = buffer)
                            len = raptorhw_candidate_get_name(GetHandle(), ptr, buffer.Length);
                        return Encoding.ASCII.GetString(buffer, 0, len);
                    }
                }

                public string Serial
                {
                    get
                    {
                        byte[] buffer = new byte[128];
                        int len;
                        fixed (byte* ptr = buffer)
                            len = raptorhw_candidate_get_serial(GetHandle(), ptr, buffer.Length);
                        return Encoding.ASCII.GetString(buffer, 0, len);
                    }
                }

                public RaptorHwDeviceCapabilities Capabilities => (RaptorHwDeviceCapabilities)raptorhw_candidate_get_capabilities(GetHandle());

                public IRaptorHwDevice Open()
                {
                    //Create handle
                    IntPtr device = raptorhw_candidate_open(GetHandle());

                    //Validate
                    if (device == IntPtr.Zero)
                        throw new CreateDeviceInstanceException();

                    //Wrap
                    return new RaptorDevice(device);
                }

                public override void EnsureHandleValid()
                {
                    //Ensure the list is valid
                    if (list.disposed)
                        throw new ObjectDisposedException(GetType().Name);
                }

                protected override void DisposeInternal()
                {
                    //Never called directly, ignore
                }

                /* NATIVE */

                [DllImport(RaptorUtil.DLL_NAME)]
                private static extern int raptorhw_candidate_get_name(IntPtr handle, byte* buffer, int bufferLen);

                [DllImport(RaptorUtil.DLL_NAME)]
                private static extern int raptorhw_candidate_get_serial(IntPtr handle, byte* buffer, int bufferLen);

                [DllImport(RaptorUtil.DLL_NAME)]
                private static extern int raptorhw_candidate_get_capabilities(IntPtr handle);

                [DllImport(RaptorUtil.DLL_NAME)]
                private static extern IntPtr raptorhw_candidate_open(IntPtr handle);
            }
        }

        /* NATIVE METHODS */

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern IntPtr raptorhw_context_create();

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_context_get_module_count(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern int raptorhw_context_get_module_info(IntPtr handle, int index, byte* buffer, int bufferSize);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern IntPtr* raptorhw_context_search(IntPtr handle);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern void raptorhw_context_search_destroy(IntPtr handle, IntPtr* candidates);

        [DllImport(RaptorUtil.DLL_NAME)]
        private static extern void raptorhw_context_destroy(IntPtr handle);
    }
}
