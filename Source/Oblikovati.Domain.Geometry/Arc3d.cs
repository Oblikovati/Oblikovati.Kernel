using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Arc3d : IArc3d
{
    public IPoint Center { get; set; }
    public IUnitVector Normal { get; set; }
    public IUnitVector ReferenceVector { get; set; }
    public double Radius { get; set; }
    public double StartAngle { get; set; }
    public double SweepAngle { get; set; }
    public IPoint StartPoint { get; set; }
    public IPoint EndPoint { get; set; }
    public ICurveEvaluator Evaluator { get; set; }

    public void GetArcData(ref List<double> Center, ref List<double> AxisVector, ref List<double> RefVector, out double Radius, out double StartAngle,
        out double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public void PutArcData(ref List<double> Center, ref List<double> AxisVector, ref List<double> RefVector, double Radius, double StartAngle,
        double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IArc3d Copy()
    {
        throw new NotImplementedException();
    }
}