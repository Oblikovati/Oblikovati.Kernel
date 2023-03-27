using System.Diagnostics;
using System.Reflection.Metadata;
using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

internal class TutorialsApiHelper
  {
    private IApplication _inventorApp;
    private LwsPortsConfig _lwsPortsConfigObj;
    private static bool _bInitializedLwsConfig;

    public TutorialsApiHelper(IApplication app)
    {
      this._inventorApp = app;
      this._lwsPortsConfigObj = (LwsPortsConfig) null;
    }

    public string CaptureModel(bool bFullPath)
    {
      string str = "";
      IDocument activeDocument = this._inventorApp.ActiveDocument;
      if (activeDocument != null)
        str = !bFullPath ? activeDocument.DisplayName : activeDocument.FullDocumentName;
      return str;
    }

    public void GetDocumentDependencies(out List<string> referencedDocs)
    {
      referencedDocs = new List<string>();
      try
      {
        IDocument activeDocument = this._inventorApp.ActiveDocument;
        if (activeDocument == null)
          return;
        IFile file = activeDocument.File;
        if (file == null)
          return;
        Dictionary<string, string> references = new Dictionary<string, string>();
        this.GetAllFileReferences(file, ref references);
        foreach (string key in references.Keys)
          referencedDocs.Add(key);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void GetAllFileReferences(IFile file, ref Dictionary<string, string> references)
    {
      IFilesEnumerator allReferencedFiles = file.AllReferencedFiles;
      if (allReferencedFiles == null || allReferencedFiles.Count <= 0)
        return;
      foreach (IFile file1 in allReferencedFiles)
      {
        if (file1 != null)
        {
          string fullFileName = file1.FullFileName;
          if (!references.ContainsKey(fullFileName))
            references.Add(fullFileName, fullFileName);
          this.GetAllFileReferences(file1, ref references);
        }
      }
    }

    public string CaptureSketch()
    {
      string str = "";
      switch (this._inventorApp.ActiveEditObject)
      {
        case ISketch sketch:
          str = sketch.Name;
          break;
        case ISketch3D sketch3D:
          str = sketch3D.Name;
          break;
      }
      return str;
    }

    private string FindSelectedNodeRecursively(IBrowserNode topNode)
    {
      string selectedNodeRecursively = "";
      if (topNode.Visible)
      {
        foreach (IBrowserNode browserNode in topNode.BrowserNodes)
        {
          if (browserNode.Selected)
          {
            selectedNodeRecursively = browserNode.FullPath;
            break;
          }
          selectedNodeRecursively = this.FindSelectedNodeRecursively(browserNode);
          if (selectedNodeRecursively.Length > 0)
            break;
        }
      }
      return selectedNodeRecursively;
    }

    public string CaptureBrowserNode()
    {
      string str = "";
      try
      {
        IDocument activeDocument = (IDocument) this._inventorApp.ActiveDocument;
        if (activeDocument != null)
          str = this.FindSelectedNodeRecursively(activeDocument.BrowserPanes.ActivePane.TopNode);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      return str;
    }

    internal void ReadServerConfiguration()
    {
      if (TutorialsApiHelper._bInitializedLwsConfig)
        return;
      try
      {
        string str = ServerData.ServerPortConfigFile();
        if (!WindowsAPIs.IsFileExist(str))
          return;
        this._lwsPortsConfigObj = JsonParser.Parse<LwsPortsConfig>(System.IO.File.ReadAllText(str));
        TutorialsApiHelper._bInitializedLwsConfig = true;
      }
      catch (Exception ex)
      {
      }
    }

    public void SetPortNumbersToDefault()
    {
      if (this._lwsPortsConfigObj == null)
        return;
      this._lwsPortsConfigObj.SocketPort = "44442";
      this._lwsPortsConfigObj.HttpPort = "44441";
    }

    internal string GetHttpPortNumber()
    {
      string httpPortNumber = "44441";
      if (this._lwsPortsConfigObj != null)
        httpPortNumber = this._lwsPortsConfigObj.HttpPort;
      return httpPortNumber;
    }

    internal string GetSocketPort(bool bDefault)
    {
      string socketPort = "44442";
      if (!bDefault && this._lwsPortsConfigObj != null)
        socketPort = this._lwsPortsConfigObj.SocketPort;
      return socketPort;
    }

    internal string GetLwsRoot()
    {
      string lwsRoot = ServerData.LwsDocStorePath();
      if (this._lwsPortsConfigObj != null)
      {
        string serverPath = this._lwsPortsConfigObj.ServerPath;
        if (serverPath != null && serverPath.Length > 0)
          lwsRoot = serverPath;
      }
      return lwsRoot;
    }

    internal string GetPlugInDocStorePath() => ServerData.PluginDocStorePath();

    public string GetTutorialURLBase() => "http://localhost" + ":" + this.GetHttpPortNumber() + "/guided-tutorial-plugin/v3";

    public string AddQueryParameter(
      string baseUrl,
      string queryName,
      string queryValue,
      ref bool bFirstParam)
    {
      string str = baseUrl + (bFirstParam ? "?" : "&");
      if (bFirstParam)
        bFirstParam = false;
      return str + queryName + "=" + queryValue;
    }

    public string GetTutorialURL(
      string engineOrGallery,
      bool bIncludeProcessId,
      bool bIncludeOnlineRouteParameter)
    {
      string baseUrl1 = this.GetTutorialURLBase() + "/" + engineOrGallery + this.GetProductVersionLangPath();
      bool bFirstParam = true;
      string baseUrl2 = this.AddQueryParameter(baseUrl1, "user", System.Environment.UserName, ref bFirstParam);
      if (bIncludeOnlineRouteParameter)
        baseUrl2 = this.AddQueryParameter(baseUrl2, "mode", Mode.Value, ref bFirstParam);
      if (bIncludeProcessId)
      {
        string queryValue = Process.GetCurrentProcess().Id.ToString();
        baseUrl2 = this.AddQueryParameter(baseUrl2, "pid", queryValue, ref bFirstParam);
      }
      return baseUrl2;
    }

    public string GetProductVersionLangPath()
    {
      string str1 = this.GetProduct() + "/" + this.GetVersion() + "/";
      string str2 = this.GetLanguage();
      if (str2 == "ESN")
        str2 = "ESP";
      return str1 + str2;
    }

    public string GetProductVersionPath() => this.GetPlugInDocStorePath() + "\\" + this.GetProduct() + "\\" + this.GetVersion() + "\\";

    public string GetLanguage(bool threeLetter = true) => FrameworkUtils.GetLanguage(this._inventorApp, threeLetter);

    public string GetProduct() => "INVNTOR";

    public string GetVersion()
    {
      string version = this._inventorApp.SoftwareVersion.DisplayVersion;
      int startIndex = version.IndexOf(".");
      if (startIndex >= 0)
        version = version.Remove(startIndex, version.Length - startIndex);
      return version;
    }

    public string GetTutorialEngineURL() => this.GetTutorialURL("engine#/main/", true, true);

    public string GetTutorialGalleryURL() => this.GetTutorialURL("gallery#/main/", true, true);
  }