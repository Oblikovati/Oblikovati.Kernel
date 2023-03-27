using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class ContentCenterOptions : IContentCenterOptions
{
    public ContentCenterOptions()
    {

    }

    public bool RefreshOutOfDateStandardParts { get; set; }
    public bool CustomFamilyAsStandard { get; set; }
    public bool CheckFamiliesUpdates { get; set; }
    public ContentCenterDecimalMarkerOptionEnum FilenameDecimalMarker { get; set; }
    public void GetAccessOption(out ContentCenterAccessOptionEnum AccessOption, out string LibrariesLocation)
    {
        throw new NotImplementedException();
    }

    public void SetAccessOption(ContentCenterAccessOptionEnum AccessOption, string LibrariesLocation)
    {
        throw new NotImplementedException();
    }
}