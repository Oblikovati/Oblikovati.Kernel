using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Environments;

public class Environments : List<IEnvironment>, IEnvironments
{
    public Environments()
    {
        
    }
    

    public IEnvironment this[string index] => this.First(p => p.InternalName.Equals(index));

    public IEnvironment Add(string DisplayName, string InternalName, string ClientId, object StandardIcon, object LargeIcon)
    {
        var env = new Environment();
        env.DisplayName = DisplayName;
        env.InternalName = InternalName;
        env.ClientId = ClientId;
        Add(env);
        return env;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}