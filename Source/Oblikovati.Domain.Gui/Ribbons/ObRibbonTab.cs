using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Ribbons;

public class ObRibbonTab : RibbonTab , IRibbonTab
{
    public ObRibbonTab(IApplication application)
    {
        Application = application;
        RibbonPanels = new RibbonPanels(Application, this);
    }
    public IRibbon Parent { get; set; }
    public IApplication Application { get; set; }
    public string DisplayName { get => this.Text; set => Text = value; }
    public string InternalName { get; set; }
    public IRibbonPanels RibbonPanels { get; set; }
    public string ClientId { get; set; }
    public string KeyTip { get; set; }
    public void Delete()
    {
        throw new NotImplementedException();
    }
}