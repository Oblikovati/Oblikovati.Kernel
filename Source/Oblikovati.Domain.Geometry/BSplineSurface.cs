using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class BSplineSurface : IBSplineSurface
{
    public IPoint PoleAtIndex { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }

    public void GetBSplineInfo(ref List<int> Order, ref List<int> NumPoles, ref List<int> NumKnots, out bool IsRational, ref List<bool> IsPeriodic,
        ref List<bool> IsClosed, out bool IsPlanar, ref List<double> PlaneVector)
    {
        throw new NotImplementedException();
    }

    public void GetBSplineData(ref List<double> Poles, ref List<double> KnotsU, ref List<double> KnotsV, ref List<double> Weights)
    {
        throw new NotImplementedException();
    }

    public void PutBSplineInfoAndData(ref List<int> Order, ref List<double> Poles, ref List<double> KnotsU, ref List<double> KnotsV, ref List<double> Weights,
        ref List<bool> IsPeriodic)
    {
        throw new NotImplementedException();
    }

    public IBSplineSurface Copy()
    {
        throw new NotImplementedException();
    }
}