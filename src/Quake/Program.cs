using Quake.Win32;
using System;
using System.Diagnostics;

namespace Quake {
    public class Program {
        static IntPtr MainWindow;
        private static IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam) {
            return Win32Methods.DefWindowProcW(hWnd, msg, wParam, lParam);
        }
        public static void Main(string[] args) {
            Sys.Run(args);

            return;
            var consoleWindow = Win32Methods.GetConsoleWindow();
            Win32Methods.ShowWindow(consoleWindow, ShowWindowCommands.Hide);


            IntPtr hInstance = Process.GetCurrentProcess().SafeHandle.DangerousGetHandle();
            WindowClass wc;

            /* Register the frame class */
            wc = new WindowClass();
            wc.lpszClassName = "WinQuake";
            wc.lpfnWndProc = CustomWndProc;

            wc.style = 0;
            wc.cbClsExtra = 0;
            wc.cbWndExtra = 0;
            wc.hInstance = hInstance;
            wc.hIcon = IntPtr.Zero;
            wc.hbrBackground = IntPtr.Zero;
            wc.lpszMenuName = "";

            var atom = Win32Methods.RegisterClass(ref wc);

            WindowStylesEx ExWindowStyle = WindowStylesEx.WS_EX_LEFT;
            WindowStyles WindowStyle = WindowStyles.WS_OVERLAPPED | WindowStyles.WS_BORDER | WindowStyles.WS_CAPTION | WindowStyles.WS_SYSMENU |
                WindowStyles.WS_MINIMIZEBOX | WindowStyles.WS_MAXIMIZEBOX | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_CLIPCHILDREN;

            Rect WindowRect = new Rect();
            WindowRect.Top = WindowRect.Left = 0;
            WindowRect.Right = 800;
            WindowRect.Bottom = 600;
            Win32Methods.AdjustWindowRectEx(ref WindowRect, (uint)WindowStyle, false, 0);

            MainWindow = Win32Methods.CreateWindowEx(
             ExWindowStyle,
             new IntPtr((int)(uint)atom),
             "WinQuake",
             WindowStyle,
             0, 0,
             WindowRect.Right - WindowRect.Left,
             WindowRect.Bottom - WindowRect.Top,
             IntPtr.Zero,
             IntPtr.Zero,
             hInstance,
             IntPtr.Zero);
            if (MainWindow == IntPtr.Zero) {
                var err = Win32Methods.GetLastError();
            }

            Win32Methods.ShowWindow(MainWindow, ShowWindowCommands.ShowDefault);

            Win32Methods.UpdateWindow(MainWindow);

            var hdc = Win32Methods.GetDC(MainWindow);
            Win32Methods.PatBlt(hdc, 0, 0, WindowRect.Right, WindowRect.Bottom, TernaryRasterOperations.BLACKNESS);
            Win32Methods.ReleaseDC(MainWindow, hdc);

            Msg msg;
            while (true) {
                while (Win32Methods.GetMessage(out msg, IntPtr.Zero, 0, 0) != 0) {
                    Win32Methods.TranslateMessage(ref msg);
                    Win32Methods.DispatchMessage(ref msg);
                }
            }
        }
    }
}
