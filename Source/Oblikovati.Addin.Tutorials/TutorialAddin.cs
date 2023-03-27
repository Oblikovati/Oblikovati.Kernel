using System.Reflection;
using System.Runtime.InteropServices;
using Oblikovati.Addin.Tutorials.Properties;
using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

public class InteractiveTutorialServer : IApplicationAddInServer
{
    public static InteractiveTutorialServer Instance;
    internal IApplication InventorApplication;
    internal IApplicationAddIn ThisApplcationAddIn;
    private bool _bInitializedUI;
    private IUserInterfaceEvents _mUserInterfaceEvents;
    private UserInterfaceEventsSink_OnResetRibbonInterfaceEventHandler UserInterfaceEventsSink_OnResetRibbonInterfaceEventDelegate;
    internal IApplicationEvents MApplicationEvents;
    private ApplicationEventsSink_OnQuitEventHandler ApplicationEventsSink_OnQuitEventDelegate;
    internal bool BInventorIsExiting;
    private const string helpPanelInternalName = "TutorialAddInHelpPanel";

    internal string AddInCLSIDString { get; set; }

    internal string InventorTheme { get; set; }

    internal TutorialEventsHandler TEEventsHandler { get; private set; }

    internal CreateTutorialCmd CreateTutorialCmdObject { get; set; }

    internal TutorialsGalleryCmd TutorialsGalleryCmdObject { get; set; }

    internal TutorialWebDialog WebDialog { get; set; }

