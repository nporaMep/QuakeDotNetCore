﻿namespace Quake {
    public static class Wad {
        public static void LoadWadFile(string filename) {
            //TODO:
            //lumpinfo_t* lump_p;
            //wadinfo_t* header;
            //unsigned i;
            //int infotableofs;

            //wad_base = COM_LoadHunkFile(filename);
            //if (!wad_base)
            //    Sys_Error("W_LoadWadFile: couldn't load %s", filename);

            //header = (wadinfo_t*)wad_base;

            //if (header->identification[0] != 'W'
            //|| header->identification[1] != 'A'
            //|| header->identification[2] != 'D'
            //|| header->identification[3] != '2')
            //    Sys_Error("Wad file %s doesn't have WAD2 id\n", filename);

            //wad_numlumps = LittleLong(header->numlumps);
            //infotableofs = LittleLong(header->infotableofs);
            //wad_lumps = (lumpinfo_t*)(wad_base + infotableofs);

            //for (i = 0, lump_p = wad_lumps; i < wad_numlumps; i++, lump_p++) {
            //    lump_p->filepos = LittleLong(lump_p->filepos);
            //    lump_p->size = LittleLong(lump_p->size);
            //    W_CleanupName(lump_p->name, lump_p->name);
            //    if (lump_p->type == TYP_QPIC)
            //        SwapPic((qpic_t*)(wad_base + lump_p->filepos));
            //}
        }
    }
}
