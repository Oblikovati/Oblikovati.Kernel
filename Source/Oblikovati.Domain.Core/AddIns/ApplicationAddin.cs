using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.Enums;
using System.Reflection;

namespace Oblikovati.Domain.Core.AddIns;

public sealed class ApplicationAddin : IApplicationAddIn
{
    public ApplicationAddin(Assembly assembly)
    {
        Assembly = assembly;
        
        addInServer = null;
    }
    private void InstantiateAddinServer()
    {
        if(addInServer is not null)
            return;

        var t = Assembly
            .GetExportedTypes()
            .First(p => p
                .GetInterfaces()
                .FirstOrDefault(i => i.Name.Equals(nameof(IApplicationAddInServer))) is not null);
        addInServer = Assembly.CreateInstance(t.FullName) as IApplicationAddInServer;
    }

    private bool firstTime = true;
    private Assembly Assembly { get; }
    private IApplicationAddInServer addInServer;
    private IApplicationAddInSite addInSite;
    public string DisplayName { get; set; }
    public string ShortDisplayName { get; set; }
    public string Description { get; set; }
    public bool StartUpEnabled { get; set; }
    public int Version { get; set; }
    public bool Hidden { get; set; }
    public bool UserUnloadable { get; set; }
    public ApplicationAddInTypeEnum AddInType { get; set; }
    public bool Activated { get; set; }
    public object Automation { get; set; }
    public int DataVersion { get; set; }
    public string ClientId { get; set; }
    public string Location { get; set; }
    public int UserInterfaceVersion { get; set; }
    public AddInLoadBehaviorEnum LoadBehavior { get; set; } = AddInLoadBehaviorEnum.kLoadImmediately;
    public bool LoadAutomatically { get; set; }
    public void Activate()
    {
        InstantiateAddinServer();
        CreateSite();
        addInServer.Activate(addInSite,firstTime);
        firstTime = false;
    }

    public void Deactivate()
    {
        addInServer.Deactivate();
    }

    public void CreateSite()
    {
        if (addInSite is not null)
            return;
        addInSite = new ApplicationAddinSite(this);
    }
}