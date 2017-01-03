namespace Quake {
    public static class Chase {
        static cvar_t chase_back = cvar_t.Create("chase_back", "100");
        static cvar_t chase_up = cvar_t.Create("chase_up", "16");
        static cvar_t chase_right = cvar_t.Create("chase_right", "0");
        static cvar_t chase_active = cvar_t.Create("chase_active", "0");

        public static void Init() {
            Cvar.RegisterVariable(chase_back);
            Cvar.RegisterVariable(chase_up);
            Cvar.RegisterVariable(chase_right);
            Cvar.RegisterVariable(chase_active);
        }
    }
}
