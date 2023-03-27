using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class AuthStatusOutData : DataBase
{
    [DataMember(EmitDefaultValue = true, Name = "status")]
    public bool Status { get; set; }
}