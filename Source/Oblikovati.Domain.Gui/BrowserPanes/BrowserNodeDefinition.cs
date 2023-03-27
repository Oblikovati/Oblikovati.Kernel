using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public abstract class BrowserNodeDefinition : IBrowserNodeDefinition
{
    public IApplicationBase Application { get; set; }
    public IDocument Parent { get; set; }
    public bool BuiltIn { get; set; }
    public string Label { get; set; }
    public string StateIconToolTipText { get; set; }
    public string ToolTipText { get; set; }
    public bool Transient { get; set; }
    public string DebugInfo { get; set; }
    public BrowserNodeDisplayStateEnum DisplayState { get; set; }
    public BrowserNodeDisplayStateEnum AdditionalDisplayState { get; set; }
    public string AdditionalStateIconToolTipText { get; set; }
    public bool Visible { get; set; }
}