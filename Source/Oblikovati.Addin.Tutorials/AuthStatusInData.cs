using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class AuthStatusInData : AuthStatusOutData
{
    [DataMember(EmitDefaultValue = false, Name = "accesstoken")]
    public string AccessToken { get; set; }

    [DataMember(EmitDefaultValue = true, Name = "env")]
    public int Env { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "username")]
    public string UserName { get; set; }
}