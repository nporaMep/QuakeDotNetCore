namespace Quake {
    public static class Render {
        public static float[] r_origin;
        public static float[] vup;//, base_vup;
        public static float[] vpn;//, base_vpn;
        public static float[] vright;//, base_vright;
        public static void Init() {
            //TODO:
            //            int dummy;

            //            // get stack position so we can guess if we are going to overflow
            //            r_stack_start = (byte*)&dummy;

            //            R_InitTurb();

            //            Cmd_AddCommand("timerefresh", R_TimeRefresh_f);
            //            Cmd_AddCommand("pointfile", R_ReadPointFile_f);

            //            Cvar_RegisterVariable(&r_draworder);
            //            Cvar_RegisterVariable(&r_speeds);
            //            Cvar_RegisterVariable(&r_timegraph);
            //            Cvar_RegisterVariable(&r_graphheight);
            //            Cvar_RegisterVariable(&r_drawflat);
            //            Cvar_RegisterVariable(&r_ambient);
            //            Cvar_RegisterVariable(&r_clearcolor);
            //            Cvar_RegisterVariable(&r_waterwarp);
            //            Cvar_RegisterVariable(&r_fullbright);
            //            Cvar_RegisterVariable(&r_drawentities);
            //            Cvar_RegisterVariable(&r_drawviewmodel);
            //            Cvar_RegisterVariable(&r_aliasstats);
            //            Cvar_RegisterVariable(&r_dspeeds);
            //            Cvar_RegisterVariable(&r_reportsurfout);
            //            Cvar_RegisterVariable(&r_maxsurfs);
            //            Cvar_RegisterVariable(&r_numsurfs);
            //            Cvar_RegisterVariable(&r_reportedgeout);
            //            Cvar_RegisterVariable(&r_maxedges);
            //            Cvar_RegisterVariable(&r_numedges);
            //            Cvar_RegisterVariable(&r_aliastransbase);
            //            Cvar_RegisterVariable(&r_aliastransadj);

            //            Cvar_SetValue("r_maxedges", (float)NUMSTACKEDGES);
            //            Cvar_SetValue("r_maxsurfs", (float)NUMSTACKSURFACES);

            //            view_clipplanes[0].leftedge = true;
            //            view_clipplanes[1].rightedge = true;
            //            view_clipplanes[1].leftedge = view_clipplanes[2].leftedge =
            //                    view_clipplanes[3].leftedge = false;
            //            view_clipplanes[0].rightedge = view_clipplanes[2].rightedge =
            //                    view_clipplanes[3].rightedge = false;

            //            r_refdef.xOrigin = XCENTERING;
            //            r_refdef.yOrigin = YCENTERING;

            //            R_InitParticles();

            //            // TODO: collect 386-specific code in one place
            //#if id386
            //	Sys_MakeCodeWriteable ((long)R_EdgeCodeStart,
            //					     (long)R_EdgeCodeEnd - (long)R_EdgeCodeStart);
            //#endif   // id386

            //            D_Init();
        }
        public static void InitTextures() {
            //TODO:
            //int x, y, m;
            //byte* dest;

            //// create a simple checkerboard texture for the default
            //r_notexture_mip = Hunk_AllocName(sizeof(texture_t) + 16 * 16 + 8 * 8 + 4 * 4 + 2 * 2, "notexture");

            //r_notexture_mip->width = r_notexture_mip->height = 16;
            //r_notexture_mip->offsets[0] = sizeof(texture_t);
            //r_notexture_mip->offsets[1] = r_notexture_mip->offsets[0] + 16 * 16;
            //r_notexture_mip->offsets[2] = r_notexture_mip->offsets[1] + 8 * 8;
            //r_notexture_mip->offsets[3] = r_notexture_mip->offsets[2] + 4 * 4;

            //for (m = 0; m < 4; m++) {
            //    dest = (byte*)r_notexture_mip + r_notexture_mip->offsets[m];
            //    for (y = 0; y < (16 >> m); y++)
            //        for (x = 0; x < (16 >> m); x++) {
            //            if ((y < (8 >> m)) ^ (x < (8 >> m)))
            //                *dest++ = 0;
            //            else
            //                *dest++ = 0xff;
            //        }
            //}
        }
    }
}
