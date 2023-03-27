using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Environments;

public class EnvironmentList : List<IEnvironment>, IEnvironmentList
{
    public EnvironmentList()
    {
        
    }
    
    public void Remove(int Index)
    {
        RemoveAt(Index);
    }
}