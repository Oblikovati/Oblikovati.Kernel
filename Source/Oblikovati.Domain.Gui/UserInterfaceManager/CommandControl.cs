using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.UserInterfaceManager;

public class CommandControl : ICommandControl
{
    public CommandControl(IApplication application, string displayName, string internalName)
    {
        Application = application;
        DisplayName = displayName;
        InternalName = internalName;
    }
    public IApplication Application { get; set; }
    public object Parent { get; set; }
    public string DisplayName { get; set; }
    public string InternalName { get; set; }
    public ICommandControls ChildControls { get; set; }
    public IControlDefinition ControlDefinition { get; set; }
    public ControlTypeEnum ControlType { get; set; }
    public IControlDefinition DisplayedControl { get; set; }
    public bool ShowText { get; set; }
    public bool UseLargeIcon { get; set; }
    public bool Visible { get; set; }
    public string KeyTip { get; set; }
    public void Delete()
    {
        throw new NotImplementedException();
    }
}