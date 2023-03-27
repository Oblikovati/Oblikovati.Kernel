using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class NavigateDialog
{
    [DataMember(Name = "data")]
    public NavigateDialogData Data { get; set; }
}