using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class PropValData : TargetBase
{
    [DataMember(Name = "propVal")]
    public string Value { get; set; }
}