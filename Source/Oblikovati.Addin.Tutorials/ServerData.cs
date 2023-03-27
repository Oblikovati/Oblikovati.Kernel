namespace Oblikovati.Addin.Tutorials;

public class ServerData
{
    public const string SocketServerAddress = "ws://localhost:";
    public const string DefaultSocketServerPort = "44442";
    public const string ClientBaseAddress = "http://localhost";
    public const string ClientVersionBase = "/guided-tutorial-plugin/v3";
    public const string EngineAddressSuffix = "engine#/main/";
    public const string PlayAddressSuffix = "engine#/play/";
    public const string GalleryAddressSuffix = "gallery#/main/";
    public const string DefaultHttpServerPortNumber = "44441";
    public const string DocStorePath = "\\Oblikovati\\.desktop-connect\\.docstore\\";
    public const string PluginDir = "guided-tutorial-plugin";

    public static string LwsDocStorePath() => Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\Oblikovati\\.desktop-connect\\.docstore\\";

    public static string PluginDocStorePath() => ServerData.LwsDocStorePath() + "guided-tutorial-plugin";

    public static string ServerPortConfigFile() => ServerData.LwsDocStorePath() + "ports.json";
}