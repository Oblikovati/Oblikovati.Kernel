using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Cone : ICone
{
    public IPoint BasePoint { get; set; }
    public IUnitVector AxisVector { get; set; }
    public double Radius { get; set; }
    public double HalfAngle { get; set; }
    public bool IsExpanding { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }

    public void GetConeData(ref List<double> BasePoint, ref List<double> AxisVector, out double Radius, out double HalfAngle,
        out bool IsExpanding)
    {
        throw new NotImplementedException();
    }

    public void PutConeData(ref List<double> BasePoint, ref List<double> AxisVector, double Radius, double HalfAngle, bool IsExpanding)
    {
        throw new NotImplementedException();
    }

    public ICone Copy()
    {
        throw new NotImplementedException();
    }
}