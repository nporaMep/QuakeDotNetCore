namespace Quake {
    public class server_static_t {

        public int maxclients;
        public int maxclientslimit;
        //public client_s clients;      // [maxclients]
        public int serverflags;        // episode completion information
        public bool changelevel_issued;    // cleared when at SV_SpawnServer
    }

    public class server_t {
        public bool active;                // false if only a net client

        public bool paused;
        public bool loadgame;          // handle connections specially

        public double time;

        public int lastcheck;          // used by PF_checkclient
        public double lastchecktime;

        public string name;          // map name
        public string modelname;     // maps/<name>.bsp, for model_precache[0]
        //public model_s worldmodel;
        public string[] model_precache = new string[QuakeDef.MAX_MODELS];   // NULL terminated
        //public model_s models[MAX_MODELS] = new string[QuakeDef.MAX_MODELS];
        public string sound_precache;   // NULL terminated
        public string lightstyles;
        public int num_edicts;
        public int max_edicts;
        //public edict_t* edicts;            // can NOT be array indexed, because
        // edict_t is variable sized, but can
        // be used to reference the world ent
        //public server_state_t state;           // some actions are only valid during load

        //public sizebuf_t datagram;
        public byte[] datagram_buf = new byte[QuakeDef.MAX_DATAGRAM];

        //public sizebuf_t reliable_datagram;    // copied to all clients at end of frame
        public byte[] reliable_datagram_buf = new byte[QuakeDef.MAX_DATAGRAM];

        //public sizebuf_t signon;
        public byte[] signon_buf = new byte[8192];
    }

    public static class Server {
        public static server_t sv = new server_t();
        public static server_static_t svs = new server_static_t();
        public static void Init() {
            //TODO:
            //           int i;

            //   extern cvar_t sv_maxvelocity;
            //       extern cvar_t sv_gravity;
            //       extern cvar_t sv_nostep;
            //       extern cvar_t sv_friction;
            //       extern cvar_t sv_edgefriction;
            //       extern cvar_t sv_stopspeed;
            //       extern cvar_t sv_maxspeed;
            //       extern cvar_t sv_accelerate;
            //       extern cvar_t sv_idealpitchscale;
            //       extern cvar_t sv_aim;


            //   Cvar_RegisterVariable(&sv_maxvelocity);

            //   Cvar_RegisterVariable(&sv_gravity);

            //   Cvar_RegisterVariable(&sv_friction);

            //   Cvar_RegisterVariable(&sv_edgefriction);

            //   Cvar_RegisterVariable(&sv_stopspeed);

            //   Cvar_RegisterVariable(&sv_maxspeed);

            //   Cvar_RegisterVariable(&sv_accelerate);

            //   Cvar_RegisterVariable(&sv_idealpitchscale);

            //   Cvar_RegisterVariable(&sv_aim);

            //   Cvar_RegisterVariable(&sv_nostep);

            //for (i=0 ; i<MAX_MODELS ; i++)

            //       sprintf(localmodels[i], "*%i", i);
            //   }
        }

        public static void ClearDatagram() {
            //TODO:
            //SZ_Clear(&sv.datagram);
        }

        public static void CheckForNewClients() {
            //TODO:
            //    struct qsocket_s    *ret;
            //	int i;

            ////
            //// check for new connections
            ////
            //	while (1)
            //	{
            //		ret = NET_CheckNewConnections();
            //		if (!ret)
            //			break;

            //	// 
            //	// init a new client structure
            //	//	
            //		for (i=0 ; i<svs.maxclients ; i++)
            //			if (!svs.clients[i].active)
            //				break;
            //		if (i == svs.maxclients)

            //            Sys_Error("Host_CheckForNewClients: no free clients");

            //        svs.clients[i].netconnection = ret;

            //        SV_ConnectClient(i);

            //        net_activeconnections++;
            //	}
        }

        public static void RunClients() {
            //TODO:
            //     int i;

            //     for (i = 0, host_client = svs.clients; i < svs.maxclients; i++, host_client++) {
            //         if (!host_client->active)
            //             continue;

            //         sv_player = host_client->edict;

            //         if (!SV_ReadClientMessage()) {
            //             SV_DropClient(false);   // client misbehaved...
            //             continue;
            //         }

            //         if (!host_client->spawned) {
            //             // clear client movement until a new packet is received
            //             memset(&host_client->cmd, 0, sizeof(host_client->cmd));
            //     continue;
            // }

            //// always pause in single player if in console or menus
            //		if (!sv.paused && (svs.maxclients > 1 || key_dest == key_game) )

            //            SV_ClientThink();
            //}
        }
        public static void Physics() {
            //TODO:
            //    int i;
            //    edict_t* ent;

            //    // let the progs know that a new frame has started
            //    pr_global_struct->self = EDICT_TO_PROG(sv.edicts);
            //    pr_global_struct->other = EDICT_TO_PROG(sv.edicts);
            //    pr_global_struct->time = sv.time;
            //    PR_ExecuteProgram(pr_global_struct->StartFrame);

            //    //SV_CheckAllEnts ();

            //    //
            //    // treat each object in turn
            //    //
            //    ent = sv.edicts;
            //    for (i = 0; i < sv.num_edicts; i++, ent = NEXT_EDICT(ent)) {
            //        if (ent->free)
            //            continue;

            //        if (pr_global_struct->force_retouch) {
            //            SV_LinkEdict(ent, true);    // force retouch even for stationary
            //        }

            //        if (i > 0 && i <= svs.maxclients)
            //            SV_Physics_Client(ent, i);
            //        else if (ent->v.movetype == MOVETYPE_PUSH)
            //            SV_Physics_Pusher(ent);
            //        else if (ent->v.movetype == MOVETYPE_NONE)
            //            SV_Physics_None(ent);
            //        else if (ent->v.movetype == MOVETYPE_NOCLIP)
            //            SV_Physics_Noclip(ent);
            //        else if (ent->v.movetype == MOVETYPE_STEP)
            //            SV_Physics_Step(ent);
            //        else if (ent->v.movetype == MOVETYPE_TOSS
            //        || ent->v.movetype == MOVETYPE_BOUNCE
            //|| ent->v.movetype == MOVETYPE_FLY
            //        || ent->v.movetype == MOVETYPE_FLYMISSILE)
            //            SV_Physics_Toss(ent);
            //        else
            //            Sys_Error("SV_Physics: bad movetype %i", (int)ent->v.movetype);
            //    }

            //    if (pr_global_struct->force_retouch)
            //        pr_global_struct->force_retouch--;

            //    sv.time += host_frametime;
        }

        public static void SendClientMessages() {
            //TODO:
            //int i;

            //// update frags, names, etc
            //SV_UpdateToReliableMessages();

            //// build individual updates
            //for (i = 0, host_client = svs.clients; i < svs.maxclients; i++, host_client++) {
            //    if (!host_client->active)
            //        continue;

            //    if (host_client->spawned) {
            //        if (!SV_SendClientDatagram(host_client))
            //            continue;
            //    } else {
            //        // the player isn't totally in the game yet
            //        // send small keepalive messages if too much time has passed
            //        // send a full message when the next signon stage has been requested
            //        // some other message data (name changes, etc) may accumulate 
            //        // between signon stages
            //        if (!host_client->sendsignon) {
            //            if (realtime - host_client->last_message > 5)
            //                SV_SendNop(host_client);
            //            continue;   // don't send out non-signon messages
            //        }
            //    }

            //    // check for an overflowed message.  Should only happen
            //    // on a very fucked up connection that backs up a lot, then
            //    // changes level
            //    if (host_client->message.overflowed) {
            //        SV_DropClient(true);
            //        host_client->message.overflowed = false;
            //        continue;
            //    }

            //    if (host_client->message.cursize || host_client->dropasap) {
            //        if (!NET_CanSendMessage(host_client->netconnection)) {
            //            //				I_Printf ("can't write\n");
            //            continue;
            //        }

            //        if (host_client->dropasap)
            //            SV_DropClient(false);   // went to another level
            //        else {
            //            if (NET_SendMessage(host_client->netconnection
            //            , &host_client->message) == -1)
            //                SV_DropClient(true);    // if the message couldn't send, kick off
            //            SZ_Clear(&host_client->message);
            //            host_client->last_message = realtime;
            //            host_client->sendsignon = false;
            //        }
            //    }
            //}


            //// clear muzzle flashes
            //SV_CleanupEnts();
        }
    }
}