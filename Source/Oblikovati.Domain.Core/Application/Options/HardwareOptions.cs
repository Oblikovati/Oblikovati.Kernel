using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class HardwareOptions : IHardwareOptions
{
    public HardwareOptions()
    {

    }

    public GraphicsDriverTypeEnum GraphicsDriverType { get; set; }
    public bool WarnForUnrecommendedDriver { get; set; }
    public bool WarnForDriverErrors { get; set; }
    public GraphicsOptimizationEnum GraphicsOptimization { get; set; }
    public string Diagnostics { get; set; }
    public GraphicsSettingTypeEnum GraphicsSettingType { get; set; }
    public bool UseSoftwareGraphics { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}