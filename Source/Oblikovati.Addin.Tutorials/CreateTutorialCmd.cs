using Oblikovati.Addin.Tutorials.Properties;
using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

internal class CreateTutorialCmd : Command
  {
    public static string CreateTutorialCmdName = nameof (CreateTutorialCmd);

    public CreateTutorialCmd(
      InteractiveTutorialServer interactiveTutorialServer)
      : base(interactiveTutorialServer)
    {
    }

    public void CreateButton() => this.CreateButton(this.InteractiveTutorialServerObj.InventorApplication,
        Resources.CreateTutorialCmd, CreateTutorialCmd.CreateTutorialCmdName, 
        CommandTypesEnum.kShapeEditCmdType,  this.InteractiveTutorialServerObj.AddInCLSIDString, 
        (string) null, (string) null, (object) null, (object) null);

    protected override void ButtonDefinition_OnExecute(INameValueMap context)
    {
      if (this.m_commandIsRunning)
        this.StopCommand();
      this.StartCommand();
    }

    public override void OnHelp(
      EventTimingEnum beforeOrAfter,
      INameValueMap context,
      out HandlingCodeEnum handlingCode)
    {
      this.InteractiveTutorialServerObj.InventorApplication.HelpManager.DisplayHelpTopic("TutorialHelp.chm", "");
      handlingCode = HandlingCodeEnum.kEventHandled;
    }

    public override void StartCommand() => this.StartCommandAtUrl(this.InteractiveTutorialServerObj.TEEventsHandler.TutorialsApiHelper.GetTutorialEngineURL());

    public void StartCommandAtUrl(string engineUrl)
    {
      try
      {
        base.StartCommand();
        this.InteractiveTutorialServerObj.TEEventsHandler.PlaybackApiHelper.WebBrowserNavigate(engineUrl);
        IDocument activeDocument = this.InteractiveTutorialServerObj.InventorApplication.ActiveDocument;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public override void ExecuteCommand() => this.StopCommand();

    public override void StopCommand()
    {
      this.DisableInteraction();
      base.StopCommand();
    }

    public override void EnableInteraction()
    {
      base.EnableInteraction();
      this.m_selectEvents.ClearSelectionFilter();
      this.m_selectEvents.ResetSelections();
      this.m_selectEvents.AddSelectionFilter(SelectionFilterEnum.kAllEntitiesFilter);
      this.m_selectEvents.SingleSelectEnabled = true;
      this.m_interactionEvents.StatusBarText = Resources.CreateTutorialStatusBarMsg;
    }

    public override void OnPreSelect(
      ref object preSelectEntity,
      out bool doHighlight,
      ref IObjectCollection morePreSelectEntities,
      SelectionDeviceEnum selectionDevice,
      IPoint modelPosition,
      IPoint2d viewPosition,
      IView view)
    {
      doHighlight = false;
    }

    public override void OnSelect(
      IObjectsEnumerator justSelectedEntities,
      SelectionDeviceEnum selectionDevice,
      IPoint modelPosition,
      IPoint2d viewPosition,
      IView view)
    {
      if (justSelectedEntities.Count <= 0)
        return;
      object justSelectedEntity = justSelectedEntities[1];
      if ((IComponentOccurrence) justSelectedEntity == null)
        return;
      this.m_selectEvents.AddToSelectedEntities(justSelectedEntity);
    }
  }