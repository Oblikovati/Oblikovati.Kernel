using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class StringData
{
    [DataMember(Name = "data")]
    public string Data { get; set; }
}