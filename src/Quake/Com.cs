using System;
using System.Linq;

namespace Quake {
    public static class Com {
        public static bool standard_quake = true, rogue, hipnotic;
        static string[] safeargvs = { "-stdvid", "-nolan", "-nosound", "-nocdaudio", "-nojoy", "-nomouse", "-dibonly" };
        public static string[] largv = new string[0];

        public static void InitArgv(string[] args) {
            largv = args.ToArray();
            if (args.Contains("-safe", StringComparer.OrdinalIgnoreCase))
                largv = largv.Union(safeargvs).ToArray();
            if (args.Contains("-rogue", StringComparer.OrdinalIgnoreCase))
                rogue = true;
            if (args.Contains("-hipnotic", StringComparer.OrdinalIgnoreCase))
                hipnotic = true;
            standard_quake = !hipnotic && !rogue;
        }

        // Returns the position (1 to argc-1) in the program's argument list
        // where the given parameter apears, or 0 if not present
        public static int CheckParm(string parm) {
            int i;

            for (i = 1; i < largv.Length; i++)
                if (string.Equals(largv[i], parm, StringComparison.OrdinalIgnoreCase))
                    return i;
            return 0;
        }

        static cvar_t registered = cvar_t.Create("registered", "0");
        static cvar_t cmdline = cvar_t.Create("cmdline", "0", false, true);
        public static void Init(string basedir) {
            byte[] swaptest = { 1, 0 };

            // set the byte swapping variables in a portable manner 
            //TODO:
            //if (*(short*)swaptest == 1) {
            //    bigendien = false;
            //    BigShort = ShortSwap;
            //    LittleShort = ShortNoSwap;
            //    BigLong = LongSwap;
            //    LittleLong = LongNoSwap;
            //    BigFloat = FloatSwap;
            //    LittleFloat = FloatNoSwap;
            //} else {
            //    bigendien = true;
            //    BigShort = ShortNoSwap;
            //    LittleShort = ShortSwap;
            //    BigLong = LongNoSwap;
            //    LittleLong = LongSwap;
            //    BigFloat = FloatNoSwap;
            //    LittleFloat = FloatSwap;
            //}

            Cvar.RegisterVariable(registered);
            Cvar.RegisterVariable(cmdline);
            Cmd.AddCommand("path", Path_f);

            InitFilesystem();
            CheckRegistered();
        }

        public static byte[] LoadHunkFile(string path) {
            return LoadFile(path, 1);
        }

        static byte[] LoadFile(string path, int usehunk) {
            //int h;
            byte[] buf = null;
            //char[] bas = new char[32];
            //int len;

            //TODO:
            //// look for it in the filesystem or pack files
            //len = COM_OpenFile(path, &h);
            //if (h == -1)
            //    return NULL;

            //// extract the filename base name for hunk tag
            //COM_FileBase(path, base);

            //if (usehunk == 1)
            //    buf = Hunk_AllocName(len + 1, base);
            //else if (usehunk == 2)
            //    buf = Hunk_TempAlloc(len + 1);
            //else if (usehunk == 0)
            //    buf = Z_Malloc(len + 1);
            //else if (usehunk == 3)
            //    buf = Cache_Alloc(loadcache, len + 1, base);
            //else if (usehunk == 4) {
            //    if (len + 1 > loadsize)
            //        buf = Hunk_TempAlloc(len + 1);
            //    else
            //        buf = loadbuf;
            //} else
            //    Sys_Error("COM_LoadFile: bad usehunk");

            //if (!buf)
            //    Sys_Error("COM_LoadFile: not enough space for %s", path);

            //((byte*)buf)[len] = 0;

            //Draw_BeginDisc();
            //Sys_FileRead(h, buf, len);
            //COM_CloseFile(h);
            //Draw_EndDisc();

            return buf;
        }

        static void Path_f() {
            //searchpath_t* s;

            //Cons.Printf("Current search path:");
            //for (s = com_searchpaths; s; s = s->next) {
            //    if (s->pack) {
            //        Cons.Printf($"%s (%i files)", s->pack->filename, s->pack->numfiles);
            //    } else
            //        Cons.Printf($"%s", s->filename);
            //}
        }

