using System.Linq;
using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Utility;

public class NameValueMap : Dictionary<string,object>, INameValueMap
{
    public void Remove(object Index)
    {
        if(!base.ContainsValue(Index))
            return;
        foreach (var vkpair in this.Where(vkpair => vkpair.Value.Equals(Index)))
        {
            base.Remove(vkpair.Key);
        }
    }

    public void Insert(string Name, object Value, object TargetIndex, bool InsertBefore)
    {
        throw new NotImplementedException();
    }
}