using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;

namespace Oblikovati.Domain.Core.Application;

public class CustomDataEvents : ICustomDataEvents
{
    public CustomDataEvents()
    {
        
        
    }
    
    
    public void add_OnRequestCustomData(CustomDataEventsSink_OnRequestCustomDataEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnRequestCustomData(CustomDataEventsSink_OnRequestCustomDataEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnExecuteCustomAction(CustomDataEventsSink_OnExecuteCustomActionEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnExecuteCustomAction(CustomDataEventsSink_OnExecuteCustomActionEventHandler handler)
    {
        throw new NotImplementedException();
    }
}