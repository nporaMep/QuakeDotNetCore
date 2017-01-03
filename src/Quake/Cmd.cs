using System;
using System.Collections.Generic;
using System.Linq;

namespace Quake {
    public static class Cmd {
        public struct cmd_function_t {
            public string name;
            public Action function;
        }
        static bool host_initialized;
        static List<cmd_function_t> cmd_functions = new List<cmd_function_t>();

        //TODO:
        //static sizebuf_t cmd_text;
        public static void Cbuf_Init() {
            //TODO:
            //SZ_Alloc(&cmd_text, 8192);		// space for commands and script files
        }
        public static void Cbuf_InsertText(string text) {
            //TODO:
            //char* temp;
            //int templen;

            //// copy off any commands still remaining in the exec buffer
            //templen = cmd_text.cursize;
            //if (templen) {
            //    temp = Z_Malloc(templen);
            //    Q_memcpy(temp, cmd_text.data, templen);
            //    SZ_Clear(&cmd_text);
            //} else
            //    temp = NULL;    // shut up compiler

            //// add the entire text of the file
            //Cbuf_AddText(text);

            //// add the copied off data
            //if (templen) {
            //    SZ_Write(&cmd_text, temp, templen);
            //    Z_Free(temp);
            //}
        }
        public static void Cbuf_Execute() {
            //TODO:
            //int i;
            //string text;
            //char line[1024];
            //int quotes;

            //while (cmd_text.cursize) {
            //    // find a \n or ; line break
            //    text = (char*)cmd_text.data;

            //    quotes = 0;
            //    for (i = 0; i < cmd_text.cursize; i++) {
            //        if (text[i] == '"')
            //            quotes++;
            //        if (!(quotes & 1) && text[i] == ';')
            //            break;  // don't break if inside a quoted string
            //        if (text[i] == '\n')
            //            break;
            //    }


            //    memcpy(line, text, i);
            //    line[i] = 0;

            //    // delete the text from the command buffer and move remaining commands down
            //    // this is necessary because commands (exec, alias) can insert data at the
            //    // beginning of the text buffer

            //    if (i == cmd_text.cursize)
            //        cmd_text.cursize = 0;
            //    else {
            //        i++;
            //        cmd_text.cursize -= i;
            //        Q_memcpy(text, text + i, cmd_text.cursize);
            //    }

            //    // execute the command line
            //    Cmd_ExecuteString(line, src_command);

            //    if (cmd_wait) { // skip out while text still remains in buffer, leaving it
            //                    // for next frame
            //        cmd_wait = false;
            //        break;
            //    }
            //}
        }
        public static void Cmd_Init() {
            AddCommand("stuffcmds", Cmd_StuffCmds_f);
            AddCommand("exec", Cmd_Exec_f);
            AddCommand("echo", Cmd_Echo_f);
            AddCommand("alias", Cmd_Alias_f);
            AddCommand("cmd", Cmd_ForwardToServer);
            AddCommand("wait", Cmd_Wait_f);
        }
        public static void AddCommand(string cmd_name, Action function) {

            if (host_initialized)   // because hunk allocation would get stomped
                Sys.Error("Cmd_AddCommand after host_initialized");

            // fail if the command is a variable name
            if (!string.IsNullOrEmpty(Cvar.VariableString(cmd_name)))
                Cons.Printf($"Cmd_AddCommand: {cmd_name} already defined as a var");
            else if (cmd_functions.Any(cmd => cmd.name.Equals(cmd_name)))
                Cons.Printf($"Cmd_AddCommand: {cmd_name} already defined");
            else {
                var cmd = new cmd_function_t();
                cmd.name = cmd_name;
                cmd.function = function;
                cmd_functions.Add(cmd);
            }
        }
 
