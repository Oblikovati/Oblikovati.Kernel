using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class DrawingOptions : IDrawingOptions
{
    public DrawingOptions()
    {

    }

    public bool DisplayLineWeights { get; set; }
    public bool CenterDimensionText { get; set; }
    public ArcDimensionTypeEnum ArcDimensionType { get; set; }
    public CircleDimensionTypeEnum CircleDimensionType { get; set; }
    public LineWeightTypeEnum LineWeightType { get; set; }
    public bool GetModelDimensions { get; set; }
    public LinearDimensionTypeEnum LinearDimensionType { get; set; }
    public StandardPartsSectionBehaviorEnum StandardPartsSectionBehavior { get; set; }
    public TitleBlockAlignmentEnum TitleBlockAlignment { get; set; }
    public double UpperLimitForFirstRangeOfLineWeights { get; set; }
    public double UpperLimitForSecondRangeOfLineWeights { get; set; }
    public double UpperLimitForThirdRangeOfLineWeights { get; set; }
    public ViewJustificationEnum ViewJustification { get; set; }
    public DefaultDrawingFileTypeEnum DefaultDrawingFileType { get; set; }
    public DefaultLayerStyleEnum DefaultLayerStyle { get; set; }
    public DefaultNonOblikovatiDWGFileOpenBehaviorEnum DefaultNonOblikovatiDWGFileOpenBehavior { get; set; }
    public DefaultObjectStyleEnum DefaultObjectStyle { get; set; }
    public bool MemorySavingMode { get; set; }
    public bool ShowUncutSectionViewPreview { get; set; }
    public ViewPreviewTypeEnum ViewPreview { get; set; }
    public bool EnableOrdinateDimGeomSelection { get; set; }
    public bool EditDimensionWhenCreated { get; set; }
    public DWGFileVersionEnum OblikovatiDWGFileVersion { get; set; }
    public ViewBlockInsertionPointEnum ViewBlockInsertionPoint { get; set; }
    public bool SkipAllUnresolvedFiles { get; set; }
    public bool EnableBackgroundUpdates { get; set; }
    public bool EnablePartModificationFromDrawing { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}