
namespace MCLauncher
{
    partial class InstanceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceManager));
            this.opendirBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.javaPage = new System.Windows.Forms.TabPage();
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resBoxHeight = new System.Windows.Forms.TextBox();
            this.resBoxWidth = new System.Windows.Forms.TextBox();
            this.minRamBox = new System.Windows.Forms.NumericUpDown();
            this.maxRamBox = new System.Windows.Forms.NumericUpDown();
            this.dirBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.grbVersion = new System.Windows.Forms.GroupBox();
            this.editionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.verBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grbExperts = new System.Windows.Forms.GroupBox();
            this.proxyCheck = new System.Windows.Forms.CheckBox();
            this.jarBtn = new System.Windows.Forms.Button();
            this.jarCheck = new System.Windows.Forms.CheckBox();
            this.jarBox = new System.Windows.Forms.TextBox();
            this.offlineModeCheck = new System.Windows.Forms.CheckBox();
            this.javaBtn = new System.Windows.Forms.Button();
            this.jvmCheck = new System.Windows.Forms.CheckBox();
            this.jvmBox = new System.Windows.Forms.TextBox();
            this.javaCheck = new System.Windows.Forms.CheckBox();
            this.javaBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.javaPage.SuspendLayout();
            this.grbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minRamBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRamBox)).BeginInit();
            this.grbVersion.SuspendLayout();
            this.grbExperts.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opendirBtn
            // 
            this.opendirBtn.Location = new System.Drawing.Point(486, 373);
            this.opendirBtn.Name = "opendirBtn";
            this.opendirBtn.Size = new System.Drawing.Size(92, 23);
            this.opendirBtn.TabIndex = 25;
            this.opendirBtn.Text = "btn.OpenDir";
            this.opendirBtn.UseVisualStyleBackColor = true;
            this.opendirBtn.Click += new System.EventHandler(this.opendirBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(12, 373);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 26;
            this.closeBtn.Text = "btn.Cancel";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(584, 373);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 28;
            this.saveBtn.Text = "btn.SaveInst";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(401, 373);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 23);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "btn.DeleteInst";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // javaPage
            // 
            this.javaPage.Controls.Add(this.grbInfo);
            this.javaPage.Controls.Add(this.grbVersion);
            this.javaPage.Controls.Add(this.grbExperts);
            this.javaPage.Location = new System.Drawing.Point(4, 22);
            this.javaPage.Margin = new System.Windows.Forms.Padding(2);
            this.javaPage.Name = "javaPage";
            this.javaPage.Padding = new System.Windows.Forms.Padding(2);
            this.javaPage.Size = new System.Drawing.Size(660, 346);
            this.javaPage.TabIndex = 0;
            this.javaPage.Text = "Profile editor";
            this.javaPage.UseVisualStyleBackColor = true;
            // 
            // grbInfo
            // 
            this.grbInfo.BackColor = System.Drawing.Color.Transparent;
            this.grbInfo.Controls.Add(this.label9);
            this.grbInfo.Controls.Add(this.label8);
            this.grbInfo.Controls.Add(this.label7);
            this.grbInfo.Controls.Add(this.resBoxHeight);
            this.grbInfo.Controls.Add(this.resBoxWidth);
            this.grbInfo.Controls.Add(this.minRamBox);
            this.grbInfo.Controls.Add(this.maxRamBox);
            this.grbInfo.Controls.Add(this.dirBtn);
            this.grbInfo.Controls.Add(this.label5);
            this.grbInfo.Controls.Add(this.label3);
            this.grbInfo.Controls.Add(this.label4);
            this.grbInfo.Controls.Add(this.lblName);
            this.grbInfo.Controls.Add(this.nameBox);
            this.grbInfo.Controls.Add(this.dirBox);
            this.grbInfo.ForeColor = System.Drawing.Color.Black;
            this.grbInfo.Location = new System.Drawing.Point(5, 6);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(650, 119);
            this.grbInfo.TabIndex = 18;
            this.grbInfo.TabStop = false;
            this.grbInfo.Text = "grb.Info";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "lbl.Dir";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "lbl.Res";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "lbl.Mem";
            // 
            // resBoxHeight
            // 
            this.resBoxHeight.Enabled = false;
            this.resBoxHeight.Location = new System.Drawing.Point(392, 64);
            this.resBoxHeight.Name = "resBoxHeight";
            this.resBoxHeight.Size = new System.Drawing.Size(246, 20);
            this.resBoxHeight.TabIndex = 34;
            // 
            // resBoxWidth
            // 
            this.resBoxWidth.Enabled = false;
            this.resBoxWidth.Location = new System.Drawing.Point(122, 64);
            this.resBoxWidth.Name = "resBoxWidth";
            this.resBoxWidth.Size = new System.Drawing.Size(246, 20);
            this.resBoxWidth.TabIndex = 33;
            // 
            // minRamBox
            // 
            this.minRamBox.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.minRamBox.Location = new System.Drawing.Point(156, 91);
            this.minRamBox.Margin = new System.Windows.Forms.Padding(2);
            this.minRamBox.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.minRamBox.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.minRamBox.Name = "minRamBox";
            this.minRamBox.Size = new System.Drawing.Size(212, 20);
            this.minRamBox.TabIndex = 32;
            this.minRamBox.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // maxRamBox
            // 
            this.maxRamBox.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.maxRamBox.Location = new System.Drawing.Point(426, 91);
            this.maxRamBox.Margin = new System.Windows.Forms.Padding(2);
            this.maxRamBox.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.maxRamBox.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.maxRamBox.Name = "maxRamBox";
            this.maxRamBox.Size = new System.Drawing.Size(212, 20);
            this.maxRamBox.TabIndex = 31;
            this.maxRamBox.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // dirBtn
            // 
            this.dirBtn.Location = new System.Drawing.Point(604, 38);
            this.dirBtn.Name = "dirBtn";
            this.dirBtn.Size = new System.Drawing.Size(34, 20);
            this.dirBtn.TabIndex = 30;
            this.dirBtn.Text = "...";
            this.dirBtn.UseVisualStyleBackColor = true;
            this.dirBtn.Click += new System.EventHandler(this.dirBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "lbl.Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "lbl.Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "x";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "lbl.Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(122, 13);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(516, 20);
            this.nameBox.TabIndex = 8;
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(143, 39);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(455, 20);
            this.dirBox.TabIndex = 12;
            this.dirBox.TextChanged += new System.EventHandler(this.dirBox_TextChanged);
            // 
            // grbVersion
            // 
            this.grbVersion.BackColor = System.Drawing.Color.Transparent;
            this.grbVersion.Controls.Add(this.editionBox);
            this.grbVersion.Controls.Add(this.label2);
            this.grbVersion.Controls.Add(this.verBox);
            this.grbVersion.Controls.Add(this.label6);
            this.grbVersion.ForeColor = System.Drawing.Color.Black;
            this.grbVersion.Location = new System.Drawing.Point(5, 131);
            this.grbVersion.Name = "grbVersion";
            this.grbVersion.Size = new System.Drawing.Size(650, 70);
            this.grbVersion.TabIndex = 21;
            this.grbVersion.TabStop = false;
            this.grbVersion.Text = "grb.Version";
            // 
            // editionBox
            // 
            this.editionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editionBox.FormattingEnabled = true;
            this.editionBox.Location = new System.Drawing.Point(122, 12);
            this.editionBox.Name = "editionBox";
            this.editionBox.Size = new System.Drawing.Size(516, 21);
            this.editionBox.TabIndex = 24;
            this.editionBox.SelectedIndexChanged += new System.EventHandler(this.editionBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "lbl.Version";
            // 
            // verBox
            // 
            this.verBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.verBox.FormattingEnabled = true;
            this.verBox.Location = new System.Drawing.Point(122, 39);
            this.verBox.Name = "verBox";
            this.verBox.Size = new System.Drawing.Size(516, 21);
            this.verBox.TabIndex = 22;
            this.verBox.SelectedIndexChanged += new System.EventHandler(this.verBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "lbl.Edition";
            // 
            // grbExperts
            // 
            this.grbExperts.BackColor = System.Drawing.Color.Transparent;
            this.grbExperts.Controls.Add(this.proxyCheck);
            this.grbExperts.Controls.Add(this.jarBtn);
            this.grbExperts.Controls.Add(this.jarCheck);
            this.grbExperts.Controls.Add(this.jarBox);
            this.grbExperts.Controls.Add(this.offlineModeCheck);
            this.grbExperts.Controls.Add(this.javaBtn);
            this.grbExperts.Controls.Add(this.jvmCheck);
            this.grbExperts.Controls.Add(this.jvmBox);
            this.grbExperts.Controls.Add(this.javaCheck);
            this.grbExperts.Controls.Add(this.javaBox);
            this.grbExperts.ForeColor = System.Drawing.Color.Black;
            this.grbExperts.Location = new System.Drawing.Point(5, 207);
            this.grbExperts.Name = "grbExperts";
            this.grbExperts.Size = new System.Drawing.Size(650, 136);
            this.grbExperts.TabIndex = 24;
            this.grbExperts.TabStop = false;
            this.grbExperts.Text = "grb.Experts";
            // 
            // proxyCheck
            // 
            this.proxyCheck.AutoSize = true;
            this.proxyCheck.Location = new System.Drawing.Point(6, 116);
            this.proxyCheck.Name = "proxyCheck";
            this.proxyCheck.Size = new System.Drawing.Size(82, 17);
            this.proxyCheck.TabIndex = 35;
            this.proxyCheck.Text = "lbl.useProxy";
            this.proxyCheck.UseVisualStyleBackColor = true;
            // 
            // jarBtn
            // 
            this.jarBtn.Enabled = false;
            this.jarBtn.Location = new System.Drawing.Point(610, 63);
            this.jarBtn.Name = "jarBtn";
            this.jarBtn.Size = new System.Drawing.Size(34, 22);
            this.jarBtn.TabIndex = 34;
            this.jarBtn.Text = "...";
            this.jarBtn.UseVisualStyleBackColor = true;
            this.jarBtn.Click += new System.EventHandler(this.jarBtn_Click);
            // 
            // jarCheck
            // 
            this.jarCheck.AutoSize = true;
            this.jarCheck.Location = new System.Drawing.Point(6, 67);
            this.jarCheck.Name = "jarCheck";
            this.jarCheck.Size = new System.Drawing.Size(74, 17);
            this.jarCheck.TabIndex = 33;
            this.jarCheck.Text = "lbl.CustJar";
            this.jarCheck.UseVisualStyleBackColor = true;
            this.jarCheck.CheckedChanged += new System.EventHandler(this.jarCheck_CheckedChanged);
            // 
            // jarBox
            // 
            this.jarBox.Enabled = false;
            this.jarBox.Location = new System.Drawing.Point(122, 65);
            this.jarBox.Name = "jarBox";
            this.jarBox.Size = new System.Drawing.Size(483, 20);
            this.jarBox.TabIndex = 31;
            this.jarBox.TextChanged += new System.EventHandler(this.jarBox_TextChanged);
            // 
            // offlineModeCheck
            // 
            this.offlineModeCheck.AutoSize = true;
            this.offlineModeCheck.Location = new System.Drawing.Point(6, 93);
            this.offlineModeCheck.Name = "offlineModeCheck";
            this.offlineModeCheck.Size = new System.Drawing.Size(94, 17);
            this.offlineModeCheck.TabIndex = 30;
            this.offlineModeCheck.Text = "lbl.offlineMode";
            this.offlineModeCheck.UseVisualStyleBackColor = true;
            // 
            // javaBtn
            // 
            this.javaBtn.Enabled = false;
            this.javaBtn.Location = new System.Drawing.Point(610, 11);
            this.javaBtn.Name = "javaBtn";
            this.javaBtn.Size = new System.Drawing.Size(34, 22);
            this.javaBtn.TabIndex = 29;
            this.javaBtn.Text = "...";
            this.javaBtn.UseVisualStyleBackColor = true;
            this.javaBtn.Click += new System.EventHandler(this.javaBtn_Click);
            // 
            // jvmCheck
            // 
            this.jvmCheck.AutoSize = true;
            this.jvmCheck.Location = new System.Drawing.Point(6, 41);
            this.jvmCheck.Name = "jvmCheck";
            this.jvmCheck.Size = new System.Drawing.Size(79, 17);
            this.jvmCheck.TabIndex = 23;
            this.jvmCheck.Text = "lbl.JvmArgs";
            this.jvmCheck.UseVisualStyleBackColor = true;
            this.jvmCheck.CheckedChanged += new System.EventHandler(this.jvmCheck_CheckedChanged);
            // 
            // jvmBox
            // 
            this.jvmBox.Enabled = false;
            this.jvmBox.Location = new System.Drawing.Point(122, 39);
            this.jvmBox.Name = "jvmBox";
            this.jvmBox.Size = new System.Drawing.Size(523, 20);
            this.jvmBox.TabIndex = 22;
            // 
            // javaCheck
            // 
            this.javaCheck.AutoSize = true;
            this.javaCheck.Location = new System.Drawing.Point(6, 15);
            this.javaCheck.Name = "javaCheck";
            this.javaCheck.Size = new System.Drawing.Size(89, 17);
            this.javaCheck.TabIndex = 21;
            this.javaCheck.Text = "lbl.JavaInstall";
            this.javaCheck.UseVisualStyleBackColor = true;
            this.javaCheck.CheckedChanged += new System.EventHandler(this.javaCheck_CheckedChanged);
            // 
            // javaBox
            // 
            this.javaBox.Enabled = false;
            this.javaBox.Location = new System.Drawing.Point(122, 13);
            this.javaBox.Name = "javaBox";
            this.javaBox.Size = new System.Drawing.Size(483, 20);
            this.javaBox.TabIndex = 8;
            this.javaBox.TextChanged += new System.EventHandler(this.javaBox_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.javaPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 372);
            this.tabControl1.TabIndex = 33;
            // 
            // InstanceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(668, 405);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.opendirBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstanceManager";
            this.Text = "Profile Manager";
            this.javaPage.ResumeLayout(false);
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minRamBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRamBox)).EndInit();
            this.grbVersion.ResumeLayout(false);
            this.grbVersion.PerformLayout();
            this.grbExperts.ResumeLayout(false);
            this.grbExperts.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button opendirBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabPage javaPage;
        private System.Windows.Forms.GroupBox grbInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox resBoxHeight;
        private System.Windows.Forms.TextBox resBoxWidth;
        private System.Windows.Forms.NumericUpDown minRamBox;
        private System.Windows.Forms.NumericUpDown maxRamBox;
        private System.Windows.Forms.Button dirBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.GroupBox grbVersion;
        private System.Windows.Forms.ComboBox editionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox verBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbExperts;
        private System.Windows.Forms.CheckBox proxyCheck;
        private System.Windows.Forms.Button jarBtn;
        private System.Windows.Forms.CheckBox jarCheck;
        private System.Windows.Forms.TextBox jarBox;
        private System.Windows.Forms.CheckBox offlineModeCheck;
        private System.Windows.Forms.Button javaBtn;
        private System.Windows.Forms.CheckBox jvmCheck;
        private System.Windows.Forms.TextBox jvmBox;
        private System.Windows.Forms.CheckBox javaCheck;
        private System.Windows.Forms.TextBox javaBox;
        private System.Windows.Forms.TabControl tabControl1;
    }
}