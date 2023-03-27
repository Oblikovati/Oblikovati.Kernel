using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Transient;

public class TransientGeometry : ITransientGeometry
{
    public double PointTolerance { get; }
    public IArc2d CreateArc2d(IPoint2d Center, double Radius, double StartAngle, double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IArc2d CreateArc2dByThreePoints(IPoint2d PointOne, IPoint2d PointTwo, IPoint2d PointThree)
    {
        throw new NotImplementedException();
    }

    public IArc3d CreateArc3d(IPoint Center, IUnitVector Normal, IUnitVector ReferenceVector, double Radius, double StartAngle,
        double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IArc3d CreateArc3dByThreePoints(IPoint PointOne, IPoint PointTwo, IPoint PointThree)
    {
        throw new NotImplementedException();
    }

    public IEllipseFull CreateEllipseFull(IPoint Center, IUnitVector Normal, IVector MajorAxisVector, double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public IEllipticalArc CreateEllipticalArc(IPoint Center, IUnitVector MajorAxis, IUnitVector MinorAxis, double MajorRadius,
        double MinorRadius, double StartAngle, double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IEllipticalArc2d CreateEllipticalArc2d(IPoint2d Center, IUnitVector2d MajorAxis, double MajorRadius, double MinorRadius,
        double StartAngle, double SweepAngle)
    {
        throw new NotImplementedException();
    }

    public IEllipseFull2d CreateEllipseFull2d(IPoint2d Center, IVector2d MajorAxisVector, double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public ILineSegment CreateLineSegment(IPoint StartPoint, IPoint EndPoint)
    {
        throw new NotImplementedException();
    }

    public ILineSegment2d CreateLineSegment2d(IPoint2d StartPoint, IPoint2d EndPoint)
    {
        throw new NotImplementedException();
    }

    public IMatrix CreateMatrix()
    {
        throw new NotImplementedException();
    }

    public IMatrix2d CreateMatrix2d()
    {
        throw new NotImplementedException();
    }

    public IBox CreateBox()
    {
        throw new NotImplementedException();
    }

    public IBox2d CreateBox2d()
    {
        throw new NotImplementedException();
    }

    public IPoint CreatePoint(double XCoord, double YCoord, double ZCoord)
    {
        throw new NotImplementedException();
    }

    public IPoint2d CreatePoint2d(double XCoord, double YCoord)
    {
        throw new NotImplementedException();
    }

    public IVector CreateVector(double XCoord, double YCoord, double ZCoord)
    {
        throw new NotImplementedException();
    }

    public IVector2d CreateVector2d(double XCoord, double YCoord)
    {
        throw new NotImplementedException();
    }

    public IUnitVector CreateUnitVector(double XCoord, double YCoord, double ZCoord)
    {
        throw new NotImplementedException();
    }

    public IUnitVector2d CreateUnitVector2d(double XCoord, double YCoord)
    {
        throw new NotImplementedException();
    }

    public ILine CreateLine(IPoint RootPoint, IVector Direction)
    {
        throw new NotImplementedException();
    }

    public ILine2d CreateLine2d(IPoint2d RootPoint, IUnitVector2d Direction)
    {
        throw new NotImplementedException();
    }

    public ICircle CreateCircle(IPoint Center, IUnitVector Normal, double Radius)
    {
        throw new NotImplementedException();
    }

    public ICircle CreateCircleByThreePoints(IPoint PointOne, IPoint PointTwo, IPoint PointThree)
    {
        throw new NotImplementedException();
    }

    public ICircle2d CreateCircle2d(IPoint2d Center, double Radius)
    {
        throw new NotImplementedException();
    }

    public ICircle2d CreateCircle2dByThreePoints(IPoint2d PointOne, IPoint2d PointTwo, IPoint2d PointThree)
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve CreateBSplineCurve(int Order, ref List<double> Poles, ref List<double> Knots, ref List<double> Weights, bool IsPeriodic)
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve2d CreateBSplineCurve2d(int Order, ref List<double> Poles, ref List<double> Knots, ref List<double> Weights, bool IsPeriodic)
    {
        throw new NotImplementedException();
    }

    public IPlane CreatePlane(IPoint RootPoint, IVector Normal)
    {
        throw new NotImplementedException();
    }

    public IPlane CreatePlaneByThreePoints(IPoint PointOne, IPoint PointTwo, IPoint PointThree)
    {
        throw new NotImplementedException();
    }

    public ICylinder CreateCylinder(IPoint RootPoint, IUnitVector Axis, double Radius)
    {
        throw new NotImplementedException();
    }

    public IEllipticalCylinder CreateEllipticalCylinder(IPoint BasePoint, IUnitVector AxisVector, IVector MajorAxisVector,
        double MinorMajorRatio)
    {
        throw new NotImplementedException();
    }

    public ICone CreateCone(IPoint RootPoint, IUnitVector Axis, double Radius, double HalfAngle, bool IsExpanding)
    {
        throw new NotImplementedException();
    }

    public IEllipticalCone CreateEllipticalCone(IPoint BasePoint, IUnitVector AxisVector, IVector MajorAxisVector,
        double MinorMajorRatio, double HalfAngle, bool IsExpanding)
    {
        throw new NotImplementedException();
    }

    public ISphere CreateSphere(IPoint CenterPoint, double Radius)
    {
        throw new NotImplementedException();
    }

    public ITorus CreateTorus(IPoint CenterPoint, IUnitVector AxisVector, double MajorRadius, double MinorRadius)
    {
        throw new NotImplementedException();
    }

    public IBSplineSurface CreateBSplineSurface(List<int> Order, List<double> Poles, List<double> KnotsU, List<double> KnotsV, List<double> Weights, List<bool> IsPeriodic)
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve2dDefinition CreateBSplineCurve2dDefinition()
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve2d CreateFittedBSplineCurve2d(IBSplineCurve2dDefinition Definition)
    {
        throw new NotImplementedException();
    }

    public IBSplineCurveDefinition CreateBSplineCurveDefinition()
    {
        throw new NotImplementedException();
    }

    public IBSplineCurve CreateFittedBSplineCurve(IBSplineCurveDefinition Definition)
    {
        throw new NotImplementedException();
    }

    public IPolyline3d CreatePolyline3d(object Points)
    {
        throw new NotImplementedException();
    }

    public IPolyline3d CreatePolyline3dFromCurve(object Curve, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IPolyline2d CreatePolyline2d(object Points)
    {
        throw new NotImplementedException();
    }

    public IPolyline2d CreatePolyline2dFromCurve(object Curve, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IObjectsEnumerator CurveCurveIntersection(object CurveOne, object CurveTwo, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IObjectsEnumerator CurveSurfaceIntersection(object Curve, object Surface, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IObjectsEnumerator SurfaceSurfaceIntersection(object SurfaceOne, object SurfaceTwo, double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IPoint GetFarmostPoint(object Entity, IUnitVector Direction)
    {
        throw new NotImplementedException();
    }

    public IOrientedBox CreateOrientedBox(object CornerPoint, object DirectionOne, object DirectionTwo, object DirectionThree)
    {
        throw new NotImplementedException();
    }
}