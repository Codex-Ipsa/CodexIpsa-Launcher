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
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.grbDefaults = new System.Windows.Forms.GroupBox();
            this.btnJre21 = new System.Windows.Forms.Button();
            this.btnGetJava21 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbJre21 = new System.Windows.Forms.ComboBox();
            this.btnGetJava17 = new System.Windows.Forms.Button();
            this.btnGetJava8 = new System.Windows.Forms.Button();
            this.lblJre17 = new System.Windows.Forms.Label();
            this.btnJre17 = new System.Windows.Forms.Button();
            this.cmbJre17 = new System.Windows.Forms.ComboBox();
            this.btnJre8 = new System.Windows.Forms.Button();
            this.lblJre8 = new System.Windows.Forms.Label();
            this.cmbJre8 = new System.Windows.Forms.ComboBox();
            this.grbLauncher = new System.Windows.Forms.GroupBox();
            this.chkDiscordRpc = new System.Windows.Forms.CheckBox();
            this.lblLang = new System.Windows.Forms.Label();
            this.cmbLangSelect = new System.Windows.Forms.ComboBox();
            this.grbUpdates = new System.Windows.Forms.GroupBox();
            this.btnCheckUpdates = new System.Windows.Forms.Button();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbUpdateSelect = new System.Windows.Forms.ComboBox();
            this.pnlCenter.SuspendLayout();
            this.grbDefaults.SuspendLayout();
            this.grbLauncher.SuspendLayout();
            this.grbUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.Transparent;
            this.pnlCenter.Controls.Add(this.grbDefaults);
            this.pnlCenter.Controls.Add(this.grbLauncher);
            this.pnlCenter.Controls.Add(this.grbUpdates);
            this.pnlCenter.Location = new System.Drawing.Point(66, 27);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(446, 311);
            this.pnlCenter.TabIndex = 24;
            // 
            // grbDefaults
            // 
            this.grbDefaults.BackColor = System.Drawing.Color.Transparent;
            this.grbDefaults.Controls.Add(this.btnJre21);
            this.grbDefaults.Controls.Add(this.btnGetJava21);
            this.grbDefaults.Controls.Add(this.label1);
            this.grbDefaults.Controls.Add(this.cmbJre21);
            this.grbDefaults.Controls.Add(this.btnGetJava17);
            this.grbDefaults.Controls.Add(this.btnGetJava8);
            this.grbDefaults.Controls.Add(this.lblJre17);
            this.grbDefaults.Controls.Add(this.btnJre17);
            this.grbDefaults.Controls.Add(this.cmbJre17);
            this.grbDefaults.Controls.Add(this.btnJre8);
            this.grbDefaults.Controls.Add(this.lblJre8);
            this.grbDefaults.Controls.Add(this.cmbJre8);
            this.grbDefaults.ForeColor = System.Drawing.Color.White;
            this.grbDefaults.Location = new System.Drawing.Point(0, 172);
            this.grbDefaults.Name = "grbDefaults";
            this.grbDefaults.Size = new System.Drawing.Size(446, 136);
            this.grbDefaults.TabIndex = 21;
            this.grbDefaults.TabStop = false;
            this.grbDefaults.Text = "grb.defaults";
            // 
            // btnJre21
            // 
            this.btnJre21.ForeColor = System.Drawing.Color.Black;
            this.btnJre21.Location = new System.Drawing.Point(403, 73);
            this.btnJre21.Name = "btnJre21";
            this.btnJre21.Size = new System.Drawing.Size(36, 21);
            this.btnJre21.TabIndex = 33;
            this.btnJre21.Text = "...";
            this.btnJre21.UseVisualStyleBackColor = true;
            this.btnJre21.Click += new System.EventHandler(this.btnJre21_Click);
            // 
            // btnGetJava21
            // 
            this.btnGetJava21.ForeColor = System.Drawing.Color.Black;
            this.btnGetJava21.Location = new System.Drawing.Point(291, 100);
            this.btnGetJava21.Name = "btnGetJava21";
            this.btnGetJava21.Size = new System.Drawing.Size(106, 23);
            this.btnGetJava21.TabIndex = 32;
            this.btnGetJava21.Text = "btn.getJava21";
            this.btnGetJava21.UseVisualStyleBackColor = true;
            this.btnGetJava21.Click += new System.EventHandler(this.btnGetJava21_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "lbl.jre21";
            // 
            // cmbJre21
            // 
            this.cmbJre21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbJre21.FormattingEnabled = true;
            this.cmbJre21.Location = new System.Drawing.Point(67, 73);
            this.cmbJre21.Name = "cmbJre21";
            this.cmbJre21.Size = new System.Drawing.Size(330, 21);
            this.cmbJre21.TabIndex = 30;
            this.cmbJre21.TextUpdate += new System.EventHandler(this.cmbJre21_TextUpdate);
            // 
            // btnGetJava17
            // 
            this.btnGetJava17.ForeColor = System.Drawing.Color.Black;
            this.btnGetJava17.Location = new System.Drawing.Point(179, 100);
            this.btnGetJava17.Name = "btnGetJava17";
            this.btnGetJava17.Size = new System.Drawing.Size(106, 23);
            this.btnGetJava17.TabIndex = 29;
            this.btnGetJava17.Text = "btn.getJava17";
            this.btnGetJava17.UseVisualStyleBackColor = true;
            this.btnGetJava17.Click += new System.EventHandler(this.btnGetJava17_Click);
            // 
            // btnGetJava8
            // 
            this.btnGetJava8.ForeColor = System.Drawing.Color.Black;
            this.btnGetJava8.Location = new System.Drawing.Point(67, 100);
            this.btnGetJava8.Name = "btnGetJava8";
            this.btnGetJava8.Size = new System.Drawing.Size(106, 23);
            this.btnGetJava8.TabIndex = 28;
            this.btnGetJava8.Text = "btn.getJava8";
            this.btnGetJava8.UseVisualStyleBackColor = true;
            this.btnGetJava8.Click += new System.EventHandler(this.btnGetJava8_Click);
            // 
            // lblJre17
            // 
            this.lblJre17.AutoSize = true;
            this.lblJre17.Location = new System.Drawing.Point(6, 49);
            this.lblJre17.Name = "lblJre17";
            this.lblJre17.Size = new System.Drawing.Size(43, 13);
            this.lblJre17.TabIndex = 27;
            this.lblJre17.Text = "lbl.jre17";
            // 
            // btnJre17
            // 
            this.btnJre17.ForeColor = System.Drawing.Color.Black;
            this.btnJre17.Location = new System.Drawing.Point(403, 45);
            this.btnJre17.Name = "btnJre17";
            this.btnJre17.Size = new System.Drawing.Size(36, 21);
            this.btnJre17.TabIndex = 26;
            this.btnJre17.Text = "...";
            this.btnJre17.UseVisualStyleBackColor = true;
            this.btnJre17.Click += new System.EventHandler(this.btnJre17_Click);
            // 
            // cmbJre17
            // 
            this.cmbJre17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbJre17.FormattingEnabled = true;
            this.cmbJre17.Location = new System.Drawing.Point(67, 46);
            this.cmbJre17.Name = "cmbJre17";
            this.cmbJre17.Size = new System.Drawing.Size(330, 21);
            this.cmbJre17.TabIndex = 25;
            this.cmbJre17.TextUpdate += new System.EventHandler(this.cmbJre17_TextUpdate);
            // 
            // btnJre8
            // 
            this.btnJre8.ForeColor = System.Drawing.Color.Black;
            this.btnJre8.Location = new System.Drawing.Point(403, 19);
            this.btnJre8.Name = "btnJre8";
            this.btnJre8.Size = new System.Drawing.Size(36, 21);
            this.btnJre8.TabIndex = 24;
            this.btnJre8.Text = "...";
            this.btnJre8.UseVisualStyleBackColor = true;
            this.btnJre8.Click += new System.EventHandler(this.btnJre8_Click);
            // 
            // lblJre8
            // 
            this.lblJre8.AutoSize = true;
            this.lblJre8.Location = new System.Drawing.Point(6, 22);
            this.lblJre8.Name = "lblJre8";
            this.lblJre8.Size = new System.Drawing.Size(37, 13);
            this.lblJre8.TabIndex = 1;
            this.lblJre8.Text = "lbl.jre8";
            // 
            // cmbJre8
            // 
            this.cmbJre8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbJre8.FormattingEnabled = true;
            this.cmbJre8.Location = new System.Drawing.Point(67, 19);
            this.cmbJre8.Name = "cmbJre8";
            this.cmbJre8.Size = new System.Drawing.Size(330, 21);
            this.cmbJre8.TabIndex = 0;
            this.cmbJre8.TextUpdate += new System.EventHandler(this.cmbJre8_TextUpdate);
            // 
            // grbLauncher
            // 
            this.grbLauncher.BackColor = System.Drawing.Color.Transparent;
            this.grbLauncher.Controls.Add(this.chkDiscordRpc);
            this.grbLauncher.Controls.Add(this.lblLang);
            this.grbLauncher.Controls.Add(this.cmbLangSelect);
            this.grbLauncher.ForeColor = System.Drawing.Color.White;
            this.grbLauncher.Location = new System.Drawing.Point(0, 0);
            this.grbLauncher.Name = "grbLauncher";
            this.grbLauncher.Size = new System.Drawing.Size(446, 70);
            this.grbLauncher.TabIndex = 20;
            this.grbLauncher.TabStop = false;
            this.grbLauncher.Text = "grb.launcher";
            // 
            // chkDiscordRpc
            // 
            this.chkDiscordRpc.AutoSize = true;
            this.chkDiscordRpc.Checked = true;
            this.chkDiscordRpc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiscordRpc.Location = new System.Drawing.Point(9, 48);
            this.chkDiscordRpc.Name = "chkDiscordRpc";
            this.chkDiscordRpc.Size = new System.Drawing.Size(101, 17);
            this.chkDiscordRpc.TabIndex = 2;
            this.chkDiscordRpc.Text = "chk.discordRpc";
            this.chkDiscordRpc.UseVisualStyleBackColor = true;
            this.chkDiscordRpc.CheckedChanged += new System.EventHandler(this.chkDiscordRpc_CheckedChanged);
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
            this.cmbLangSelect.SelectedIndexChanged += new System.EventHandler(this.cmbLangSelect_SelectedIndexChanged);
            // 
            // grbUpdates
            // 
            this.grbUpdates.BackColor = System.Drawing.Color.Transparent;
            this.grbUpdates.Controls.Add(this.btnCheckUpdates);
            this.grbUpdates.Controls.Add(this.lblBranch);
            this.grbUpdates.Controls.Add(this.cmbUpdateSelect);
            this.grbUpdates.ForeColor = System.Drawing.Color.White;
            this.grbUpdates.Location = new System.Drawing.Point(0, 76);
            this.grbUpdates.Name = "grbUpdates";
            this.grbUpdates.Size = new System.Drawing.Size(446, 90);
            this.grbUpdates.TabIndex = 21;
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
            this.cmbUpdateSelect.Location = new System.Drawing.Point(109, 19);
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
            this.Controls.Add(this.pnlCenter);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(784, 387);
            this.Name = "SettingsScreen";
            this.Size = new System.Drawing.Size(784, 387);
            this.pnlCenter.ResumeLayout(false);
            this.grbDefaults.ResumeLayout(false);
            this.grbDefaults.PerformLayout();
            this.grbLauncher.ResumeLayout(false);
            this.grbLauncher.PerformLayout();
            this.grbUpdates.ResumeLayout(false);
            this.grbUpdates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCenter;
        public System.Windows.Forms.GroupBox grbDefaults;
        public System.Windows.Forms.Label lblJre17;
        private System.Windows.Forms.Button btnJre17;
        private System.Windows.Forms.ComboBox cmbJre17;
        private System.Windows.Forms.Button btnJre8;
        public System.Windows.Forms.Label lblJre8;
        private System.Windows.Forms.ComboBox cmbJre8;
        public System.Windows.Forms.GroupBox grbLauncher;
        public System.Windows.Forms.CheckBox chkDiscordRpc;
        public System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.ComboBox cmbLangSelect;
        public System.Windows.Forms.GroupBox grbUpdates;
        public System.Windows.Forms.Button btnCheckUpdates;
        public System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbUpdateSelect;
        public System.Windows.Forms.Button btnGetJava8;
        public System.Windows.Forms.Button btnGetJava17;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbJre21;
        public System.Windows.Forms.Button btnGetJava21;
        private System.Windows.Forms.Button btnJre21;
    }
}
