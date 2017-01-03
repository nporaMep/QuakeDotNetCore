namespace Quake {
    public struct font_t {
        public string name;/* Name of the font			*/
        public short fontType;     /* Type of font						*/
        public short maxWidth;     /* Maximum character width			*/
        public short maxKern;      /* Maximum character kern			*/
        public short fontWidth;        /* Font width						*/
        public short fontHeight;       /* Font height						*/
        public short ascent;           /* Font ascent value				*/
        public short descent;      /* Font descent value				*/
        public short leading;      /* Font leading value				*/
    }
    public struct text_settings_t {

        public int horizJust;        /* Horizontal justfication			*/
        public int vertJust;     /* Vertical justification			*/
        public int dir;          /* Text drawing direction			*/
        public int szNumerx;     /* Text x size numerator			*/
        public int szNumery;     /* Text y size numerator			*/
        public int szDenomx;     /* Text x size denominator			*/
        public int szDenomy;     /* Text y size denominator			*/
        public int spaceExtra;       /* Space extra term					*/
        public font_t font;           /* Currently selected font			*/
    }
    public struct rect_t {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    public struct point_t {
        public int x, y;
    }
    public struct attributes_t {
        public uint color;          /* Foreground color					*/
        public uint backColor;      /* Background color					*/
        public int colorMode;        /* Current color mode				*/
        public int markerSize;       /* Size of markers in pixels		*/
        public int markerStyle;  /* Style of markers					*/
        public uint markerColor;    /* Color to draw markers in			*/
        public uint bdrBright;      /* Border bright color				*/
        public uint bdrDark;        /* Border dark color				*/
        public point_t CP;             /* Graphics pen position			*/
        public int writeMode;        /* Scan conversion write mode op.	*/
        public int penStyle;     /* Pen style						*/
        public int penHeight;        /* Height of pen					*/
        public int penWidth;     /* Width of pen						*/
        public byte penPat;           /* Pattern for pen					*/
        public byte penPixPat;     /* Pixmap pattern for pen			*/
        public int lineStyle;        /* Line style						*/
        public ushort lineStipple; /* Line stipple						*/
        public uint stippleCount;    /* Current line stipple count		*/
        public rect_t viewPort;        /* Viewport dimensions				*/
        public point_t viewPortOrg;    /* Logical viewport origin			*/
        public rect_t clipRect;        /* Clipping rectangle dimensions	*/
        public int clip;         /* Is clipping on?					*/
        public int polyType;     /* Polygon drawing type				*/
        public text_settings_t ts;             /* Text drawing attributes			*/
    }

    public struct pixel_format_t {
        public byte redMask, greenMask;       /* Mask values for pixels			*/
        public byte blueMask, rsvdMask;
        public int redPos, redAdjust;        /* Red position and adjustment		*/
        public int greenPos, greenAdjust;    /* Green position and adjustment	*/
        public int bluePos, blueAdjust;      /* Blue position and adjustment		*/
        public int rsvdPos, rsvdAdjust;      /* Reserved position and adjustment */
    }

    public struct gmode_t {
        public int xRes;         /* Device x resolution - 1					*/
        public int yRes;         /* Device y resolution - 1					*/
        public int bitsPerPixel; /* Number of bits per pixel					*/
        public int numberOfPlanes;   /* Number of planes in image				*/
        public uint maxColor;       /* Maximum number of colors - 1				*/
        public int maxPage;      /* Maximum number of video pages - 1		*/
        public int bytesPerLine; /* Number of bytes in a line				*/
        public int aspectRatio;  /* Mode aspect ratio (horiz/vert * 1000)	*/
        public long pageSize;      /* Number of bytes in a page				*/
        public int scratch1;     /* Scratch pad value 1						*/
        public int scratch2;     /* Scratch pad value 2						*/
        public char redMaskSize;            /* Size of direct color red mask    */
        public char redFieldPosition;       /* Bit posn of lsb of red mask      */
        public char greenMaskSize;          /* Size of direct color green mask  */
        public char greenFieldPosition;     /* Bit posn of lsb of green mask    */
        public char blueMaskSize;           /* Size of direct color blue mask   */
        public char blueFieldPosition;      /* Bit posn of lsb of blue mask     */
        public char rsvdMaskSize;          /* Size of reserved mask			*/
        public char rsvdFieldPosition;     /* Bit posn of reserved mask		*/
    }
    public class MGLDC {
        public attributes_t a;
        public object surface;
        public object zbuffer;
        public int zbits;
        public int zwidth;
        public gmode_t mi;
        public pixel_format_t pf;
        public uint colorTab;
        public uint shadeTab;
        public int bankOffset;
    }

    public struct viddef_t {
        public byte[] buffer;        // invisible buffer
        public byte colormap;      // 256 * VID_GRADES size
        public ushort colormap16; // 256 * VID_GRADES size
        public int fullbright;     // index of first fullbright color
        public uint rowbytes;  // may be > width if displayed in a window
        public uint width;
        public uint height;
        public float aspect;       // width / height -- < 0 is taller than wide
        public int numpages;
        public int recalc_refdef;  // if true, recalc vid-based stuff
        public byte[] conbuffer;
        public int conrowbytes;
        public uint conwidth;
        public uint conheight;
        public int maxwarpwidth;
        public int maxwarpheight;
        public byte[] direct;        // direct drawing to framebuffer, if not
    }

    public static class Video {
        public static bool DDActive;
        static int lockcount;
        static MGLDC dibdc = null;
        static viddef_t vid;

        static byte[] d_viewbuffer;

        public static void Init(byte[] palette) {
            //TODO:
            //int i, bestmatch, bestmatchmetric, t, dr, dg, db;
            //int basenummodes;
            //byte[] ptmp;

            //Cvar.RegisterVariable(&vid_mode);
            //Cvar.RegisterVariable(&vid_wait);
            //Cvar.RegisterVariable(&vid_nopageflip);
            //Cvar.RegisterVariable(&_vid_wait_override);
            //Cvar.RegisterVariable(&_vid_default_mode);
            //Cvar.RegisterVariable(&_vid_default_mode_win);
            //Cvar.RegisterVariable(&vid_config_x);
            //Cvar.RegisterVariable(&vid_config_y);
            //Cvar.RegisterVariable(&vid_stretch_by_2);
            //Cvar.RegisterVariable(&_windowed_mouse);
            //Cvar.RegisterVariable(&vid_fullscreen_mode);
            //Cvar.RegisterVariable(&vid_windowed_mode);
            //Cvar.RegisterVariable(&block_switch);
            //Cvar.RegisterVariable(&vid_window_x);
            //Cvar.RegisterVariable(&vid_window_y);

            //Cmd.AddCommand("vid_testmode", VID_TestMode_f);
            //Cmd.AddCommand("vid_nummodes", VID_NumModes_f);
            //Cmd.AddCommand("vid_describecurrentmode", VID_DescribeCurrentMode_f);
            //Cmd.AddCommand("vid_describemode", VID_DescribeMode_f);
            //Cmd.AddCommand("vid_describemodes", VID_DescribeModes_f);
            //Cmd.AddCommand("vid_forcemode", VID_ForceMode_f);
            //Cmd.AddCommand("vid_windowed", VID_Windowed_f);
            //Cmd.AddCommand("vid_fullscreen", VID_Fullscreen_f);
            //Cmd.AddCommand("vid_minimize", VID_Minimize_f);

            //if (Com.CheckParm("-dibonly"))
            //    dibonly = true;

            //VID_InitMGLDIB(global_hInstance);

            //basenummodes = nummodes;

            //if (!dibonly)
            //    VID_InitMGLFull(global_hInstance);

            //// if there are no non-windowed modes, or only windowed and mode 0x13, then use
            //// fullscreen DIBs as well
            //if (((nummodes == basenummodes) ||
            //     ((nummodes == (basenummodes + 1)) && is_mode0x13)) &&
            //    !COM_CheckParm("-nofulldib")) {
            //    VID_InitFullDIB(global_hInstance);
            //}

            //vid.maxwarpwidth = WARP_WIDTH;
            //vid.maxwarpheight = WARP_HEIGHT;
            //vid.colormap = host_colormap;
            //vid.fullbright = 256 - LittleLong(*((int*)vid.colormap + 2048));
            //vid_testingmode = 0;

            //// GDI doesn't let us remap palette index 0, so we'll remap color
            //// mappings from that black to another one
            //bestmatchmetric = 256 * 256 * 3;

            //for (i = 1; i < 256; i++) {
            //    dr = palette[0] - palette[i * 3];
            //    dg = palette[1] - palette[i * 3 + 1];
            //    db = palette[2] - palette[i * 3 + 2];

            //    t = (dr * dr) + (dg * dg) + (db * db);

            //    if (t < bestmatchmetric) {
            //        bestmatchmetric = t;
            //        bestmatch = i;

            //        if (t == 0)
            //            break;
            //    }
            //}

            //for (i = 0, ptmp = vid.colormap; i < (1 << (VID_CBITS + 8)); i++, ptmp++) {
            //    if (*ptmp == 0)
            //        *ptmp = bestmatch;
            //}

            //if (COM_CheckParm("-startwindowed")) {
            //    startwindowed = 1;
            //    vid_default = windowed_default;
            //}

            //if (hwnd_dialog)
            //    DestroyWindow(hwnd_dialog);

            //// sound initialization has to go here, preceded by a windowed mode set,
            //// so there's a window for DirectSound to work with but we're not yet
            //// fullscreen so the "hardware already in use" dialog is visible if it
            //// gets displayed

            //// keep the window minimized until we're ready for the first real mode set
            //hide_window = true;
            //VID_SetMode(MODE_WINDOWED, palette);
            //hide_window = false;
            //S_Init();

            //vid_initialized = true;

            //force_mode_set = true;
            //VID_SetMode(vid_default, palette);
            //force_mode_set = false;

            //vid_realmode = vid_modenum;

            //VID_SetPalette(palette);

            //vid_menudrawfn = VID_MenuDraw;
            //vid_menukeyfn = VID_MenuKey;

            //strcpy(badmode.modedesc, "Bad mode");
        }

        public static int ForceUnlockedAndReturnState() {
            int lk;

            if (lockcount == 0)
                return 0;

            lk = lockcount;

            if (dibdc != null) {
                lockcount = 0;
            } else {
                lockcount = 1;
                UnlockBuffer();
            }

            return lk;
        }

        static void UnlockBuffer() {
            if (dibdc != null)
                return;

            lockcount--;

            if (lockcount > 0)
                return;

            if (lockcount < 0)
                Sys.Error("Unbalanced unlock");

            //MGL_endDirectAccess();

            // to turn up any unlocked accesses
            vid.buffer = vid.conbuffer = vid.direct = d_viewbuffer = null;
        }

    }
}
