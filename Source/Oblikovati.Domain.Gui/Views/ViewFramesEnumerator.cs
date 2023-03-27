using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Views;

public class ViewFramesEnumerator : List<IViewFrame>, IViewFramesEnumerator
{
    public ViewFramesEnumerator(IApplication application)
    {
        Application = application;
    }

    public IApplication Application { get; }
}