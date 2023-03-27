using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Geometry;

public class Point2d : IPoint2d
{
    public double X { get; set; }
    public double Y { get; set; }
    public void GetPointData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void PutPointData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public double DistanceTo(IPoint2d Point)
    {
        throw new NotImplementedException();
    }

    public void TransformBy(IMatrix2d Matrix)
    {
        throw new NotImplementedException();
    }

    public void TranslateBy(IVector2d Vector)
    {
        throw new NotImplementedException();
    }

    public IVector2d VectorTo(IPoint2d Point)
    {
        throw new NotImplementedException();
    }

    public bool IsEqualTo(IPoint2d Point, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IPoint2d Copy()
    {
        throw new NotImplementedException();
    }
}