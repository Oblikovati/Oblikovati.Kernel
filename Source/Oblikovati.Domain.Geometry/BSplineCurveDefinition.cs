using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Geometry;

public class BSplineCurveDefinition : IBSplineCurveDefinition
{
    public SplineFitMethodEnum FitMethod { get; set; }
    public double Length { get; set; }
    public bool FixedLength { get; set; }
    public void AddPoint(IPoint Point, double Weight, object Tangent)
    {
        throw new NotImplementedException();
    }
}