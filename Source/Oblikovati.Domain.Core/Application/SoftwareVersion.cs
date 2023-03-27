using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application;

public class SoftwareVersion : ISoftwareVersion
{
    public int Major { get; set; }
    public int Minor { get; set; }
    public int ServicePack { get; set; }
    public int BetaVersion { get; set; }
    public bool NotProduction { get; set; }
    public int BuildIdentifier { get; set; }
    public int _InternalBuildIdentifier { get; set; }
    public int _DebugBuildIdentifier { get; set; }
    public int _PatchBuildIdentifier { get; set; }
    public string DisplayName { get; set; }
    public bool Is64BitVersion { get; set; }
    public ProductEditionEnum ProductEdition { get; set; }
    public string DisplayVersion { get; set; }
    public bool IsEducationVersion { get; set; }
    public string ProductName { get; set; }
}