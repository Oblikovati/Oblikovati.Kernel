using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;

namespace Oblikovati.Domain.Core.Application;

public class CameraEvents : ICameraEvents
{
    public CameraEvents()
    {
        
        
    }
    
    
    public void add_OnCameraChange(CameraEventsSink_OnCameraChangeEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnCameraChange(CameraEventsSink_OnCameraChangeEventHandler handler)
    {
        throw new NotImplementedException();
    }
}