using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class EventPacket
{
    [DataMember(EmitDefaultValue = false, Name = "event")]
    public string EventName { get; set; }

    [DataMember(EmitDefaultValue = false, Name = "data")]
    public string EventData { get; set; }
}