using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class LoadStep
{
    [DataMember(Name = "data")]
    public LoadStepData Data { get; set; }
}