using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Utility;

public class Camera : ICamera
{
    public Camera(object parent)
    {
        
        ViewOrientationType = ViewOrientationTypeEnum.kDefaultViewOrientation;
    }
    
    public ViewOrientationTypeEnum ViewOrientationType { get; set; }
    public IMatrix WorldToView { get; set; }
    public IMatrix ViewToWorld { get; set; }
    public IPoint Eye { get; set; }
    public IPoint Target { get; set; }
    public IUnitVector UpVector { get; set; }
    public bool Perspective { get; set; }
    public double PerspectiveAngle { get; set; }
    public object SceneObject { get; set; }
    public IMatrix ModelToViewTransformation { get; set; }
    public bool Animating { get; set; }
    public bool DumpingNodeCount { get; set; }
    public void Fit()
    {
        throw new NotImplementedException();
    }

    public void Apply()
    {
        throw new NotImplementedException();
    }

    public void ApplyWithoutTransition()
    {
        throw new NotImplementedException();
    }

    public void SetExtents(double Width, double Height)
    {
        throw new NotImplementedException();
    }

    public void GetExtents(out double Width, out double Height)
    {
        throw new NotImplementedException();
    }

    public void ComputeWithMouseInput(IPoint2d FromPoint, IPoint2d ToPoint, int WheelDelta, ViewOperationTypeEnum ViewOperation)
    {
        throw new NotImplementedException();
    }

    public IPoint2d ModelToViewSpace(IPoint ModelCoordinate)
    {
        throw new NotImplementedException();
    }

    public IPoint ViewToModelSpace(IPoint2d ViewCoordinate)
    {
        throw new NotImplementedException();
    }

    public void SaveAsBitmap(string FullFileName, int Width, int Height, object topColor, object bottomColor)
    {
        throw new NotImplementedException();
    }
}