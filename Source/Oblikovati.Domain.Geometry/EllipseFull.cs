using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class EllipseFull : IEllipseFull
{
    public IPoint Center { get; set; }
    public IUnitVector Normal { get; set; }
    public IVector MajorAxisVector { get; set; }
    public double MinorMajorRatio { get; set; }
    public ICurveEvaluator Evaluator { get; set; }
    public void GetEllipseFullData(ref List<double> Center, ref List<double> AxisVector, ref List<double> MajorAxis, out double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public void PutEllipseFullData(ref List<double> Center, ref List<double> AxisVector, ref List<double> MajorAxis, double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public IEllipseFull Copy()
    {
        throw new NotImplementedException();
    }
}