namespace Oblikovati.Domain.Gui.Views
{
    partial class ViewTabControl
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
            this.viewTabControlLabel = new System.Windows.Forms.Label();
            this.viewTabControlCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewTabControlLabel
            // 
            this.viewTabControlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewTabControlLabel.AutoSize = true;
            this.viewTabControlLabel.Location = new System.Drawing.Point(3, 7);
            this.viewTabControlLabel.Name = "viewTabControlLabel";
            this.viewTabControlLabel.Size = new System.Drawing.Size(120, 20);
            this.viewTabControlLabel.TabIndex = 0;
            this.viewTabControlLabel.Text = "BigFileName.opt";
            // 
            // viewTabControlCloseButton
            // 
            this.viewTabControlCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewTabControlCloseButton.Location = new System.Drawing.Point(129, 3);
            this.viewTabControlCloseButton.Name = "viewTabControlCloseButton";
            this.viewTabControlCloseButton.Size = new System.Drawing.Size(25, 25);
            this.viewTabControlCloseButton.TabIndex = 1;
            this.viewTabControlCloseButton.Text = "X";
            this.viewTabControlCloseButton.UseVisualStyleBackColor = true;
            // 
            // ViewTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewTabControlCloseButton);
            this.Controls.Add(this.viewTabControlLabel);
            this.Name = "ViewTabControl";
            this.Size = new System.Drawing.Size(160, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Label viewTabControlLabel;
        protected Button viewTabControlCloseButton;
    }
}
