using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class Vector : IVector
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double Length { get; set; }
    public void GetVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void PutVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void TransformBy(IMatrix Matrix)
    {
        throw new NotImplementedException();
    }

    public void ScaleBy(double Scale)
    {
        throw new NotImplementedException();
    }

    public void AddVector(IVector Argument)
    {
        throw new NotImplementedException();
    }

    public void SubtractVector(IVector Argument)
    {
        throw new NotImplementedException();
    }

    public double AngleTo(IVector Argument)
    {
        throw new NotImplementedException();
    }

    public void Normalize()
    {
        throw new NotImplementedException();
    }

    public bool IsParallelTo(IVector Argument, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsPerpendicularTo(IVector Argument, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsEqualTo(IVector Argument, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public double DotProduct(IVector Argument)
    {
        throw new NotImplementedException();
    }

    public IVector CrossProduct(IVector Argument)
    {
        throw new NotImplementedException();
    }

    public IUnitVector AsUnitVector()
    {
        throw new NotImplementedException();
    }

    public IVector Copy()
    {
        throw new NotImplementedException();
    }
}