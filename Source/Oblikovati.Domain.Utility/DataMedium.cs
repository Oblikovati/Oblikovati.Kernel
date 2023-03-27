using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Utility;

public class DataMedium : IDataMedium
{
    public string FileName { get; set; }
    public object Stream { get; set; }
    public object IDataObject { get; set; }
    public string String { get; set; }
    public MediumTypeEnum MediumType { get; set; }
}