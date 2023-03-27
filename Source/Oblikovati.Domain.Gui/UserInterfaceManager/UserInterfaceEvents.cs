using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.UserInterfaceManager;

public class UserInterfaceEvents : IUserInterfaceEvents
{
    public UserInterfaceEvents(IApplication application,IUserInterfaceManager parent)
    {
        Parent = parent;
        Application = application;
    }
    public IUserInterfaceManager Parent { get; set; }
    public IApplication Application { get; set; }
    public void add_OnResetEnvironments(UserInterfaceEventsSink_OnResetEnvironmentsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnResetEnvironments(UserInterfaceEventsSink_OnResetEnvironmentsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnResetCommandBars(UserInterfaceEventsSink_OnResetCommandBarsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnResetCommandBars(UserInterfaceEventsSink_OnResetCommandBarsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnEnvironmentChange(UserInterfaceEventsSink_OnEnvironmentChangeEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnEnvironmentChange(UserInterfaceEventsSink_OnEnvironmentChangeEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnResetShortcuts(UserInterfaceEventsSink_OnResetShortcutsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnResetShortcuts(UserInterfaceEventsSink_OnResetShortcutsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnResetRibbonInterface(UserInterfaceEventsSink_OnResetRibbonInterfaceEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnResetRibbonInterface(UserInterfaceEventsSink_OnResetRibbonInterfaceEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnResetMarkingMenu(UserInterfaceEventsSink_OnResetMarkingMenuEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnResetMarkingMenu(UserInterfaceEventsSink_OnResetMarkingMenuEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnResetOblikovatiLayout(UserInterfaceEventsSink_OnResetOblikovatiLayoutEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnResetOblikovatiLayout(UserInterfaceEventsSink_OnResetOblikovatiLayoutEventHandler handler)
    {
        throw new NotImplementedException();
    }
}