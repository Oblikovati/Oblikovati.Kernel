using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class GenericData : PacketBase
{
    [DataMember(Name = "data")]
    public StringData Data { get; set; }
}