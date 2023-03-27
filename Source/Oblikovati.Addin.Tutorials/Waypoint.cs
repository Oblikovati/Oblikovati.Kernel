using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class Waypoint : PacketBase
{
    [DataMember(Name = "data")]
    public WaypointData Data { get; set; }
}