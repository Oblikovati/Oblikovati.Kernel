using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class Vector2d : IVector2d
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Length { get; set; }
    public void GetVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void PutVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void TransformBy(IMatrix2d Value)
    {
        throw new NotImplementedException();
    }

    public void ScaleBy(double Value)
    {
        throw new NotImplementedException();
    }

    public void AddVector(IVector2d Value)
    {
        throw new NotImplementedException();
    }

    public void SubtractVector(IVector2d Value)
    {
        throw new NotImplementedException();
    }

    public double AngleTo(IVector2d Vector)
    {
        throw new NotImplementedException();
    }

    public void Normalize()
    {
        throw new NotImplementedException();
    }

    public bool IsParallelTo(IVector2d Vector, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsPerpendicularTo(IVector2d Vector, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsEqualTo(IVector2d Vector, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public double DotProduct(IVector2d Vector)
    {
        throw new NotImplementedException();
    }

    public IUnitVector2d AsUnitVector()
    {
        throw new NotImplementedException();
    }

    public IVector2d Copy()
    {
        throw new NotImplementedException();
    }
}