using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class Box2d : IBox2d
{
    public IPoint2d MinPoint { get; set; }
    public IPoint2d MaxPoint { get; set; }
    public void GetBoxData(ref List<double> MinPoint, ref List<double> MaxPoint)
    {
        throw new NotImplementedException();
    }

    public void PutBoxData(ref List<double> MinPoint, ref List<double> MaxPoint)
    {
        throw new NotImplementedException();
    }

    public void Extend(IPoint2d Point)
    {
        throw new NotImplementedException();
    }

    public void Expand(double Distance)
    {
        throw new NotImplementedException();
    }

    public bool Contains(IPoint2d Point)
    {
        throw new NotImplementedException();
    }

    public bool IsDisjoint(IBox2d Box)
    {
        throw new NotImplementedException();
    }

    public IBox2d Copy()
    {
        throw new NotImplementedException();
    }
}