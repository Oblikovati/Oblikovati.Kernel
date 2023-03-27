using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class DataBase
{
    [DataMember(EmitDefaultValue = false, Name = "target")]
    public string Target { get; set; }
}