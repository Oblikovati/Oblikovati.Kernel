using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class ProdInfoPropVal : PacketBase
{
    [DataMember(Name = "data")]
    public ProdInfoPropValData Data { get; set; }
}