using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quake
{
    public static class CDAudio
    {
        public static int Init() {
            //TODO:
            //DWORD dwReturn;
            //MCI_OPEN_PARMS mciOpenParms;
            //MCI_SET_PARMS mciSetParms;
            //int n;

            //if (cls.state == ca_dedicated)
            //    return -1;

            //if (COM_CheckParm("-nocdaudio"))
            //    return -1;

            //mciOpenParms.lpstrDeviceType = "cdaudio";
            //if (dwReturn = mciSendCommand(0, MCI_OPEN, MCI_OPEN_TYPE | MCI_OPEN_SHAREABLE, (DWORD)(LPVOID) & mciOpenParms)) {
            //    Con_Printf("CDAudio_Init: MCI_OPEN failed (%i)\n", dwReturn);
            //    return -1;
            //}
            //wDeviceID = mciOpenParms.wDeviceID;

            //// Set the time format to track/minute/second/frame (TMSF).
            //mciSetParms.dwTimeFormat = MCI_FORMAT_TMSF;
            //if (dwReturn = mciSendCommand(wDeviceID, MCI_SET, MCI_SET_TIME_FORMAT, (DWORD)(LPVOID) & mciSetParms)) {
            //    Con_Printf("MCI_SET_TIME_FORMAT failed (%i)\n", dwReturn);
            //    mciSendCommand(wDeviceID, MCI_CLOSE, 0, (DWORD)NULL);
            //    return -1;
            //}

            //for (n = 0; n < 100; n++)
            //    remap[n] = n;
            //initialized = true;
            //enabled = true;

            //if (CDAudio_GetAudioDiskInfo()) {
            //    Con_Printf("CDAudio_Init: No CD in player.\n");
            //    cdValid = false;
            //}

            //Cmd_AddCommand("cd", CD_f);

            //Con_Printf("CD Audio Initialized\n");

            return 0;
        }

        public static void Update() {
            //if (!enabled)
            //    return;

            //if (bgmvolume.value != cdvolume) {
            //    if (cdvolume) {
            //        Cvar_SetValue("bgmvolume", 0.0);
            //        cdvolume = bgmvolume.value;
            //        CDAudio_Pause();
            //    } else {
            //        Cvar_SetValue("bgmvolume", 1.0);
            //        cdvolume = bgmvolume.value;
            //        CDAudio_Resume();
            //    }
            //}
        }
    }
}
