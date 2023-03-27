using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class BrowserFoldersEnumerator : List<IBrowserFolder> , IBrowserFoldersEnumerator
{
    public BrowserFoldersEnumerator(IApplication application)
    {
        Application = application;
    }
    public IApplication Application { get; set; }
}