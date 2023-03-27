using Oblikovati.Addin.Tutorials.Properties;

namespace Oblikovati.Addin.Tutorials;

internal class CaptureEvents
  {
    private TutorialEventsHandler TutorialEventsHandler { get; set; }

    public CaptureEvents(TutorialEventsHandler tutorialEventsHandler) => this.TutorialEventsHandler = tutorialEventsHandler;

    internal void CaptureData(string eventName)
    {
      string str = "";
      try
      {
        str = this.TutorialEventsHandler.TutorialsApiHelper.CaptureModel(true);
        bool bAllowDialog = string.IsNullOrWhiteSpace(str);
        if (!bAllowDialog)
        {
          if (!InteractiveTutorialServer.Instance.InventorApplication.ActiveDocument.Dirty)
            goto label_6;
        }
        if (this.LetUserSaveUnsavedDoc())
        {
          this.TutorialEventsHandler.SaveActiveDocument(bAllowDialog);
          str = this.TutorialEventsHandler.TutorialsApiHelper.CaptureModel(true);
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
label_6:
      try
      {
        if (!this.TutorialEventsHandler.ServerCommunicator.IsInitialized)
        {
          int num = (int) MessageBox.Show(Resources.EngineNotRunning);
        }
        else
        {
          if (string.IsNullOrWhiteSpace(str))
            return;
          List<string> referencedDocs;
          this.TutorialEventsHandler.TutorialsApiHelper.GetDocumentDependencies(out referencedDocs);
          ModelDocsData modelDocsData = new ModelDocsData();
          modelDocsData.Dependencies = referencedDocs;
          modelDocsData.Value = str;
          modelDocsData.Target = this.TutorialEventsHandler.ResponseChannelName;
          ModelDocs packet = new ModelDocs();
          packet.LwsEvent = eventName;
          packet.Data = modelDocsData;
          this.TutorialEventsHandler.EmitMessage((PacketBase) packet);
        }
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    internal void IsActiveDocumentValid(bool bUseActive = true)
    {
      try
      {
        string str = bUseActive ? this.TutorialEventsHandler.TutorialsApiHelper.CaptureModel(false) : "";
        StringData stringData = new StringData();
        stringData.Data = str;
        ActiveDoc packet = new ActiveDoc();
        packet.LwsEvent = nameof (IsActiveDocumentValid);
        packet.Data = stringData;
        this.TutorialEventsHandler.EmitMessage((PacketBase) packet);
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    public bool LetUserSaveUnsavedDoc()
    {
      try
      {
        TEUtil.UpdateCulture();
        string displayName = InteractiveTutorialServer.Instance.ThisApplcationAddIn.DisplayName;
        string unsavedActiveDocument = Resources.UnsavedActiveDocument;
        //TODO: this
        //if (FwModalDialogs.YesNoDiaLog(InteractiveTutorialServer.Instance.InventorApplication, displayName, unsavedActiveDocument) == DialogResult.Yes)
        //  return true;
      }
      catch (Exception ex)
      {
        if (ex.HResult == -2147467259)
          return false;
        WindowsAPIs.ShowErrorMessage(ex);
        return false;
      }
      return false;
    }

    internal void CaptureSketch()
    {
      try
      {
        string str = this.TutorialEventsHandler.TutorialsApiHelper.CaptureSketch();
        if (this.TutorialEventsHandler.ServerCommunicator.IsInitialized)
        {
          PropValData propValData1 = new PropValData();
          propValData1.Value = str;
          propValData1.Target = this.TutorialEventsHandler.ResponseChannelName;
          PropValData propValData2 = propValData1;
          PropVal packet = new PropVal();
          packet.LwsEvent = "SetActiveSketch";
          packet.Data = propValData2;
          this.TutorialEventsHandler.EmitMessage((PacketBase) packet);
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
  }