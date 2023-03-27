using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class EllipticalCylinder : IEllipticalCylinder
{
    public IPoint BasePoint { get; set; }
    public IUnitVector AxisVector { get; set; }
    public IVector MajorAxisVector { get; set; }
    public double MinorMajorRatio { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }
    public void GetEllipticalCylinderData(ref List<double> BasePoint, ref List<double> AxisVector, ref List<double> MajorAxis, out double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public void PutEllipticalCylinderData(ref List<double> BasePoint, ref List<double> AxisVector, ref List<double> MajorAxis, double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public IEllipticalCylinder Copy()
    {
        throw new NotImplementedException();
    }
}