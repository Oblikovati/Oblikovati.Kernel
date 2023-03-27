using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class AssemblyOptions : IAssemblyOptions
{
    public bool OnlyActiveComponentIsOpaque { get; set; }
    public bool PartFeaturesInitiallyAdaptive { get; set; }
    public bool DeferUpdate { get; set; }
    public bool DeleteComponentPatternSources { get; set; }
    public bool EnableConstraintRedundancyAnalysis { get; set; }
    public bool SectionAllParts { get; set; }
    public bool FromToExtentsMatePlane { get; set; }
    public bool FromToExtentsAdaptFeature { get; set; }
    public bool EnableCrossPartEdgeLoopProjection { get; set; }
    public ZoomTargetComponentWithiMateEnum ZoomTargetComponentWithiMate { get; set; }
    public bool ConstraintAudioNotification { get; set; }
    public bool UseiMate { get; set; }
    public bool EnableRelatedConstraintFailureAnalysis { get; set; }
    public LevelOfDetailEnum DefaultLevelOfDetail { get; set; }
    public DesignViewTypeEnum DefaultDesignView { get; set; }
    public bool DefaultDesignViewIsAssociative { get; set; }
    public bool UseLastOccurrenceOrientationForPlacement { get; set; }
    public bool DisplayComponentNamesInConstraints { get; set; }
    public bool SkipAllUnresolvedFiles { get; set; }
    public bool EnableCrossPartSketchGeometryProjection { get; set; }
    public bool EnableAssemblyLite { get; set; }
    public int AssemblyLiteMinimumUniqueDocument { get; set; }
    public bool EnableAssemblyExpress { get; set; }
    public int AssemblyExpressMinimumUniqueDocument { get; set; }
    public bool PlaceAndGroundFirstComponentAtOrigin { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}