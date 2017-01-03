
using System;
using System.Diagnostics;

namespace Quake {
    public static class Host {
        static int minimum_memory;
        static quakeparms_t host_parms;
        static bool host_initialized;
        static byte[] host_basepal;
        static byte[] host_colormap;
        const string host_abortserver = "host_abortserver";
        static Random rand = new Random();
        public static void Init(quakeparms_t parms) {
            if (Com.standard_quake)
                minimum_memory = QuakeDef.MINIMUM_MEMORY;
            else
                minimum_memory = QuakeDef.MINIMUM_MEMORY_LEVELPAK;

            if (Com.CheckParm("-minmemory") != 0) {
                parms.membase = new byte[minimum_memory];
            }

            host_parms = parms;

            if (parms.membase.Length < minimum_memory)
                Sys.Error($"Only {parms.membase.Length / (float)0x100000:4.1f} megs of memory available, can't execute game");

            Com.largv = parms.argv;

            Zone.Memory_Init(parms.membase);
            Cmd.Cbuf_Init();
            Cmd.Cmd_Init();
            View.Init();
            Chase.Init();
            InitVCR(parms);
            Com.Init(parms.basedir);
            InitLocal();
            Wad.LoadWadFile("gfx.wad");
            Keys.Init();
            Cons.Init();
            Menu.Init();
            Predict.Init();
            Model.Init();
            Net.Init();
            Server.Init();

            //Cons.Printf("Exe: "__TIME__" "__DATE__"\n");
            Cons.Printf($"{parms.membase.Length / (1024 * 1024.0):%4.1f} megabyte heap\n");

            Render.InitTextures();       // needed even for dedicated servers

            if (Client.cls.state != cactive_t.ca_dedicated) {
                host_basepal = Com.LoadHunkFile("gfx/palette.lmp");
                if (host_basepal == null)
                    Sys.Error("Couldn't load gfx/palette.lmp");
                host_colormap = Com.LoadHunkFile("gfx/colormap.lmp");
                if (host_colormap == null)
                    Sys.Error("Couldn't load gfx/colormap.lmp");


                Video.Init(host_basepal);
                Draw.Init();
                Screen.Init();
                Render.Init();
                Sound.Init();

                CDAudio.Init();
                StatusBar.Init();
                Client.Init();
                Input.Init();
            }

            Cmd.Cbuf_InsertText("exec quake.rc\n");

            // Hunk_AllocName(0, "-HOST_HUNKLEVEL-");
            // host_hunklevel = Hunk_LowMark();

            host_initialized = true;

            Sys.Printf("========Quake Initialized=========\n");
        }

        static double timetotal;
        static int timecount;
        public static void Frame(float time) {
            double time1, time2;
            int c;
            double m;

            //TODO:
            //if (!serverprofile.value) {
            //    _Host_Frame(time);
            //    return;
            //}

            time1 = Sys.FloatTime();
            _Frame(time);
            time2 = Sys.FloatTime();

            timetotal += time2 - time1;
            timecount++;

            if (timecount < 1000)
                return;

            m = timetotal * 1000 / timecount;
            timecount = 0;
            timetotal = 0;
            c = 0;
            //TODO:
            //for (int i = 0; i < svs.maxclients; i++) {
            //    if (svs.clients[i].active)
            //        c++;
            //}

            Cons.Printf($"serverprofile: {c} clients {m} msec");
        }

        //Runs all active servers
        static double time1 = 0;
        static double time2 = 0;
        static double time3 = 0;
        static int host_framecount;
        static void _Frame(float time) {
            int pass1, pass2, pass3;

           
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(host_abortserver)))
                return;         // something bad happened, or the server disconnected

            // keep the random time dependent
            rand.Next();

            // decide the simulation time
            if (FilterTime(time))
                return;         // don't run too fast, or packets will flood out

            // get new key events
            Sys.SendKeyEvents();

            // allow mice or other external controllers to add commands
            Input.Commands();

            // process console commands
            Cmd.Cbuf_Execute();

            Net.Poll();

            // if running the server locally, make intentions now
            if (Server.sv.active)
                Client.SendCmd();

            //-------------------
            //
            // server operations
            //
            //-------------------

            // check for commands typed to the host
            GetConsoleCommands();

            if (Server.sv.active)
                ServerFrame();

