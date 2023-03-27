using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class NavigatePaneData
{
    [DataMember(Name = "source")]
    public string Source { get; set; }

    [DataMember(Name = "dest")]
    public string DestUrl { get; set; }
}