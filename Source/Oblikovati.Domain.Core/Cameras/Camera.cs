using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Cameras;

public class Camera : ICamera
{
    public Camera(object parent)
    {
        
    }
    private object _parent;
    private ViewOrientationTypeEnum _viewOrientationType;
    private IMatrix _worldToView;
    private IMatrix _viewToWorld;
    private IPoint _eye;
    private IPoint _target;
    private IUnitVector _upVector;
    private bool _perspective;
    private double _perspectiveAngle;
    private object _sceneObject;
    private IMatrix _modelToViewTransformation;
    private bool _animating;
    private bool _dumpingNodeCount;

    public object Parent
    {
        get => _parent;
        set => _parent = value;
    }

    public ViewOrientationTypeEnum ViewOrientationType
    {
        get => _viewOrientationType;
        set => _viewOrientationType = value;
    }

    public IMatrix WorldToView
    {
        get => _worldToView;
        set => _worldToView = value;
    }

    public IMatrix ViewToWorld
    {
        get => _viewToWorld;
        set => _viewToWorld = value;
    }

    public IPoint Eye
    {
        get => _eye;
        set => _eye = value;
    }

    public IPoint Target
    {
        get => _target;
        set => _target = value;
    }

    public IUnitVector UpVector
    {
        get => _upVector;
        set => _upVector = value;
    }

    public bool Perspective
    {
        get => _perspective;
        set => _perspective = value;
    }

    public double PerspectiveAngle
    {
        get => _perspectiveAngle;
        set => _perspectiveAngle = value;
    }

    public object SceneObject
    {
        get => _sceneObject;
        set => _sceneObject = value;
    }

    public IMatrix ModelToViewTransformation
    {
        get => _modelToViewTransformation;
        set => _modelToViewTransformation = value;
    }

    public bool Animating
    {
        set => _animating = value;
    }

    public bool DumpingNodeCount
    {
        set => _dumpingNodeCount = value;
    }

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