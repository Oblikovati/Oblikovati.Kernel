using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Environments;

public class EnvironmentBaseCollection : List<IEnvironmentBase>, IEnvironmentBaseCollection
{
    public EnvironmentBaseCollection()
    {
        
    }
    
    public ICommandBarBaseCollection CommandBarBaseCollection { get; set; }
}