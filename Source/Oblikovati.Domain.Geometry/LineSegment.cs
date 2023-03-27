using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class LineSegment : ILineSegment
{
    public IPoint StartPoint { get; set; }
    public IPoint EndPoint { get; set; }
    public IPoint MidPoint { get; set; }
    public IUnitVector Direction { get; set; }
    public ICurveEvaluator Evaluator { get; set; }
    public void GetLineSegmentData(ref List<double> StartPoint, ref List<double> EndPoint)
    {
        throw new NotImplementedException();
    }

    public void PutLineSegmentData(ref List<double> StartPoint, ref List<double> EndPoint)
    {
        throw new NotImplementedException();
    }

    public double DistanceTo(IPoint Point)
    {
        throw new NotImplementedException();
    }

    public IObjectsEnumerator IntersectWithCurve(object Curve, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IObjectsEnumerator IntersectWithSurface(object Surface, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public ILineSegment Copy()
    {
        throw new NotImplementedException();
    }
}