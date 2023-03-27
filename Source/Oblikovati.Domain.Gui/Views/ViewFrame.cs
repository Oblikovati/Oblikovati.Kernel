using Oblikovati.Domain.Core;
using WeifenLuo.WinFormsUI.Docking;

namespace Oblikovati.Domain.Gui.Views;

public class ViewFrame : DockContent, IViewFrame, IDockableWindow
{
    protected View view;
    private IUserInterfaceManager _parent;

    public ViewFrame(IApplication application, IApplication parent)
    {
        Application = application;
        Parent = parent;
        ViewTabs = new ViewTabsEnumerator(Application);
        AutoScaleMode = AutoScaleMode.Dpi;
        DockAreas = DockAreas.Document | DockAreas.Float;
    }

    public IApplication Application { get; set; }
    public string ClientId { get; set; }
    public object Control { get; set; }
    public DockingStateEnum DisabledDockingStates { get; set; }
    public DockingStateEnum DockingState { get; set; }
    public int HWND { get; set; }
    public string InternalName { get; set; }

    IUserInterfaceManager IDockableWindow.Parent => _parent;

    public string Title { get; set; }
    IApplicationBase IDockableWindow.Application { get; }
    public IApplication Parent { get; set; }
    public IViewTabsEnumerator ViewTabs { get; set; }
    public IViewTabGroupsEnumerator ViewTabGroups { get; set; }
    public bool IsDefault { get; set; }
    public string Caption { get; set; }
    public bool ShowTitleBar { get; set; }
    public bool IsCustomized { get; set; }
    public IControlDefinition VisibilityControl { get; set; }
    public bool ShowVisibilityCheckBox { get; set; }
    public bool DisableCloseButton { get; set; }
    public void AddChild(object Identifier)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Delete2(bool SaveCurrentStates)
    {
        throw new NotImplementedException();
    }

    public WindowsSizeEnum WindowState { get; set; }
    public void Arrange(object Value)
    {
        throw new NotImplementedException();
    }

    public void RestorePreviousLayout()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public void Move(int Top, int Left, int Height, int Width)
    {
        throw new NotImplementedException();
    }

    public void SetMinimumSize(int Height, int Width)
    {
        throw new NotImplementedException();
    }

    public void GetDockingState(out DockingStateEnum DockingState, out object DockToObject)
    {
        throw new NotImplementedException();
    }

    public void SetDockingState(DockingStateEnum DockingState, object DockToObject)
    {
        throw new NotImplementedException();
    }

    private void InitializeComponent()
    {
            this.view = new Oblikovati.Domain.Gui.Views.View();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.Application = null;
            this.view.AreTexturesOn = false;
            this.view.Camera = null;
            this.view.Caption = null;
            this.view.DisplayMode = Oblikovati.Domain.Core.DisplayModeEnum.kWireframeRendering;
            this.view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view.Document = null;
            this.view.GroundShadow = Oblikovati.Domain.Core.GroundShadowEnum.kNoGroundShadow;
            this.view.IsRayTracingPaused = false;
            this.view.Location = new System.Drawing.Point(0, 0);
            this.view.Name = "view";
            this.view.NavigationBarEnabled = false;
            this.view.Parent = null;
            this.view.RayTracing = false;
            this.view.RayTracingProgress = 0D;
            this.view.RayTracingQuality = Oblikovati.Domain.Core.RayTracingQualityEnum.kInteractiveRayTracingQuality;
            this.view.ShowAmbientShadows = false;
            this.view.ShowGroundPlane = false;
            this.view.ShowGroundReflections = false;
            this.view.ShowGroundShadows = false;
            this.view.ShowObjectShadows = false;
            this.view.Size = new System.Drawing.Size(942, 561);
            this.view.SteeringWheelEnabled = false;
            this.view.TabIndex = 0;
            this.view.ViewCubeEnabled = false;
            this.view.ViewFrame = null;
            this.view.ViewTab = null;
            this.view.WindowState = Oblikovati.Domain.Core.WindowsSizeEnum.kNormalWindow;
            // 
            // ViewFrame
            // 
            this.ClientSize = new System.Drawing.Size(942, 561);
            this.Controls.Add(this.view);
            this.Name = "ViewFrame";
            this.ResumeLayout(false);

    }
}