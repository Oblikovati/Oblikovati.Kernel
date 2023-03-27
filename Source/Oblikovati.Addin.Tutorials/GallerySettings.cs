using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class GallerySettings : PacketBase
{
    [DataMember(Name = "data")]
    public GallerySettingsData Data { get; set; }
}