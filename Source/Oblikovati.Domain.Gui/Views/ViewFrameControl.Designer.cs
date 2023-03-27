namespace Oblikovati.Domain.Gui.Views
{
    partial class ViewFrameControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelView = new System.Windows.Forms.Panel();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Margin = new System.Windows.Forms.Padding(0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(1085, 702);
            this.panelView.TabIndex = 0;
            // 
            // panelTabs
            // 
            this.panelTabs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTabs.Location = new System.Drawing.Point(0, 705);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(1085, 41);
            this.panelTabs.TabIndex = 1;
            // 
            // ViewFrameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTabs);
            this.Controls.Add(this.panelView);
            this.Name = "ViewFrameControl";
            this.Size = new System.Drawing.Size(1085, 746);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelView;
        private Panel panelTabs;
    }
}
