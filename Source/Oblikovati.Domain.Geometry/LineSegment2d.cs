using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class LineSegment2d : ILineSegment2d
{
    public IPoint2d StartPoint { get; set; }
    public IPoint2d EndPoint { get; set; }
    public IPoint2d MidPoint { get; set; }
    public IUnitVector2d Direction { get; set; }
    public ICurve2dEvaluator Evaluator { get; set; }
    public void GetLineSegmentData(ref List<double> StartPoint, ref List<double> EndPoint)
    {
        throw new NotImplementedException();
    }

    public void PutLineSegmentData(ref List<double> StartPoint, ref List<double> EndPoint)
    {
        throw new NotImplementedException();
    }

    public double DistanceTo(IPoint2d Point)
    {
        throw new NotImplementedException();
    }

    public IObjectsEnumerator IntersectWithCurve(object Curve, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public ILineSegment2d Copy()
    {
        throw new NotImplementedException();
    }
}