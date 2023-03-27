using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Circle : ICircle
{
    public IPoint Center { get; set; }
    public IUnitVector Normal { get; set; }
    public double Radius { get; set; }
    public ICurveEvaluator Evaluator { get; set; }
    public void GetCircleData(ref List<double> Center, ref List<double> AxisVector, out double Radius)
    {
        throw new NotImplementedException();
    }

    public void PutCircleData(ref List<double> Center, ref List<double> AxisVector, double Radius)
    {
        throw new NotImplementedException();
    }

    public ICircle Copy()
    {
        throw new NotImplementedException();
    }
}