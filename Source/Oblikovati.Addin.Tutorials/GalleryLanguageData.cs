using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class GalleryLanguageData
{
    [DataMember(Name = "text")]
    public string Text { get; set; }

    [DataMember(Name = "val")]
    public string Val { get; set; }

    [DataMember(Name = "$$hashKey")]
    public string HashKey { get; set; }
}