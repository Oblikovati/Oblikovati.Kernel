using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Utility;

public class EdgeCollection : List<object>, IEdgeCollection
{
    public EdgeCollectionEnum CollectionType { get; set; }
    public void Remove(int Index)
    {
        RemoveAt(Index);
    }

    public void RemoveByObject(object Object)
    {
        Remove(Object);
    }
}