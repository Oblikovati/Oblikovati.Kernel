using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Cylinder : ICylinder
{
    public IPoint BasePoint { get; set; }
    public IUnitVector AxisVector { get; set; }
    public double Radius { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }
    public void GetCylinderData(ref List<double> BasePoint, ref List<double> AxisVector, out double Radius)
    {
        throw new NotImplementedException();
    }

    public void PutCylinderData(ref List<double> BasePoint, ref List<double> AxisVector, double Radius)
    {
        throw new NotImplementedException();
    }

    public ICylinder Copy()
    {
        throw new NotImplementedException();
    }
}