using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class EllipticalCone : IEllipticalCone
{
    public IPoint BasePoint { get; set; }
    public IUnitVector AxisVector { get; set; }
    public IVector MajorAxisVector { get; set; }
    public double MinorMajorRatio { get; set; }
    public double HalfAngle { get; set; }
    public bool IsExpanding { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }

    public void GetEllipticalConeData(ref List<double> BasePoint, ref List<double> AxisVector, ref List<double> MajorAxis, out double MinorMajorRatio,
        out double HalfAngle, out bool IsExpanding)
    {
        throw new NotImplementedException();
    }

    public void PutEllipticalConeData(ref List<double> BasePoint, ref List<double> AxisVector, ref List<double> MajorAxis, double MinorMajorRatio,
        double HalfAngle, bool IsExpanding)
    {
        throw new NotImplementedException();
    }

    public IEllipticalCone Copy()
    {
        throw new NotImplementedException();
    }
}