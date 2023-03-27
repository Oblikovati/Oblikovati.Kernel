using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class LoadStepData
{
    [DataMember(Name = "propVal")]
    public string DataPath { get; set; }

    [DataMember(Name = "isImport")]
    public bool IsImport { get; set; }
}