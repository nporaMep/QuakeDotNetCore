﻿using System.Runtime.InteropServices;

namespace Quake.Win32 {
    [StructLayout(LayoutKind.Sequential)]
    public struct Point {
        public int X;
        public int Y;

        public Point(int x, int y) {
            X = x;
            Y = y;
        }
    }
}
