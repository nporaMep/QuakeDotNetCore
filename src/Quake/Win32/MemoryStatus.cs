using System;
using System.Runtime.InteropServices;

namespace Quake.Win32 {
    /// <summary>
    /// The MEMORYSTATUS structure contains information about the current state of both physical and virtual memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryStatus {
        /// <summary>
        /// Size of the MEMORYSTATUS data structure, in bytes. You do not need to set this member before calling the GlobalMemoryStatus function; the function sets it. 
        /// </summary>
        public uint dwLength;

        /// <summary>
        /// Number between 0 and 100 that specifies the approximate percentage of physical memory that is in use (0 indicates no memory use and 100 indicates full memory use). 
        /// Windows NT:  Percentage of approximately the last 1000 pages of physical memory that is in use.
        /// </summary>
        public uint dwMemoryLoad;

        /// <summary>
        /// Total size of physical memory, in bytes. 
        /// </summary>
        public int dwTotalPhys;

        /// <summary>
        /// Size of physical memory available, in bytes
        /// </summary>
        public int dwAvailPhys;

        /// <summary>
        /// Size of the committed memory limit, in bytes. 
        /// </summary>
        public UIntPtr dwTotalPageFile;

        /// <summary>
        /// Size of available memory to commit, in bytes. 
        /// </summary>
        public UIntPtr dwAvailPageFile;

        /// <summary>
        /// Total size of the user mode portion of the virtual address space of the calling process, in bytes. 
        /// </summary>
        public UIntPtr dwTotalVirtual;

        /// <summary>
        /// Size of unreserved and uncommitted memory in the user mode portion of the virtual address space of the calling process, in bytes. 
        /// </summary>
        public UIntPtr dwAvailVirtual;

    } // class MEMORYSTATUS
}
