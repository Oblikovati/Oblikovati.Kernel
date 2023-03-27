using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Views;

public class ViewTabsEnumerator : List<IViewTab>, IViewTabsEnumerator
{
    public ViewTabsEnumerator(IApplicationBase application)
    {
        Application = application;
    }
    public IApplicationBase Application { get; set; }
}