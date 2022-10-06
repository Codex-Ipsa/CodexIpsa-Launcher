namespace MCLauncher.controls
{
    partial class SettingsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsScreen));
            this.grbLauncher = new System.Windows.Forms.GroupBox();
            this.lblLang = new System.Windows.Forms.Label();
            this.cmbLangSelect = new System.Windows.Forms.ComboBox();
            this.grbUpdates = new System.Windows.Forms.GroupBox();
            this.btnCheckUpdates = new System.Windows.Forms.Button();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbUpdateSelect = new System.Windows.Forms.ComboBox();
            this.grbLauncher.SuspendLayout();
            this.grbUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLauncher
            // 
            this.grbLauncher.BackColor = System.Drawing.Color.Transparent;
            this.grbLauncher.Controls.Add(this.lblLang);
            this.grbLauncher.Controls.Add(this.cmbLangSelect);
            this.grbLauncher.ForeColor = System.Drawing.Color.White;
            this.grbLauncher.Location = new System.Drawing.Point(169, 116);
            this.grbLauncher.Name = "grbLauncher";
            this.grbLauncher.Size = new System.Drawing.Size(446, 58);
            this.grbLauncher.TabIndex = 18;
            this.grbLauncher.TabStop = false;
            this.grbLauncher.Text = "grb.launcher";
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Location = new System.Drawing.Point(6, 22);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(64, 13);
            this.lblLang.TabIndex = 1;
            this.lblLang.Text = "lbl.language";
            // 
            // cmbLangSelect
            // 
            this.cmbLangSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLangSelect.FormattingEnabled = true;
            this.cmbLangSelect.Location = new System.Drawing.Point(110, 19);
            this.cmbLangSelect.Name = "cmbLangSelect";
            this.cmbLangSelect.Size = new System.Drawing.Size(330, 21);
            this.cmbLangSelect.TabIndex = 0;
            // 
            // grbUpdates
            // 
            this.grbUpdates.BackColor = System.Drawing.Color.Transparent;
            this.grbUpdates.Controls.Add(this.btnCheckUpdates);
            this.grbUpdates.Controls.Add(this.lblBranch);
            this.grbUpdates.Controls.Add(this.cmbUpdateSelect);
            this.grbUpdates.ForeColor = System.Drawing.Color.White;
            this.grbUpdates.Location = new System.Drawing.Point(169, 180);
            this.grbUpdates.Name = "grbUpdates";
            this.grbUpdates.Size = new System.Drawing.Size(446, 90);
            this.grbUpdates.TabIndex = 19;
            this.grbUpdates.TabStop = false;
            this.grbUpdates.Text = "grb.updates";
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.ForeColor = System.Drawing.Color.Black;
            this.btnCheckUpdates.Location = new System.Drawing.Point(5, 52);
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.Size = new System.Drawing.Size(434, 23);
            this.btnCheckUpdates.TabIndex = 3;
            this.btnCheckUpdates.Text = "btn.checkUpdates";
            this.btnCheckUpdates.UseVisualStyleBackColor = true;
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(6, 22);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(53, 13);
            this.lblBranch.TabIndex = 1;
            this.lblBranch.Text = "lbl.branch";
            // 
            // cmbUpdateSelect
            // 
            this.cmbUpdateSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateSelect.ForeColor = System.Drawing.Color.Black;
            this.cmbUpdateSelect.FormattingEnabled = true;
            this.cmbUpdateSelect.Location = new System.Drawing.Point(110, 19);
            this.cmbUpdateSelect.Name = "cmbUpdateSelect";
            this.cmbUpdateSelect.Size = new System.Drawing.Size(330, 21);
            this.cmbUpdateSelect.TabIndex = 0;
            this.cmbUpdateSelect.SelectedIndexChanged += new System.EventHandler(this.cmbUpdateSelect_SelectedIndexChanged);
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.grbLauncher);
            this.Controls.Add(this.grbUpdates);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SettingsScreen";
            this.Size = new System.Drawing.Size(784, 387);
            this.grbLauncher.ResumeLayout(false);
            this.grbLauncher.PerformLayout();
            this.grbUpdates.ResumeLayout(false);
            this.grbUpdates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbLauncher;
        private System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.ComboBox cmbLangSelect;
        private System.Windows.Forms.GroupBox grbUpdates;
        private System.Windows.Forms.Button btnCheckUpdates;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbUpdateSelect;
    }
}
