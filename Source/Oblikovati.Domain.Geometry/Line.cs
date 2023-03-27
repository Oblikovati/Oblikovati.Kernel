using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Line : ILine
{
    public IPoint RootPoint { get; set; }
    public IUnitVector Direction { get; set; }
    public ICurveEvaluator Evaluator { get; set; }
    public bool IsColinearTo { get; set; }
    public void GetLineData(ref List<double> RootPoint, ref List<double> Direction)
    {
        throw new NotImplementedException();
    }

    public void PutLineData(ref List<double> RootPoint, ref List<double> Direction)
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

    public ILine Copy()
    {
        throw new NotImplementedException();
    }
}