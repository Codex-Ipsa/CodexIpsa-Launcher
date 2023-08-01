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
            this.grbJava = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grbLauncher = new System.Windows.Forms.GroupBox();
            this.chkDiscordRpc = new System.Windows.Forms.CheckBox();
            this.lblLang = new System.Windows.Forms.Label();
            this.cmbLangSelect = new System.Windows.Forms.ComboBox();
            this.grbUpdates = new System.Windows.Forms.GroupBox();
            this.btnCheckUpdates = new System.Windows.Forms.Button();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbUpdateSelect = new System.Windows.Forms.ComboBox();
            this.pnlCenter.SuspendLayout();
            this.grbJava.SuspendLayout();
            this.grbLauncher.SuspendLayout();
            this.grbUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.Transparent;
            this.pnlCenter.Controls.Add(this.grbJava);
            this.pnlCenter.Controls.Add(this.grbLauncher);
            this.pnlCenter.Controls.Add(this.grbUpdates);
            this.pnlCenter.Location = new System.Drawing.Point(169, 70);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(446, 247);
            this.pnlCenter.TabIndex = 24;
            // 
            // grbJava
            // 
            this.grbJava.BackColor = System.Drawing.Color.Transparent;
            this.grbJava.Controls.Add(this.label2);
            this.grbJava.Controls.Add(this.button2);
            this.grbJava.Controls.Add(this.comboBox2);
            this.grbJava.Controls.Add(this.button1);
            this.grbJava.Controls.Add(this.label1);
            this.grbJava.Controls.Add(this.comboBox1);
            this.grbJava.ForeColor = System.Drawing.Color.White;
            this.grbJava.Location = new System.Drawing.Point(0, 172);
            this.grbJava.Name = "grbJava";
            this.grbJava.Size = new System.Drawing.Size(446, 75);
            this.grbJava.TabIndex = 21;
            this.grbJava.TabStop = false;
            this.grbJava.Text = "grb.defaults";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "lbl.jre16";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(403, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 21);
            this.button2.TabIndex = 26;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(67, 46);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(330, 21);
            this.comboBox2.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(403, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 21);
            this.button1.TabIndex = 24;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "lbl.jre8";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(67, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(330, 21);
            this.comboBox1.TabIndex = 0;
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
            this.grbJava.ResumeLayout(false);
            this.grbJava.PerformLayout();
            this.grbLauncher.ResumeLayout(false);
            this.grbLauncher.PerformLayout();
            this.grbUpdates.ResumeLayout(false);
            this.grbUpdates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCenter;
        public System.Windows.Forms.GroupBox grbJava;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.GroupBox grbLauncher;
        public System.Windows.Forms.CheckBox chkDiscordRpc;
        public System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.ComboBox cmbLangSelect;
        public System.Windows.Forms.GroupBox grbUpdates;
        public System.Windows.Forms.Button btnCheckUpdates;
        public System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbUpdateSelect;
    }
}
