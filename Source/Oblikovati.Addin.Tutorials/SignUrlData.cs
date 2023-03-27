using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;
[DataContract]
public class SignUrlData
{
    [DataMember(Name = "url")]
    public string Url { get; set; }

    [DataMember(Name = "channel")]
    public string Channel { get; set; }

    [DataMember(Name = "id")]
    public string Id { get; set; }
}