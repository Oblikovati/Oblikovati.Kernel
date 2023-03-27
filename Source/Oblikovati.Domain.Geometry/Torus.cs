using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Torus : ITorus
{
    public IPoint CenterPoint { get; set; }
    public IUnitVector AxisVector { get; set; }
    public double MajorRadius { get; set; }
    public double MinorRadius { get; set; }
    public ISurfaceEvaluator Evaluator { get; set; }
    public void GetTorusData(ref List<double> CenterPoint, ref List<double> AxisVector, out double MajorRadius, out double MinorRadius)
    {
        throw new NotImplementedException();
    }

    public void PutTorusData(ref List<double> CenterPoint, ref List<double> AxisVector, double MajorRadius, double MinorRadius)
    {
        throw new NotImplementedException();
    }

    public ITorus Copy()
    {
        throw new NotImplementedException();
    }
}