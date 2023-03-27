using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class ResizeDialog
{
    [DataMember(Name = "data")]
    public ResizeDialogData Data { get; set; }
}