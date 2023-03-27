using Oblikovati.Domain.Core;
using Oblikovati.Domain.Gui.UserInterfaceManager;

namespace Oblikovati.Domain.Gui.Ribbons;

public class ObRibbonPanel : RibbonPanel , IRibbonPanel
{
    public ObRibbonPanel(IApplication application, IRibbonTab parent)
    {
        Application = application;
        Parent = parent;
        CommandControls = new CommandControls(Application,this);
        SlideoutControls = new CommandControls(Application,this);
    }
    public IRibbonTab Parent { get; set; }
    public IApplication Application { get; set; }
    public string DisplayName { get => Text; set => Text = value; }
    public string InternalName { get; set; }
    public ICommandControls CommandControls { get; } 
    public string ClientId { get; set; }
    public bool Docked { get; set; }
    public ICommandControls SlideoutControls { get; }
    public string SlideOutKeyTip { get; set; }
    public void Delete()
    {
        Parent.RibbonPanels.Remove(this);
    }

    public void Reposition(string TargetPanelInternalName, bool InsertBeforeTargetPanel)
    {
        throw new NotImplementedException();
    }

    public void Move(int Top, int Left)
    {
        throw new NotImplementedException();
    }

    public void RefreshControls()
    {
        this.Items.Add(new RibbonButton("Button"));
        //Items.Add(new RibbonDescriptionMenuItem("Text","Description"));
        Items.Add(new RibbonButtonList(new List<RibbonButton>(){new RibbonButton("Test")}));
    }
}