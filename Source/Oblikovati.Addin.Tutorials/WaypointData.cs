using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class WaypointData
{
    [DataMember(Name = "waypoint")]
    public string Waypoint { get; set; }

    [DataMember(Name = "substate")]
    public string SubState { get; set; }

    [DataMember(Name = "attributes")]
    public Dictionary<string, string> Attributes { get; set; }
}