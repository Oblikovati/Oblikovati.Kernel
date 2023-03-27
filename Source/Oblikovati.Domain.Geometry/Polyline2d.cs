using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Polyline2d : IPolyline2d
{
    public ICurve2dEvaluator Evaluator { get; set; }
    public IPoint2d PointAtIndex { get; set; }
    public int PointCount { get; set; }
    public void GetPoints(out List<double> Points)
    {
        throw new NotImplementedException();
    }

    public void PutPoints(object Points)
    {
        throw new NotImplementedException();
    }

    public IPolyline2d Copy()
    {
        throw new NotImplementedException();
    }
}