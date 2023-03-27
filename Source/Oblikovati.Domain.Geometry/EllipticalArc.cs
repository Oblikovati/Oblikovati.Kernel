using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class EllipticalArc : IEllipticalArc
{
    public IPoint Center { get; set; }
    public IUnitVector MajorAxis { get; set; }
    public IUnitVector MinorAxis { get; set; }
    public double MajorRadius { get; set; }
    public double MinorRadius { get; set; }
    public double StartAngle { get; set; }
    public double SweepAngle { get; set; }
    public IPoint StartPoint { get; set; }
    public IPoint EndPoint { get; set; }
    public ICurveEvaluator Evaluator { get; set; }

    public void GetEllipticalArcData(ref List<double> Center, ref List<double> MajorAxis, ref List<double> MinorAxis, out double MajorRadius,
        out double MinorRadius, out double StartAngle, out double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public void PutEllipticalArcData(ref List<double> Center, ref List<double> MajorAxis, ref List<double> MinorAxis, double MajorRadius,
        double MinorRadius, double StartAngle, double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IEllipticalArc Copy()
    {
        throw new NotImplementedException();
    }
}