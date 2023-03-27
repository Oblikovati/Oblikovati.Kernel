using Oblikovati.Domain.Core;
using Oblikovati.Domain.Core.Environments;
using Oblikovati.Domain.Gui.Windows;

namespace Oblikovati.Domain.Gui.UserInterfaceManager;

public class UserInterfaceManager : MainWindow, IUserInterfaceManager
{
    protected UserInterfaceManager() { }
    public UserInterfaceManager(IApplication application, IApplication parent)
    {
        Application = application;
        Parent = parent;
        Environments = new Core.Environments.Environments(Application);
        ParallelEnvironments = new EnvironmentList(Application);
        UserInterfaceEvents = new UserInterfaceEvents(Application, this);
        Ribbons = new Ribbons.Ribbons(Application);
    }

    private IEnvironment activeEnvironment;
    public IApplication Parent { get; set; }
    public IApplication Application { get; set; }
    public ICommandBars CommandBars { get; set; }

    public IEnvironment ActiveEnvironment
    {
        get => activeEnvironment;
        set
        {
            activeEnvironment = value;
            if (Controls.ContainsKey("ribbon"))
                this.Controls.RemoveByKey("ribbon"); 
            Controls.Add(activeEnvironment.Ribbon as Control);
        }
    }

    public IEnvironmentList ParallelEnvironments { get; set; }
    public IEnvironments Environments { get; set; }
    public bool ShowBrowser { get; set; }
    public bool ExpertMode { get; set; }
    public bool LargeIcons { get; set; }
    public bool ShowPanelBar { get; set; }
    public bool ShowToolBar { get; set; }
    public bool ShowStatusBar { get; set; }
    public bool ProgressBarEnabled { get; set; }
    public bool UserInteractionDisabled { get; set; }
    public IUserInterfaceEvents UserInterfaceEvents { get; set; }
    public bool CapacityMeterEnabled { get; set; }
    public IRibbons Ribbons { get; set; }
    public ICommandControls FileBrowserControls { get; set; }
    public RibbonAppearanceEnum RibbonAppearance { get; set; }
    public RibbonDockingStateEnum RibbonDockingState { get; set; }
    public RibbonStateEnum RibbonState { get; set; }
    public bool ShowCleanScreen { get; set; }
    public bool ShowDocumentTabs { get; set; }
    public bool ShowPanelTitles { get; set; }
    public bool ShowQuickAccessControlsBelowRibbon { get; set; }
    public ICommandControls HelpControls { get; set; }
    public InterfaceStyleEnum InterfaceStyle { get; set; }
    public IDockableWindows DockableWindows { get; set; }
    public bool ShowNavigationBar { get; set; }
    public bool ShowSteeringWheel { get; set; }
    public bool ShowViewCube { get; set; }
    public IBalloonTips BalloonTips { get; set; }
    public bool ShowMarkingMenu { get; set; }
    public OverflowMenuBehaviorEnum OverflowMenuBehavior { get; set; }
    public bool PinMiniToolbarPosition { get; set; }
    public void DoEvents()
    {
        throw new NotImplementedException();
    }

    public ICommandControlsEnumerator AllReferencedControls(IControlDefinition Definition)
    {
        throw new NotImplementedException();
    }

    public void ResetRibbonInterface()
    {
        throw new NotImplementedException();
    }

    public string GetCommandPaths(string CommandInternalName, object Environment)
    {
        throw new NotImplementedException();
    }

    public void RegisterFileExtension(INameValueMap pValueMap)
    {
        throw new NotImplementedException();
    }
}