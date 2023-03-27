using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class BrowserFolder : IBrowserFolder
{
    public BrowserFolder(IApplicationBase application, object parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplicationBase Application { get; set; }
    public object Parent { get; set; }
    public IBrowserNode BrowserNode { get; set; }
    public string Name { get; set; }
    public bool AllowAddRemove { get; set; }
    public bool AllowDelete { get; set; }
    public bool AllowRename { get; set; }
    public bool AllowReorder { get; set; }
    public void Add(IBrowserNode BrowserNode, object TargetNode, bool Before)
    {
        throw new NotImplementedException();
    }

    public void Delete(bool Reserved)
    {
        throw new NotImplementedException();
    }

    public void Remove(IBrowserNode BrowserNode, object TargetNode, bool Before)
    {
        throw new NotImplementedException();
    }

    public void SetEndOfPart(bool Before)
    {
        throw new NotImplementedException();
    }
}