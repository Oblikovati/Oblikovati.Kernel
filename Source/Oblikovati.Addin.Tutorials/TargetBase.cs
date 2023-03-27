using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class TargetBase
{
    [DataMember(EmitDefaultValue = false, Name = "target")]
    public string Target { get; set; }
}