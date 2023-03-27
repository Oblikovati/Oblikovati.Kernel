using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class NavigatePane
{
    [DataMember(Name = "data")]
    public NavigatePaneData Data { get; set; }
}