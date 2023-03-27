using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application;

public class DebugInstrumentation : IDebugInstrumentation
{
    public string ObjectDescription { get; set; }
    public object Object { get; set; }
    public int ObjectReferenceCount { get; set; }
    public int ObjectInstanceNumber { get; set; }
    public DebugWatchType ObjectWatchType { get; set; }
    public void GetLiveObjects(ref List<int> Cookies)
    {
        throw new NotImplementedException();
    }

    public int GetObjectCookie(object Object)
    {
        throw new NotImplementedException();
    }

    public void SetTrace(bool Enable, string TraceFilename)
    {
        throw new NotImplementedException();
    }

    public void GetTraceInfo(out bool Enabled, out string TraceFilename)
    {
        throw new NotImplementedException();
    }

    public void SetProfileInfo(bool Enable, bool WriteToFileOnStop, string FileName)
    {
        throw new NotImplementedException();
    }

    public void add_ObjectCreated(DebugInstrumentationSink_ObjectCreatedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_ObjectCreated(DebugInstrumentationSink_ObjectCreatedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_ObjectDestroyed(DebugInstrumentationSink_ObjectDestroyedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_ObjectDestroyed(DebugInstrumentationSink_ObjectDestroyedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_ObjectAddRefd(DebugInstrumentationSink_ObjectAddRefdEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_ObjectAddRefd(DebugInstrumentationSink_ObjectAddRefdEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_ObjectReleased(DebugInstrumentationSink_ObjectReleasedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_ObjectReleased(DebugInstrumentationSink_ObjectReleasedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_ObjectQueryInterfaced(DebugInstrumentationSink_ObjectQueryInterfacedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_ObjectQueryInterfaced(DebugInstrumentationSink_ObjectQueryInterfacedEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnMemberInvoke(DebugInstrumentationSink_OnMemberInvokeEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnMemberInvoke(DebugInstrumentationSink_OnMemberInvokeEventHandler handler)
    {
        throw new NotImplementedException();
    }
}