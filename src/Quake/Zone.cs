namespace Quake {
    public class memblock_t {
        public int size;           // including the header and possibly tiny fragments
        public int tag;            // a tag of 0 is a free block
        public int id;             // should be ZONEID
        public memblock_t next, prev;
        public int pad;            // pad to 64 bit boundary
    }

    public class memzone_t {
        public int size;       // total bytes malloced, including header
        public memblock_t blocklist;       // start / end cap for linked list
        public memblock_t rover;
    }

    public struct cache_user_t {
        byte[] data;
    }

    public class cache_system_t {
        public int size;       // including this header
        public cache_user_t user;
        public string name;
        public cache_system_t prev, next;
        public cache_system_t lru_prev, lru_next;   // for LRU flushing	
    }

    public static class Zone {
        const int DYNAMIC_SIZE = 0xc000;
        static byte[] hunk_base;
        static int hunk_low_used, hunk_high_used;
        static memzone_t mainzone;

        static cache_system_t cache_head = new cache_system_t();

        public static void Memory_Init(byte[] membase) {
            int p;
            int zonesize = DYNAMIC_SIZE;

            hunk_base = membase;
            hunk_low_used = 0;
            hunk_high_used = 0;

            Cache_Init();
            p = Com.CheckParm("-zone");
            if (p != 0) {
                if (p + 1 < Com.largv.Length - 1) {
                    int parsedKbs = 0;
                    int.TryParse(Com.largv[p + 1], out parsedKbs);
                    zonesize = parsedKbs * 1024;
                } else
                    Sys.Error("Memory_Init: you must specify a size in KB after -zone");
            }
            //TODO:
            //mainzone = Hunk_AllocName(zonesize, "zone");
            Z_ClearZone(mainzone, zonesize);

        }

        static void Z_ClearZone(memzone_t zone, int size) {
            //TODO:
            //memblock_t* block;

            //// set the entire zone to one free block

            //zone->blocklist.next = zone->blocklist.prev = block =
            //    (memblock_t*)((byte*)zone + sizeof(memzone_t));
            //zone->blocklist.tag = 1;    // in use block
            //zone->blocklist.id = 0;
            //zone->blocklist.size = 0;
            //zone->rover = block;

            //block->prev = block->next = &zone->blocklist;
            //block->tag = 0;         // free block
            //block->id = ZONEID;
            //block->size = size - sizeof(memzone_t);
        }

        static void Hunk_AllocName(int size, string name) {
            //TODO:
            //hunk_t* h;

            //if (size < 0)
            //    Sys_Error("Hunk_Alloc: bad size: %i", size);

            //size = sizeof(hunk_t) + ((size + 15) & ~15);

            //if (hunk_size - hunk_low_used - hunk_high_used < size)
            //    Sys_Error("Hunk_Alloc: failed on %i bytes", size);

            //h = (hunk_t*)(hunk_base + hunk_low_used);
            //hunk_low_used += size;

            //Cache_FreeLow(hunk_low_used);

            //memset(h, 0, size);

            //h->size = size;
            //h->sentinal = HUNK_SENTINAL;
            //Q_strncpy(h->name, name, 8);

            //return (void*)(h + 1);
        }

        static void Cache_Init() {
            cache_head.next = cache_head.prev = cache_head;
            cache_head.lru_next = cache_head.lru_prev = cache_head;

            Cmd.AddCommand("flush", Cache_Flush);
        }

        static void Cache_Flush() {
            //TODO:
            //while (cache_head.next != &cache_head)
            //    Cache_Free(cache_head.next->user);  // reclaim the space
        }

        static void Cache_Free(cache_user_t c) {
            //TODO:
            //cache_system_t* cs;

            //if (!c->data)
            //    Windows.Error("Cache_Free: not allocated");

            //cs = ((cache_system_t*)c->data) - 1;

            //cs->prev->next = cs->next;
            //cs->next->prev = cs->prev;
            //cs->next = cs->prev = NULL;

            //c->data = NULL;

            //Cache_UnlinkLRU(cs);
        }

        static void Cache_UnlinkLRU(cache_system_t cs) {
            //TODO:
            //if (!cs->lru_next || !cs->lru_prev)
            //    Windows.Error("Cache_UnlinkLRU: NULL link");

            //cs->lru_next->lru_prev = cs->lru_prev;
            //cs->lru_prev->lru_next = cs->lru_next;

            //cs->lru_prev = cs->lru_next = NULL;
        }
    }
}
