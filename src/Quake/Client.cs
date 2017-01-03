namespace Quake {

    public enum cactive_t {
        ca_dedicated,       // a dedicated server with no ability to start a client
        ca_disconnected,    // full screen console with no connection
        ca_connected        // valid netcon, talking to a server
    }
    public class client_static_t {
        public cactive_t state;

        // personalization data sent to server	
        public string mapstring;
        public string spawnparms; // to restart a level

        // demo loop control
        public int demonum;        // -1 = don't play demos
        public string demos;       // when not playing

        // demo recording info must be here, because record is started before
        // entering a map (and clearing client_state_t)
        public bool demorecording;
        public bool demoplayback;
        public bool timedemo;
        public int forcetrack;         // -1 = use normal cd track
        //TODO:
        //public FILE* demofile;
        public int td_lastframe;       // to meter out one message a frame
        public int td_startframe;      // host_framecount at start
        public float td_starttime;     // realtime at second frame of timedemo


        // connection information
        public int signon;         // 0 to SIGNONS
        //TODO:
        //public struct qsocket_s    * netcon;
        //public sizebuf_t message;      // writing buffer to send to server
    }

    //
    // the client_state_t structure is wiped completely at every
    // server signon
    //
    public class client_state_t {
        public int movemessages;   // since connecting to this server
                                   // throw out the first couple, so the player
                                   // doesn't accidentally do something the 
                                   // first frame
        //public usercmd_t cmd;          // last command sent to the server

        // information for local display
        //public int stats[MAX_CL_STATS];    // health, etc
        public int items;          // inventory bit flags
        //public float item_gettime[32]; // cl.time of aquiring item, for blinking
        public float faceanimtime; // use anim frame if cl.time < this

        //public cshift_t cshifts[NUM_CSHIFTS];  // color shifts for damage, powerups
        //public cshift_t prev_cshifts[NUM_CSHIFTS]; // and content types

        // the client maintains its own idea of view angles, which are
        // sent to the server each frame.  The server sets punchangle when
        // the view is temporarliy offset, and an angle reset commands at the start
        // of each level and after teleporting.
        //public vec3_t mviewangles[2];  // during demo playback viewangles is lerped
                                       // between these
        //public vec3_t viewangles;

        //public vec3_t mvelocity[2];    // update by server, used for lean+bob
                                       // (0 is newest)
        //public vec3_t velocity;        // lerped between mvelocity[0] and [1]

        //public vec3_t punchangle;      // temporary offset

        // pitch drifting vars
        public float idealpitch;
        public float pitchvel;
        public bool nodrift;
        public float driftmove;
        public double laststop;

        public float viewheight;
        public float crouch;           // local amount for smoothing stepups

        public bool paused;            // send over by server
        public bool onground;
        public bool inwater;

        public int intermission;   // don't change view angle, full screen, etc
        public int completed_time; // latched at intermission start

        //public double mtime[2];        // the timestamp of last two messages	
        public double time;            // clients view of time, should be between
                                       // servertime and oldservertime to generate
                                       // a lerp point for other data
        public double oldtime;     // previous cl.time, time-oldtime is used
                                   // to decay light values and smooth step ups


        public float last_received_message;    // (realtime) for net trouble icon

        //
        // information that is static for the entire time connected to a server
        //
        //public model_s       model_precache[MAX_MODELS];
        //public sfx_s         sound_precache[MAX_SOUNDS];

        //public char levelname[40]; // for display on solo scoreboard
        public int viewentity;     // cl_entitites[cl.viewentity] = player
        public int maxclients;
        public int gametype;

        // refresh related state
        //public model_s   worldmodel;   // cl_entitites[0].model
        //public efrag_s   free_efrags;
        public int num_entities;   // held in cl_entities array
        public int num_statics;    // held in cl_staticentities array
        //public entity_t viewent;           // the gun model

        public int cdtrack, looptrack; // cd audio

        // frag scoreboard
        //public scoreboard_t* scores;       // [cl.maxclients]

        //# ifdef QUAKE2
        //    // light level at player's position including dlights
        //    // this is sent back to the server each frame
        //    // architectually ugly but it works
        //    int light_level;
        //#endif
    }

    public static class Client {
        public const int MAX_MAPSTRING = 2048;
        public const int MAX_DEMOS = 8;
        public const int MAX_DEMONAME = 16;
        public const int SIGNONS = 4;

        public static client_static_t cls = new client_static_t();
        public static client_state_t cl = new client_state_t();

        public static void Init() {
            //TODO:
            //SZ_Alloc(&cls.message, 1024);

            //CL_InitInput();
            //CL_InitTEnts();

            ////
            //// register our commands
            ////
            //Cvar_RegisterVariable(&cl_name);
            //Cvar_RegisterVariable(&cl_color);
            //Cvar_RegisterVariable(&cl_upspeed);
            //Cvar_RegisterVariable(&cl_forwardspeed);
            //Cvar_RegisterVariable(&cl_backspeed);
            //Cvar_RegisterVariable(&cl_sidespeed);
            //Cvar_RegisterVariable(&cl_movespeedkey);
            //Cvar_RegisterVariable(&cl_yawspeed);
            //Cvar_RegisterVariable(&cl_pitchspeed);
            //Cvar_RegisterVariable(&cl_anglespeedkey);
            //Cvar_RegisterVariable(&cl_shownet);
            //Cvar_RegisterVariable(&cl_nolerp);
            //Cvar_RegisterVariable(&lookspring);
            //Cvar_RegisterVariable(&lookstrafe);
            //Cvar_RegisterVariable(&sensitivity);

            //Cvar_RegisterVariable(&m_pitch);
            //Cvar_RegisterVariable(&m_yaw);
            //Cvar_RegisterVariable(&m_forward);
            //Cvar_RegisterVariable(&m_side);

            ////	Cvar_RegisterVariable (&cl_autofire);

            //Cmd_AddCommand("entities", CL_PrintEntities_f);
            //Cmd_AddCommand("disconnect", CL_Disconnect_f);
            //Cmd_AddCommand("record", CL_Record_f);
            //Cmd_AddCommand("stop", CL_Stop_f);
            //Cmd_AddCommand("playdemo", CL_PlayDemo_f);
            //Cmd_AddCommand("timedemo", CL_TimeDemo_f);
        }

        public static void DecayLights() {
            //TODO:
            //int i;
            //dlight_t* dl;
            //float time;

            //time = cl.time - cl.oldtime;

            //dl = cl_dlights;
            //for (i = 0; i < MAX_DLIGHTS; i++, dl++) {
            //    if (dl->die < cl.time || !dl->radius)
            //        continue;

            //    dl->radius -= time * dl->decay;
            //    if (dl->radius < 0)
            //        dl->radius = 0;
            //}
        }

        public static void ReadFromServer() {
            //TODO:
            //int ret;

            //cl.oldtime = cl.time;
            //cl.time += host_frametime;

            //do {
            //    ret = CL_GetMessage();
            //    if (ret == -1)
            //        Host_Error("CL_ReadFromServer: lost server connection");
            //    if (!ret)
            //        break;

            //    cl.last_received_message = realtime;
            //    CL_ParseServerMessage();
            //} while (ret && cls.state == ca_connected);

            //if (cl_shownet.value)
            //    Con_Printf("\n");

            //CL_RelinkEntities();
            //CL_UpdateTEnts();
        }

        public static void SendCmd() {
            //TODO:
            //usercmd_t cmd;

            //if (cls.state != ca_connected)
            //    return;

            //if (cls.signon == SIGNONS) {
            //    // get basic movement from keyboard
            //    CL_BaseMove(&cmd);

            //    // allow mice or other external controllers to add to the move
            //    IN_Move(&cmd);

            //    // send the unreliable message
            //    CL_SendMove(&cmd);

            //}

            //if (cls.demoplayback) {
            //    SZ_Clear(&cls.message);
            //    return;
            //}

            //// send the reliable message
            //if (!cls.message.cursize)
            //    return;     // no message at all

            //if (!NET_CanSendMessage(cls.netcon)) {
            //    Con_DPrintf("CL_WriteToServer: can't send\n");
            //    return;
            //}

            //if (NET_SendMessage(cls.netcon, &cls.message) == -1)
            //    Host_Error("CL_WriteToServer: lost server connection");

            //SZ_Clear(&cls.message);
        }
    }
}
