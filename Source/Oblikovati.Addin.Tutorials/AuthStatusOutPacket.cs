using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class AuthStatusOutPacket : PacketBase
{
    [DataMember(EmitDefaultValue = false, Name = "data")]
    public AuthStatusOutData LwsData { get; set; }
}