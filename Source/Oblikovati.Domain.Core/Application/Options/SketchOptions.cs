using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class SketchOptions : ISketchOptions
{
    public SketchOptions()
    {

    }

    public IHeadsUpDisplayOptions HeadsUpDisplayOptions { get; set; }
    public bool AutoProjectEdges { get; set; }
    public bool AutomaticReferenceEdges { get; set; }
    public ConstraintPriorityEnum ConstraintPriority { get; set; }
    public bool DisplayAxes { get; set; }
    public bool DisplayCoordinateSystemIndicator { get; set; }
    public bool DisplayGridLines { get; set; }
    public bool DisplayMinorGridLines { get; set; }
    public bool EditDimensionWhenCreated { get; set; }
    public OverConstrainedDimensionBehaviorEnum OverConstrainedDimensionBehavior { get; set; }
    public bool SnapToGrid { get; set; }
    public bool ParallelViewOnSketchCreation { get; set; }
    public bool _DeferUpdates { get; set; }
    public bool AutoProjectPartOrigin { get; set; }
    public bool ProjectObjectsAsConstructionGeometry { get; set; }
    public bool AutoScaleSketchGeometriesOnInitialDimension { get; set; }
    public double ConstraintToolbarScale { get; set; }
    public bool DisplayCoincidentConstraintsOnCreation { get; set; }
    public bool PointAlignment { get; set; }
    public int SplineDefaultTension { get; set; }
    public SplineFitMethodEnum SplineFitMethod { get; set; }
    public ISketchConstraintSettings SketchConstraintSettings { get; set; }
    public bool ImageInsertionLINKOptionCheckedAsDefault { get; set; }
    public bool ParallelViewOnSketchCreationInPart { get; set; }
    public bool ParallelViewOnSketchCreationInAssembly { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}