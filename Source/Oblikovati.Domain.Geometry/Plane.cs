using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Plane : IPlane
{
    public IPoint RootPoint { get; set; }
    public IUnitVector Normal { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }
    public bool IsCoplanarTo { get; set; }
    public bool IsParallelTo { get; set; }
    public bool IsPerpendicularTo { get; set; }
    public void GetPlaneData(ref List<double> RootPoint, ref List<double> Normal)
    {
        throw new NotImplementedException();
    }

    public void PutPlaneData(ref List<double> RootPoint, ref List<double> Normal)
    {
        throw new NotImplementedException();
    }

    public IPoint IntersectWithLine(object Line, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public ILine IntersectWithPlane(IPlane Plane, double Tolerance)
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

    public IPlane Copy()
    {
        throw new NotImplementedException();
    }
}