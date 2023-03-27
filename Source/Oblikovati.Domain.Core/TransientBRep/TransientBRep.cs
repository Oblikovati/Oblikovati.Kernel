using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.TransientBRep;

public class TransientBRep : ITransientBRep
{
    public IApplicationUtilities ApplicationUtilities { get; set; }
    public ISurfaceBody CreateSilhouetteCurve(IFace Face, IUnitVector ViewDirection, bool ReturnCoincidentSilhouettes)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBody CreateSolidCylinderCone(IPoint BottomPoint, IPoint TopPoint, double BottomMajorRadius,
        double BottomMinorRadius, double TopMajorRadius, object MajorAxisPosition)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBody CreateSolidSphere(IPoint Center, double Radius)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBody CreateSolidTorus(IPoint Center, double MajorRadius, double MinorRadius)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBody CreateSolidBlock(IBox Box)
    {
        throw new NotImplementedException();
    }

    public void DoBoolean(ISurfaceBody BlankBody, ISurfaceBody ToolBody, BooleanTypeEnum BooleanType)
    {
        throw new NotImplementedException();
    }

    public void Transform(ISurfaceBody SurfaceBody, IMatrix Transform)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBody Copy(object Entity)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBody CreateIntersectionWithPlane(ISurfaceBody Body, IPlane Plane)
    {
        throw new NotImplementedException();
    }

    public void DeleteFaces(object Faces, bool DeleteSpecifiedFaces)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBodyDefinition CreateSurfaceBodyDefinition()
    {
        throw new NotImplementedException();
    }

    public ISurfaceBodies ReadFromFile(string FileName)
    {
        throw new NotImplementedException();
    }

    public ISurfaceBody CreateRuledSurface(IWire SectionOne, IWire SectionTwo)
    {
        throw new NotImplementedException();
    }

    public void WriteToFile(IObjectCollection Bodies, string FileName, string Format)
    {
        throw new NotImplementedException();
    }

    public void ImprintBodies(ISurfaceBody InputBodyOne, ISurfaceBody InputBodyTwo, bool ImprintCoincidentEdges,
        out ISurfaceBody OutputBodyOne, out ISurfaceBody OutputBodyTwo, out IFaces BodyOneOverlappingFaces,
        out IFaces BodyTwoOverlappingFaces, out IEdges BodyOneOverlappingEdges, out IEdges BodyTwoOverlappingEdges,
        double Tolerance)
    {
        throw new NotImplementedException();
    }

    public IObjectCollection GetIdenticalBodies(IObjectCollection InputSurfaceBodies, object Options)
    {
        throw new NotImplementedException();
    }
}