using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class PacketBase
{
    [DataMember(EmitDefaultValue = false, Name = "event")]
    public string LwsEvent { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "version")]
    public int LwsVersion { get; set; }
}