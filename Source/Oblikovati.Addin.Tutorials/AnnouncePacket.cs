using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class AnnouncePacket : PacketBase
{
    [DataMember(EmitDefaultValue = false, Name = "data")]
    public AnnounceData LwsData { get; set; }
}