            //-------------------
            //
            // client operations
            //
            //-------------------

            // if running the server remotely, send intentions now after
            // the incoming messages have been read
            if (!Server.sv.active)
                Client.SendCmd();

            host_time += host_frametime;

            // fetch results from server
            if (Client.cls.state == cactive_t.ca_connected) {
                Client.ReadFromServer();
            }

            // update video
            if (host_speeds.value != 0)
                time1 = Sys.FloatTime();

            Screen.UpdateScreen();

            if (host_speeds.value != 0)
                time2 = Sys.FloatTime();

            // update audio
            if (Client.cls.signon == Client.SIGNONS) {
                Sound.Update(Render.r_origin, Render.vpn, Render.vright, Render.vup);
                Client.DecayLights();
            } else
                Sound.Update(Mathlib.vec3_origin, Mathlib.vec3_origin, Mathlib.vec3_origin, Mathlib.vec3_origin);

            CDAudio.Update();

            if (host_speeds.value != 0) {
                pass1 = Convert.ToInt32((time1 - time3) * 1000);
                time3 = Sys.FloatTime();
                pass2 = Convert.ToInt32((time2 - time1) * 1000);
                pass3 = Convert.ToInt32((time3 - time2) * 1000);
                Cons.Printf($"{pass1 + pass2 + pass3} tot {pass1} server {pass2} gfx {pass3} snd");
            }

