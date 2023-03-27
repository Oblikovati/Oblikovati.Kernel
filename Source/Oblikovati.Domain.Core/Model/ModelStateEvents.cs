using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;

namespace Oblikovati.Domain.Core.Model;

public class ModelStateEvents : IModelStateEvents
{
    public ModelStateEvents()
    {
        
        
    }
     
    public void add_OnDeleteModelState(ModelStateEventsSink_OnDeleteModelStateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnDeleteModelState(ModelStateEventsSink_OnDeleteModelStateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnNewModelState(ModelStateEventsSink_OnNewModelStateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnNewModelState(ModelStateEventsSink_OnNewModelStateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnActivateModelState(ModelStateEventsSink_OnActivateModelStateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnActivateModelState(ModelStateEventsSink_OnActivateModelStateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}