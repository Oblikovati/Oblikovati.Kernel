using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class LwsPortsConfig
{
    [DataMember(Name = "http")]
    public string HttpPort { get; set; }

    [DataMember(Name = "socket")]
    public string SocketPort { get; set; }
    [DataMember(Name = "serverRootPath")]
    public string ServerPath { get; set; }
}