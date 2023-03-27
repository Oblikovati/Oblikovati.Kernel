using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class UnitVector2d : IUnitVector2d
{
    public double X { get; set; }
    public double Y { get; set; }
    public void GetUnitVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void PutUnitVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void TransformBy(IMatrix2d Value)
    {
        throw new NotImplementedException();
    }

    public double AngleTo(IUnitVector2d Vector)
    {
        throw new NotImplementedException();
    }

    public bool IsParallelTo(IUnitVector2d Vector, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsPerpendicularTo(IUnitVector2d Vector, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsEqualTo(IUnitVector2d Vector, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public double DotProduct(IUnitVector2d Vector)
    {
        throw new NotImplementedException();
    }

    public IVector2d AsVector()
    {
        throw new NotImplementedException();
    }

    public IUnitVector2d Copy()
    {
        throw new NotImplementedException();
    }
}