using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class SignUrlPropVal : PacketBase
{
    [DataMember(Name = "data")]
    public SignUrlPropValData Data { get; set; }
}