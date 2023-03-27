using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application;

public class MeasureTools : IMeasureTools
{
    public MeasureTools()
    {
        
        
    }
    
    

    public double GetMinimumDistance(object EntityOne, object EntityTwo, InferredTypeEnum EntityOneInferredType,
        InferredTypeEnum EntityTwoInferredType, ref object Context)
    {
        throw new NotImplementedException();
    }

    public double GetAngle(object EntityOne, object EntityTwo, object EntityThree)
    {
        throw new NotImplementedException();
    }

    public double GetLoopLength(object Curves)
    {
        throw new NotImplementedException();
    }

    public int GetAnglePrecision(IDocument Document)
    {
        throw new NotImplementedException();
    }

    public int SetAnglePrecision(IDocument Document, int Precision)
    {
        throw new NotImplementedException();
    }

    public int GetLengthPrecision(IDocument Document)
    {
        throw new NotImplementedException();
    }

    public int SetLengthPrecision(IDocument Document, int Precision)
    {
        throw new NotImplementedException();
    }
}