using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class iLogicOptions : IiLogicOptions
{
    public iLogicOptions()
    {

    }

    public object ExternalRuleDirectories { get; set; }
    public object ExternalRuleFileNames { get; set; }
    public string ExternalRuleDefaultExtension { get; set; }
    public string CustomAddInDirectory { get; set; }
    public iLogicEventTriggersFilterEnum EventTriggersFilter { get; set; }
    public bool EnableRuleSecurityInspection { get; set; }
    public iLogicExcelEngineTypeEnum ExcelEngineType { get; set; }
}