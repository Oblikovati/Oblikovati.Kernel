using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.MiniToolbar;

public class MiniToolbar : IMiniToolbar
{
    public object Parent { get; set; }
    public IApplication Application { get; set; }
    public IPoint2d Position { get; set; }
    public bool ShowApply { get; set; }
    public bool ShowCancel { get; set; }
    public bool ShowOK { get; set; }
    public bool Visible { get; set; }
    public bool EnableApply { get; set; }
    public bool EnableOK { get; set; }
    public IMiniToolbarControls Controls { get; set; }
    public bool ShowOptionBox { get; set; }
    public bool ShowHandle { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public bool IgnorePinnedPosition { get; set; }
    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void add_OnApply(MiniToolbarSink_OnApplyEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnApply(MiniToolbarSink_OnApplyEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnCancel(MiniToolbarSink_OnCancelEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnCancel(MiniToolbarSink_OnCancelEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnOK(MiniToolbarSink_OnOKEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnOK(MiniToolbarSink_OnOKEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnStartMove(MiniToolbarSink_OnStartMoveEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnStartMove(MiniToolbarSink_OnStartMoveEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnMove(MiniToolbarSink_OnMoveEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnMove(MiniToolbarSink_OnMoveEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnEndMove(MiniToolbarSink_OnEndMoveEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnEndMove(MiniToolbarSink_OnEndMoveEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnHide(MiniToolbarSink_OnHideEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnHide(MiniToolbarSink_OnHideEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnShow(MiniToolbarSink_OnShowEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnShow(MiniToolbarSink_OnShowEventHandler handler)
    {
        throw new NotImplementedException();
    }
}