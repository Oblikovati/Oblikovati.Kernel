using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Files;

public class FileAccessEvents : IFileAccessEvents
{
    public void FireOnFileResolution(string RelativeFileName, string LibraryName, ref List<byte> CustomLogicalName,
        EventTimingEnum BeforeOrAfter, INameValueMap Context, out string FullFileName, out HandlingCodeEnum HandlingCode)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileResolution(FileAccessEventsSink_OnFileResolutionEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileResolution(FileAccessEventsSink_OnFileResolutionEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileDirty(FileAccessEventsSink_OnFileDirtyEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileDirty(FileAccessEventsSink_OnFileDirtyEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}