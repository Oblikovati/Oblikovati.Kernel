namespace Oblikovati.Addin.Tutorials;

internal struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
{
    public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
    public IO_COUNTERS IoInfo;
    public IntPtr ProcessMemoryLimit;
    public IntPtr JobMemoryLimit;
    public IntPtr PeakProcessMemoryUsed;
    public IntPtr PeakJobMemoryUsed;
}