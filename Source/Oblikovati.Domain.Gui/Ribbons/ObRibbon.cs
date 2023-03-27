using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Ribbons;

public class ObRibbon : Ribbon , IRibbon
{
    protected ObRibbon(){ }
    public ObRibbon(IUserInterfaceManager parent, IApplication application, string internalName)
    {
        Parent = parent;
        Application = application;
        InternalName = internalName;
        RibbonTabs = new RibbonTabs(Application,this);
        ThemeColor = RibbonTheme.VSDark;
    }
    public IUserInterfaceManager Parent { get; set; }
    public IApplication Application { get; set; }
    public string InternalName { get; set; }
    public IRibbonTabs RibbonTabs { get; set; }
    public bool Active { get; set; }
    public ICommandControls QuickAccessControls { get; set; }
}