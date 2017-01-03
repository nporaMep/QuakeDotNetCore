namespace Quake {
    public enum keydest_t {
        key_game,
        key_console,
        key_message,
        key_menu
    }

    public static class Keys {
        public static keydest_t key_dest;
        public static void Init() {
            //int i;

            //for (i = 0; i < 32; i++) {
            //    key_lines[i][0] = ']';
            //    key_lines[i][1] = 0;
            //}
            //key_linepos = 1;

            ////
            //// init ascii characters in console mode
            ////
            //for (i = 32; i < 128; i++)
            //    consolekeys[i] = true;
            //consolekeys[K_ENTER] = true;
            //consolekeys[K_TAB] = true;
            //consolekeys[K_LEFTARROW] = true;
            //consolekeys[K_RIGHTARROW] = true;
            //consolekeys[K_UPARROW] = true;
            //consolekeys[K_DOWNARROW] = true;
            //consolekeys[K_BACKSPACE] = true;
            //consolekeys[K_PGUP] = true;
            //consolekeys[K_PGDN] = true;
            //consolekeys[K_SHIFT] = true;
            //consolekeys[K_MWHEELUP] = true;
            //consolekeys[K_MWHEELDOWN] = true;
            //consolekeys['`'] = false;
            //consolekeys['~'] = false;

            //for (i = 0; i < 256; i++)
            //    keyshift[i] = i;
            //for (i = 'a'; i <= 'z'; i++)
            //    keyshift[i] = i - 'a' + 'A';
            //keyshift['1'] = '!';
            //keyshift['2'] = '@';
            //keyshift['3'] = '#';
            //keyshift['4'] = '$';
            //keyshift['5'] = '%';
            //keyshift['6'] = '^';
            //keyshift['7'] = '&';
            //keyshift['8'] = '*';
            //keyshift['9'] = '(';
            //keyshift['0'] = ')';
            //keyshift['-'] = '_';
            //keyshift['='] = '+';
            //keyshift[','] = '<';
            //keyshift['.'] = '>';
            //keyshift['/'] = '?';
            //keyshift[';'] = ':';
            //keyshift['\''] = '"';
            //keyshift['['] = '{';
            //keyshift[']'] = '}';
            //keyshift['`'] = '~';
            //keyshift['\\'] = '|';

            //menubound[K_ESCAPE] = true;
            //for (i = 0; i < 12; i++)
            //    menubound[K_F1 + i] = true;

            ////
            //// register our functions
            ////
            //Cmd.AddCommand("bind", Key_Bind_f);
            //Cmd.AddCommand("unbind", Key_Unbind_f);
            //Cmd.AddCommand("unbindall", Key_Unbindall_f);
        }
    }
}
