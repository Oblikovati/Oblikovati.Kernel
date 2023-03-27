using Oblikovati.Domain.Core;
using WeifenLuo.WinFormsUI.Docking;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class BrowserPane : DockContent,  IBrowserPane
{
    public BrowserPane()
    {
        InitializeComponent();
        AutoScaleMode = AutoScaleMode.Dpi;
        DockAreas = DockAreas.DockLeft | DockAreas.Float;
    }

    protected FlowLayoutPanel flowLayoutPanel;
    private SearchBox searchBox;

    public IApplicationBase Application { get; set; }
    public IDocument Parent { get; set; }
    public string Name { get; set; }
    public bool BuiltIn { get; set; }
    public bool TreeBrowser { get; set; }
    public string InternalName { get; set; }
    public object Control { get; set; }
    public IBrowserNode TopNode { get; set; }
    public bool Visible { get; set; }
    public bool Default { get; set; }
    public bool Transient { get; set; }
    public ISearchBox SearchBox { get; set; }
    public void Activate()
    {
        throw new NotImplementedException();
    }

    public void Deactivate()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Reorder(IBrowserNode TargetNode, bool Before, IBrowserNode StartNode, object EndNode)
    {
        throw new NotImplementedException();
    }

    public void Refresh()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public IBrowserFolder AddBrowserFolder(string Name, object BrowserNodes)
    {
        throw new NotImplementedException();
    }

    public IBrowserNode GetBrowserNodeFromObject(object NativeObject)
    {
        throw new NotImplementedException();
    }

    public void ClearPreSelect()
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

    public void add_OnActivate(BrowserPaneSink_OnActivateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnActivate(BrowserPaneSink_OnActivateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnDeactivate(BrowserPaneSink_OnDeactivateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnDeactivate(BrowserPaneSink_OnDeactivateEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnHelp(BrowserPaneSink_OnHelpEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnHelp(BrowserPaneSink_OnHelpEventHandler handler)
    {
        throw new NotImplementedException();
    }

    private void InitializeComponent()
    {
            this.searchBox = new Oblikovati.Domain.Gui.BrowserPanes.SearchBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Application = null;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBox.Enabled = false;
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Name = "searchBox";
            this.searchBox.Parent = null;
            this.searchBox.SearchBoxEvents = null;
            this.searchBox.SearchFilter = Oblikovati.Domain.Core.SearchBoxFilterEnum.kUnresolvedFiles;
            this.searchBox.SearchText = null;
            this.searchBox.Size = new System.Drawing.Size(360, 34);
            this.searchBox.TabIndex = 0;
            this.searchBox.Visible = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 34);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(360, 497);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // BrowserPane
            // 
            this.ClientSize = new System.Drawing.Size(360, 531);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.searchBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowserPane";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Model";
            this.ResumeLayout(false);

    }
}