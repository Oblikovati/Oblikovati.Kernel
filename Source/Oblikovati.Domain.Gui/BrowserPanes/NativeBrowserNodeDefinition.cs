using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class NativeBrowserNodeDefinition : BrowserNodeDefinition, INativeBrowserNodeDefinition
{
    public IClientNodeResource OverrideIcon { get; set; }
    public object NativeObject { get; set; }
    public IClientNodeResource OverrideExpandedIcon { get; set; }
    public IClientNodeResource OverrideStateIcon { get; set; }
    public bool LabelModified { get; set; }
    public void add_OnLabelEdit(BrowserNodeDefinitionSink_OnLabelEditEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnLabelEdit(BrowserNodeDefinitionSink_OnLabelEditEventHandler handler)
    {
        throw new NotImplementedException();
    }
}