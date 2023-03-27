using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;

namespace Oblikovati.Domain.Core.Model;

public class PublicationEvents : IPublicationEvents
{
    public void add_OnModelingDataUpdate(PublicationEventsSink_OnModelingDataUpdateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnModelingDataUpdate(PublicationEventsSink_OnModelingDataUpdateEventHandler handler)
    {
        throw new NotImplementedException();
    }
}