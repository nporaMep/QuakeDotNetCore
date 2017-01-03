using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Quake.Win32 {
    public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    public static class Win32Methods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr DefWindowProcW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CreateWindowEx(WindowStylesEx dwExStyle, IntPtr lpClassName, string lpWindowName, WindowStyles dwStyle,
            int x, int y, int nWidth, int nHeight,
            IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        [DllImport("user32.dll")]
        public static extern ushort RegisterClass([In] ref WindowClass lpWndClass);

        [DllImport("user32.dll")]
        public static extern bool AdjustWindowRectEx(ref Rect lpRect, uint dwStyle, bool bMenu, uint dwExStyle);
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int GetMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        [DllImport("user32.dll")]
        public static extern bool TranslateMessage([In] ref Msg lpMsg);
        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref Msg lpmsg);
        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, TernaryRasterOperations dwRop);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatus(ref MemoryStatus lpBuffer);
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentDirectory(uint nBufferLength, [Out] StringBuilder lpBuffer);
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool QueryPerformanceFrequency(out long frequency);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("user32.dll")]
        public static extern uint MsgWaitForMultipleObjects(uint nCount, IntPtr[] pHandles,
            bool bWaitAll, uint dwMilliseconds, QueueStatusFlags dwWakeMask);
        [DllImport("user32.dll")]
        public static extern uint MsgWaitForMultipleObjectsEx(uint nCount, IntPtr[] pHandles,
            uint dwMilliseconds, uint dwWakeMask, uint dwFlags);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin,
            uint wMsgFilterMax, PeekMessageParams wRemoveMsg);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        public static extern bool SetEvent(IntPtr hEvent);
    }
}
