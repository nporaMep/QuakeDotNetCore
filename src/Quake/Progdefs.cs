using System;

namespace Quake {
    public struct globalvars_t {
        public static globalvars_t Create() {
            var res = new globalvars_t();
            res.pad = new int[28];
            res.v_forward = new float[3];
            res.v_up = new float[3];
            res.v_right = new float[3];
            res.trace_endpos = new float[3];
            res.trace_plane_normal = new float[3];
            return res;
        }
        public int[] pad;
        public int self;
        public int other;
        public int world;
        public float time;
        public float frametime;
        public float force_retouch;
        public string mapname;
        public float deathmatch;
        public float coop;
        public float teamplay;
        public float serverflags;
        public float total_secrets;
        public float total_monsters;
        public float found_secrets;
        public float killed_monsters;
        public float parm1;
        public float parm2;
        public float parm3;
        public float parm4;
        public float parm5;
        public float parm6;
        public float parm7;
        public float parm8;
        public float parm9;
        public float parm10;
        public float parm11;
        public float parm12;
        public float parm13;
        public float parm14;
        public float parm15;
        public float parm16;
        public float[] v_forward;
        public float[] v_up;
        public float[] v_right;
        public float trace_allsolid;
        public float trace_startsolid;
        public float trace_fraction;
        public float[] trace_endpos;
        public float[] trace_plane_normal;
        public float trace_plane_dist;
        public int trace_ent;
        public float trace_inopen;
        public float trace_inwater;
        public int msg_entity;
        public Action main;
        public Action StartFrame;
        public Action PlayerPreThink;
        public Action PlayerPostThink;
        public Action ClientKill;
        public Action ClientConnect;
        public Action PutClientInServer;
        public Action ClientDisconnect;
        public Action SetNewParms;
        public Action SetChangeParms;
    }
}