            host_framecount++;
        }

        static void ServerFrame() {
            // run the world state	
            Predict.pr_global_struct.frametime = Convert.ToSingle(host_frametime);

            // set the time and clear the general datagram
            Server.ClearDatagram();

            // check for new clients
            Server.CheckForNewClients();

            // read client messages
            Server.RunClients();

            // move things around and think
            // always pause in single player if in console or menus
            if (!Server.sv.paused && (Server.svs.maxclients > 1 || Keys.key_dest == keydest_t.key_game))
                Server.Physics();

            // send all messages to the clients
            Server.SendClientMessages();
        }

        //Add them exactly as if they had been typed at the console
        static void GetConsoleCommands() {
            //TODO:
            //string cmd;

            //while (true) {
            //    cmd = Sys.ConsoleInput();
            //    if (!cmd)
            //        break;
            //    Cmd.Cbuf_AddText(cmd);
            //}
        }

        static double host_frametime;
        static double realtime;                // without any filtering or bounding
        static double oldrealtime;
        //Returns false if the time is too short to run a frame
        static bool FilterTime(float time) {
            realtime += time;

            if (!Client.cls.timedemo && realtime - oldrealtime < 1.0 / 72.0) {
                return false;       // framerate is too high
            }

            host_frametime = realtime - oldrealtime;
            oldrealtime = realtime;

            if (host_framerate.value > 0)
                host_frametime = host_framerate.value;
            else {  // don't allow really long or short frames
                if (host_frametime > 0.1)
                    host_frametime = 0.1;
                if (host_frametime < 0.001)
                    host_frametime = 0.001;
            }

            return true;
        }

        static double host_time;
        static cvar_t host_framerate = cvar_t.Create("host_framerate", "0");
        static cvar_t host_speeds = cvar_t.Create("host_speeds", "0");
        static void InitLocal() {
            HostCmd.InitCommands();

            //TODO:
            Cvar.RegisterVariable(host_framerate);
            Cvar.RegisterVariable(host_speeds);

            //Cvar.RegisterVariable(&sys_ticrate);
            //Cvar.RegisterVariable(&serverprofile);

            //Cvar.RegisterVariable(&fraglimit);
            //Cvar.RegisterVariable(&timelimit);
            //Cvar.RegisterVariable(&teamplay);
            //Cvar.RegisterVariable(&samelevel);
            //Cvar.RegisterVariable(&noexit);
            //Cvar.RegisterVariable(&skill);
            //Cvar.RegisterVariable(&developer);
            //Cvar.RegisterVariable(&deathmatch);
            //Cvar.RegisterVariable(&coop);

            //Cvar.RegisterVariable(&pausable);

            //Cvar.RegisterVariable(&temp1);

            FindMaxClients();

            host_time = 1.0;        // so a think at time 0 won't get called
        }

        static void FindMaxClients() {
            //TODO:
            //int i;

            //svs.maxclients = 1;

            //i = COM_CheckParm("-dedicated");
            //if (i) {
            //    cls.state = ca_dedicated;
            //    if (i != (com_argc - 1)) {
            //        svs.maxclients = Q_atoi(com_argv[i + 1]);
            //    } else
            //        svs.maxclients = 8;
            //} else
            //    cls.state = ca_disconnected;

            //i = COM_CheckParm("-listen");
            //if (i) {
            //    if (cls.state == ca_dedicated)
            //        Sys_Error("Only one of -dedicated or -listen can be specified");
            //    if (i != (com_argc - 1))
            //        svs.maxclients = Q_atoi(com_argv[i + 1]);
            //    else
            //        svs.maxclients = 8;
            //}
            //if (svs.maxclients < 1)
            //    svs.maxclients = 8;
            //else if (svs.maxclients > MAX_SCOREBOARD)
            //    svs.maxclients = MAX_SCOREBOARD;

            //svs.maxclientslimit = svs.maxclients;
            //if (svs.maxclientslimit < 4)
            //    svs.maxclientslimit = 4;
            //svs.clients = Hunk_AllocName(svs.maxclientslimit * sizeof(client_t), "clients");

            //if (svs.maxclients > 1)
            //    Cvar_SetValue("deathmatch", 1.0);
            //else
            //    Cvar_SetValue("deathmatch", 0.0);
        }

        public static int vcrFile;
        const int VCR_SIGNATURE = 0x56435231;
        // "VCR1"

        static void InitVCR(quakeparms_t parms) {
            //TODO:
            //int i, len, n;

            //if (Com.CheckParm("-playback") != 0) {
            //    if (Com.largv.Length > 1)
            //        Sys.Error("No other parameters allowed with -playback\n");

            //    Sys_FileOpenRead("quake.vcr", &vcrFile);
            //    if (vcrFile == -1)
            //        Sys_Error("playback file not found\n");

            //    Sys_FileRead(vcrFile, &i, sizeof(int));
            //    if (i != VCR_SIGNATURE)
            //        Sys_Error("Invalid signature in vcr file\n");

            //    Sys_FileRead(vcrFile, &com_argc, sizeof(int));
            //    com_argv = malloc(com_argc * sizeof(char*));
            //    com_argv[0] = parms->argv[0];
            //    for (i = 0; i < com_argc; i++) {
            //        Sys_FileRead(vcrFile, &len, sizeof(int));
            //        char* p;
            //        p = malloc(len);
            //        Sys_FileRead(vcrFile, p, len);
            //        com_argv[i + 1] = p;
            //    }
            //    com_argc++; /* add one for arg[0] */
            //    parms->argc = com_argc;
            //    parms->argv = com_argv;
            //}

            //if ((n = COM_CheckParm("-record")) != 0) {
            //    vcrFile = Sys_FileOpenWrite("quake.vcr");

            //    i = VCR_SIGNATURE;
            //    Sys_FileWrite(vcrFile, &i, sizeof(int));
            //    i = com_argc - 1;
            //    Sys_FileWrite(vcrFile, &i, sizeof(int));
            //    for (i = 1; i < com_argc; i++) {
            //        if (i == n) {
            //            len = 10;
            //            Sys_FileWrite(vcrFile, &len, sizeof(int));
            //            Sys_FileWrite(vcrFile, "-playback", len);
            //            continue;
            //        }
            //        len = Q_strlen(com_argv[i]) + 1;
            //        Sys_FileWrite(vcrFile, &len, sizeof(int));
            //        Sys_FileWrite(vcrFile, com_argv[i], len);
            //    }
            //}
        }

        static bool isdown = false;
        // ===============
        // Host_Shutdown
        // 
        // FIXME: this is a callback from Sys_Quit and Sys_Error.  It would be better
        // to run quit through here before the final handoff to the sys code.
        // ===============
        public static void Shutdown() {

            if (isdown) {
                Console.WriteLine("recursive shutdown");
                return;
            }
            isdown = true;

            // keep Con_Printf from trying to update the screen
            //TODO:
            //scr_disabled_for_loading = true;

            //Host_WriteConfiguration();

            //CDAudio_Shutdown();
            //NET_Shutdown();
            //S_Shutdown();
            //IN_Shutdown();

            //if (cls.state != ca_dedicated) {
            //    VID_Shutdown();
            //}
        }
    }
}
