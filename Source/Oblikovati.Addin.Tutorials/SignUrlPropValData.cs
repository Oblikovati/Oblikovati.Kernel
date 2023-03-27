using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class SignUrlPropValData : PropValData
{
    [DataMember(Name = "url")]
    public string Url { get; set; }

    [DataMember(Name = "id")]
    public string Id { get; set; }
}