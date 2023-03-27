using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class AnnounceData
{
    [DataMember(EmitDefaultValue = false, Name = "room")]
    public string Room { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "channels")]
    public string[] Channels { get; set; }
}