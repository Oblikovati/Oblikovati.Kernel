using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.AddIns;

public class ApplicationAddIns : List<IApplicationAddIn>, IApplicationAddIns
{
    public new void Add(IApplicationAddIn addIn)
    {
        base.Add(addIn);
        if(addIn.LoadBehavior == AddInLoadBehaviorEnum.kLoadImmediately)
            addIn.Activate();
    }
    public void UpdateAddInList()
    {
        throw new NotImplementedException();
    }
}