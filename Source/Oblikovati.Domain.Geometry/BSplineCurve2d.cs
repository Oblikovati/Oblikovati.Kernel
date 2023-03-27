using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class BSplineCurve2d : IBSplineCurve2d
{
    public IPoint2d PoleAtIndex { get; set; }
    public ICurve2dEvaluator Evaluator { get; set; }

    public void GetBSplineInfo(out int Order, out int NumPoles, out int NumKnots, out bool IsRational, out bool IsPeriodic,
        out bool IsClosed)
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

    public IBSplineCurve2d Copy()
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve2d ExtractPartial(double StartParam, double EndParam)
    {
        throw new NotImplementedException();
    }

    public void Split(double SplitParam, out IBSplineCurve2d CurveOne, out IBSplineCurve2d CurveTwo)
    {
        throw new NotImplementedException();
    }
}