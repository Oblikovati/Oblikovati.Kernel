using System.Drawing;
using System.Reflection.Metadata;
using System.Web;
using Oblikovati.Addin.Tutorials.Properties;
using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

internal class PlaybackApiHelper
  {
    private const string PlayTutorialCmdName = "PlayTutorialCmd";
    private const string TutorialNameMapItem = "TutorialName";
    private const string PlayVideoCmdName = "PlayTutorialVideoCmd";
    private const string VideoNameMapItem = "VideoName";
    private const string CleanScreenCmdName = "AppCleanScreenCmd";
    private const string TutorialDataProjectFileName = "TutorialData.ipj";
    private const string MEventIdentity = "{4d9c80fe-e70f-4c29-b6c7-8a5ac3f40eb2}";
    private const string MClientId = "{4d9c80fe-e70f-4c29-b6c7-8a5ac3f40eb2}";
    private readonly string _mTargetDirectory = TutorialsData.TutorialFolder();
    private readonly string _mWebBrowserDockableInternalName;
    private readonly string _mTitle;
    private readonly string _mTutorialDocName = "TutorialFile";
    private const string HelpNamespace = "InvGuidedTutorials";
    private const string HelpRedirect = "REDIRECT_ID_GUIDEDTUTORIALS_HELP";
    private readonly IApplication _inventorApp;
    internal IApplicationEvents MApplicationEvents;
    private IDocumentEvents MDocEvents;
    private IUserInputEvents MUserInputEvents;
    private TutorialEventsHandler TutorialEventsHandlerObject;
    private IWebBrowserDockableWindow MWebBrowserDockableWindow;
    private IDockableWindowsEvents _inventorDockableWindowEvents;
    private bool _bInAddMarker;
    private bool _bCaptureBrowserNode;
    private DocumentEventsSink_OnChangeSelectSetEventHandler MDocumentEventsSinkOnChangeSelectSetDelegate;
    private string _mTargetTaskFilePath = "";
    private string _mEditingTaskFilePath = "";
    private bool _bExitTaskEdit;
    private string _mPreviousProjectPath = "";
    private FileAccessEventsHandling _accessEventsHandling;

    public PlaybackApiHelper(IApplication app, TutorialEventsHandler eventsHandler)
    {
      this._inventorApp = app;
      this.TutorialEventsHandlerObject = eventsHandler;
      this.MApplicationEvents = this._inventorApp.ApplicationEvents;
      this._bExitTaskEdit = false;
      
      //this.MApplicationEvents.add_OnActivateDocument(new ApplicationEventsSink_OnActivateDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnActivateDocument)));
      
      //this.MApplicationEvents.add_OnDeactivateDocument(new ApplicationEventsSink_OnDeactivateDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnDeactivateDocument)));
      
      //this.MApplicationEvents.add_OnTerminateDocument(new ApplicationEventsSink_OnTerminateDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnTerminateDocument)));
      
      //this.MApplicationEvents.add_OnSaveDocument(new ApplicationEventsSink_OnSaveDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnSaveDocument)));
      
      //this.MApplicationEvents.add_OnActivateWebView(new ApplicationEventsSink_OnActivateWebViewEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnActivateWebView)));
      this.MWebBrowserDockableWindow = null;
      this._mWebBrowserDockableInternalName = "tutorialplaybackdockablewindow";
      this._mTitle = Resources.DockableWindowPlaybackTitle;
      // ISSUE: method pointer
      //UserInputEventsSink_OnActivateCommandEventHandler commandEventHandler = new UserInputEventsSink_OnActivateCommandEventHandler((object) this, (UIntPtr) __methodptr(UserInputEvents_OnActivate));
      this.MUserInputEvents = this._inventorApp.CommandManager.UserInputEvents;
      //this.MUserInputEvents.add_OnActivateCommand(commandEventHandler);
      // ISSUE: method pointer
      //this.MUserInputEvents.add_OnSelect(new UserInputEventsSink_OnSelectEventHandler((object) this, (UIntPtr) __methodptr(UserInputEvents_OnSelect)));
      // ISSUE: method pointer
      //this.MUserInputEvents.add_OnMarkTutorialCommand(new UserInputEventsSink_OnMarkTutorialCommandEventHandler((object) this, (UIntPtr) __methodptr(UserInputEvents_OnTutorialMarkCommand)));
      // ISSUE: method pointer
      //this.MDocumentEventsSinkOnChangeSelectSetDelegate = new DocumentEventsSink_OnChangeSelectSetEventHandler((object) this, (UIntPtr) __methodptr(DocEvents_OnChangeSelectSet));
      this._accessEventsHandling = new FileAccessEventsHandling(this._inventorApp, this.TutorialEventsHandlerObject);
    }

    ~PlaybackApiHelper()
    {
      // ISSUE: method pointer
      //this.MApplicationEvents.remove_OnActivateDocument(new ApplicationEventsSink_OnActivateDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnActivateDocument)));
      // ISSUE: method pointer
      //this.MApplicationEvents.remove_OnDeactivateDocument(new ApplicationEventsSink_OnDeactivateDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnDeactivateDocument)));
      // ISSUE: method pointer
      //this.MApplicationEvents.remove_OnTerminateDocument(new ApplicationEventsSink_OnTerminateDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnTerminateDocument)));
      // ISSUE: method pointer
      //this.MApplicationEvents.remove_OnSaveDocument(new ApplicationEventsSink_OnSaveDocumentEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnSaveDocument)));
      if (this._inventorDockableWindowEvents != null)
      {
        // ISSUE: method pointer
        //this._inventorDockableWindowEvents.remove_OnHelp(new DockableWindowsEventsSink_OnHelpEventHandler((object) this, (UIntPtr) __methodptr(DockableWindowEvents_OnHelp)));
      }
      this.MWebBrowserDockableWindow = null;
    }

    private string GetContextItem(INameValueMap context, string name)
    {
      string contextItem = "";
      if (context.Count > 0 && name != null)
      {
        if (name.Length > 0)
        {
          try
          {
            object obj = context[name];
            if (obj != null)
            {
              string str = obj.ToString();
              if (str.Length > 0)
                contextItem = str;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      return contextItem;
    }

    public void EndTutorial()
    {
      this.SetTutorialDockableWindowVisiblity(false);
      if (this._bInAddMarker)
        this.EndAddMarker();
      if (this.CloseTutorialDocument())
        return;
      this.ExitTaskEdit();
    }

    public bool IsTutorialDockableWindowVisible() => this.MWebBrowserDockableWindow != null && this.MWebBrowserDockableWindow.Visible;

    private void SetTutorialDockableWindowVisiblity(bool bShow)
    {
      try
      {
        if (this.MWebBrowserDockableWindow == null || this.MWebBrowserDockableWindow.Visible == bShow)
          return;
        if (bShow)
        {
          this.MWebBrowserDockableWindow.Visible = true;
          // ISSUE: method pointer
          //this._inventorDockableWindowEvents.add_OnHide(new DockableWindowsEventsSink_OnHideEventHandler((object) this, (UIntPtr) __methodptr(DockableWindowEvents_OnHide)));
        }
        else
        {
          // ISSUE: method pointer
          //this._inventorDockableWindowEvents.remove_OnHide(new DockableWindowsEventsSink_OnHideEventHandler((object) this, (UIntPtr) __methodptr(DockableWindowEvents_OnHide)));
          this.MWebBrowserDockableWindow.Visible = false;
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void CreateWebBrowserWindow()
    {
      if (this.MWebBrowserDockableWindow == null)
      {
        IDockableWindows dockableWindows = this._inventorApp.UserInterfaceManager.DockableWindows;
        if (dockableWindows != null)
        {
          this.MWebBrowserDockableWindow = dockableWindows.AddWithWebBrowser("{4d9c80fe-e70f-4c29-b6c7-8a5ac3f40eb2}", this._mWebBrowserDockableInternalName, this._mTitle);
          this.MWebBrowserDockableWindow.DockingState = DockingStateEnum.kDockRight;
          this.MWebBrowserDockableWindow.Title = this._mTitle;
          this.MWebBrowserDockableWindow.ShowTitleBar = false;
        }
      }
      if (this.MWebBrowserDockableWindow == null)
      {
        //int num = (int) MessageBox.Show("The WebBrowserDockableWindow has not been created successfully!");
      }
      if (this._inventorApp == null)
        return;
      this._inventorDockableWindowEvents = this._inventorApp.UserInterfaceManager.DockableWindows.Events;
      try
      {
        // ISSUE: method pointer
        //this._inventorDockableWindowEvents.add_OnHelp(new DockableWindowsEventsSink_OnHelpEventHandler((object) this, (UIntPtr) __methodptr(DockableWindowEvents_OnHelp)));
        InteractiveTutorialServer.Instance.InventorApplication.HelpManager?.RegisterHelpContext("InvGuidedTutorials", 1, "REDIRECT_ID_GUIDEDTUTORIALS_HELP");
      }
      catch (Exception ex)
      {
      }
    }

    public void WidenPane(int desiredWidth)
    {
      int width1 = this.MWebBrowserDockableWindow.Width;
      int width2 = this._inventorApp.Width;
      int y = 0;
      desiredWidth += 20;
     // DPI.Scale(ref desiredWidth, ref y);
      if (width1 >= desiredWidth)
        return;
      int num = (int) (0.66 * (double) width2);
      if (desiredWidth > num)
        desiredWidth = num;
      this.MWebBrowserDockableWindow.Width = desiredWidth;
    }

    public void WebBrowserNavigate(string url)
    {
      try
      {
        if (this.MWebBrowserDockableWindow == null)
          this.CreateWebBrowserWindow();
        if (this.MWebBrowserDockableWindow == null)
          return;
        this.SetTutorialDockableWindowVisiblity(true);
        this.TutorialEventsHandlerObject.Init();
        this.MWebBrowserDockableWindow.Navigate(url);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void DockableWindowEvents_OnHide(
      IDockableWindow DockableWindow,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum handlingCode)
    {
      if (DockableWindow.ClientId == "{4d9c80fe-e70f-4c29-b6c7-8a5ac3f40eb2}")
      {
        handlingCode = HandlingCodeEnum.kEventHandled;
        // ISSUE: method pointer
        //this._inventorDockableWindowEvents.remove_OnHide(new DockableWindowsEventsSink_OnHideEventHandler((object) this, (UIntPtr) __methodptr(DockableWindowEvents_OnHide)));
        if (this._bInAddMarker)
          this.EndAddMarker();
        if (!this.CloseTutorialDocument())
          this.ExitTaskEdit();
        InteractiveTutorialServer.Instance.TutorialsGalleryCmdObject.ExecuteCommand();
      }
      else
        handlingCode = HandlingCodeEnum.kEventNotHandled;
    }

    private void DockableWindowEvents_OnHelp(
      IDockableWindow DockableWindow,
      INameValueMap Context,
      out HandlingCodeEnum handlingCode)
    {
      handlingCode = HandlingCodeEnum.kEventNotHandled;
      try
      {
        if (this._inventorApp == null || string.Compare(DockableWindow.InternalName, this._mWebBrowserDockableInternalName, StringComparison.OrdinalIgnoreCase) != 0)
          return;
        IHelpManager helpManager = this._inventorApp.HelpManager;
        if (helpManager == null)
          return;
        helpManager.DisplayHelpTopic("InvGuidedTutorials", "REDIRECT_ID_GUIDEDTUTORIALS_HELP");
        handlingCode = HandlingCodeEnum.kEventHandled;
      }
      catch (Exception ex)
      {
        //int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public bool IsInAddMarker() => this._bInAddMarker;

    public void ShowTutorialCommandIndicator(string sCmdIndicator, ColorStyleEnum color)
    {
      try
      {
        if (this._inventorApp == null)
          return;
        ShapeStyleEnum Shape = ShapeStyleEnum.kUnknownShapeTutorialIndicator;
        this._inventorApp.TutorialsManager.ShowTutorialCommandIndicatorWithStyles(sCmdIndicator, color, Shape);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public void ClearTutorialCommandIndicator()
    {
      try
      {
        if (this._inventorApp == null)
          return;
        this._inventorApp.TutorialsManager.ClearTutorialCommandIndicator();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public void ShowTutorialHotspot(string sSceneIndicator)
    {
      try
      {
        if (this._inventorApp == null)
          return;
        this._inventorApp.TutorialsManager.ShowTutorialHotspot(sSceneIndicator);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public void ClearTutorialHotspot()
    {
      try
      {
        if (this._inventorApp == null)
          return;
        this._inventorApp.TutorialsManager.ClearTutorialHotspot();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public void ShowModelBrowserIndicator(string sCmdIndicator, ColorStyleEnum color)
    {
      try
      {
        if (this._inventorApp == null)
          return;
        ShapeStyleEnum Shape = ShapeStyleEnum.kUnknownShapeTutorialIndicator;
        this._inventorApp.TutorialsManager.ShowTutorialBrowserIndicatorWithStyles(sCmdIndicator, color, Shape);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    internal void StartAddMarker()
    {
      this._bInAddMarker = true;
      this._inventorApp.TutorialsManager.InTutorialRecordStatus = true;
      if (this._inventorApp.ActiveDocument == null)
        return;
      this.MDocEvents = this._inventorApp.ActiveDocument.DocumentEvents;
      this.MDocEvents.add_OnChangeSelectSet(this.MDocumentEventsSinkOnChangeSelectSetDelegate);
    }

    internal void EndAddMarker()
    {
      this._bInAddMarker = false;
      this._inventorApp.TutorialsManager.InTutorialRecordStatus = false;
      this.ClearTutorialCommandIndicator();
      if (this.MDocEvents == null)
        return;
      this.MDocEvents.remove_OnChangeSelectSet(this.MDocumentEventsSinkOnChangeSelectSetDelegate);
    }

    public void UserInputEvents_OnTutorialMarkCommand(
      string commandName,
      INameValueMap context,
      out HandlingCodeEnum handlingCode)
    {
      handlingCode = HandlingCodeEnum.kEventNotHandled;
      try
      {
        if (!this._bInAddMarker)
          return;
        this.TutorialEventsHandlerObject.SendCommandMarker(commandName);
        handlingCode = HandlingCodeEnum.kEventHandled;
      }
      catch (Exception ex)
      {
        //int num = (int) MessageBox.Show(ex.Message);
      }
    }

    public void UserInputEvents_OnSelect(
      IObjectsEnumerator JustSelectedEntities,
      ref IObjectCollection MoreSelectedEntities,
      SelectionDeviceEnum SelectionDevice,
      Point ModelPosition,
      IPoint2d ViewPosition,
      IView View)
    {
      if (SelectionDevice != SelectionDeviceEnum.kBrowserSelection || !this._bInAddMarker || JustSelectedEntities.Count == 0)
        return;
      this._bCaptureBrowserNode = true;
    }

    public void DocEvents_OnChangeSelectSet(
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventNotHandled;
      if (BeforeOrAfter != EventTimingEnum.kAfter || !this._bCaptureBrowserNode)
        return;
      this.TutorialEventsHandlerObject.SendBrowserMarker();
      this._bCaptureBrowserNode = false;
    }

    public IDocument GetTutorialDocument()
    {
      if (this._inventorApp != null)
      {
        if (!string.IsNullOrEmpty(this._mTargetTaskFilePath))
        {
          try
          {
            return this._inventorApp.Documents[this._mTargetTaskFilePath];
          }
          catch
          {
          }
          return  null;
        }
      }
      return null;
    }

    public void LoadTaskForPlay(string sSourceFilePath)
    {
      try
      {
        if (!WindowsAPIs.IsFileExist(sSourceFilePath))
          return;
        DocumentTypeEnum docType = DocumentTypeEnum.kUnknownDocumentObject;
        if (!this.IsValidFiletype(sSourceFilePath, ref docType))
          return;
        if (this.GetTutorialDocument() != null)
          this.CloseTutorialDocument();
        this.SwitchToTutorialProject(System.IO.Path.GetDirectoryName(sSourceFilePath));
        IDocument document = this._OpenTutorialDocument(sSourceFilePath, docType);
        if (document != null)
        {
          if (System.IO.Path.GetFileNameWithoutExtension(sSourceFilePath) != this._mTutorialDocName)
            document.DisplayName = this._mTutorialDocName + System.IO.Path.GetExtension(sSourceFilePath);
          this._mTargetTaskFilePath = document.FullFileName;
          this.SetTutorialDockableWindowVisiblity(true);
        }
        //else
          //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, TutorialAddinResources.ErrorOpeningFile);
      }
      catch (Exception ex)
      {
        //int num = (int) MessageBox.Show(ex.Message);
        //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, TutorialAddinResources.ErrorOpeningFile);
      }
    }

    public void LoadTaskForEdit(string sSourceFilePath)
    {
      try
      {
        if (!WindowsAPIs.IsFileExist(sSourceFilePath))
          return;
        DocumentTypeEnum docType = DocumentTypeEnum.kUnknownDocumentObject;
        if (!this.IsValidFiletype(sSourceFilePath, ref docType))
          return;
        this.ExitTaskEdit();
        IDocument DocumentObject = this._OpenTutorialDocument(sSourceFilePath, docType, true);
        if (DocumentObject != null)
        {
          this._mEditingTaskFilePath = DocumentObject.FullFileName;
          this._accessEventsHandling.InitializeFileDirty(this._mTargetDirectory);
          // ISSUE: method pointer
          //this.MApplicationEvents.add_OnNewEditObject(new ApplicationEventsSink_OnNewEditObjectEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnNewEditObject)));
          this._inventorApp.TutorialsManager.SetDocumentTabTutorialColor(DocumentObject);
        }
        //else
         // FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, TutorialAddinResources.ErrorOpeningFile);
      }
      catch (Exception ex)
      {
        //int num = (int) MessageBox.Show(ex.Message);
        //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, TutorialAddinResources.ErrorOpeningFile);
      }
    }

    public bool CloseTutorialDocument()
    {
      bool flag = false;
      try
      {
        IDocument tutorialDocument = this.GetTutorialDocument();
        if (tutorialDocument != null)
        {
          this._mTargetTaskFilePath = "";
          tutorialDocument.Close(true);
          this.RestorePreviousInventorProject();
          flag = true;
        }
      }
      catch (Exception ex)
      {
        //int num = (int) MessageBox.Show(ex.Message);
      }
      return flag;
    }

    public void ExitTaskEdit()
    {
      if (this.TutorialEventsHandlerObject == null || this._mEditingTaskFilePath.Length <= 0)
        return;
      foreach (IDocument document in InteractiveTutorialServer.Instance.InventorApplication.Documents)
      {
        if (string.Compare(document.FullFileName, this._mEditingTaskFilePath, StringComparison.OrdinalIgnoreCase) == 0)
        {
          this._bExitTaskEdit = true;
          bool silentOperation = InteractiveTutorialServer.Instance.InventorApplication.SilentOperation;
          InteractiveTutorialServer.Instance.InventorApplication.SilentOperation = true;
          document.Close();
          InteractiveTutorialServer.Instance.InventorApplication.SilentOperation = silentOperation;
          this._mEditingTaskFilePath = "";
          this._accessEventsHandling.RemoveFileDirtyHandler();
          // ISSUE: method pointer
          //InteractiveTutorialServer.Instance.MApplicationEvents.remove_OnNewEditObject(new ApplicationEventsSink_OnNewEditObjectEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnNewEditObject)));
          this._bExitTaskEdit = false;
          break;
        }
      }
      this.CleanUpTempTutorialDataFolder();
    }

    private void PlayVideo(string sVideoPath)
    {
      try
      {
        if (this._inventorApp == null)
          return;
        this._inventorApp.TutorialsManager.PlayVideo(sVideoPath);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void CleanUpTempTutorialDataFolder()
    {
      if (!Directory.Exists(TutorialsData.TutorialFolder()))
        return;
      try
      {
        if (this._inventorApp != null && this._inventorApp.Documents.Count > 0)
          this._inventorApp.Documents.CloseAll(true);
        WindowsAPIs.DeleteDirectory(TutorialsData.TutorialFolder());
      }
      catch (Exception ex)
      {
      }
    }

    private string _CopyFileToTemp(string sSourceFilePath)
    {
      int count = sSourceFilePath.LastIndexOf(".");
      string temp = this._mTargetDirectory + "\\" + this._mTutorialDocName + sSourceFilePath.Remove(0, count);
      if (WindowsAPIs.IsDirectoryExist(this._mTargetDirectory))
        WindowsAPIs.DeleteDirectory(this._mTargetDirectory);
      WindowsAPIs.CreateDirectory(this._mTargetDirectory);
      string directoryName = System.IO.Path.GetDirectoryName(sSourceFilePath);
      string destDirName = this._mTargetDirectory + "\\";
      WindowsAPIs.DirectoryCopy(directoryName, destDirName, true, true);
      string str = System.IO.Path.GetDirectoryName(directoryName) + "\\SharedFiles\\";
      if (Directory.Exists(str))
        WindowsAPIs.DirectoryCopy(str, destDirName, true);
      WindowsAPIs.ChangeFileAttributesRecursively(this._mTargetDirectory, FileAttributes.Normal);
      WindowsAPIs.CopyFile(sSourceFilePath, temp, true);
      WindowsAPIs.SetFileAttributes(temp, FileAttributes.Normal);
      return temp;
    }

    private IDocument _OpenTutorialDocument(
      string sSourceFilePath,
      DocumentTypeEnum docType,
      bool bCopyToTemp = false)
    {
      if (this._inventorApp == null)
        return (IDocument) null;
      if (docType != DocumentTypeEnum.kAssemblyDocumentObject && docType != DocumentTypeEnum.kPartDocumentObject && docType != DocumentTypeEnum.kDrawingDocumentObject && docType != DocumentTypeEnum.kPresentationDocumentObject)
        return (IDocument) null;
      InteractiveTutorialServer.Instance.InventorApplication.CommandManager.StopActiveCommand();
      string str = sSourceFilePath;
      if (bCopyToTemp)
        str = this._CopyFileToTemp(sSourceFilePath);
      List<string> serachPathList = new List<string>();
      string directoryName = System.IO.Path.GetDirectoryName(str);
      serachPathList.Add(directoryName);
      string path = System.IO.Path.GetDirectoryName(directoryName) + "\\SharedFiles\\";
      if (Directory.Exists(path))
        serachPathList.Add(path);
      this._accessEventsHandling.InitializeFileResolution(serachPathList);
      bool mruEnabled = this._inventorApp.MRUEnabled;
      this._inventorApp.MRUEnabled = false;
      bool silentOperation = this._inventorApp.SilentOperation;
      this._inventorApp.SilentOperation = true;
      IDocument document;
      if (docType == DocumentTypeEnum.kAssemblyDocumentObject)
      {
        INameValueMap nameValueMap = this._inventorApp.TransientObjects.CreateNameValueMap();
        nameValueMap.Add("DesignViewRepresentation", (object) "Default");
        try
        {
          document = this._inventorApp.Documents.OpenWithOptions(str, nameValueMap);
        }
        catch (Exception ex)
        {
          document = this._inventorApp.Documents.Open(str);
        }
      }
      else
        document = this._inventorApp.Documents.Open(str);
      this._inventorApp.SilentOperation = silentOperation;
      this._inventorApp.MRUEnabled = mruEnabled;
      this._accessEventsHandling.RemoveFileResolutionHandler();
      return document;
    }

    private bool IsValidFiletype(string sSourceFilePath, ref DocumentTypeEnum docType)
    {
      docType = DocumentTypeEnum.kUnknownDocumentObject;
      bool flag = false;
      string extension = System.IO.Path.GetExtension(sSourceFilePath);
      if (extension.Length > 0)
      {
        if (extension == ".opt")
        {
          docType = DocumentTypeEnum.kPartDocumentObject;
          flag = true;
        }
        else if (extension == ".oam")
        {
          docType = DocumentTypeEnum.kAssemblyDocumentObject;
          flag = true;
        }
        else if (extension == ".odw")
        {
          docType = DocumentTypeEnum.kDrawingDocumentObject;
          flag = true;
        }
        else if (extension == ".dwg")
        {
          docType = DocumentTypeEnum.kDrawingDocumentObject;
          flag = true;
        }
        else if (extension == ".opn")
        {
          docType = DocumentTypeEnum.kPresentationDocumentObject;
          flag = true;
        }
        else if (extension == ".ode")
        {
          docType = DocumentTypeEnum.kDesignElementDocumentObject;
          flag = true;
        }
        else
        {
          //int num = (int) MessageBox.Show("Warning: Now the file type is not supported!");
        }
      }
      return flag;
    }

    private void SwitchToTutorialProject(string modelDataFolder)
    {
      IDesignProjectManager designProjectManager = this._inventorApp.DesignProjectManager;
      if (designProjectManager == null)
        return;
      IDesignProject activeDesignProject = this._inventorApp.DesignProjectManager.ActiveDesignProject;
      if (activeDesignProject == null)
        return;
      string fullFileName = activeDesignProject.FullFileName;
      string productVersionPath = InteractiveTutorialServer.Instance.TEEventsHandler.TutorialsApiHelper.GetProductVersionPath();
      string str = System.IO.Path.Combine(productVersionPath, "TutorialData.opj");
      if (string.Compare(fullFileName, str, true) != 0)
      {
        if (this._inventorApp.Documents.Count > 0)
        {
          //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, TutorialAddinResources.NeedToCloseOpenDocuments);
        }
        else
        {
          try
          {
            IDesignProject designProject = !WindowsAPIs.IsFileExist(str) ? designProjectManager.DesignProjects.Add(MultiUserModeEnum.kSingleUserMode, "TutorialData.ipj", productVersionPath) : designProjectManager.DesignProjects.AddExisting(str);
            if (designProject == null)
              return;
            this._mPreviousProjectPath = activeDesignProject.FullFileName;
            designProject.WorkspacePath = modelDataFolder;
            designProject.Activate();
          }
          catch (Exception ex)
          {
            //int num = (int) MessageBox.Show(ex.Message);
            //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, TutorialAddinResources.ErrorActivatingTutorialProject);
          }
        }
      }
      else
      {
        if (string.Compare(activeDesignProject.WorkspacePath, modelDataFolder, true) == 0)
          return;
        activeDesignProject.WorkspacePath = modelDataFolder;
      }
    }

    private void RestorePreviousInventorProject()
    {
      if (string.IsNullOrEmpty(this._mPreviousProjectPath))
        return;
      try
      {
        IDesignProjectManager designProjectManager = this._inventorApp.DesignProjectManager;
        if (designProjectManager != null)
        {
          IDesignProject activeDesignProject = this._inventorApp.DesignProjectManager.ActiveDesignProject;
          if (activeDesignProject != null)
          {
            if (string.Compare(activeDesignProject.FullFileName, InteractiveTutorialServer.Instance.TEEventsHandler.TutorialsApiHelper.GetProductVersionPath() + "TutorialData.ipj", true) == 0)
            {
              int count = this._inventorApp.Documents.Count;
              if (count > 0)
              {
                this._inventorApp.Documents.CloseAll(true);
                count = this._inventorApp.Documents.Count;
              }
              if (count == 0)
              {
                try
                {
                  designProjectManager.DesignProjects[this._mPreviousProjectPath]?.Activate();
                }
                catch (Exception ex)
                {
                }
              }
              else
              {
                //string iMessage = string.Format(TutorialAddinResources.CouldNotRestorePreviousInventorProject, (object) this._mPreviousProjectPath);
                //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, iMessage);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        //int num = (int) MessageBox.Show(ex.Message);
        //string iMessage = string.Format(TutorialAddinResources.CouldNotRestorePreviousInventorProject, (object) this._mPreviousProjectPath);
        //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, iMessage);
      }
      this._mPreviousProjectPath = "";
    }

    private void UserInputEvents_OnActivate(string commandName, INameValueMap context)
    {
      try
      {
        if (commandName == "AppCleanScreenCmd" && this.MWebBrowserDockableWindow != null && this.MWebBrowserDockableWindow.Visible)
        {
          //int num = (int) MessageBox.Show(TutorialAddinResources.CannotDoCleanScreen, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          context.Add("HandlingCode", (object) HandlingCodeEnum.kEventCanceled);
        }
        else
        {
          string name;
          if (commandName == "PlayTutorialCmd")
          {
            name = "TutorialName";
          }
          else
          {
            if (!(commandName == "PlayTutorialVideoCmd"))
              return;
            name = "VideoName";
          }
          IControlDefinition controlDefinition = this._inventorApp.CommandManager.ControlDefinitions[commandName];
          if (controlDefinition == null || !(controlDefinition.ClientId == "{4d9c80fe-e70f-4c29-b6c7-8a5ac3f40eb2}".ToUpper()) || context.Count <= 0)
            return;
          string contextItem = this.GetContextItem(context, name);
          if (contextItem.Length <= 0)
            return;
          if (commandName == "PlayTutorialCmd")
          {
            string str = InteractiveTutorialServer.Instance.TEEventsHandler.ResponseChannelName;
            if (str == null || str.Length <= 0)
              str = "guided-tutorial-response-channel-000000";
            string url = InteractiveTutorialServer.Instance.TEEventsHandler.TutorialsApiHelper.GetTutorialURLBase() + "/" + "engine#/play/" + InteractiveTutorialServer.Instance.TEEventsHandler.TutorialsApiHelper.GetProductVersionLangPath() + "/" + HttpUtility.UrlPathEncode(contextItem) + "?channel=" + str + "?mode=" + Mode.Value + "?user=" + System.Environment.UserName + "?tutorialLanguage=" + InteractiveTutorialServer.Instance.TEEventsHandler.TutorialsApiHelper.GetLanguage();
            InteractiveTutorialServer.Instance.TEEventsHandler.PlaybackApiHelper.WebBrowserNavigate(url);
          }
          else
          {
            if (!(commandName == "PlayTutorialVideoCmd"))
              return;
            this.PlayVideo(InteractiveTutorialServer.Instance.TEEventsHandler.TutorialsApiHelper.GetPlugInDocStorePath() + "\\" + InteractiveTutorialServer.Instance.TEEventsHandler.TutorialsApiHelper.GetProductVersionLangPath() + "\\" + contextItem);
          }
        }
      }
      catch (Exception ex)
      {
        //int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void ApplicationEvents_OnActivateDocument(
      IDocument DocumentObject,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventNotHandled;
      if (BeforeOrAfter != EventTimingEnum.kAfter)
        return;
      if (InteractiveTutorialServer.Instance.TEEventsHandler.BInitializedWebSocketConnection && (string.IsNullOrEmpty(this._mTargetTaskFilePath) || string.IsNullOrEmpty(DocumentObject.FullFileName) || string.Compare(DocumentObject.FullFileName, this._mTargetTaskFilePath, StringComparison.OrdinalIgnoreCase) != 0))
        InteractiveTutorialServer.Instance.TEEventsHandler.CaptureEvents.IsActiveDocumentValid();
      if (string.IsNullOrEmpty(this._mTargetTaskFilePath) || string.Compare(DocumentObject.FullFileName, this._mTargetTaskFilePath, StringComparison.OrdinalIgnoreCase) != 0)
        return;
      this.SetTutorialDockableWindowVisiblity(true);
    }

    private void ApplicationEvents_OnDeactivateDocument(
      IDocument DocumentObject,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventNotHandled;
      if (BeforeOrAfter != EventTimingEnum.kBefore)
        return;
      if (InteractiveTutorialServer.Instance.TEEventsHandler.BInitializedWebSocketConnection && (string.IsNullOrEmpty(this._mEditingTaskFilePath) || string.IsNullOrEmpty(DocumentObject.FullFileName) || string.Compare(DocumentObject.FullFileName, this._mEditingTaskFilePath, StringComparison.OrdinalIgnoreCase) != 0))
      {
        bool bUseActive = false;
        InteractiveTutorialServer.Instance.TEEventsHandler.CaptureEvents.IsActiveDocumentValid(bUseActive);
      }
      if (string.IsNullOrEmpty(this._mTargetTaskFilePath) || string.Compare(DocumentObject.FullFileName, this._mTargetTaskFilePath, StringComparison.OrdinalIgnoreCase) != 0)
        return;
      this.SetTutorialDockableWindowVisiblity(false);
    }

    private void ApplicationEvents_OnTerminateDocument(
      IDocument DocumentObject,
      string FullDocumentName,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventNotHandled;
      if (BeforeOrAfter != EventTimingEnum.kAfter)
        return;
      if (!string.IsNullOrEmpty(this._mTargetTaskFilePath) && string.Compare(FullDocumentName, this._mTargetTaskFilePath, StringComparison.OrdinalIgnoreCase) == 0)
      {
        this._mTargetTaskFilePath = "";
        this.RestorePreviousInventorProject();
        this.SetTutorialDockableWindowVisiblity(false);
      }
      else
      {
        if (string.IsNullOrWhiteSpace(this._mEditingTaskFilePath) || string.Compare(FullDocumentName, this._mEditingTaskFilePath, StringComparison.OrdinalIgnoreCase) != 0 || this._bExitTaskEdit)
          return;
        InteractiveTutorialServer.Instance.TEEventsHandler.SendToggleActiveStep();
      }
    }

    private void ApplicationEvents_OnSaveDocument(
      IDocument DocumentObject,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventHandled;
      if (BeforeOrAfter != EventTimingEnum.kBefore || !DocumentObject.FullFileName.Replace('/', '\\').ToLower().Contains(ServerData.PluginDocStorePath().Replace('/', '\\').ToLower()))
        return;
      for (int Index = 1; Index < Context.Count; ++Index)
      {
        //if (Context.GetEnumerator().== "SaveFileName")
        {
          //FwModalDialogs.WarningMessage(this._inventorApp, InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName, TutorialAddinResources.DontModifyFileUnderDocStore);
          HandlingCode = HandlingCodeEnum.kEventCanceled;
          break;
        }
      }
    }

    private void ApplicationEvents_OnActivateWebView(
      IWebView WebView,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum handlingCode)
    {
      handlingCode = HandlingCodeEnum.kEventNotHandled;
    }

    private void ApplicationEvents_OnNewEditObject(
      object EditObject,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventNotHandled;
      if (BeforeOrAfter != EventTimingEnum.kAfter || EditObject == null)
        return;
      this.TutorialEventsHandlerObject.CaptureEvents.CaptureSketch();
    }
  }