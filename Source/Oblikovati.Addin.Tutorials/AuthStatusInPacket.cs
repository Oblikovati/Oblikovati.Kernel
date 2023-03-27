using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class AuthStatusInPacket : PacketBase
{
    [DataMember(EmitDefaultValue = false, Name = "data")]
    public AuthStatusInData LwsData { get; set; }
}