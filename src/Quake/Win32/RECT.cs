using System.Runtime.InteropServices;

namespace Quake.Win32 {
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect {
        public int Left, Top, Right, Bottom;
    }
}
