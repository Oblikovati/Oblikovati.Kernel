using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class BSplineCurve : IBSplineCurve
{
    public IPoint PoleAtIndex { get; set; }
    public ICurveEvaluator Evaluator { get; set; }

    public void GetBSplineInfo(out int Order, out int NumPoles, out int NumKnots, out bool IsRational, out bool IsPeriodic,
        out bool IsClosed, out bool IsPlanar, ref List<double> PlaneVector)
    {
        throw new NotImplementedException();
    }

    public void GetBSplineData(ref List<double> Poles, ref List<double> Knots, ref List<double> Weights)
    {
        throw new NotImplementedException();
    }

    public void PutBSplineInfoAndData(int Order, ref List<double> Poles, ref List<double> Knots, ref List<double> Weights, bool IsPeriodic)
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve Copy()
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve ExtractPartial(double StartParam, double EndParam)
    {
        throw new NotImplementedException();
    }

    public void Split(double SplitParam, out IBSplineCurve CurveOne, out IBSplineCurve CurveTwo)
    {
        throw new NotImplementedException();
    }
}