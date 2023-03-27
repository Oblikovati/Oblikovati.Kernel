using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class NavigateDialogData
{
    [DataMember(Name = "source")]
    public string Source { get; set; }

    [DataMember(Name = "dest")]
    public string DestUrl { get; set; }

    [DataMember(Name = "top")]
    public int Top { get; set; }

    [DataMember(Name = "left")]
    public int Left { get; set; }

    [DataMember(Name = "width")]
    public int Width { get; set; }

    [DataMember(Name = "height")]
    public int Height { get; set; }
}