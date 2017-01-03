namespace Quake {
    public static class QuakeDef {
        public const int MINIMUM_MEMORY = 0x550000;
        public const int MINIMUM_MEMORY_LEVELPAK = (MINIMUM_MEMORY + 0x100000);

        public const int MAX_QPATH = 64;

        public const int MAX_DATAGRAM = 1024;   // max length of unreliable message

        //
        // per-level limits
        //
        public const int MAX_LIGHTSTYLES = 64;
        public const int MAX_MODELS = 256;      // these are sent over the net as bytes
        public const int MAX_SOUNDS = 256;	// so they cannot be blindly increased

    }
}
