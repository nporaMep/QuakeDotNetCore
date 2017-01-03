namespace Quake {
    public class Screen {
        public static bool block_drawing;
        public static bool scr_skipupdate;

        public static void Init() {
            //TODO:
            //Cvar.RegisterVariable(&scr_fov);
            //Cvar.RegisterVariable(&scr_viewsize);
            //Cvar.RegisterVariable(&scr_conspeed);
            //Cvar.RegisterVariable(&scr_showram);
            //Cvar.RegisterVariable(&scr_showturtle);
            //Cvar.RegisterVariable(&scr_showpause);
            //Cvar.RegisterVariable(&scr_centertime);
            //Cvar.RegisterVariable(&scr_printspeed);

            ////
            //// register our commands
            ////
            //Cmd.AddCommand("screenshot", SCR_ScreenShot_f);
            //Cmd.AddCommand("sizeup", SCR_SizeUp_f);
            //Cmd.AddCommand("sizedown", SCR_SizeDown_f);

            //scr_ram = Draw_PicFromWad("ram");
            //scr_net = Draw_PicFromWad("net");
            //scr_turtle = Draw_PicFromWad("turtle");

            //scr_initialized = true;
        }

        //This is called every frame, and can also be called explicitly to flush
        //text to the screen.

        //WARNING: be very careful calling this from elsewhere, because the refresh
        //needs almost the entire 256k of stack space!
        static float oldscr_viewsize;
        static float oldlcd_x;
        public static void UpdateScreen() {
            //TODO:
            //vrect_t vrect;

            //if (scr_skipupdate || block_drawing)
            //    return;

            //scr_copytop = 0;
            //scr_copyeverything = 0;

            //if (scr_disabled_for_loading) {
            //    if (realtime - scr_disabled_time > 60) {
            //        scr_disabled_for_loading = false;
            //        Con_Printf("load failed.\n");
            //    } else
            //        return;
            //}

            //if (cls.state == ca_dedicated)
            //    return;             // stdout only

            //if (!scr_initialized || !con_initialized)
            //    return;             // not initialized yet

            //if (scr_viewsize.value != oldscr_viewsize) {
            //    oldscr_viewsize = scr_viewsize.value;
            //    vid.recalc_refdef = 1;
            //}

            ////
            //// check for vid changes
            ////
            //if (oldfov != scr_fov.value) {
            //    oldfov = scr_fov.value;
            //    vid.recalc_refdef = true;
            //}

            //if (oldlcd_x != lcd_x.value) {
            //    oldlcd_x = lcd_x.value;
            //    vid.recalc_refdef = true;
            //}

            //if (oldscreensize != scr_viewsize.value) {
            //    oldscreensize = scr_viewsize.value;
            //    vid.recalc_refdef = true;
            //}

            //if (vid.recalc_refdef) {
            //    // something changed, so reorder the screen
            //    SCR_CalcRefdef();
            //}

            ////
            //// do 3D refresh drawing, and then update the screen
            ////
            //D_EnableBackBufferAccess(); // of all overlay stuff if drawing directly

            //if (scr_fullupdate++ < vid.numpages) {  // clear the entire screen
            //    scr_copyeverything = 1;
            //    Draw_TileClear(0, 0, vid.width, vid.height);
            //    Sbar_Changed();
            //}

            //pconupdate = NULL;


            //SCR_SetUpToDrawConsole();
            //SCR_EraseCenterString();

            //D_DisableBackBufferAccess();    // for adapters that can't stay mapped in
            //                                //  for linear writes all the time

            //VID_LockBuffer();

            //V_RenderView();

            //VID_UnlockBuffer();

            //D_EnableBackBufferAccess(); // of all overlay stuff if drawing directly

            //if (scr_drawdialog) {
            //    Sbar_Draw();
            //    Draw_FadeScreen();
            //    SCR_DrawNotifyString();
            //    scr_copyeverything = true;
            //} else if (scr_drawloading) {
            //    SCR_DrawLoading();
            //    Sbar_Draw();
            //} else if (cl.intermission == 1 && key_dest == key_game) {
            //    Sbar_IntermissionOverlay();
            //} else if (cl.intermission == 2 && key_dest == key_game) {
            //    Sbar_FinaleOverlay();
            //    SCR_CheckDrawCenterString();
            //} else if (cl.intermission == 3 && key_dest == key_game) {
            //    SCR_CheckDrawCenterString();
            //} else {
            //    SCR_DrawRam();
            //    SCR_DrawNet();
            //    SCR_DrawTurtle();
            //    SCR_DrawPause();
            //    SCR_CheckDrawCenterString();
            //    Sbar_Draw();
            //    SCR_DrawConsole();
            //    M_Draw();
            //}

            //D_DisableBackBufferAccess();    // for adapters that can't stay mapped in
            //                                //  for linear writes all the time
            //if (pconupdate) {
            //    D_UpdateRects(pconupdate);
            //}

            //V_UpdatePalette();

            ////
            //// update one of three areas
            ////

            //if (scr_copyeverything) {
            //    vrect.x = 0;
            //    vrect.y = 0;
            //    vrect.width = vid.width;
            //    vrect.height = vid.height;
            //    vrect.pnext = 0;

            //    VID_Update(&vrect);
            //} else if (scr_copytop) {
            //    vrect.x = 0;
            //    vrect.y = 0;
            //    vrect.width = vid.width;
            //    vrect.height = vid.height - sb_lines;
            //    vrect.pnext = 0;

            //    VID_Update(&vrect);
            //} else {
            //    vrect.x = scr_vrect.x;
            //    vrect.y = scr_vrect.y;
            //    vrect.width = scr_vrect.width;
            //    vrect.height = scr_vrect.height;
            //    vrect.pnext = 0;

            //    VID_Update(&vrect);
            //}
        }
    }
}
