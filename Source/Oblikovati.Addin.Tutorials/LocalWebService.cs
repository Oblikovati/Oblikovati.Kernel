using System.Diagnostics;
using System.Net.Sockets;

namespace Oblikovati.Addin.Tutorials;

public class LocalWebService
  {
    private static LocalWebService _instance;
    private Job _lwsJob;
    private static bool? _isInDevelopment = new bool?();
    private static bool? _isRunning = new bool?();
    private const string DefaultHttpPort = "44441";
    private const string DefaultSocketPort = "44442";
    public static string HttpPort = "44441";
    public static string SocketPort = "44442";
    private static bool _bInitializedLwsConfig;

    public static LocalWebService Instance()
    {
      if (LocalWebService._instance == null)
        LocalWebService._instance = new LocalWebService();
      return LocalWebService._instance;
    }

    public static bool IsInDevelopment()
    {
      if (!LocalWebService._isInDevelopment.HasValue)
      {
        LocalWebService._isInDevelopment = new bool?(false);
        if (Application.ExecutablePath.ToLower().Substring(0, 6).CompareTo("r:\\lib") == 0)
          LocalWebService._isInDevelopment = new bool?(true);
      }
      return LocalWebService._isInDevelopment.Value;
    }

    public static string InstallDir() => !LocalWebService.IsInDevelopment() ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Autodesk\\Desktop Connect" : Environment.GetEnvironmentVariable("_DESKTOPCONNECT");

    public void Start(Action<bool> callback)
    {
      if (LocalWebService.IsAutoStartEnabled())
      {
        if (LocalWebService.Instance().AutoStart())
          return;
        callback(true);
      }
      else
        callback(false);
    }

    public bool AutoStart()
    {
      if (LocalWebService.IsRunning())
        return true;
      string str1 = LocalWebService.InstallDir();
      string str2 = str1 + "\\forever\\node.exe";
      string str3 = "\"" + str1 + "\\desktop-connect\\server\\main.js\"";
      this._lwsJob = new Job();
      using (Process process = new Process())
      {
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.FileName = str2;
        process.StartInfo.Arguments = str3;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.Start();
        if (!this._lwsJob.AddProcess(process.Handle))
        {
          process.Kill();
          LocalWebService._isRunning = new bool?(false);
        }
        LocalWebService._isRunning = new bool?(true);
      }
      bool? isRunning = LocalWebService._isRunning;
      bool flag = true;
      return isRunning.GetValueOrDefault() == flag & isRunning.HasValue;
    }

    public static bool IsRunning() => LocalWebService.PingServer();

    public static bool IsAutoStartEnabled()
    {
      string environmentVariable = Environment.GetEnvironmentVariable("StartLocalWebServer");
      if (LocalWebService.IsInDevelopment())
      {
        if (environmentVariable == null || environmentVariable == "0")
          return false;
      }
      else if (environmentVariable != null && environmentVariable == "0")
        return false;
      return true;
    }

    public static bool IsDefaultHttpPort() => "44441" == LocalWebService.HttpPort;

    public static void SetAsDefaultHttpPort() => LocalWebService.HttpPort = "44441";

    public static bool IsDefaultSocketPort() => "44442" == LocalWebService.SocketPort;

    public static void SetAsDefaultSocketPort() => LocalWebService.SocketPort = "44442";

    public static string GetServerUrl() => "http://localhost:" + LocalWebService.HttpPort;

    public static bool PingServer()
    {
      bool flag = true;
      TcpClient tcpClient = (TcpClient) null;
      try
      {
        tcpClient = new TcpClient();
        tcpClient.ReceiveTimeout = tcpClient.SendTimeout = 2000;
        tcpClient.Connect("localhost", Convert.ToInt32(LocalWebService.HttpPort));
      }
      catch
      {
        flag = false;
      }
      finally
      {
        tcpClient?.Close();
      }
      return flag;
    }

    public void ReadServerConfiguration()
    {
      if (LocalWebService._bInitializedLwsConfig)
        return;
      try
      {
        string path = LocalWebService.ServerPortConfigFile();
        if (!File.Exists(path))
          return;
        LwsPortsConfig lwsPortsConfig = JsonParser.Parse<LwsPortsConfig>(File.ReadAllText(path));
        if (lwsPortsConfig != null)
        {
          LocalWebService.HttpPort = lwsPortsConfig.HttpPort;
          LocalWebService.SocketPort = lwsPortsConfig.SocketPort;
        }
        LocalWebService._bInitializedLwsConfig = true;
      }
      catch (Exception ex)
      {
      }
    }

    public static string ServerPortConfigFile() => LocalWebService.DocStorePath() + "ports.json";

    public static string DocStorePath() => Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\Autodesk\\.desktop-connect\\";
  }