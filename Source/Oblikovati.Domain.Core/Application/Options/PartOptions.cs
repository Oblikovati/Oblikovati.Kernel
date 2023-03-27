using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class PartOptions : IPartOptions
{
    public PartOptions()
    {

    }

    public bool AutoHideInLineWorkFeatures { get; set; }
    public bool OpaqueConstructionSurfaces { get; set; }
    public SketchCreationOnNewPartEnum SketchCreationOnNewPart { get; set; }
    public DimensionConstraintsRelaxationEnum DimensionConstraintsRelaxation { get; set; }
    public GeometricConstraintsBreakageEnum GeometricConstraintsBreakage { get; set; }
    public bool AutoConsumeWorkAndSurfaceFeatures { get; set; }
    public bool Enable3DGrips { get; set; }
    public bool DisplayGripsOnSelection { get; set; }
    public bool EditBaseSolidsUsingFusion { get; set; }
    public bool SkipAllUnresolvedFiles { get; set; }
    public DesignViewTypeEnum DefaultDesignView { get; set; }
    public bool DefaultDesignViewIsAssociative { get; set; }
    public bool DisplayExtendedName { get; set; }
    public bool EnableConstructionEnvironment { get; set; }
    public bool DerivedPartColorOverride { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}