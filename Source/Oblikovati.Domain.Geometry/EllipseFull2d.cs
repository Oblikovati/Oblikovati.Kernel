using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class EllipseFull2d : IEllipseFull2d
{
    public IPoint2d Center { get; set; }
    public IVector2d MajorAxisVector { get; set; }
    public double MinorMajorRatio { get; set; }
    public ICurve2dEvaluator Evaluator { get; set; }
    public void GetEllipseFullData(ref List<double> Center, ref List<double> MajorAxis, out double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public void PutEllipseFullData(ref List<double> Center, ref List<double> MajorAxis, double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public IEllipseFull2d Copy()
    {
        throw new NotImplementedException();
    }
}