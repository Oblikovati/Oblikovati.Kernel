using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Point : IPoint
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public void GetPointData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void PutPointData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void TransformBy(IMatrix Matrix)
    {
        throw new NotImplementedException();
    }

    public void TranslateBy(IVector Vector)
    {
        throw new NotImplementedException();
    }

    public double DistanceTo(IPoint Point)
    {
        throw new NotImplementedException();
    }

    public IVector VectorTo(IPoint Point)
    {
        throw new NotImplementedException();
    }

    public bool IsEqualTo(IPoint Point, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IPoint Copy()
    {
        throw new NotImplementedException();
    }
}