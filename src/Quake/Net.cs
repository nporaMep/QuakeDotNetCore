﻿namespace Quake {
    public static class Net {
        public static void Init() {
            //TODO:
            //            int i;
            //            int controlSocket;
            //            qsocket_t* s;

            //            if (COM_CheckParm("-playback")) {
            //                net_numdrivers = 1;
            //                net_drivers[0].Init = VCR_Init;
            //            }

            //            if (COM_CheckParm("-record"))
            //                recording = true;

            //            i = COM_CheckParm("-port");
            //            if (!i)
            //                i = COM_CheckParm("-udpport");
            //            if (!i)
            //                i = COM_CheckParm("-ipxport");

            //            if (i) {
            //                if (i < com_argc - 1)
            //                    DEFAULTnet_hostport = Q_atoi(com_argv[i + 1]);
            //                else
            //                    Sys_Error("NET_Init: you must specify a number after -port");
            //            }
            //            net_hostport = DEFAULTnet_hostport;

            //            if (COM_CheckParm("-listen") || cls.state == ca_dedicated)
            //                listening = true;
            //            net_numsockets = svs.maxclientslimit;
            //            if (cls.state != ca_dedicated)
            //                net_numsockets++;

            //            SetNetTime();

            //            for (i = 0; i < net_numsockets; i++) {
            //                s = (qsocket_t*)Hunk_AllocName(sizeof(qsocket_t), "qsocket");
            //                s->next = net_freeSockets;
            //                net_freeSockets = s;
            //                s->disconnected = true;
            //            }

            //            // allocate space for network message buffer
            //            SZ_Alloc(&net_message, NET_MAXMESSAGE);

            //            Cvar_RegisterVariable(&net_messagetimeout);
            //            Cvar_RegisterVariable(&hostname);
            //            Cvar_RegisterVariable(&config_com_port);
            //            Cvar_RegisterVariable(&config_com_irq);
            //            Cvar_RegisterVariable(&config_com_baud);
            //            Cvar_RegisterVariable(&config_com_modem);
            //            Cvar_RegisterVariable(&config_modem_dialtype);
            //            Cvar_RegisterVariable(&config_modem_clear);
            //            Cvar_RegisterVariable(&config_modem_init);
            //            Cvar_RegisterVariable(&config_modem_hangup);
            //# ifdef IDGODS
            //            Cvar_RegisterVariable(&idgods);
            //#endif

            //            Cmd_AddCommand("slist", NET_Slist_f);
            //            Cmd_AddCommand("listen", NET_Listen_f);
            //            Cmd_AddCommand("maxplayers", MaxPlayers_f);
            //            Cmd_AddCommand("port", NET_Port_f);

            //            // initialize all the drivers
            //            for (net_driverlevel = 0; net_driverlevel < net_numdrivers; net_driverlevel++) {
            //                controlSocket = net_drivers[net_driverlevel].Init();
            //                if (controlSocket == -1)
            //                    continue;
            //                net_drivers[net_driverlevel].initialized = true;
            //                net_drivers[net_driverlevel].controlSock = controlSocket;
            //                if (listening)
            //                    net_drivers[net_driverlevel].Listen(true);
            //            }

            //            if (*my_ipx_address)
            //                Con_DPrintf("IPX address %s\n", my_ipx_address);
            //            if (*my_tcpip_address)
            //                Con_DPrintf("TCP/IP address %s\n", my_tcpip_address);
        }

        public static void Poll() {
            //TODO:
            //PollProcedure* pp;
            //qboolean useModem;

            //if (!configRestored) {
            //    if (serialAvailable) {
            //        if (config_com_modem.value == 1.0)
            //            useModem = true;
            //        else
            //            useModem = false;
            //        SetComPortConfig(0, (int)config_com_port.value, (int)config_com_irq.value, (int)config_com_baud.value, useModem);
            //        SetModemConfig(0, config_modem_dialtype.string, config_modem_clear.string, config_modem_init.string, config_modem_hangup.string);
            //    }
            //    configRestored = true;
            //}

            //SetNetTime();

            //for (pp = pollProcedureList; pp; pp = pp->next) {
            //    if (pp->nextTime > net_time)
            //        break;
            //    pollProcedureList = pp->next;
            //    pp->procedure(pp->arg);
            //}
        }
    }
}
