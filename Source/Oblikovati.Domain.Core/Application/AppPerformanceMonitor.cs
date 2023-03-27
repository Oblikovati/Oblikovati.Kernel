using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application;

public class AppPerformanceMonitor : I_AppPerformanceMonitor
{
    public int AllMemoryInUse { get; set; }
    public int ASMActiveEntityMemory { get; set; }
    public int ASMHistoryMemory { get; set; }
    public bool StatsActive { get; set; }
    public void GetMemoryInUse(out int Committed, out int Reserved)
    {
        throw new NotImplementedException();
    }

    public void SetGraphicsLOD(ref List<double> LODTolerances)
    {
        throw new NotImplementedException();
    }

    public void GetASMMemoryTotals(out long Allocations, out long DeAllocations, out int BytesAllocated, out int HighWaterMark)
    {
        throw new NotImplementedException();
    }

    public void GetASMFreeListMemory(out int Blocks, out int EmptyBlocks, out int TotalBytes, out int AllocatedBytes)
    {
        throw new NotImplementedException();
    }

    public void GetASMMemoryUtilizationRatios(out double Gross, out double Capacity, out double Theoretical)
    {
        throw new NotImplementedException();
    }

    public void InitStats()
    {
        throw new NotImplementedException();
    }

    public void StartTimer(string TimerName)
    {
        throw new NotImplementedException();
    }

    public void LogElapsedTime(string TimerName)
    {
        throw new NotImplementedException();
    }

    public void LogMemoryStatistics(string MemStatName)
    {
        throw new NotImplementedException();
    }

    public string OutputMetrics()
    {
        throw new NotImplementedException();
    }

    public void OutputElapsedTime(string TimerName, out int ElapsedTime)
    {
        throw new NotImplementedException();
    }

    public void OutputMemoryStatistics(string EntryName, out string CommittedMem, out string ReservedMem, out string WastedMem)
    {
        throw new NotImplementedException();
    }
}