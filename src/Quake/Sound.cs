namespace Quake {
    public static class Sound {
        public static void Init() {
            //TODO:

            //Con_Printf("\nSound Initialization\n");

            //if (COM_CheckParm("-nosound"))
            //    return;

            //if (COM_CheckParm("-simsound"))
            //    fakedma = true;

            //Cmd_AddCommand("play", S_Play);
            //Cmd_AddCommand("playvol", S_PlayVol);
            //Cmd_AddCommand("stopsound", S_StopAllSoundsC);
            //Cmd_AddCommand("soundlist", S_SoundList);
            //Cmd_AddCommand("soundinfo", S_SoundInfo_f);

            //Cvar_RegisterVariable(&nosound);
            //Cvar_RegisterVariable(&volume);
            //Cvar_RegisterVariable(&precache);
            //Cvar_RegisterVariable(&loadas8bit);
            //Cvar_RegisterVariable(&bgmvolume);
            //Cvar_RegisterVariable(&bgmbuffer);
            //Cvar_RegisterVariable(&ambient_level);
            //Cvar_RegisterVariable(&ambient_fade);
            //Cvar_RegisterVariable(&snd_noextraupdate);
            //Cvar_RegisterVariable(&snd_show);
            //Cvar_RegisterVariable(&_snd_mixahead);

            //if (host_parms.memsize < 0x800000) {
            //    Cvar_Set("loadas8bit", "1");
            //    Con_Printf("loading all sounds as 8bit\n");
            //}



            //snd_initialized = true;

            //S_Startup();

            //SND_InitScaletable();

            //known_sfx = Hunk_AllocName(MAX_SFX * sizeof(sfx_t), "sfx_t");
            //num_sfx = 0;

            //// create a piece of DMA memory

            //if (fakedma) {
            //    shm = (void*)Hunk_AllocName(sizeof(*shm), "shm");
            //    shm->splitbuffer = 0;
            //    shm->samplebits = 16;
            //    shm->speed = 22050;
            //    shm->channels = 2;
            //    shm->samples = 32768;
            //    shm->samplepos = 0;
            //    shm->soundalive = true;
            //    shm->gamealive = true;
            //    shm->submission_chunk = 1;
            //    shm->buffer = Hunk_AllocName(1 << 16, "shmbuf");
            //}

            //Con_Printf("Sound sampling rate: %i\n", shm->speed);

            //// provides a tick sound until washed clean

            ////	if (shm->buffer)
            ////		shm->buffer[4] = shm->buffer[5] = 0x7f;	// force a pop for debugging

            //ambient_sfx[AMBIENT_WATER] = S_PrecacheSound("ambience/water1.wav");
            //ambient_sfx[AMBIENT_SKY] = S_PrecacheSound("ambience/wind2.wav");

            //S_StopAllSounds(true);
        }

        //Called once each time through the main loop
        public static void Update(float[] origin, float[] forward, float[] right, float[] up) {
            //TODO:
            //int i, j;
            //int total;
            //channel_t* ch;
            //channel_t* combine;

            //if (!sound_started || (snd_blocked > 0))
            //    return;

            //VectorCopy(origin, listener_origin);
            //VectorCopy(forward, listener_forward);
            //VectorCopy(right, listener_right);
            //VectorCopy(up, listener_up);

            //// update general area ambient sound sources
            //S_UpdateAmbientSounds();

            //combine = NULL;

            //// update spatialization for static and dynamic sounds	
            //ch = channels + NUM_AMBIENTS;
            //for (i = NUM_AMBIENTS; i < total_channels; i++, ch++) {
            //    if (!ch->sfx)
            //        continue;
            //    SND_Spatialize(ch);         // respatialize channel
            //    if (!ch->leftvol && !ch->rightvol)
            //        continue;

            //    // try to combine static sounds with a previous channel of the same
            //    // sound effect so we don't mix five torches every frame

            //    if (i >= MAX_DYNAMIC_CHANNELS + NUM_AMBIENTS) {
            //        // see if it can just use the last one
            //        if (combine && combine->sfx == ch->sfx) {
            //            combine->leftvol += ch->leftvol;
            //            combine->rightvol += ch->rightvol;
            //            ch->leftvol = ch->rightvol = 0;
            //            continue;
            //        }
            //        // search for one
            //        combine = channels + MAX_DYNAMIC_CHANNELS + NUM_AMBIENTS;
            //        for (j = MAX_DYNAMIC_CHANNELS + NUM_AMBIENTS; j < i; j++, combine++)
            //            if (combine->sfx == ch->sfx)
            //                break;

            //        if (j == total_channels) {
            //            combine = NULL;
            //        } else {
            //            if (combine != ch) {
            //                combine->leftvol += ch->leftvol;
            //                combine->rightvol += ch->rightvol;
            //                ch->leftvol = ch->rightvol = 0;
            //            }
            //            continue;
            //        }
            //    }


            //}

            ////
            //// debugging output
            ////
            //if (snd_show.value) {
            //    total = 0;
            //    ch = channels;
            //    for (i = 0; i < total_channels; i++, ch++)
            //        if (ch->sfx && (ch->leftvol || ch->rightvol)) {
            //            //Con_Printf ("%3i %3i %s\n", ch->leftvol, ch->rightvol, ch->sfx->name);
            //            total++;
            //        }

            //    Con_Printf("----(%i)----\n", total);
            //}

            //// mix some sound
            //S_Update_();
        }

        public static void BlockSound() {

        }
    }
}
