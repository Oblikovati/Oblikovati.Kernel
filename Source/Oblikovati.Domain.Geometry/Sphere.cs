using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Sphere : ISphere
{
    public IPoint CenterPoint { get; set; }
    public double Radius { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }
    public void GetSphereData(ref List<double> CenterPoint, out double Radius)
    {
        throw new NotImplementedException();
    }

    public void PutSphereData(ref List<double> CenterPoint, double Radius)
    {
        throw new NotImplementedException();
    }

    public ISphere Copy()
    {
        throw new NotImplementedException();
    }
}