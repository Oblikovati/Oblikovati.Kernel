using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Math;

public class Box : IBox
{
    public IPoint MinPoint { get; set; }
    public IPoint MaxPoint { get; set; }
    public void GetBoxData(ref List<double> MinPoint, ref List<double> MaxPoint)
    {
        throw new NotImplementedException();
    }

    public void PutBoxData(ref List<double> MinPoint, ref List<double> MaxPoint)
    {
        throw new NotImplementedException();
    }

    public void Extend(IPoint Point)
    {
        throw new NotImplementedException();
    }

    public void Expand(double Distance)
    {
        throw new NotImplementedException();
    }

    public bool Contains(IPoint Point)
    {
        throw new NotImplementedException();
    }

    public bool IsDisjoint(IBox Box)
    {
        throw new NotImplementedException();
    }

    public IBox Copy()
    {
        throw new NotImplementedException();
    }
}