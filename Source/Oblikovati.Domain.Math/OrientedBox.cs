using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class OrientedBox : IOrientedBox
{
    public IPoint CornerPoint { get; set; }
    public IVector DirectionOne { get; set; }
    public IVector DirectionTwo { get; set; }
    public IVector DirectionThree { get; set; }

    public void GetOrientedBoxData(out IPoint CornerPoint, out IVector DirectionOne, out IVector DirectionTwo,
        out IVector DirectionThree)
    {
        throw new NotImplementedException();
    }

    public void PutOrientedBoxData(IPoint CornerPoint, IVector DirectionOne, IVector DirectionTwo, IVector DirectionThree)
    {
        throw new NotImplementedException();
    }

    public IOrientedBox Copy()
    {
        throw new NotImplementedException();
    }

    public bool Contains(IPoint Point)
    {
        throw new NotImplementedException();
    }

    public bool IsDisjoint(IOrientedBox OrientedBox)
    {
        throw new NotImplementedException();
    }
}