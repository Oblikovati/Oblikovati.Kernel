using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class ClientBrowserNodeDefinition : BrowserNodeDefinition, IClientBrowserNodeDefinition
{
    public int Id { get; set; }
    public IClientNodeResource Icon { get; set; }
    public IAttributeSets AttributeSets { get; set; }
    public IClientNodeResource ExpandedIcon { get; set; }
    public IClientNodeResource StateIcon { get; set; }
    public bool IsReferenced { get; set; }
    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void SetLabel(string Label)
    {
        throw new NotImplementedException();
    }

    public void GetReferenceKey(ref List<byte> ReferenceKey, int KeyContext)
    {
        throw new NotImplementedException();
    }

    public void add_OnActivate(ClientBrowserNodeDefinitionSink_OnActivateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnActivate(ClientBrowserNodeDefinitionSink_OnActivateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnGetDisplayObjects(ClientBrowserNodeDefinitionSink_OnGetDisplayObjectsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnGetDisplayObjects(ClientBrowserNodeDefinitionSink_OnGetDisplayObjectsEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnLabelEdit(ClientBrowserNodeDefinitionSink_OnLabelEditEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnLabelEdit(ClientBrowserNodeDefinitionSink_OnLabelEditEventHandler handler)
    {
        throw new NotImplementedException();
    }
}