using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class ModelDocsData : PropValData
{
    [DataMember(Name = "dependencies")]
    public List<string> Dependencies { get; set; }
}