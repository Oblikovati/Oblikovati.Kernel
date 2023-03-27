using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Utility;

public class ObjectCollection : List<object>, IObjectCollection
{
    public void Remove(int Index)
    {
        RemoveAt(Index);
    }

    public void RemoveByObject(object Object)
    {
        Remove(Object);
    }
}