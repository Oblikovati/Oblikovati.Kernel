using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class EllipticalArc2d : IEllipticalArc2d
{
    public IPoint2d Center { get; set; }
    public IUnitVector2d MajorAxis { get; set; }
    public double MajorRadius { get; set; }
    public double MinorRadius { get; set; }
    public double StartAngle { get; set; }
    public double SweepAngle { get; set; }
    public IPoint2d StartPoint { get; set; }
    public IPoint2d EndPoint { get; set; }
    public ICurve2dEvaluator Evaluator { get; set; }

    public void GetEllipticalArcData(ref List<double> Center, ref List<double> MajorAxis, out double MajorRadius, out double MinorRadius,
        out double StartAngle, out double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public void PutEllipticalArcData(ref List<double> Center, ref List<double> MajorAxis, double MajorRadius, double MinorRadius,
        double StartAngle, double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IEllipticalArc2d Copy()
    {
        throw new NotImplementedException();
    }
}