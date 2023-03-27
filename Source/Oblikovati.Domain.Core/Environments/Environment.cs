using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Environments;

public class Environment : IEnvironment
{
    public Environment()
    {
        
    }
    
    public string InternalName { get; set; }
    public string ClientId { get; set; }
    public string DisplayName { get; set; }
    public ICommandBar DefaultMenuBar { get; set; }
    public ICommandBar DefaultToolBar { get; set; }
    public bool BuiltIn { get; set; }
    public IDisabledCommandList DisabledCommandList { get; set; }
    public CommandTypesEnum DisabledCommandTypes { get; set; }
    public ICommandBarList ContextMenuList { get; set; }
    public IPanelBar PanelBar { get; set; }
    public List<string> AdditionalVisibleRibbonTabs { get; set; } = new();
    public string DefaultRibbonTab { get; set; }
    public bool InheritAllRibbonTabs { get; set; }
    public IRibbon Ribbon { get; set; }
    public IRadialMarkingMenus RadialMarkingMenus { get; set; }
    public object EnabledCommandList { get; set; }
    public string ExitDisplayName { get; set; }
    public bool PreserveWhenSwitchModelState { get; set; }
    public void Delete()
    {
        throw new NotImplementedException();
    }

    public IRadialMarkingMenu GetRadialMarkingMenu(object ObjectType)
    {
        throw new NotImplementedException();
    }
}