        static void InitFilesystem() {
            //TODO:
            //int i, j;
            //char basedir[MAX_OSPATH];
            //searchpath_t* search;

            ////
            //// -basedir <path>
            //// Overrides the system supplied base directory (under GAMENAME)
            ////
            //i = COM_CheckParm("-basedir");
            //if (i && i < com_argc - 1)
            //    strcpy(basedir, com_argv[i + 1]);
            //else
            //    strcpy(basedir, host_parms.basedir);

            //j = strlen(basedir);

            //if (j > 0) {
            //    if ((basedir[j - 1] == '\\') || (basedir[j - 1] == '/'))
            //        basedir[j - 1] = 0;
            //}

            ////
            //// -cachedir <path>
            //// Overrides the system supplied cache directory (NULL or /qcache)
            //// -cachedir - will disable caching.
            ////
            //i = COM_CheckParm("-cachedir");
            //if (i && i < com_argc - 1) {
            //    if (com_argv[i + 1][0] == '-')
            //        com_cachedir[0] = 0;
            //    else
            //        strcpy(com_cachedir, com_argv[i + 1]);
            //} else if (host_parms.cachedir)
            //    strcpy(com_cachedir, host_parms.cachedir);
            //else
            //    com_cachedir[0] = 0;

            ////
            //// start up with GAMENAME by default (id1)
            ////
            //COM_AddGameDirectory(va("%s/"GAMENAME, basedir));

            //if (COM_CheckParm("-rogue"))
            //    COM_AddGameDirectory(va("%s/rogue", basedir));
            //if (COM_CheckParm("-hipnotic"))
            //    COM_AddGameDirectory(va("%s/hipnotic", basedir));

            ////
            //// -game <gamedir>
            //// Adds basedir/gamedir as an override game
            ////
            //i = COM_CheckParm("-game");
            //if (i && i < com_argc - 1) {
            //    com_modified = true;
            //    COM_AddGameDirectory(va("%s/%s", basedir, com_argv[i + 1]));
            //}

            ////
            //// -path <dir or packfile> [<dir or packfile>] ...
            //// Fully specifies the exact serach path, overriding the generated one
            ////
            //i = COM_CheckParm("-path");
            //if (i) {
            //    com_modified = true;
            //    com_searchpaths = NULL;
            //    while (++i < com_argc) {
            //        if (!com_argv[i] || com_argv[i][0] == '+' || com_argv[i][0] == '-')
            //            break;

            //        search = Hunk_Alloc(sizeof(searchpath_t));
            //        if (!strcmp(COM_FileExtension(com_argv[i]), "pak")) {
            //            search->pack = COM_LoadPackFile(com_argv[i]);
            //            if (!search->pack)
            //                Sys_Error("Couldn't load packfile: %s", com_argv[i]);
            //        } else
            //            strcpy(search->filename, com_argv[i]);
            //        search->next = com_searchpaths;
            //        com_searchpaths = search;
            //    }
            //}

            //if (COM_CheckParm("-proghack"))
            //    proghack = true;
        }

        //Looks for the pop.txt file and verifies it.
        //Sets the "registered" cvar.
        //Immediately exits out if an alternate game was attempted to be started without
        //being registered.
        static void CheckRegistered() {
//            int h;
//            ushort check[128];
//            int i;

//            COM_OpenFile("gfx/pop.lmp", &h);
//            static_registered = 0;

//            if (h == -1) {
//#if WINDED
//	Sys_Error ("This dedicated server requires a full registered copy of Quake");
//#endif
//                Con_Printf("Playing shareware version.\n");
//                if (com_modified)
//                    Sys_Error("You must have the registered version to use modified games");
//                return;
//            }

//            Sys_FileRead(h, check, sizeof(check));
//            COM_CloseFile(h);

//            for (i = 0; i < 128; i++)
//                if (pop[i] != (unsigned short)BigShort(check[i]))
//			Sys_Error("Corrupted data file.");

//            Cvar_Set("cmdline", com_cmdline);
//            Cvar_Set("registered", "1");
//            static_registered = 1;
//            Con_Printf("Playing registered version.\n");
        }

        //TODO:
        //public static void SZ_Alloc(sizebuf_t* buf, int startsize) {
        //    if (startsize < 256)
        //        startsize = 256;
        //    buf->data = Hunk_AllocName(startsize, "sizebuf");
        //    buf->maxsize = startsize;
        //    buf->cursize = 0;
        //}
    }
}
