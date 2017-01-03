using System;

namespace Quake {
    public static class View
    {
        static cvar_t lcd_x = cvar_t.Create("lcd_x", "0");
        static cvar_t lcd_yaw = cvar_t.Create("lcd_yaw", "0");
        static cvar_t scr_ofsx = cvar_t.Create("scr_ofsx", "0", false);
        static cvar_t scr_ofsy = cvar_t.Create("scr_ofsy", "0", false);
        static cvar_t scr_ofsz = cvar_t.Create("scr_ofsz", "0", false);
        static cvar_t cl_rollspeed = cvar_t.Create("cl_rollspeed", "200");
        static cvar_t cl_rollangle = cvar_t.Create("cl_rollangle", "2.0");
        static cvar_t cl_bob = cvar_t.Create("cl_bob", "0.02", false);
        static cvar_t cl_bobcycle = cvar_t.Create("cl_bobcycle", "0.6", false);
        static cvar_t cl_bobup = cvar_t.Create("cl_bobup", "0.5", false);
        static cvar_t v_kicktime = cvar_t.Create("v_kicktime", "0.5", false);
        static cvar_t v_kickroll = cvar_t.Create("v_kickroll", "0.6", false);
        static cvar_t v_kickpitch = cvar_t.Create("v_kickpitch", "0.6", false);
        static cvar_t v_iyaw_cycle = cvar_t.Create("v_iyaw_cycle", "2", false);
        static cvar_t v_iroll_cycle = cvar_t.Create("v_iroll_cycle", "0.5", false);
        static cvar_t v_ipitch_cycle = cvar_t.Create("v_ipitch_cycle", "1", false);
        static cvar_t v_iyaw_level = cvar_t.Create("v_iyaw_level", "0.3", false);
        static cvar_t v_iroll_level = cvar_t.Create("v_iroll_level", "0.1", false);
        static cvar_t v_ipitch_level = cvar_t.Create("v_ipitch_level", "0.3", false);
        static cvar_t v_idlescale = cvar_t.Create("v_idlescale", "0", false);
        static cvar_t crosshair = cvar_t.Create("crosshair", "0", true);
        static cvar_t cl_crossx = cvar_t.Create("cl_crossx", "0", false);
        static cvar_t cl_crossy = cvar_t.Create("cl_crossy", "0", false);
        static cvar_t gl_cshiftpercent = cvar_t.Create("gl_cshiftpercent", "100", false);
        static cvar_t v_centermove = cvar_t.Create("v_centermove", "0.15", false);
        static cvar_t v_centerspeed = cvar_t.Create("v_centerspeed", "500");
        static cvar_t v_gamma = cvar_t.Create("gamma", "1", true);

        public static void Init() {
            Cmd.AddCommand("v_cshift", V_cshift_f);
            Cmd.AddCommand("bf", V_BonusFlash_f);
            Cmd.AddCommand("centerview", V_StartPitchDrift);

            Cvar.RegisterVariable(lcd_x);
            Cvar.RegisterVariable(lcd_yaw);

            Cvar.RegisterVariable(v_centermove);
            Cvar.RegisterVariable(v_centerspeed);

            Cvar.RegisterVariable(v_iyaw_cycle);
            Cvar.RegisterVariable(v_iroll_cycle);
            Cvar.RegisterVariable(v_ipitch_cycle);
            Cvar.RegisterVariable(v_iyaw_level);
            Cvar.RegisterVariable(v_iroll_level);
            Cvar.RegisterVariable(v_ipitch_level);

            Cvar.RegisterVariable(v_idlescale);
            Cvar.RegisterVariable(crosshair);
            Cvar.RegisterVariable(cl_crossx);
            Cvar.RegisterVariable(cl_crossy);
            Cvar.RegisterVariable(gl_cshiftpercent);

            Cvar.RegisterVariable(scr_ofsx);
            Cvar.RegisterVariable(scr_ofsy);
            Cvar.RegisterVariable(scr_ofsz);
            Cvar.RegisterVariable(cl_rollspeed);
            Cvar.RegisterVariable(cl_rollangle);
            Cvar.RegisterVariable(cl_bob);
            Cvar.RegisterVariable(cl_bobcycle);
            Cvar.RegisterVariable(cl_bobup);

            Cvar.RegisterVariable(v_kicktime);
            Cvar.RegisterVariable(v_kickroll);
            Cvar.RegisterVariable(v_kickpitch);

            BuildGammaTable(1.0f);   // no gamma yet
            Cvar.RegisterVariable(v_gamma);
        }

        static void V_cshift_f() {
            //TODO:
            //cshift_empty.destcolor[0] = atoi(Cmd_Argv(1));
            //cshift_empty.destcolor[1] = atoi(Cmd_Argv(2));
            //cshift_empty.destcolor[2] = atoi(Cmd_Argv(3));
            //cshift_empty.percent = atoi(Cmd_Argv(4));
        }

        static void V_BonusFlash_f() {
            //TODO:
            //cl.cshifts[CSHIFT_BONUS].destcolor[0] = 215;
            //cl.cshifts[CSHIFT_BONUS].destcolor[1] = 186;
            //cl.cshifts[CSHIFT_BONUS].destcolor[2] = 69;
            //cl.cshifts[CSHIFT_BONUS].percent = 50;
        }

        static void V_StartPitchDrift() {
            //TODO:
            //if (cl.laststop == cl.time) {
            //    return;     // something else is keeping it from drifting
            //}
            //if (cl.nodrift || !cl.pitchvel) {
            //    cl.pitchvel = v_centerspeed.value;
            //    cl.nodrift = false;
            //    cl.driftmove = 0;
            //}
        }

        static byte[] gammatable = new byte[256];	// palette is sent through this
        static void BuildGammaTable(float g) {
            if (g == 1.0) {
                for (int i = 0; i <= byte.MaxValue; i++)
                    gammatable[i] = Convert.ToByte(i);
                return;
            }

            for (int i = 0; i <= byte.MaxValue; i++) {
                var inf = (int)(255 * Math.Pow((i + 0.5) / 255.5, g) + 0.5);
                if (inf < 0)
                    inf = 0;
                if (inf > 255)
                    inf = 255;
                gammatable[i] = Convert.ToByte(inf);
            }
        }
    }
}
