using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class ClientNodeResources : List<IClientNodeResource>, IClientNodeResources
{
    public ClientNodeResources(IApplicationBase application)
    {
        Application = application;
    }
    public IApplicationBase Application { get; set; }
    public IClientNodeResource ItemById(string ClientId, int Id)
    {
        throw new NotImplementedException();
    }

    public IClientNodeResource AddNodeResource(string ClientId, int Id, string IconName)
    {
        throw new NotImplementedException();
    }
}