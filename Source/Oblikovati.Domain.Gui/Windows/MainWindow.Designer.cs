namespace Oblikovati.Domain.Gui.Windows
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ribbonContext = new System.Windows.Forms.RibbonContext();
            this.ribbonContext1 = new System.Windows.Forms.RibbonContext();
            this.SuspendLayout();
            // 
            // ribbonContext
            // 
            this.ribbonContext.GlowColor = System.Drawing.Color.Empty;
            this.ribbonContext.Text = null;
            // 
            // ribbonContext1
            // 
            this.ribbonContext1.GlowColor = System.Drawing.Color.Empty;
            this.ribbonContext1.Text = null;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private RibbonContext ribbonContext;
        private RibbonContext ribbonContext1;
    }
}