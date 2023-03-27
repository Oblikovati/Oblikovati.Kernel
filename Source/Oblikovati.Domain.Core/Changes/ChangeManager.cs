using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Changes;

public class ChangeManager : List<IChangeDefinitions>, IChangeManager
{
    
    public IChangeDefinitions Add(string ClientId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public object GetObjectFromScriptKey(string ScriptKey)
    {
        throw new NotImplementedException();
    }

    public string GetScriptKeyFromObject(object Object)
    {
        throw new NotImplementedException();
    }
}