    private void DeleteRibbonButtons()
    {
      foreach (IRibbon ribbon in this.InventorApplication.UserInterfaceManager.Ribbons)
      {
        try
        {
          if (ribbon != null)
          {
            if (ribbon.RibbonTabs.Count > 0)
            {
              IRibbonTab ribbonTab;
              try
              {
                ribbonTab = ribbon.RibbonTabs["id_GetStarted"];
              }
              catch (ArgumentException ex)
              {
                continue;
              }
              if (ribbonTab != null)
              {
                IRibbonPanel ribbonPanel1;
                try
                {
                  ribbonPanel1 = ribbonTab.RibbonPanels["id_Panel_MyHome"];
                }
                catch (Exception ex)
                {
                  continue;
                }
                if (ribbonPanel1 != null)
                {
                  ribbonPanel1.CommandControls[TutorialsGalleryCmdObject.ButtonDefinition.InternalName]?.Delete();
                  IRibbonPanel ribbonPanel2;
                  try
                  {
                    ribbonPanel2 = ribbonTab.RibbonPanels["TutorialAddInHelpPanel"];
                  }
                  catch (Exception ex)
                  {
                    continue;
                  }
                  ICommandControl commandControl = ribbonPanel1.CommandControls["AppShowHomeBaseHelpCmd"];
                  ribbonPanel2.CommandControls[commandControl.InternalName]?.Delete();
                  if (commandControl != null)
                    commandControl.Visible = true;
                  ribbonPanel2?.Delete();
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
    }

    private void Clear()
    {
      try
      {
        if (this._mUserInterfaceEvents != null)
          this._mUserInterfaceEvents.remove_OnResetRibbonInterface(this.UserInterfaceEventsSink_OnResetRibbonInterfaceEventDelegate);
        this.UserInterfaceEventsSink_OnResetRibbonInterfaceEventDelegate = null;
        if (this.TEEventsHandler != null)
          this.TEEventsHandler.Clear(this.BInventorIsExiting);
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
      this.DeleteRibbonButtons();
      this.InventorApplication = null;
      this.ThisApplcationAddIn = null;
    }

    public void Activate(IApplicationAddInSite addInSiteObject, bool firstTime)
    {
      try
      {
        GuidAttribute customAttribute = (GuidAttribute) System.Attribute.GetCustomAttribute((MemberInfo) typeof (InteractiveTutorialServer), typeof (GuidAttribute));
        if (customAttribute != null)
          this.AddInCLSIDString = "{" + customAttribute.Value + "}";
        InteractiveTutorialServer.Instance = this;
        
        if (this.ThisApplcationAddIn == null)
        {
          foreach (IApplicationAddIn applicationAddIn in this.InventorApplication.ApplicationAddIns)
          {
            //if (string.Equals(applicationAddIn.ClassIdString, this.AddInCLSIDString, StringComparison.OrdinalIgnoreCase))
            //{
            //  this.ThisApplcationAddIn = applicationAddIn;
            //  break;
            //}
          }
        }
        this.TEEventsHandler = new TutorialEventsHandler(this.InventorApplication);
        try
        {
          LocalWebService.Instance().ReadServerConfiguration();
          LocalWebService.Instance().Start((Action<bool>) (bError => this.HandleLwsStartError(bError)));
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(Resources.ServiceDown);
          return;
        }
        this.MApplicationEvents = this.InventorApplication.ApplicationEvents;
        //this.ApplicationEventsSink_OnQuitEventDelegate = new ApplicationEventsSink_OnQuitEventHandler((object) this, (UIntPtr) __methodptr(ApplicationEvents_OnQuit));
        this.MApplicationEvents.add_OnQuit(this.ApplicationEventsSink_OnQuitEventDelegate);
        this._mUserInterfaceEvents = this.InventorApplication.UserInterfaceManager.UserInterfaceEvents;

        //this.UserInterfaceEventsSink_OnResetRibbonInterfaceEventDelegate = new UserInterfaceEventsSink_OnResetRibbonInterfaceEventHandler((object) this, (UIntPtr) __methodptr(UserInterfaceEvents_OnResetRibbonInterface));
        this._mUserInterfaceEvents.remove_OnResetRibbonInterface(this.UserInterfaceEventsSink_OnResetRibbonInterfaceEventDelegate);
        this._mUserInterfaceEvents.add_OnResetRibbonInterface(this.UserInterfaceEventsSink_OnResetRibbonInterfaceEventDelegate);
        this.BInventorIsExiting = false;
        this.InventorTheme = this.InventorApplication.ThemeManager.ActiveTheme.Name;
        this.InitializeUI();
        OfflineMode.Init();
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    public void Deactivate()
    {
      try
      {
        this.Clear();
        GC.WaitForPendingFinalizers();
        GC.Collect();
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    public void ExecuteCommand(int commandID)
    {
    }

    public object Automation => (object) null;

    private void UserInterfaceEvents_OnResetRibbonInterface(INameValueMap context)
    {
      try
      {
        this.AddButtonsToTheRibbon();
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    internal void InitializeUI()
    {
      if (this._bInitializedUI)
        return;
      this._bInitializedUI = true;
      try
      {
        this.CreateTutorialCmdObject = new CreateTutorialCmd(this);
        this.CreateTutorialCmdObject.CreateButton();
        this.TutorialsGalleryCmdObject = new TutorialsGalleryCmd(this);
        this.TutorialsGalleryCmdObject.CreateButton();
        this.WebDialog = new TutorialWebDialog(this);
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
      this.AddButtonsToTheRibbon();
    }

    private void AddButtonsToTheRibbon()
    {
      try
      {
        foreach (IRibbon ribbon in this.InventorApplication.UserInterfaceManager.Ribbons)
        {
          if (ribbon != null)
          {
            IRibbonTab ribbonTab = ribbon.RibbonTabs["id_GetStarted"];
            if (ribbonTab != null)
            {
              IRibbonPanel ribbonPanel1 = ribbonTab.RibbonPanels["id_Panel_MyHome"];
              if (ribbonPanel1 != null)
              {
                ICommandControl control = null;
                try
                {
                  control = ribbonPanel1.CommandControls.AddButton(this.TutorialsGalleryCmdObject.ButtonDefinition, true,true, "AppTeamWebCmd");
                }
                catch
                {
                }
                if (control != null)
                {
                  control.KeyTip = "TU";
                  HighlightNew.SetupControl(control);
                }
                try
                {
                  IRibbonPanel ribbonPanel2 = ribbonTab.RibbonPanels.Add(Resources.HelpPanel, "TutorialAddInHelpPanel", this.AddInCLSIDString, "id_Panel_GetStartedWhatsNew");
                  if (ribbonPanel2 != null)
                  {
                    ICommandControl commandControl = ribbonPanel1.CommandControls["AppShowHomeBaseHelpCmd"];
                    if (commandControl != null)
                    {
                      IButtonDefinition controlDefinition = (IButtonDefinition) commandControl.ControlDefinition;
                      if (controlDefinition != null)
                      {
                        ribbonPanel2.CommandControls.AddButton(controlDefinition, true,true);
                        commandControl.Visible = false;
                      }
                    }
                  }
                }
                catch (Exception ex)
                {
                  WindowsAPIs.ShowErrorMessage(ex);
                }
              }
            }
          }
        }
        HighlightNew.Refresh(this.InventorApplication);
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    private void ApplicationEvents_OnQuit(
      EventTimingEnum beforeOrAfter,
      INameValueMap context,
      out HandlingCodeEnum handlingCode)
    {
      handlingCode = HandlingCodeEnum.kEventNotHandled;
      this.BInventorIsExiting = true;
    }

    private void HandleLwsStartError(bool errorOnStart)
    {
      if (!errorOnStart)
        return;
      this.TEEventsHandler.ShowConnectionFailed();
    }
}
