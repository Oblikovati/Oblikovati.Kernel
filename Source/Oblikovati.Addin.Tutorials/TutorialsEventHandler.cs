using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Oblikovati.Addin.Tutorials.Properties;
using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

  internal class TutorialEventsHandler
  {
    private const string A360StatusEvent = "AuthStatus";
    private bool _bSavedTaskDocDoNotCloseYet;
    private const string SidePanelModeEdit = "engine#/edit";
    private const string SidePanelModePlay = "engine#/play";
    internal string ResponseChannelName;
    private bool _bRetriedConnecting;

    public WebSocketUtil ServerCommunicator { get; private set; }

    public PlaybackApiHelper PlaybackApiHelper { get; private set; }

    public TutorialsApiHelper TutorialsApiHelper { get; private set; }

    public CaptureEvents CaptureEvents { get; set; }

    public bool BInitializedWebSocketConnection { get; private set; }

    public bool SidePanelModeIsPlay { get; private set; }

    public TutorialEventsHandler()
    {
    }

    public TutorialEventsHandler(IApplication app)
    {
      this.PlaybackApiHelper = new PlaybackApiHelper(app, this);
      this.TutorialsApiHelper = new TutorialsApiHelper(app);
      this.CaptureEvents = new CaptureEvents(this);
      this.BInitializedWebSocketConnection = false;
    }

    private void ConnectToWebSocketServer(bool bUseDefaultPort) => this.ServerCommunicator.Connect(true, "ws://localhost:" + this.TutorialsApiHelper.GetSocketPort(bUseDefaultPort));

    public bool isHttpPortOccupied()
    {
      int num = int.Parse(this.TutorialsApiHelper.GetHttpPortNumber());
      IPAddress ipAddress = new IPAddress(16777343L);
      foreach (IPEndPoint activeTcpListener in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners())
      {
        if (activeTcpListener.Port == num && activeTcpListener.Address.ToString() != ipAddress.ToString())
          return true;
      }
      return false;
    }

    public bool Init()
    {
      bool flag = true;
      if (!this.BInitializedWebSocketConnection)
      {
        try
        {
          this.TutorialsApiHelper.ReadServerConfiguration();
          this.ServerCommunicator = new WebSocketUtil();
          this.ServerCommunicator.SetOnMessageSocketFunction(new WebSocketUtil.OnMessageSocketDelegate(this.HandleEvent));
          this.ServerCommunicator.SetOnOpenSocketFunction(new WebSocketUtil.OnOpenSocketDelegate(this.HandleSocketOpen));
          this.ServerCommunicator.SetOnErrorSocketFunction(new WebSocketUtil.OnErrorSocketDelegate(this.ConnectionError));
          this.ConnectToWebSocketServer(false);
        }
        catch (Exception ex)
        {
          flag = false;
          WindowsAPIs.ShowErrorMessage(ex);
        }
      }
      return flag;
    }
    private uint ComputeStringHash(string s)
    {
        uint stringHash = default;
        if (s != null)
        {
            stringHash = 2166136261U;
            for (int index = 0; index < s.Length; ++index)
                stringHash = (uint) (((int) s[index] ^ (int) stringHash) * 16777619);
        }
        return stringHash;
    }
    public void HandleEvent(string data)
    {
      try
      {
        string lwsEvent = JsonParser.Parse<PacketBase>(data).LwsEvent;
        // ISSUE: reference to a compiler-generated method
        switch (ComputeStringHash(lwsEvent))
        {
          case 129162371:
            if (!(lwsEvent == "LoadActiveSketch"))
              break;
            string Index = JsonParser.Parse<PropVal>(data).Data.Value;
            if (string.IsNullOrWhiteSpace(Index))
              break;
            IDocument document = !this.SidePanelModeIsPlay ? 
                (IDocument) InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument : 
                (IDocument) this.PlaybackApiHelper.GetTutorialDocument();
            if (document == null || document.DocumentType != DocumentTypeEnum.kPartDocumentObject 
                                 || !(document is IPartDocument partDocument))
              break;
            IPartComponentDefinition componentDefinition = partDocument.ComponentDefinition;
            if (componentDefinition == null)
              break;
            if (componentDefinition.Sketches.Count <= 0)
              break;
            try
            {
              IPlanarSketch sketch = componentDefinition.Sketches[Index];
              if (sketch == null)
                break;
              sketch.Edit();
              if (!InteractiveTutorialServer.Instance.InventorApplication.SketchOptions.ParallelViewOnSketchCreationInPart)
                break;
              InteractiveTutorialServer.Instance.InventorApplication.CommandManager.DoSelect((object) sketch);
              InteractiveTutorialServer.Instance.InventorApplication.CommandManager.ControlDefinitions["AppLookAtCmd"]?.Execute();
              break;
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show(string.Format(Resources.ErrorEditingSketch, (object) Index));
              break;
            }
          case 139655005:
            if (!(lwsEvent == "SignUrl"))
              break;
            SignUrl signUrl = JsonParser.Parse<SignUrl>(data);
            if (!(signUrl.Data.Channel == this.ResponseChannelName))
              break;
            this.SignTutorialUrl(signUrl.Data.Url, signUrl.Data.Id);
            break;
          case 207949216:
            if (!(lwsEvent == "GallerySettings"))
              break;
            try
            {
              GallerySettingsFile.Save(data);
              break;
            }
            catch (Exception ex)
            {
              WindowsAPIs.ShowErrorMessage(ex);
              break;
            }
          case 466618310:
            if (!(lwsEvent == "NavigateDialog"))
              break;
            this.ShowWebDialog(JsonParser.Parse<NavigateDialog>(data));
            break;
          case 471156321:
            if (!(lwsEvent == "CloseStep"))
              break;
            if (!this._bSavedTaskDocDoNotCloseYet)
              this.PlaybackApiHelper.ExitTaskEdit();
            this._bSavedTaskDocDoNotCloseYet = false;
            break;
          case 663276924:
            if (!(lwsEvent == "SaveActiveDocumentCommand") || InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument != null && !this.SaveActiveDocument(false))
              break;
            this.EmitMessage((PacketBase) this.GetActiveDocumentSavedPacket());
            break;
          case 683985261:
            if (!(lwsEvent == "CancelHighlightCapture"))
              break;
            this.PlaybackApiHelper.EndAddMarker();
            break;
          case 843336460:
            if (!(lwsEvent == "SaveTaskDocument") || !this.SaveActiveDocument(false))
              break;
            StringData stringData1 = new StringData();
            stringData1.Data = "";
            GenericData packet1 = new GenericData();
            packet1.LwsEvent = "TaskDocumentSaved";
            packet1.Data = stringData1;
            this._bSavedTaskDocDoNotCloseYet = true;
            this.EmitMessage((PacketBase) packet1);
            break;
          case 932589221:
            if (!(lwsEvent == "ResizeDialog"))
              break;
            this.ResizeDialog(JsonParser.Parse<ResizeDialog>(data));
            break;
          case 1119497105:
            if (!(lwsEvent == "SetActiveSketch"))
              break;
            this.CaptureEvents.CaptureSketch();
            break;
          case 1208034537:
            if (!(lwsEvent == "DoLogin"))
              break;
            //this._loginMgr.SignOn(InteractiveTutorialServer.Instance.InventorApplication);
            this._onAuthStatusChanged();
            break;
          case 1309059122:
            if (!(lwsEvent == "CreateWaypoint"))
              break;
            Waypoint waypoint = JsonParser.Parse<Waypoint>(data);
            if (waypoint == null)
              break;
            WaypointData data1 = waypoint.Data;
            CIPState state = new CIPState(CIPEnum.GetSubType(data1.SubState), data1.Attributes);
            new CIPWaypoint(CIPEnum.GetWaypoint(data1.Waypoint), state).SendCIP(InteractiveTutorialServer.Instance.InventorApplication);
            break;
          case 1410870406:
            if (!(lwsEvent == "GetGallerySettings"))
              break;
            this.SendGallerySettings();
            break;
          case 1690381979:
            if (!(lwsEvent == "ShowBlueMarkers"))
              break;
            using (List<MarkerData>.Enumerator enumerator = JsonParser.Parse<ShowMarkers>(data).Data.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                MarkerData current = enumerator.Current;
                string title = current.Title;
                if (!(title == "CmdID"))
                {
                  if (!(title == "IndicatorAttrName"))
                  {
                    if (title == "ModelBrowserNodeName")
                      this.PlaybackApiHelper.ShowModelBrowserIndicator(current.Value, ColorStyleEnum.kBlueTutorialIndicator);
                  }
                  else
                    this.PlaybackApiHelper.ShowTutorialHotspot(current.Value);
                }
                else
                  this.PlaybackApiHelper.ShowTutorialCommandIndicator(current.Value, ColorStyleEnum.kBlueTutorialIndicator);
              }
              break;
            }
          case 2091932636:
            if (!(lwsEvent == "IsActiveDocumentValid"))
              break;
            this.CaptureEvents.IsActiveDocumentValid();
            break;
          case 2115354991:
            if (!(lwsEvent == "ShowMarkers"))
              break;
            ShowMarkers showMarkers = JsonParser.Parse<ShowMarkers>(data);
            ColorStyleEnum color = this.PlaybackApiHelper.IsInAddMarker() ? ColorStyleEnum.kYellowTutorialIndicator : ColorStyleEnum.kRedTutorialIndicator;
            using (List<MarkerData>.Enumerator enumerator = showMarkers.Data.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                MarkerData current = enumerator.Current;
                string title = current.Title;
                if (!(title == "CmdID"))
                {
                  if (!(title == "IndicatorAttrName"))
                  {
                    if (title == "ModelBrowserNodeName")
                      this.PlaybackApiHelper.ShowModelBrowserIndicator(current.Value, color);
                  }
                  else
                    this.PlaybackApiHelper.ShowTutorialHotspot(current.Value);
                }
                else
                  this.PlaybackApiHelper.ShowTutorialCommandIndicator(current.Value, color);
              }
              break;
            }
          case 2475357344:
            if (!(lwsEvent == "NeedToImportTutorials"))
              break;
            this.HandleImportLegacyTutorials();
            break;
          case 2502994007:
            if (!(lwsEvent == "WidenCreatorPlayerPane"))
              break;
            int data2 = JsonParser.Parse<WidenCreatorPlayerPane>(data).Data;
            if (data2 <= 0)
              break;
            this.PlaybackApiHelper.WidenPane(data2);
            break;
          case 2714903390:
            if (!(lwsEvent == "RegisterResponseChannel"))
              break;
            StringData stringData2 = JsonParser.Parse<StringData>(data);
            if (this.ResponseChannelName != stringData2.Data && this.PlaybackApiHelper.IsTutorialDockableWindowVisible())
            {
              PropValData propValData1 = new PropValData();
              propValData1.Target = this.ResponseChannelName;
              propValData1.Value = stringData2.Data;
              PropValData propValData2 = propValData1;
              PropVal packet2 = new PropVal();
              packet2.LwsEvent = "UpdateResponseChannel";
              packet2.Data = propValData2;
              this.EmitMessage((PacketBase) packet2);
            }
            this.ResponseChannelName = stringData2.Data;
            break;
          case 2718243507:
            if (!(lwsEvent == "LoadStep"))
              break;
            LoadStepData data3 = JsonParser.Parse<LoadStep>(data).Data;
            this.PlaybackApiHelper.LoadTaskForPlay(ServerData.PluginDocStorePath() + "\\" + data3.DataPath);
            break;
          case 2728945284:
            if (!(lwsEvent == "HideMarkers"))
              break;
            this.PlaybackApiHelper.ClearTutorialCommandIndicator();
            this.PlaybackApiHelper.ClearTutorialHotspot();
            break;
          case 2813498803:
            if (!(lwsEvent == "CheckAuthStatus"))
              break;
            this._onAuthStatusChanged();
            break;
          case 2981731155:
            if (!(lwsEvent == "DatasetSelect"))
              break;
            IFileDialog Dialog;
            InteractiveTutorialServer.Instance.InventorApplication.CreateFileDialog(out Dialog);
            Dialog.DialogTitle = Resources.BrowseDialogTitle;
            Dialog.Filter = Resources.InventorFileOpenFilter;
            Dialog.InsertMode = true;
            Dialog.MultiSelectEnabled = false;
            try
            {
              Dialog.ShowOpen();
              string fileName = Dialog.FileName;
              if (string.IsNullOrEmpty(fileName))
                break;
              InteractiveTutorialServer.Instance.InventorApplication.Documents.Open(fileName);
              this.CaptureEvents.CaptureData("DatasetSelect");
              break;
            }
            catch (COMException ex)
            {
              break;
            }
          case 3860025467:
            if (!(lwsEvent == "LoadTaskForEdit"))
              break;
            StringData stringData3 = JsonParser.Parse<StringData>(data);
            this.PlaybackApiHelper.LoadTaskForEdit(ServerData.PluginDocStorePath() + stringData3.Data);
            break;
          case 3863561545:
            if (!(lwsEvent == "StartHighlightCapture"))
              break;
            this.PlaybackApiHelper.StartAddMarker();
            break;
          case 3893229963:
            if (!(lwsEvent == "NavigateSidePane"))
              break;
            NavigatePane navigatePane1 = JsonParser.Parse<NavigatePane>(data);
            string engineUrl = this.TutorialsApiHelper.GetTutorialURLBase() + navigatePane1.Data.DestUrl;
            this.SidePanelModeIsPlay = engineUrl.Contains("engine#/play");
            InteractiveTutorialServer.Instance.CreateTutorialCmdObject.StartCommandAtUrl(engineUrl);
            break;
          case 3936456769:
            if (!(lwsEvent == "NavigateMainPane"))
              break;
            this.PlaybackApiHelper.EndTutorial();
            NavigatePane navigatePane2 = JsonParser.Parse<NavigatePane>(data);
            string str = this.TutorialsApiHelper.GetTutorialURLBase() + navigatePane2.Data.DestUrl;
            InteractiveTutorialServer.Instance.TutorialsGalleryCmdObject.GalleryURL = str;
            InteractiveTutorialServer.Instance.TutorialsGalleryCmdObject.ExecuteCommand();
            InteractiveTutorialServer.Instance.TutorialsGalleryCmdObject.GalleryURL = this.TutorialsApiHelper.GetTutorialGalleryURL();
            break;
          case 4225566193:
            if (!(lwsEvent == "CaptureData"))
              break;
            this.CaptureEvents.CaptureData("CaptureData");
            break;
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    private void SendGallerySettings()
    {
      try
      {
        this.EmitMessage((PacketBase) GallerySettingsFile.Read());
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    private void ShowWebDialog(NavigateDialog data)
    {
      string strUrl = this.TutorialsApiHelper.GetTutorialURLBase() + data.Data.DestUrl;
      UIRect rect = new UIRect(data.Data.Top, data.Data.Left, data.Data.Height, data.Data.Width);
      TutorialWebDialog webDialog = InteractiveTutorialServer.Instance.WebDialog;
      webDialog.SetUrl(strUrl);
      webDialog.ShowWebDialog(rect);
    }

    private void ResizeDialog(ResizeDialog data) => InteractiveTutorialServer.Instance.WebDialog.ResizeDialog(data.Data.Width, data.Data.Height);

    public void HandleImportLegacyTutorials()
    {
      if (!this.ServerCommunicator.IsInitialized)
        return;
      string userDataDir1 = this.GetUserDataDir("2015");
      PropVal packet1 = this.RegisterStaticRoute(userDataDir1);
      ProdInfoPropVal packet2 = this.ImportTutorials(userDataDir1);
      this.EmitMessage((PacketBase) packet1);
      this.EmitMessage((PacketBase) packet2);
      string userDataDir2 = this.GetUserDataDir("2016");
      PropVal packet3 = this.RegisterStaticRoute(userDataDir2);
      ProdInfoPropVal packet4 = this.ImportTutorials(userDataDir2);
      this.EmitMessage((PacketBase) packet3);
      this.EmitMessage((PacketBase) packet4);
    }

    internal void HandleSocketOpen()
    {
      if (!this.ServerCommunicator.IsInitialized)
        return;
      this.BInitializedWebSocketConnection = true;
      this.EmitMessage((PacketBase) this.AnnounceRoom());
      ProdInfoPropValData prodInfoPropValData = new ProdInfoPropValData();
      prodInfoPropValData.Target = "server";
      prodInfoPropValData.Value = "";
      prodInfoPropValData.Product = this.TutorialsApiHelper.GetProduct();
      prodInfoPropValData.Language = "";
      prodInfoPropValData.Version = this.TutorialsApiHelper.GetVersion();
      ProdInfoPropVal packet = new ProdInfoPropVal();
      packet.LwsEvent = "checkNeedToImportTutorials";
      packet.Data = prodInfoPropValData;
      this.EmitMessage((PacketBase) packet);
      //this._loginMgr = A360LoginManager.GetInstance();
      //this._loginMgr.Register("guided-tutorials", (A360LoginManager.ILoginEventsListener) this);
    }


    private AuthStatusInPacket createPacketForValidUser()
    {
        string accessToken = "";//this._loginMgr.GetAccessToken();
      string userName = "";//this._loginMgr.GetUserName();
      int server = 0;//this._loginMgr.GetServer();
      AuthStatusInData authStatusInData1 = new AuthStatusInData();
      authStatusInData1.Target = "";
      authStatusInData1.Status = true;
      authStatusInData1.AccessToken = accessToken;
      authStatusInData1.Env = server;
      authStatusInData1.UserName = userName;
      AuthStatusInData authStatusInData2 = authStatusInData1;
      AuthStatusInPacket packetForValidUser = new AuthStatusInPacket();
      packetForValidUser.LwsEvent = "AuthStatus";
      packetForValidUser.LwsData = authStatusInData2;
      return packetForValidUser;
    }

    private AuthStatusOutPacket createPacketForInvalidUser()
    {
      AuthStatusOutData authStatusOutData1 = new AuthStatusOutData();
      authStatusOutData1.Target = "";
      authStatusOutData1.Status = false;
      AuthStatusOutData authStatusOutData2 = authStatusOutData1;
      AuthStatusOutPacket packetForInvalidUser = new AuthStatusOutPacket();
      packetForInvalidUser.LwsEvent = "AuthStatus";
      packetForInvalidUser.LwsData = authStatusOutData2;
      return packetForInvalidUser;
    }

    private void _onAuthStatusChanged()
    {
      if (this.ServerCommunicator == null)
        return;
      try
      {
        PacketBase eventPacket;
        if (true)
        {
          AuthStatusInPacket packetForValidUser = this.createPacketForValidUser();
          packetForValidUser.LwsData.Target = this.ResponseChannelName;
          eventPacket = (PacketBase) packetForValidUser;
        }
        else
        {
          AuthStatusOutPacket packetForInvalidUser = this.createPacketForInvalidUser();
          packetForInvalidUser.LwsData.Target = this.ResponseChannelName;
          eventPacket = (PacketBase) packetForInvalidUser;
        }
        this.ServerCommunicator.SendEventMessage(true, eventPacket);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    internal AnnouncePacket AnnounceRoom()
    {
      string[] strArray = new string[1]
      {
        "guided-tutorial-plugin-" + Process.GetCurrentProcess().Id.ToString()
      };
      AnnounceData announceData = new AnnounceData()
      {
        Room = "guided-tutorial",
        Channels = strArray
      };
      AnnouncePacket announcePacket = new AnnouncePacket();
      announcePacket.LwsEvent = "announce";
      announcePacket.LwsData = announceData;
      return announcePacket;
    }

    internal ActiveDoc GetActiveDocumentSavedPacket()
    {
      StringData stringData = new StringData();
      stringData.Data = InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument == null ? "" : InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument.FullDocumentName;
      ActiveDoc documentSavedPacket = new ActiveDoc();
      documentSavedPacket.LwsEvent = "ActiveDocumentSavedEvent";
      documentSavedPacket.Data = stringData;
      return documentSavedPacket;
    }

    internal PropVal RegisterStaticRoute(string route)
    {
      PropValData propValData = new PropValData();
      propValData.Target = "server";
      propValData.Value = route;
      PropVal propVal = new PropVal();
      propVal.LwsEvent = "registerStaticRoute";
      propVal.Data = propValData;
      return propVal;
    }

    internal ProdInfoPropVal ImportTutorials(string route)
    {
      this.TutorialsApiHelper.GetProductVersionLangPath();
      ProdInfoPropValData prodInfoPropValData = new ProdInfoPropValData();
      prodInfoPropValData.Target = "server";
      prodInfoPropValData.Value = route;
      prodInfoPropValData.Product = this.TutorialsApiHelper.GetProduct();
      prodInfoPropValData.Language = this.TutorialsApiHelper.GetLanguage();
      prodInfoPropValData.Version = this.TutorialsApiHelper.GetVersion();
      ProdInfoPropVal prodInfoPropVal = new ProdInfoPropVal();
      prodInfoPropVal.LwsEvent = "importTutorials";
      prodInfoPropVal.Data = prodInfoPropValData;
      return prodInfoPropVal;
    }

    internal string GetUserDataDir(string releaseYear) => System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonDocuments) + 
                                                          "/Oblikovati " + releaseYear + "/Interactive Tutorial/" +
                                                          this.TutorialsApiHelper.GetLanguage(false);

    public void ShowConnectionFailed()
    {
      string Url = "file:///" + (System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + 
                                 "/Oblikovati " + this.TutorialsApiHelper.GetVersion() + "/InteractiveTutorials/ConnectionError.html") +
                   "?message=" + Resources.ConnectionError + "&font=" +
                   InteractiveTutorialServer.Instance.InventorApplication.GeneralOptions.TextAppearance;
      InteractiveTutorialServer.Instance.TutorialsGalleryCmdObject?.GetWebView()?.Navigate(Url);
    }

    internal void ConnectionError(Type errorType)
    {
      this.BInitializedWebSocketConnection = false;
      if (!this._bRetriedConnecting)
      {
        this._bRetriedConnecting = true;
        bool bUseDefaultPort = true;
        this.TutorialsApiHelper.SetPortNumbersToDefault();
        this.ConnectToWebSocketServer(bUseDefaultPort);
      }
      else if (LocalWebService.Instance().AutoStart())
      {
        this.Init();
      }
      else
      {
        this.ShowConnectionFailed();
        this.ServerCommunicator.SetOnErrorSocketFunction((WebSocketUtil.OnErrorSocketDelegate) null);
      }
    }

    public void EmitMessage(PacketBase packet)
    {
      try
      {
        this.Init();
        if (this.ServerCommunicator.IsInitialized)
        {
          this.ServerCommunicator.SendEventMessage(true, packet);
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.ConnectionError);
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    public void Clear(bool bInventorIsExiting)
    {
      //if (this._loginMgr != null)
      //  this._loginMgr.Unregister("guided-tutorials");
      this.ServerCommunicator = (WebSocketUtil) null;
      if (bInventorIsExiting)
        return;
      this.PlaybackApiHelper.CloseTutorialDocument();
    }

    internal void SendCommandMarker(string commandName)
    {
      try
      {
        if (this.ServerCommunicator.IsInitialized)
        {
          PropValData propValData1 = new PropValData();
          propValData1.Value = commandName;
          propValData1.Target = this.ResponseChannelName;
          PropValData propValData2 = propValData1;
          PropVal packet = new PropVal();
          packet.LwsEvent = "AddCommandMarker";
          packet.Data = propValData2;
          this.EmitMessage((PacketBase) packet);
          this.PlaybackApiHelper.ShowTutorialCommandIndicator(commandName, ColorStyleEnum.kYellowTutorialIndicator);
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.EngineNotRunning);
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    internal void SendBrowserMarker()
    {
      try
      {
        string sCmdIndicator = this.TutorialsApiHelper.CaptureBrowserNode();
        if (this.ServerCommunicator.IsInitialized)
        {
          PropValData propValData1 = new PropValData();
          propValData1.Value = sCmdIndicator;
          propValData1.Target = this.ResponseChannelName;
          PropValData propValData2 = propValData1;
          PropVal packet = new PropVal();
          packet.LwsEvent = "AddBrowserMarker";
          packet.Data = propValData2;
          this.EmitMessage((PacketBase) packet);
          this.PlaybackApiHelper.ShowModelBrowserIndicator(sCmdIndicator, ColorStyleEnum.kYellowTutorialIndicator);
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.EngineNotRunning);
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    internal void SendModelDirty()
    {
      try
      {
        if (this.ServerCommunicator.IsInitialized)
        {
          PropValData propValData1 = new PropValData();
          propValData1.Target = this.ResponseChannelName;
          PropValData propValData2 = propValData1;
          PropVal packet = new PropVal();
          packet.LwsEvent = "ModelDirty";
          packet.Data = propValData2;
          this.EmitMessage((PacketBase) packet);
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.EngineNotRunning);
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    public void SendToggleActiveStep()
    {
      try
      {
        if (this.ServerCommunicator.IsInitialized)
        {
          StringData stringData = new StringData();
          stringData.Data = "";
          GenericData packet = new GenericData();
          packet.LwsEvent = "ToggleActiveStep";
          packet.Data = stringData;
          this.EmitMessage(packet);
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.EngineNotRunning);
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    internal void SignTutorialUrl(string url, string id)
    {
      //string str = this._loginMgr.SignRequest(url, "Get");
      //if (str == null)
      //  return;
      SignUrlPropValData signUrlPropValData = new SignUrlPropValData();
      signUrlPropValData.Target = "server";
      //signUrlPropValData.Value = str;
      signUrlPropValData.Url = url;
      signUrlPropValData.Id = id;
      SignUrlPropVal packet = new SignUrlPropVal();
      packet.LwsEvent = "tutorialUrlSigned";
      packet.Data = signUrlPropValData;
      this.EmitMessage((PacketBase) packet);
    }

    public bool SaveActiveDocument(bool bAllowDialog)
    {
      if (bAllowDialog)
      {
        try
        {
          InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument.Save();
          return true;
        }
        catch (Exception ex)
        {
          return false;
        }
      }
      else
      {
        try
        {
          IDocument activeDocument = InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument;
          if (activeDocument != null && activeDocument.isAssemblyDocument() && activeDocument is IAssemblyDocument assemblyDocument)
          {
            IAssemblyComponentDefinition componentDefinition = assemblyDocument.ComponentDefinition;
            if (componentDefinition != null)
            {
              IComponentOccurrence activeOccurrence = componentDefinition.ActiveOccurrence;
              if (activeOccurrence != null)
                activeOccurrence.ExitEdit(ExitTypeEnum.kExitToTop);
              else if (!componentDefinition.RepresentationsManager.ActivePositionalRepresentation.Master)
              {
                foreach (IPositionalRepresentation positionalRepresentation in componentDefinition.RepresentationsManager.PositionalRepresentations)
                {
                  if (positionalRepresentation.Master)
                  {
                    positionalRepresentation.Activate();
                    break;
                  }
                }
              }
            }
          }
          bool silentOperation = InteractiveTutorialServer.Instance.InventorApplication.SilentOperation;
          InteractiveTutorialServer.Instance.InventorApplication.SilentOperation = true;
          InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument.Save2(true, Type.Missing);
          InteractiveTutorialServer.Instance.InventorApplication.SilentOperation = silentOperation;
          return true;
        }
        catch (Exception ex)
        {
          WindowsAPIs.ShowErrorMessage(ex);
          return false;
        }
      }
    }
  }