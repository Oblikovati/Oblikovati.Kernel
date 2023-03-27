using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.AddIns;

public class ApplicationAddinSite : IApplicationAddInSite
{
    public ApplicationAddinSite(IApplicationAddIn parent)
    {
        
        
    }
    public IApplicationAddIn Parent { get; }
    
    public ICommand CreateCommand(string CommandName, int CommandID, object InstallInTools)
    {
        throw new NotImplementedException();
    }

    public void DeleteCommand(int CommandID)
    {
        throw new NotImplementedException();
    }

    public string LicenseChallenge()
    {
        throw new NotImplementedException();
    }

    public IButtonDefinitionHandler CreateButtonDefinitionHandler(string InternalName, CommandTypesEnum Classification,
        string DisplayName, object DescriptionText, object ToolTipText, object StandardIcon, object LargeIcon)
    {
        throw new NotImplementedException();
    }

    public IEnvironmentBaseHandler CreateEnvironmentBaseHandler(string EnvironmentID, string InternalName, string DisplayName,
        IEnvironmentBase CopyFrom)
    {
        throw new NotImplementedException();
    }
}