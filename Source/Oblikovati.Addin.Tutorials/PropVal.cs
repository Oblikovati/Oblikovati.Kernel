using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class PropVal : PacketBase
{
    [DataMember(Name = "data")]
    public PropValData Data { get; set; }
}