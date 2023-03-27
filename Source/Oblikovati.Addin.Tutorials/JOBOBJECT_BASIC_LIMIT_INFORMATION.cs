namespace Oblikovati.Addin.Tutorials;

internal struct JOBOBJECT_BASIC_LIMIT_INFORMATION
{
    public long PerProcessUserTimeLimit;
    public long PerJobUserTimeLimit;
    public short LimitFlags;
    public UIntPtr MinimumWorkingSetSize;
    public UIntPtr MaximumWorkingSetSize;
    public short ActiveProcessLimit;
    public long Affinity;
    public short PriorityClass;
    public short SchedulingClass;
}