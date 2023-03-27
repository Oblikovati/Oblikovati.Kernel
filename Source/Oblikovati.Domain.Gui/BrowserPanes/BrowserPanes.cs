using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class BrowserPanes : List<IBrowserPane>, IBrowserPanes
{
    public IApplicationBase Application { get; set; }
    public IBrowserPane ActivePane { get; set; }
    public IClientNodeResources ClientNodeResources { get; set; }
    public IBrowserPanesEvents BrowserPanesEvents { get; set; }
    public IBrowserPane Add(string Name, string InternalName)
    {
        throw new NotImplementedException();
    }

    public IBrowserPane AddTreeBrowserPane(string Name, string InternalName, IBrowserNodeDefinition TopNodeDefinition)
    {
        throw new NotImplementedException();
    }

    public IClientBrowserNodeDefinition CreateBrowserNodeDefinition(string Label, int Id, IClientNodeResource Icon,
        object ToolTipText, object ExpandedIcon, object DisplayState, object StateIconToolTipText)
    {
        throw new NotImplementedException();
    }

    public IBrowserPane AddTransientTreeBrowserPane(string Name, string InternalName, IBrowserNodeDefinition TopNodeDefinition)
    {
        throw new NotImplementedException();
    }

    public INativeBrowserNodeDefinition GetNativeBrowserNodeDefinition(object NativeObject)
    {
        throw new NotImplementedException();
    }

    public IClientBrowserNodeDefinition GetClientBrowserNodeDefinition(string ClientId, int Id)
    {
        throw new NotImplementedException();
    }

    public IBrowserPane AddByManifest(string Name, string InternalName, string ManifestFileName)
    {
        throw new NotImplementedException();
    }

    public INativeBrowserNodeDefinition GetNativeBrowserNodeDefinitionWithOptions(object NativeObject, object Options)
    {
        throw new NotImplementedException();
    }
}