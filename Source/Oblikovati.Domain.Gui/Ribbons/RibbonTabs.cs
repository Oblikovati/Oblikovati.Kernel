using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Ribbons;

public class RibbonTabs : List<IRibbonTab>, IRibbonTabs
{
    public RibbonTabs(IApplication application, IRibbon parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplication Application { get; set; }
    public IRibbon Parent { get;  }

    public IRibbonTab this[string index] => this.First(p => p.InternalName.Equals(index));

    public IRibbonTab Add(string DisplayName, string InternalName, string ClientId, string TargetTabInternalName,
        bool InsertBeforeTargetTab, bool Contextual)
    {
        var rt = new ObRibbonTab(Application);
        rt.DisplayName = DisplayName;
        rt.InternalName = InternalName;
        rt.ClientId = ClientId;
        
        if(InsertBeforeTargetTab)
            Insert(IndexOf(this[TargetTabInternalName]),rt);
        else
            Add(rt);
        var p = Parent as ObRibbon;
        p.Tabs.Add(rt);
        return rt;
    }
}