using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class WidenCreatorPlayerPane
{
    [DataMember(Name = "data")]
    public int Data { get; set; }
}