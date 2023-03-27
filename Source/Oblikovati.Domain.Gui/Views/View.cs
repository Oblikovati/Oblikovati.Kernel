using Oblikovati.Domain.Core;
using Oblikovati.Domain.Core.Cameras;

namespace Oblikovati.Domain.Gui.Views;
/// <summary>
/// The View object represents a view in a document.
/// </summary>
public class View : ViewControl, IView
{
    public View()
    {
        
    }
    public View(IApplicationBase application)
    {
        Application = application;
        Camera = new Camera(this);
    }
    public View(IApplicationBase application, IDocument parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplicationBase Application { get; set; }
    public IDocument Parent { get; set; }
    public IDocument Document { get; set; }
    public ICamera Camera { get; set; }
    public string Caption { get; set; }
    public DisplayModeEnum DisplayMode { get; set; }
    public WindowsSizeEnum WindowState { get; set; }
    public GroundShadowEnum GroundShadow { get; set; }
    public bool ViewCubeEnabled { get; set; }
    public bool SteeringWheelEnabled { get; set; }
    public bool NavigationBarEnabled { get; set; }
    public bool ShowGroundPlane { get; set; }
    public bool ShowGroundReflections { get; set; }
    public bool ShowAmbientShadows { get; set; }
    public bool ShowGroundShadows { get; set; }
    public bool ShowObjectShadows { get; set; }
    public bool RayTracing { get; set; }
    public RayTracingQualityEnum RayTracingQuality { get; set; }
    public bool AreTexturesOn { get; set; }
    public bool IsRayTracingPaused { get; set; }
    public double RayTracingProgress { get; set; }
    public IViewFrame ViewFrame { get; set; }
    public IViewTab ViewTab { get; set; }
    public void Activate()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public void Fit(bool DoUpdate)
    {
        throw new NotImplementedException();
    }

    public void GetWindowExtents(out int Top, out int Left, out int Height, out int Width)
    {
        throw new NotImplementedException();
    }

    public void SaveAsBitmap(string FullFileName, int Width, int Height)
    {
        throw new NotImplementedException();
    }

    public void Move(int Top, int Left, int Height, int Width)
    {
        throw new NotImplementedException();
    }

    public void GoHome()
    {
        throw new NotImplementedException();
    }

    public void ResetFront()
    {
        throw new NotImplementedException();
    }

    public void SetCurrentAsFront()
    {
        throw new NotImplementedException();
    }

    public void SetCurrentAsTop()
    {
        throw new NotImplementedException();
    }

    public void SetCurrentAsHome(bool FitToView)
    {
        throw new NotImplementedException();
    }

    public void SaveAsBitmapWithRayTracing(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void SaveAsBitmapWithOptions(string FullFileName, int Width, int Height, INameValueMap Options)
    {
        throw new NotImplementedException();
    }
}