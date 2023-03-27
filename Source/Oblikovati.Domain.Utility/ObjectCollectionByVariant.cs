using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Utility;

public class ObjectCollectionByVariant : List<object>, IObjectCollectionByVariant
{
    public void Add(string StringIndex, object Object)
    {
        throw new NotImplementedException();
    }
}