        // ===============
        // Adds command line parameters as script statements
        // Commands lead with a +, and continue until a - or another +
        // quake +prog jctest.qp +cmd amlev1
        // quake -nosound +cmd amlev1
        // ===============
        static void Cmd_StuffCmds_f() {
            //TODO:
            //int i, j;
            //int s;
            //char* text, *build, c;

            //if (Cmd_Argc() != 1) {
            //    Con_Printf("stuffcmds : execute command line parameters\n");
            //    return;
            //}

            //// build the combined string to parse from
            //s = 0;
            //for (i = 1; i < com_argc; i++) {
            //    if (!com_argv[i])
            //        continue;       // NEXTSTEP nulls out -NXHost
            //    s += Q_strlen(com_argv[i]) + 1;
            //}
            //if (!s)
            //    return;

            //text = Z_Malloc(s + 1);
            //text[0] = 0;
            //for (i = 1; i < com_argc; i++) {
            //    if (!com_argv[i])
            //        continue;       // NEXTSTEP nulls out -NXHost
            //    Q_strcat(text, com_argv[i]);
            //    if (i != com_argc - 1)
            //        Q_strcat(text, " ");
            //}

            //// pull out the commands
            //build = Z_Malloc(s + 1);
            //build[0] = 0;

            //for (i = 0; i < s - 1; i++) {
            //    if (text[i] == '+') {
            //        i++;

            //        for (j = i; (text[j] != '+') && (text[j] != '-') && (text[j] != 0); j++)
            //            ;

            //        c = text[j];
            //        text[j] = 0;

            //        Q_strcat(build, text + i);
            //        Q_strcat(build, "\n");
            //        text[j] = c;
            //        i = j - 1;
            //    }
            //}

            //if (build[0])
            //    Cbuf_InsertText(build);

            //Z_Free(text);
            //Z_Free(build);
        }

        static void Cmd_Exec_f() {
            //TODO:
            //char* f;
            //int mark;

            //if (Cmd_Argc() != 2) {
            //    Con_Printf("exec <filename> : execute a script file\n");
            //    return;
            //}

            //mark = Hunk_LowMark();
            //f = (char*)COM_LoadHunkFile(Cmd_Argv(1));
            //if (!f) {
            //    Con_Printf("couldn't exec %s\n", Cmd_Argv(1));
            //    return;
            //}
            //Con_Printf("execing %s\n", Cmd_Argv(1));

            //Cbuf_InsertText(f);
            //Hunk_FreeToLowMark(mark);
        }

        static void Cmd_Echo_f() {
            //TODO:
            //for (int i = 1; i < Cmd_Argc(); i++)
            //    Console.Printf("%s ", Cmd_Argv(i));
            Cons.Printf("\n");
        }

        static void Cmd_Alias_f() {
            //TODO:
            //cmdalias_t* a;
            //char cmd[1024];
            //int i, c;
            //char* s;

            //if (Cmd_Argc() == 1) {
            //    Con_Printf("Current alias commands:\n");
            //    for (a = cmd_alias; a; a = a->next)
            //        Con_Printf("%s : %s\n", a->name, a->value);
            //    return;
            //}

            //s = Cmd_Argv(1);
            //if (strlen(s) >= MAX_ALIAS_NAME) {
            //    Con_Printf("Alias name is too long\n");
            //    return;
            //}

            //// if the alias allready exists, reuse it
            //for (a = cmd_alias; a; a = a->next) {
            //    if (!strcmp(s, a->name)) {
            //        Z_Free(a->value);
            //        break;
            //    }
            //}

            //if (!a) {
            //    a = Z_Malloc(sizeof(cmdalias_t));
            //    a->next = cmd_alias;
            //    cmd_alias = a;
            //}
            //strcpy(a->name, s);

            //// copy the rest of the command line
            //cmd[0] = 0;     // start out with a null string
            //c = Cmd_Argc();
            //for (i = 2; i < c; i++) {
            //    strcat(cmd, Cmd_Argv(i));
            //    if (i != c)
            //        strcat(cmd, " ");
            //}
            //strcat(cmd, "\n");

            //a->value = CopyString(cmd);
        }

        //Sends the entire command line over to the server
        static void Cmd_ForwardToServer() {
            //TODO:
            //if (cls.state != ca_connected) {
            //    Con_Printf("Can't \"%s\", not connected\n", Cmd_Argv(0));
            //    return;
            //}

            //if (cls.demoplayback)
            //    return;     // not really connected

            //MSG_WriteByte(&cls.message, clc_stringcmd);
            //if (Q_strcasecmp(Cmd_Argv(0), "cmd") != 0) {
            //    SZ_Print(&cls.message, Cmd_Argv(0));
            //    SZ_Print(&cls.message, " ");
            //}
            //if (Cmd_Argc() > 1)
            //    SZ_Print(&cls.message, Cmd_Args());
            //else
            //    SZ_Print(&cls.message, "\n");
        }

        static bool cmd_wait;
        static void Cmd_Wait_f() {
            cmd_wait = true;
        }
    }
}
