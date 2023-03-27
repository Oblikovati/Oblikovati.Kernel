using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class ClientNodeResource : IClientNodeResource
{
    public ClientNodeResource(IApplicationBase application, IDocument parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplicationBase Application { get; set; }
    public IDocument Parent { get; set; }
    public int Id { get; set; }
    public string ClientId { get; set; }
    public string IconName { get; set; }
    public string InvisibleIconName { get; set; }
    public string SuppressedIconName { get; set; }
    public string DisabledIconName { get; set; }
    public string ExpandedInvisibleIconName { get; set; }
    public string ExpandedSuppressedIconName { get; set; }
    public string ExpandedDisabledIconName { get; set; }
    public string GroundedIconName { get; set; }
    public string GroundedSuppressedIconName { get; set; }
    public string GroundedInvisibleIconName { get; set; }
    public string GroundedDisabledIconName { get; set; }
    public void Delete()
    {
        throw new NotImplementedException();
    }
}