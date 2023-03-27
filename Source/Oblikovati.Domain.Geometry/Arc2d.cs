using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Arc2d : IArc2d
{
    public IPoint2d Center { get; set; }
    public double Radius { get; set; }
    public double StartAngle { get; set; }
    public double SweepAngle { get; set; }
    public IPoint2d StartPoint { get; set; }
    public IPoint2d EndPoint { get; set; }
    public ICurve2dEvaluator Evaluator { get; set; }
    public void GetArcData(ref List<double> Center, out double Radius, out double StartAngle, out double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public void PutArcData(ref List<double> Center, double Radius, double StartAngle, double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IArc2d Copy()
    {
        throw new NotImplementedException();
    }
}