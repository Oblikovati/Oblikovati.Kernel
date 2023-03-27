using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class ActiveDoc : PacketBase
{
    [DataMember(Name = "data")]
    public StringData Data { get; set; }
}