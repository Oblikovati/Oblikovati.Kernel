using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class BrowserNode : IBrowserNode
{
    public BrowserNode(IApplicationBase application, object parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplicationBase Application { get; set; }
    public object Parent { get; set; }
    public IBrowserNodeDefinition BrowserNodeDefinition { get; set; }
    public IBrowserNodesEnumerator BrowserNodes { get; set; }
    public bool Expanded { get; set; }
    public bool Selected { get; set; }
    public bool Visible { get; set; }
    public string FullPath { get; set; }
    public bool OverrideNativeGraying { get; set; }
    public object NativeObject { get; set; }
    public IBrowserFoldersEnumerator BrowserFolders { get; set; }
    public IBrowserNode AddChild(IBrowserNodeDefinition Definition)
    {
        throw new NotImplementedException();
    }

    public void EnsureVisible()
    {
        throw new NotImplementedException();
    }

    public void DoPreSelect()
    {
        throw new NotImplementedException();
    }

    public void DoSelect()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public IBrowserNodesEnumerator AllReferencedNodes(IBrowserNodeDefinition Definition)
    {
        throw new NotImplementedException();
    }

    public IBrowserNode InsertChild(IBrowserNodeDefinition Definition, IBrowserNode TargetNode, bool InsertBefore)
    {
        throw new NotImplementedException();
    }
}