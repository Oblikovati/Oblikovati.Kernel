using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class UnitVector : IUnitVector
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public void GetUnitVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void PutUnitVectorData(ref List<double> Coords)
    {
        throw new NotImplementedException();
    }

    public void TransformBy(IMatrix Matrix)
    {
        throw new NotImplementedException();
    }

    public double AngleTo(IUnitVector Argument)
    {
        throw new NotImplementedException();
    }

    public bool IsParallelTo(IUnitVector Argument, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsPerpendicularTo(IUnitVector Argument, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public bool IsEqualTo(IUnitVector Argument, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public double DotProduct(IUnitVector Argument)
    {
        throw new NotImplementedException();
    }

    public IUnitVector CrossProduct(IUnitVector Argument)
    {
        throw new NotImplementedException();
    }

    public IVector AsVector()
    {
        throw new NotImplementedException();
    }

    public IUnitVector Copy()
    {
        throw new NotImplementedException();
    }
}