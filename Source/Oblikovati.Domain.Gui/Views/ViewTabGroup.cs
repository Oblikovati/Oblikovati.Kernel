using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Views;

public class ViewTabGroup : List<IViewTab>, IViewTabGroup
{
    public ViewTabGroup(IApplicationBase application)
    {
        Application = application;
    }
    public IApplicationBase Application { get; set; }
    public IViewFrame ViewFrame { get; set; }
    public void Close()
    {
        throw new NotImplementedException();
    }

    public IViewTabGroup MoveToGroup(IViewTab TargetViewTab, DockingStateEnum DockingState)
    {
        throw new NotImplementedException();
    }

    public IViewFrame MoveToNewViewFrame(object ViewFrameWidth, object ViewFrameHeight, object ViewFrameLeft, object ViewFrameTop)
    {
        throw new NotImplementedException();
    }
}