using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Polyline3d : IPolyline3d
{
    public ICurveEvaluator Evaluator { get; set; }
    public IPoint PointAtIndex { get; set; }
    public int PointCount { get; set; }
    public void GetPoints(out List<double> Points)
    {
        throw new NotImplementedException();
    }

    public void PutPoints(object Points)
    {
        throw new NotImplementedException();
    }

    public IPolyline3d Copy()
    {
        throw new NotImplementedException();
    }
}