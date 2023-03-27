using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Views;

public class ViewTab : ViewTabControl, IViewTab
{
    public ViewTab(IApplicationBase application)
    {
        Application = application;
        viewTabControlCloseButton.Click += ViewTabControlCloseButton_Click;
    }

    private void ViewTabControlCloseButton_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private IView view;
    private IWebView webView;

    public IApplicationBase Application { get; set; }

    public object View
    {
        get
        {
            if (view is object)
                return view;
            if (webView is object)
                return webView;
            return null;
        }
        set
        {
            if (value is IView v)
            {
                view = v;
                viewTabControlLabel.Text = view.Document.DisplayName;
            }
            else if (value is IWebView wv)
            {
                webView = wv;
                viewTabControlLabel.Text = webView.Caption;
            }
            else
                throw new ArgumentException("Only IView and IWebView objects are supported");

        }
    }

    public IViewFrame ViewFrame { get; set; }
    public IViewTabGroup ViewTabGroup { get; set; }
    public void Close()
    {
        
    }

    public IViewTabGroup MoveToGroup(bool CreateNewGroup, IViewTab TargetViewTab, DockingStateEnum DockingState,
        object AdditionalViewTabs)
    {
        throw new NotImplementedException();
    }

    public IViewFrame MoveToNewViewFrame(object ViewFrameWidth, object ViewFrameHeight, object ViewFrameLeft, object ViewFrameTop,
        object AdditionalViewTabs)
    {
        throw new NotImplementedException();
    }
}