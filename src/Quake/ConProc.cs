using Quake.Win32;
using System;

namespace Quake {
    public static class ConProc
    {
        static IntPtr heventDone;
        public static void DeinitConProc() {
            if (heventDone != IntPtr.Zero)
                Win32Methods.SetEvent(heventDone);
        }
    }
}
