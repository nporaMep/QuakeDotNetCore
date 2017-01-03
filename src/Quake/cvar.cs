namespace Quake {
    public class cvar_t {
        public static cvar_t Create(string name, string @string, bool archive = false, bool server = false) =>
            new cvar_t {
                name = name,
                @string = @string,
                archive = archive,
                server = server
            };
        public string name;
        public string @string;
        public bool archive;       // set to true to cause it to be saved to vars.rc
        public bool server;        // notifies players when changed
        public float value;
    }

    public static class Cvar {
        public static string VariableString(string var_name) {
            return "";
            //TODO:
            //cvar_t* var;

            //var = Cvar_FindVar(var_name);
            //if (!var)
            //    return cvar_null_string;
            //return var->string;
        }

        //Adds a freestanding variable to the variable list.
        public static void RegisterVariable(cvar_t variable) {
            //char* oldstr;

            //// first check to see if it has allready been defined
            //if (Cvar_FindVar(variable->name)) {
            //    Con_Printf("Can't register variable %s, allready defined\n", variable->name);
            //    return;
            //}

            //// check for overlap with a command
            //if (Cmd_Exists(variable->name)) {
            //    Con_Printf("Cvar_RegisterVariable: %s is a command\n", variable->name);
            //    return;
            //}

            //// copy the value off, because future sets will Z_Free it
            //oldstr = variable->string;
            //variable->string = Z_Malloc(Q_strlen(variable->string) + 1);
            //Q_strcpy(variable->string, oldstr);
            //variable->value = Q_atof(variable->string);

            //// link the variable in
            //variable->next = cvar_vars;
            //cvar_vars = variable;
        }
    }
}
