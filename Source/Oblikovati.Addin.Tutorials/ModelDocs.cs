using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class ModelDocs : PacketBase
{
    [DataMember(Name = "data")]
    public ModelDocsData Data { get; set; }
}