using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

internal class FileAccessEventsHandling
  {
    private readonly IApplication _inventorApp;
    private List<string> _searchPaths;
    private IFileAccessEvents _fileAccessEvents;
    private string _folderForDirtyMornitor;
    private TutorialEventsHandler _eventsHandler;

    internal FileAccessEventsHandling(IApplication app, TutorialEventsHandler eventsHandler)
    {
      this._inventorApp = app;
      this._eventsHandler = eventsHandler;
      if (this._inventorApp == null)
        return;
      this._fileAccessEvents = this._inventorApp.FileAccessEvents;
    }

    internal void InitializeFileResolution(List<string> serachPathList)
    {
      if (this._fileAccessEvents == null)
        return;
      this._searchPaths = serachPathList;
      // ISSUE: method pointer
     // this._fileAccessEvents.add_OnFileResolution(new FileAccessEventsSink_OnFileResolutionEventHandler((object) this, (UIntPtr) __methodptr(OnFileResolutionEventHandler)));
    }

    internal void InitializeFileDirty(string folderForDirtyMornitor)
    {
      if (this._fileAccessEvents == null)
        return;
      this._folderForDirtyMornitor = folderForDirtyMornitor.Replace('/', '\\').ToLower();
      // ISSUE: method pointer
      //this._fileAccessEvents.add_OnFileDirty(new FileAccessEventsSink_OnFileDirtyEventHandler((object) this, (UIntPtr) __methodptr(OnFileDirtyEventHandler)));
    }

    internal void RemoveFileResolutionHandler()
    {
      if (this._fileAccessEvents == null)
        return;
      // ISSUE: method pointer
      //this._fileAccessEvents.remove_OnFileResolution(new FileAccessEventsSink_OnFileResolutionEventHandler((object) this, (UIntPtr) __methodptr(OnFileResolutionEventHandler)));
      this._searchPaths = (List<string>) null;
    }

    internal void RemoveFileDirtyHandler()
    {
      if (this._fileAccessEvents == null)
        return;
      // ISSUE: method pointer
      //this._fileAccessEvents.remove_OnFileDirty(new FileAccessEventsSink_OnFileDirtyEventHandler((object) this, (UIntPtr) __methodptr(OnFileDirtyEventHandler)));
      this._folderForDirtyMornitor = (string) null;
    }

    public void OnFileResolutionEventHandler(
      string RelativeFileName,
      string LibraryName,
      ref byte[] CustomLogicalName,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out string FullFileName,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventHandled;
      FullFileName = "";
      if (BeforeOrAfter != EventTimingEnum.kAfter || this._searchPaths == null)
        return;
      if (this._searchPaths.Count <= 0)
        return;
      try
      {
        string fileName = System.IO.Path.GetFileName(RelativeFileName);
        foreach (string searchPath in this._searchPaths)
        {
          string str = WindowsAPIs.DirectorySearch(searchPath, fileName);
          if (str.Length > 0)
          {
            FullFileName = str + "\\" + fileName;
            break;
          }
        }
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        FullFileName = "";
        HandlingCode = HandlingCodeEnum.kEventNotHandled;
      }
    }

    public void OnFileDirtyEventHandler(
      string RelativeFileName,
      string LibraryName,
      ref byte[] CustomLogicalName,
      string FullFileName,
      IDocument Document,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventHandled;
      if (string.IsNullOrEmpty(this._folderForDirtyMornitor) || !FullFileName.Replace('/', '\\').ToLower().Contains(this._folderForDirtyMornitor))
        return;
      this._eventsHandler.SendModelDirty();
    }
  }