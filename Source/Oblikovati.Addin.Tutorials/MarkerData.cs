using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class MarkerData
{
    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "val")]
    public string Value { get; set; }
}