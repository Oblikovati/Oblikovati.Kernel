using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Math;

namespace Oblikovati.Domain.Geometry;

public class TransientGeometry : ITransientGeometry
{
    public double PointTolerance { get; set; }
    public IArc2d CreateArc2d(IPoint2d Center, double Radius, double StartAngle, double SweepAngle)
    {
        return new Arc2d()
        {
            Center = Center,
            Radius = Radius,
            StartAngle = StartAngle,
            SweepAngle = SweepAngle
        };
    }

    public IArc2d CreateArc2dByThreePoints(IPoint2d PointOne, IPoint2d PointTwo, IPoint2d PointThree)
    {
        throw new NotImplementedException();
    }

    public IArc3d CreateArc3d(IPoint Center, IUnitVector Normal, IUnitVector ReferenceVector, double Radius, double StartAngle,
        double SweepAngle)
    {
        return new Arc3d()
        {
            Center = Center,
            Normal = Normal,
            ReferenceVector = ReferenceVector,
            Radius = Radius,
            StartAngle = StartAngle,
            SweepAngle = SweepAngle
        };
    }

    public IArc3d CreateArc3dByThreePoints(IPoint PointOne, IPoint PointTwo, IPoint PointThree)
    {
        throw new NotImplementedException();
    }

    public IEllipseFull CreateEllipseFull(IPoint Center, IUnitVector Normal, IVector MajorAxisVector, double MinorMajorRatio)
    {
        return new EllipseFull()
        {
            Center = Center,
            Normal = Normal,
            MajorAxisVector = MajorAxisVector,
            MinorMajorRatio = MinorMajorRatio
        };
    }

    public IEllipticalArc CreateEllipticalArc(IPoint Center, IUnitVector MajorAxis, IUnitVector MinorAxis, double MajorRadius,
        double MinorRadius, double StartAngle, double SweepAngle)
    {
        return new EllipticalArc()
        {
            Center = Center,
            MajorAxis = MajorAxis,
            MinorAxis = MinorAxis,
            MajorRadius = MajorRadius,
            MinorRadius = MinorRadius,
            StartAngle = StartAngle,
            SweepAngle = SweepAngle
        };
    }

    public IEllipticalArc2d CreateEllipticalArc2d(IPoint2d Center, IUnitVector2d MajorAxis, double MajorRadius, double MinorRadius,
        double StartAngle, double SweepAngle)
    {
        return new EllipticalArc2d()
        {
            Center = Center,
            MajorAxis = MajorAxis,
            MajorRadius = MajorRadius,
            MinorRadius = MinorRadius,
            StartAngle = StartAngle,
            SweepAngle = SweepAngle
        };
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
        return new Point()
        {
            X = XCoord,
            Y = YCoord,
            Z = ZCoord
        };
    }

    public IPoint2d CreatePoint2d(double XCoord, double YCoord)
    {
        return new Point2d()
        {
            X = XCoord,
            Y = YCoord
        };
    }

    public IVector CreateVector(double XCoord, double YCoord, double ZCoord)
    {
        return new Vector()
        {
            X = XCoord,
            Z = YCoord,
            Y = YCoord,
            Length = 0
        };
    }

    public IVector2d CreateVector2d(double XCoord, double YCoord)
    {
        return new Vector2d()
        {
            Length = 0,
            X = XCoord,
            Y = YCoord
        };
    }

    public IUnitVector CreateUnitVector(double XCoord, double YCoord, double ZCoord)
    {
        return new UnitVector()
        {
            X = XCoord,
            Z = YCoord,
            Y = YCoord
        };
    }

    public IUnitVector2d CreateUnitVector2d(double XCoord, double YCoord)
    {
        return new UnitVector2d()
        {
            X = XCoord,
            Y = YCoord
        };
    }

    public ILine CreateLine(IPoint RootPoint, IVector Direction)
    {
        return new Line()
        {
            Direction = Direction.AsUnitVector(),
            RootPoint = RootPoint
        };
    }

    public ILine2d CreateLine2d(IPoint2d RootPoint, IUnitVector2d Direction)
    {
        return new Line2d()
        {
            Direction = Direction,
            RootPoint = RootPoint
        };
    }

    public ICircle CreateCircle(IPoint Center, IUnitVector Normal, double Radius)
    {
        return new Circle()
        {
            Center = Center,
            Radius = Radius,
            Normal = Normal
        };
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