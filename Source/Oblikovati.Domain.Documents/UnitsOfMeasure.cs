using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Documents;

public class UnitsOfMeasure : IUnitsOfMeasure
{
    public UnitsOfMeasure(object parent)
    {
        
    }
    
    public UnitsTypeEnum LengthUnits { get; set; }
    public UnitsTypeEnum AngleUnits { get; set; }
    public UnitsTypeEnum MassUnits { get; set; }
    public UnitsTypeEnum TimeUnits { get; set; }
    public int LengthDisplayPrecision { get; set; }
    public int AngleDisplayPrecision { get; set; }
    public double _GetValueFromExpression(string Expression, object UnitsSpecifier)
    {
        throw new NotImplementedException();
    }

    public object GetValueFromExpression(string Expression, object UnitsSpecifier)
    {
        throw new NotImplementedException();
    }

    public string GetStringFromValue(double Value, object UnitsSpecifier)
    {
        throw new NotImplementedException();
    }

    public string GetStringFromType(UnitsTypeEnum UnitsType)
    {
        throw new NotImplementedException();
    }

    public bool CompatibleUnits(string Expression1, object UnitsSpecifier1, string Expression2, object UnitsSpecifier2)
    {
        throw new NotImplementedException();
    }

    public double ConvertUnits(double Value, object InputUnitsSpecifier, object OutputUnitsSpecifier)
    {
        throw new NotImplementedException();
    }

    public string GetLocaleCorrectedExpression(string Expression, object UnitsSpecifier)
    {
        throw new NotImplementedException();
    }

    public IParametersEnumerator GetDrivingParameters(string Expression)
    {
        throw new NotImplementedException();
    }

    public string GetDatabaseUnitsFromExpression(string Expression, object UnitsSpecifier)
    {
        throw new NotImplementedException();
    }

    public string GetPreciseStringFromValue(double Value, object UnitsSpecifier)
    {
        throw new NotImplementedException();
    }

    public bool IsExpressionValid(string Expression, object UnitsSpecifier)
    {
        throw new NotImplementedException();
    }
}