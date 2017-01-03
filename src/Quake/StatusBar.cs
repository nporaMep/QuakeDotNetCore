namespace Quake {
    public static class StatusBar
    {
        public static void Init() {
            //TODO:
            //int i;

            //for (i = 0; i < 10; i++) {
            //    sb_nums[0][i] = Draw_PicFromWad(va("num_%i", i));
            //    sb_nums[1][i] = Draw_PicFromWad(va("anum_%i", i));
            //}

            //sb_nums[0][10] = Draw_PicFromWad("num_minus");
            //sb_nums[1][10] = Draw_PicFromWad("anum_minus");

            //sb_colon = Draw_PicFromWad("num_colon");
            //sb_slash = Draw_PicFromWad("num_slash");

            //sb_weapons[0][0] = Draw_PicFromWad("inv_shotgun");
            //sb_weapons[0][1] = Draw_PicFromWad("inv_sshotgun");
            //sb_weapons[0][2] = Draw_PicFromWad("inv_nailgun");
            //sb_weapons[0][3] = Draw_PicFromWad("inv_snailgun");
            //sb_weapons[0][4] = Draw_PicFromWad("inv_rlaunch");
            //sb_weapons[0][5] = Draw_PicFromWad("inv_srlaunch");
            //sb_weapons[0][6] = Draw_PicFromWad("inv_lightng");

            //sb_weapons[1][0] = Draw_PicFromWad("inv2_shotgun");
            //sb_weapons[1][1] = Draw_PicFromWad("inv2_sshotgun");
            //sb_weapons[1][2] = Draw_PicFromWad("inv2_nailgun");
            //sb_weapons[1][3] = Draw_PicFromWad("inv2_snailgun");
            //sb_weapons[1][4] = Draw_PicFromWad("inv2_rlaunch");
            //sb_weapons[1][5] = Draw_PicFromWad("inv2_srlaunch");
            //sb_weapons[1][6] = Draw_PicFromWad("inv2_lightng");

            //for (i = 0; i < 5; i++) {
            //    sb_weapons[2 + i][0] = Draw_PicFromWad(va("inva%i_shotgun", i + 1));
            //    sb_weapons[2 + i][1] = Draw_PicFromWad(va("inva%i_sshotgun", i + 1));
            //    sb_weapons[2 + i][2] = Draw_PicFromWad(va("inva%i_nailgun", i + 1));
            //    sb_weapons[2 + i][3] = Draw_PicFromWad(va("inva%i_snailgun", i + 1));
            //    sb_weapons[2 + i][4] = Draw_PicFromWad(va("inva%i_rlaunch", i + 1));
            //    sb_weapons[2 + i][5] = Draw_PicFromWad(va("inva%i_srlaunch", i + 1));
            //    sb_weapons[2 + i][6] = Draw_PicFromWad(va("inva%i_lightng", i + 1));
            //}

            //sb_ammo[0] = Draw_PicFromWad("sb_shells");
            //sb_ammo[1] = Draw_PicFromWad("sb_nails");
            //sb_ammo[2] = Draw_PicFromWad("sb_rocket");
            //sb_ammo[3] = Draw_PicFromWad("sb_cells");

            //sb_armor[0] = Draw_PicFromWad("sb_armor1");
            //sb_armor[1] = Draw_PicFromWad("sb_armor2");
            //sb_armor[2] = Draw_PicFromWad("sb_armor3");

            //sb_items[0] = Draw_PicFromWad("sb_key1");
            //sb_items[1] = Draw_PicFromWad("sb_key2");
            //sb_items[2] = Draw_PicFromWad("sb_invis");
            //sb_items[3] = Draw_PicFromWad("sb_invuln");
            //sb_items[4] = Draw_PicFromWad("sb_suit");
            //sb_items[5] = Draw_PicFromWad("sb_quad");

            //sb_sigil[0] = Draw_PicFromWad("sb_sigil1");
            //sb_sigil[1] = Draw_PicFromWad("sb_sigil2");
            //sb_sigil[2] = Draw_PicFromWad("sb_sigil3");
            //sb_sigil[3] = Draw_PicFromWad("sb_sigil4");

            //sb_faces[4][0] = Draw_PicFromWad("face1");
            //sb_faces[4][1] = Draw_PicFromWad("face_p1");
            //sb_faces[3][0] = Draw_PicFromWad("face2");
            //sb_faces[3][1] = Draw_PicFromWad("face_p2");
            //sb_faces[2][0] = Draw_PicFromWad("face3");
            //sb_faces[2][1] = Draw_PicFromWad("face_p3");
            //sb_faces[1][0] = Draw_PicFromWad("face4");
            //sb_faces[1][1] = Draw_PicFromWad("face_p4");
            //sb_faces[0][0] = Draw_PicFromWad("face5");
            //sb_faces[0][1] = Draw_PicFromWad("face_p5");

            //sb_face_invis = Draw_PicFromWad("face_invis");
            //sb_face_invuln = Draw_PicFromWad("face_invul2");
            //sb_face_invis_invuln = Draw_PicFromWad("face_inv2");
            //sb_face_quad = Draw_PicFromWad("face_quad");

            //Cmd_AddCommand("+showscores", Sbar_ShowScores);
            //Cmd_AddCommand("-showscores", Sbar_DontShowScores);

            //sb_sbar = Draw_PicFromWad("sbar");
            //sb_ibar = Draw_PicFromWad("ibar");
            //sb_scorebar = Draw_PicFromWad("scorebar");

            ////MED 01/04/97 added new hipnotic weapons
            //if (hipnotic) {
            //    hsb_weapons[0][0] = Draw_PicFromWad("inv_laser");
            //    hsb_weapons[0][1] = Draw_PicFromWad("inv_mjolnir");
            //    hsb_weapons[0][2] = Draw_PicFromWad("inv_gren_prox");
            //    hsb_weapons[0][3] = Draw_PicFromWad("inv_prox_gren");
            //    hsb_weapons[0][4] = Draw_PicFromWad("inv_prox");

            //    hsb_weapons[1][0] = Draw_PicFromWad("inv2_laser");
            //    hsb_weapons[1][1] = Draw_PicFromWad("inv2_mjolnir");
            //    hsb_weapons[1][2] = Draw_PicFromWad("inv2_gren_prox");
            //    hsb_weapons[1][3] = Draw_PicFromWad("inv2_prox_gren");
            //    hsb_weapons[1][4] = Draw_PicFromWad("inv2_prox");

            //    for (i = 0; i < 5; i++) {
            //        hsb_weapons[2 + i][0] = Draw_PicFromWad(va("inva%i_laser", i + 1));
            //        hsb_weapons[2 + i][1] = Draw_PicFromWad(va("inva%i_mjolnir", i + 1));
            //        hsb_weapons[2 + i][2] = Draw_PicFromWad(va("inva%i_gren_prox", i + 1));
            //        hsb_weapons[2 + i][3] = Draw_PicFromWad(va("inva%i_prox_gren", i + 1));
            //        hsb_weapons[2 + i][4] = Draw_PicFromWad(va("inva%i_prox", i + 1));
            //    }

            //    hsb_items[0] = Draw_PicFromWad("sb_wsuit");
            //    hsb_items[1] = Draw_PicFromWad("sb_eshld");
            //}

            //if (rogue) {
            //    rsb_invbar[0] = Draw_PicFromWad("r_invbar1");
            //    rsb_invbar[1] = Draw_PicFromWad("r_invbar2");

            //    rsb_weapons[0] = Draw_PicFromWad("r_lava");
            //    rsb_weapons[1] = Draw_PicFromWad("r_superlava");
            //    rsb_weapons[2] = Draw_PicFromWad("r_gren");
            //    rsb_weapons[3] = Draw_PicFromWad("r_multirock");
            //    rsb_weapons[4] = Draw_PicFromWad("r_plasma");

            //    rsb_items[0] = Draw_PicFromWad("r_shield1");
            //    rsb_items[1] = Draw_PicFromWad("r_agrav1");

            //    // PGM 01/19/97 - team color border
            //    rsb_teambord = Draw_PicFromWad("r_teambord");
            //    // PGM 01/19/97 - team color border

            //    rsb_ammo[0] = Draw_PicFromWad("r_ammolava");
            //    rsb_ammo[1] = Draw_PicFromWad("r_ammomulti");
            //    rsb_ammo[2] = Draw_PicFromWad("r_ammoplasma");
            //}
        }
    }
}
