using Quake.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quake {
    public struct quakeparms_t {
        public string basedir;
        public string cachedir;     // for development over ISDN lines
        public string[] argv;
        public byte[] membase;
    }

    public static class Sys {
        public const int MINIMUM_WIN_MEMORY = 0x0880000;
        public const int MAXIMUM_WIN_MEMORY = 0x1000000;
        const uint PAUSE_SLEEP = 50;                // sleep time on pause or minimization
        const uint NOT_FOCUS_SLEEP = 20;			// sleep time when not focus

        public static IntPtr hInstance;
        static IntPtr tevent;
        static bool ActiveApp, Minimized;
        public static void Run(string[] args) {
            hInstance = Process.GetCurrentProcess().SafeHandle.DangerousGetHandle();

            var lpBuffer = new MemoryStatus();
            Win32Methods.GlobalMemoryStatus(ref lpBuffer);

            var cwd = new StringBuilder(1024);
            if (Win32Methods.GetCurrentDirectory(1024, cwd) == 0)
                Error("Couldn't determine current directory");

            quakeparms_t parms = new quakeparms_t();
            parms.basedir = cwd.ToString();
            parms.argv = args;

            //TODO:
            Com.InitArgv(args);

            isDedicated = Com.CheckParm("-dedicated") != 0;

            //TODO: not clear what it is for
            //if (!isDedicated) {
            //    hwnd_dialog = CreateDialog(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, NULL);

            //    if (hwnd_dialog) {
            //        if (GetWindowRect(hwnd_dialog, &rect)) {
            //            if (rect.left > (rect.top * 2)) {
            //                SetWindowPos(hwnd_dialog, 0,
            //                    (rect.left / 2) - ((rect.right - rect.left) / 2),
            //                    rect.top, 0, 0,
            //                    SWP_NOZORDER | SWP_NOSIZE);
            //            }
            //        }

            //        ShowWindow(hwnd_dialog, SW_SHOWDEFAULT);
            //        UpdateWindow(hwnd_dialog);
            //        SetForegroundWindow(hwnd_dialog);
            //    }
            //}

            //TODO: need to use GlobalMemoryStatusEx for 4GB+ PCs
            //parms.memsize = lpBuffer.dwAvailPhys;

            //if (parms.memsize < MINIMUM_WIN_MEMORY)
            //    parms.memsize = MINIMUM_WIN_MEMORY;

            //if (parms.memsize < (lpBuffer.dwTotalPhys >> 1))
            //    parms.memsize = lpBuffer.dwTotalPhys >> 1;

            //if (parms.memsize > MAXIMUM_WIN_MEMORY)
            //    parms.memsize = MAXIMUM_WIN_MEMORY;

            //TODO: not needed probably
            //if (COM_CheckParm("-heapsize")) {
            //    t = COM_CheckParm("-heapsize") + 1;

            //    if (t < com_argc)
            //        parms.memsize = Q_atoi(com_argv[t]) * 1024;
            //}

            parms.membase = new byte[MAXIMUM_WIN_MEMORY];

            //TODO: not needed
            //if (!parms.membase)
            //    Sys_Error("Not enough memory free; check disk space\n");

            PageIn(parms.membase);

            tevent = Win32Methods.CreateEvent(IntPtr.Zero, false, false, null);
            if (tevent == IntPtr.Zero)
                Error("Couldn't create event");

            //TODO: skipping dedicated server for now
            //if (isDedicated) {
            //    if (!AllocConsole()) {
            //        Sys_Error("Couldn't create dedicated server console");
            //    }

            //    hinput = GetStdHandle(STD_INPUT_HANDLE);
            //    houtput = GetStdHandle(STD_OUTPUT_HANDLE);

            //    // give QHOST a chance to hook into the console
            //    if ((t = COM_CheckParm("-HFILE")) > 0) {
            //        if (t < com_argc)
            //            hFile = (HANDLE)Q_atoi(com_argv[t + 1]);
            //    }

            //    if ((t = COM_CheckParm("-HPARENT")) > 0) {
            //        if (t < com_argc)
            //            heventParent = (HANDLE)Q_atoi(com_argv[t + 1]);
            //    }

            //    if ((t = COM_CheckParm("-HCHILD")) > 0) {
            //        if (t < com_argc)
            //            heventChild = (HANDLE)Q_atoi(com_argv[t + 1]);
            //    }

            //    InitConProc(hFile, heventParent, heventChild);
            //}

            Init();

            // because sound is off until we become active
            Sound.BlockSound();

            Printf("Host_Init");
            Host.Init(parms);

            double time = 0, oldtime, newtime = 0;

            oldtime = FloatTime();

            /* main window message loop */
            while (true) {
                if (isDedicated) {
                    //        newtime = Sys_FloatTime();
                    //        time = newtime - oldtime;

                    //        while (time < sys_ticrate.value) {
                    //            Sys_Sleep();
                    //            newtime = Sys_FloatTime();
                    //            time = newtime - oldtime;
                    //        }
                } else {
                    // yield the CPU for a little while when paused, minimized, or not the focus
                    //if ((Client.cl.paused && (!ActiveApp && !Video.DDActive)) || Minimized || Screen.block_drawing) {
                    //    SleepUntilInput(PAUSE_SLEEP);
                    //    Screen.scr_skipupdate = true;     // no point in bothering to draw
                    //} else if (!ActiveApp && !Video.DDActive) {
                    //    SleepUntilInput(NOT_FOCUS_SLEEP);
                    //}

                    newtime = FloatTime();
                    time = newtime - oldtime;
                }

                Host.Frame(Convert.ToSingle(time));
                oldtime = newtime;
            }
        }

        public static void SendKeyEvents() {
            Msg msg;

            while (Win32Methods.PeekMessage(out msg, IntPtr.Zero, 0, 0, PeekMessageParams.PM_NOREMOVE)) {
                // we always update if there are any event, even if we're paused
                Screen.scr_skipupdate = false;

                if (Win32Methods.GetMessage(out msg, IntPtr.Zero, 0, 0) == 0)
                    Quit();

                Win32Methods.TranslateMessage(ref msg);
                Win32Methods.DispatchMessage(ref msg);
            }
        }

        public static void Printf(string str) {
            if (isDedicated) {
                Console.WriteLine(str);
            }
        }

        static void Quit() {
            Video.ForceUnlockedAndReturnState();

            Host.Shutdown();

            if (tevent != IntPtr.Zero)
                Win32Methods.CloseHandle(tevent);

            if (isDedicated)
                Win32Methods.FreeConsole();

            // shut down QHOST hooks if necessary
            ConProc.DeinitConProc();

            Environment.Exit(0);
        }

        static void SleepUntilInput(uint time) {
           Win32Methods.MsgWaitForMultipleObjects(1, new IntPtr[] { tevent }, false, time, QueueStatusFlags.QS_ALLINPUT);
        }

        static double pfreq;
        static void Init() {
            long PerformanceFreq;
            if (!Win32Methods.QueryPerformanceFrequency(out PerformanceFreq))
                Error("No hardware timer available");

            pfreq = 1.0 / (double)PerformanceFreq;

            InitFloatTime();
        }

        static double curtime = 0.0;
        static double lastcurtime = 0.0;
        static void InitFloatTime() {
            //int j;

            FloatTime();

            //TODO: support -starttime
            //j = Com.CheckParm("-starttime");

            //if (j) {
            //    curtime = (double)(Q_atof(com_argv[j + 1]));
            //} else {
                curtime = 0.0;
            //}

            lastcurtime = curtime;
        }

        static int sametimecount;
        static double oldtime = 0.0;
        static bool first = true;
        public static double FloatTime() {
            long PerformanceCount;
            long temp;
            double t2;
            double time;

            Win32Methods.QueryPerformanceCounter(out PerformanceCount);

            temp = PerformanceCount;

            if (first) {
                oldtime = temp;
                first = false;
            } else {
                // check for turnover or backward time
                if ((temp <= oldtime) && ((oldtime - temp) < 0x10000000)) {
                    oldtime = temp; // so we can't get stuck
                } else {
                    t2 = temp - oldtime;

                    time = t2 * pfreq;
                    oldtime = temp;

                    curtime += time;

                    if (curtime == lastcurtime) {
                        sametimecount++;

                        if (sametimecount > 100000) {
                            curtime += 1.0;
                            sametimecount = 0;
                        }
                    } else {
                        sametimecount = 0;
                    }

                    lastcurtime = curtime;
                }
            }

            return curtime;
        }

        static void PageIn(byte[] membase) {
            //TODO: not needed
            //byte* x;
            //int j, m, n;

            //// touch all the memory to make sure it's there. The 16-page skip is to
            //// keep Win 95 from thinking we're trying to page ourselves in (we are
            //// doing that, of course, but there's no reason we shouldn't)
            //x = (byte*)ptr;

            //for (n = 0; n < 4; n++) {
            //    for (m = 0; m < (size - 16 * 0x1000); m += 4) {
            //        sys_checksum += *(int*)&x[m];
            //        sys_checksum += *(int*)&x[m + 16 * 0x1000];
            //    }
            //}
        }

        static bool in_sys_error0;
        static bool in_sys_error1;
        static bool in_sys_error2;
        static bool in_sys_error3;
        static bool isDedicated;
        public static void Error(string error) {
            if (!in_sys_error3) {
                in_sys_error3 = true;
                Video.ForceUnlockedAndReturnState();
            }

            if (isDedicated) {
                Console.WriteLine();
                Console.WriteLine("***********************************");
                Console.WriteLine($"ERROR: {error}");
                Console.WriteLine("Press Enter to exit");
                Console.WriteLine("***********************************");

                //TODO:
                //starttime = Sys_FloatTime();
                //sc_return_on_enter = true;  // so Enter will get us out of here

                //while (!Sys_ConsoleInput() &&
                //        ((Sys_FloatTime() - starttime) < CONSOLE_ERROR_TIMEOUT)) {
                //}
            } else {
                // switch to windowed so the message box is visible, unless we already
                // tried that and failed
                //TODO:
                //if (!in_sys_error0) {
                //    in_sys_error0 = 1;
                //    VID_SetDefaultMode();
                //    MessageBox(NULL, text, "Quake Error",
                //               MB_OK | MB_SETFOREGROUND | MB_ICONSTOP);
                //} else {
                //    MessageBox(NULL, text, "Double Quake Error",
                //               MB_OK | MB_SETFOREGROUND | MB_ICONSTOP);
                //}
            }

            if (!in_sys_error1) {
                in_sys_error1 = true;
                Host.Shutdown();
            }

            // shut down QHOST hooks if necessary
            //if (!in_sys_error2) {
            //    in_sys_error2 = 1;
            //    DeinitConProc();
            //}

            Environment.Exit(1);
        }


    }
}
