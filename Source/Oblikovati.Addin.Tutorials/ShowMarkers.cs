using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class ShowMarkers
{
    [DataMember(Name = "data")]
    public List<MarkerData> Data { get; set; }
}