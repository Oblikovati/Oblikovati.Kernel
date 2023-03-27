using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class BrowserNodesEnumerator : List<IBrowserNode>, IBrowserNodesEnumerator
{
    public BrowserNodesEnumerator(IApplication application)
    {
        Application = application;
    }
    public IApplication Application { get; set; }
    public IBrowserNode ItemById(int Id)
    {
        throw new NotImplementedException();
    }
}