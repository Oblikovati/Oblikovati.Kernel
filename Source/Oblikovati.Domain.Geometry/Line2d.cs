using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Line2d : ILine2d
{
    public IPoint2d RootPoint { get; set; }
    public IUnitVector2d Direction { get; set; }
    public ICurve2dEvaluator Evaluator { get; set; }
    public void GetLineData(ref List<double> RootPoint, ref List<double> Direction)
    {
        throw new NotImplementedException();
    }

    public void PutLineData(ref List<double> RootPoint, ref List<double> Direction)
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

    public ILine2d Copy()
    {
        throw new NotImplementedException();
    }
}