using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Ribbons;

public class RibbonPanels : List<IRibbonPanel>, IRibbonPanels
{
    public RibbonPanels(IApplication application, IRibbonTab parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplication Application { get; set; }
    public IRibbonTab Parent { get; set; }

    public IRibbonPanel this[string index] => Find(p => p.InternalName.Equals(index));

    public IRibbonPanel Add(string DisplayName, string InternalName, string ClientId = null, string TargetPanelInternalName = null,
        bool InsertBeforeTargetPanel = false)
    {
        var rp = new ObRibbonPanel(Application,Parent);
        rp.DisplayName = DisplayName;
        rp.InternalName = InternalName;
        rp.ClientId = ClientId;
        if (InsertBeforeTargetPanel)
            Insert(IndexOf(this[TargetPanelInternalName]), rp);
        else
            Add(rp);
        var t = Parent as ObRibbonTab;
        t.Panels.Add(rp);
        return rp;
    }
}