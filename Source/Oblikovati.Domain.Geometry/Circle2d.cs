using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Circle2d : ICircle2d
{
    public IPoint2d Center { get; set; }
    public double Radius { get; set; }
    public ICurve2dEvaluator Evaluator { get; set; }
    public void GetCircleData(ref List<double> Center, out double Radius)
    {
        throw new NotImplementedException();
    }

    public void PutCircleData(ref List<double> Center, double Radius)
    {
        throw new NotImplementedException();
    }

    public ICircle2d Copy()
    {
        throw new NotImplementedException();
    }
}