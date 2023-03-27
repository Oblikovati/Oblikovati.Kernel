using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class ProdInfoPropValData : PropValData
{
    [DataMember(Name = "product")]
    public string Product { get; set; }

    [DataMember(Name = "language")]
    public string Language { get; set; }

    [DataMember(Name = "version")]
    public string Version { get; set; }
}