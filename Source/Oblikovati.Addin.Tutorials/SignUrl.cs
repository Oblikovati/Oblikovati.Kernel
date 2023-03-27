using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class SignUrl
{
    [DataMember(Name = "data")]
    public SignUrlData Data { get; set; }
}