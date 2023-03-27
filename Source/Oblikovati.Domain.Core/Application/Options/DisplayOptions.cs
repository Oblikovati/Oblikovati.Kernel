using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class DisplayOptions : IDisplayOptions
{
    public DisplayOptions()
    {

    }

    public int HiddenLineDimmingPercent { get; set; }
    public double MinimumFrameRate { get; set; }
    public IShadedDisplayOptions ShadedDisplayOptions { get; set; }
    public IWireframeDisplayOptions WireframeDisplayOptions { get; set; }
    public double ViewTransitionTime { get; set; }
    public DisplayQualityEnum DisplayQuality { get; set; }
    public bool ReverseZoomDirection { get; set; }
    public bool SolidLinesForHiddenEdges { get; set; }
    public bool ZoomToCursor { get; set; }
    public OrbitTypeEnum DefaultOrbitType { get; set; }
    public DisplayModeEnum NewWindowDisplayMode { get; set; }
    public ProjectionTypeEnum NewWindowProjectionType { get; set; }
    public bool DepthDimming { get; set; }
    public bool DisplaySilhouettes { get; set; }
    public IColor EdgeColor { get; set; }
    public IColor InactiveComponentsEdgeColor { get; set; }
    public bool InactiveComponentsEdgeDisplay { get; set; }
    public bool InactiveComponentsShaded { get; set; }
    public int InactiveComponentsShadeOpacity { get; set; }
    public bool NewWindowShowGroundPlane { get; set; }
    public bool NewWindowShowGroundReflections { get; set; }
    public bool UseDocumentDisplaySettings { get; set; }
    public bool NewWindowShowAmbientShadows { get; set; }
    public bool NewWindowShowGroundShadows { get; set; }
    public bool NewWindowShowObjectShadows { get; set; }
    public bool Show3DIndicator { get; set; }
    public bool ShowXYZAxisLabels { get; set; }
    public bool UseRayTracingForRealisticDisplay { get; set; }
    public RayTracingQualityEnum RayTracingQuality { get; set; }
    public bool AreTexturesOn { get; set; }
    public bool TrackSelection { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}