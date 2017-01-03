namespace Quake {
    public static class Input
    {
        public static void Init() {
            //// mouse variables
            //Cvar_RegisterVariable(&m_filter);

            //// joystick variables
            //Cvar_RegisterVariable(&in_joystick);
            //Cvar_RegisterVariable(&joy_name);
            //Cvar_RegisterVariable(&joy_advanced);
            //Cvar_RegisterVariable(&joy_advaxisx);
            //Cvar_RegisterVariable(&joy_advaxisy);
            //Cvar_RegisterVariable(&joy_advaxisz);
            //Cvar_RegisterVariable(&joy_advaxisr);
            //Cvar_RegisterVariable(&joy_advaxisu);
            //Cvar_RegisterVariable(&joy_advaxisv);
            //Cvar_RegisterVariable(&joy_forwardthreshold);
            //Cvar_RegisterVariable(&joy_sidethreshold);
            //Cvar_RegisterVariable(&joy_pitchthreshold);
            //Cvar_RegisterVariable(&joy_yawthreshold);
            //Cvar_RegisterVariable(&joy_forwardsensitivity);
            //Cvar_RegisterVariable(&joy_sidesensitivity);
            //Cvar_RegisterVariable(&joy_pitchsensitivity);
            //Cvar_RegisterVariable(&joy_yawsensitivity);
            //Cvar_RegisterVariable(&joy_wwhack1);
            //Cvar_RegisterVariable(&joy_wwhack2);

            //Cmd_AddCommand("force_centerview", Force_CenterView_f);
            //Cmd_AddCommand("joyadvancedupdate", Joy_AdvancedUpdate_f);

            //uiWheelMessage = RegisterWindowMessage("MSWHEEL_ROLLMSG");

            //IN_StartupMouse();
            //IN_StartupJoystick();
        }

        public static void Commands() {
            //TODO:
            //int i, key_index;
            //DWORD buttonstate, povstate;

            //if (!joy_avail) {
            //    return;
            //}


            //// loop through the joystick buttons
            //// key a joystick event or auxillary event for higher number buttons for each state change
            //buttonstate = ji.dwButtons;
            //for (i = 0; i < joy_numbuttons; i++) {
            //    if ((buttonstate & (1 << i)) && !(joy_oldbuttonstate & (1 << i))) {
            //        key_index = (i < 4) ? K_JOY1 : K_AUX1;
            //        Key_Event(key_index + i, true);
            //    }

            //    if (!(buttonstate & (1 << i)) && (joy_oldbuttonstate & (1 << i))) {
            //        key_index = (i < 4) ? K_JOY1 : K_AUX1;
            //        Key_Event(key_index + i, false);
            //    }
            //}
            //joy_oldbuttonstate = buttonstate;

            //if (joy_haspov) {
            //    // convert POV information into 4 bits of state information
            //    // this avoids any potential problems related to moving from one
            //    // direction to another without going through the center position
            //    povstate = 0;
            //    if (ji.dwPOV != JOY_POVCENTERED) {
            //        if (ji.dwPOV == JOY_POVFORWARD)
            //            povstate |= 0x01;
            //        if (ji.dwPOV == JOY_POVRIGHT)
            //            povstate |= 0x02;
            //        if (ji.dwPOV == JOY_POVBACKWARD)
            //            povstate |= 0x04;
            //        if (ji.dwPOV == JOY_POVLEFT)
            //            povstate |= 0x08;
            //    }
            //    // determine which bits have changed and key an auxillary event for each change
            //    for (i = 0; i < 4; i++) {
            //        if ((povstate & (1 << i)) && !(joy_oldpovstate & (1 << i))) {
            //            Key_Event(K_AUX29 + i, true);
            //        }

            //        if (!(povstate & (1 << i)) && (joy_oldpovstate & (1 << i))) {
            //            Key_Event(K_AUX29 + i, false);
            //        }
            //    }
            //    joy_oldpovstate = povstate;
            //}
        }
    }
}
