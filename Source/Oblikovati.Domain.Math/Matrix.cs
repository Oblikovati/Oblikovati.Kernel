using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class Matrix : IMatrix
{
    public double Cell { get; set; }
    public double Determinant { get; set; }
    public IVector Translation { get; set; }
    public void GetMatrixData(ref List<double> Cells)
    {
        throw new NotImplementedException();
    }

    public void PutMatrixData(ref List<double> Cells)
    {
        throw new NotImplementedException();
    }

    public void Invert()
    {
        throw new NotImplementedException();
    }

    public void GetCoordinateSystem(out IPoint Origin, out IVector XAxis, out IVector YAxis, out IVector ZAxis)
    {
        throw new NotImplementedException();
    }

    public void SetCoordinateSystem(IPoint Origin, IVector XAxis, IVector YAxis, IVector ZAxis)
    {
        throw new NotImplementedException();
    }

    public void SetToAlignCoordinateSystems(IPoint FromOrigin, IVector FromXAxis, IVector FromYAxis, IVector FromZAxis,
        IPoint ToOrigin, IVector ToXAxis, IVector ToYAxis, IVector ToZAxis)
    {
        throw new NotImplementedException();
    }

    public void SetToIdentity()
    {
        throw new NotImplementedException();
    }

    public void SetToRotation(double Angle, IVector Axis, IPoint Center)
    {
        throw new NotImplementedException();
    }

    public void SetToRotateTo(IVector From, IVector To, IVector Axis)
    {
        throw new NotImplementedException();
    }

    public void SetTranslation(IVector Translation, bool ResetRotation)
    {
        throw new NotImplementedException();
    }

    public bool IsEqualTo(IMatrix Matrix, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public void TransformBy(IMatrix Matrix)
    {
        throw new NotImplementedException();
    }

    public void PreMultiplyBy(IMatrix Matrix)
    {
        throw new NotImplementedException();
    }

    public void PostMultiplyBy(IMatrix Matrix)
    {
        throw new NotImplementedException();
    }

    public IMatrix Copy()
    {
        throw new NotImplementedException();
    }

    public void MultiplyBy(IMatrix Matrix)
    {
        throw new NotImplementedException();
    }
}