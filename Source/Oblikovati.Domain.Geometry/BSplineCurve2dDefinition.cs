using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Geometry;

public class BSplineCurve2dDefinition : IBSplineCurve2dDefinition
{
    public SplineFitMethodEnum FitMethod { get; set; }
    public void AddPoint(IPoint2d Point, double Weight, object Tangent)
    {
        throw new NotImplementedException();
    }
}