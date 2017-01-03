namespace Quake {
    public static class Cons {
        public static void Init() {
            //TODO:
            //const int MAXGAMEDIRLEN = 1000;
            //char temp[MAXGAMEDIRLEN + 1];
            //char* t2 = "/qconsole.log";

            //con_debuglog = COM_CheckParm("-condebug");

            //if (con_debuglog) {
            //    if (strlen(com_gamedir) < (MAXGAMEDIRLEN - strlen(t2))) {
            //        sprintf(temp, "%s%s", com_gamedir, t2);
            //        unlink(temp);
            //    }
            //}

            //con_text = Hunk_AllocName(CON_TEXTSIZE, "context");
            //Q_memset(con_text, ' ', CON_TEXTSIZE);
            //con_linewidth = -1;
            //Con_CheckResize();

            //Printf("Console initialized.\n");

            ////
            //// register our commands
            ////
            //Cvar.RegisterVariable(&con_notifytime);

            //Cmd.AddCommand("toggleconsole", Con_ToggleConsole_f);
            //Cmd.AddCommand("messagemode", Con_MessageMode_f);
            //Cmd.AddCommand("messagemode2", Con_MessageMode2_f);
            //Cmd.AddCommand("clear", Con_Clear_f);
            //con_initialized = true;
        }

        public static void Printf(string str) {
            //TODO:
            //va_list argptr;
            //char msg[MAXPRINTMSG];
            //static qboolean inupdate;

            //va_start(argptr, fmt);
            //vsprintf(msg, fmt, argptr);
            //va_end(argptr);

            //// also echo to debugging console
            //Sys_Printf("%s", msg);  // also echo to debugging console

            //// log all messages to file
            //if (con_debuglog)
            //    Con_DebugLog(va("%s/qconsole.log", com_gamedir), "%s", msg);

            //if (!con_initialized)
            //    return;

            //if (cls.state == ca_dedicated)
            //    return;     // no graphics mode

            //// write it to the scrollable buffer
            //Con_Print(msg);

            //// update the screen if the console is displayed
            //if (cls.signon != SIGNONS && !scr_disabled_for_loading) {
            //    // protect against infinite loop if something in SCR_UpdateScreen calls
            //    // Con_Printd
            //    if (!inupdate) {
            //        inupdate = true;
            //        SCR_UpdateScreen();
            //        inupdate = false;
            //    }
            //}
        }
    }
}
