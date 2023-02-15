
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
            this.mainPage = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.verPage = new System.Windows.Forms.TabPage();
            this.preclassBox = new System.Windows.Forms.CheckBox();
            this.indevBox = new System.Windows.Forms.CheckBox();
            this.infdevBox = new System.Windows.Forms.CheckBox();
            this.releaseBox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modsPage = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.snapshotBox = new System.Windows.Forms.CheckBox();
            this.experimentBox = new System.Windows.Forms.CheckBox();
            this.betaBox = new System.Windows.Forms.CheckBox();
            this.alphaBox = new System.Windows.Forms.CheckBox();
            this.classicBox = new System.Windows.Forms.CheckBox();
            this.otherBox = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.javaPage.SuspendLayout();
            this.grbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minRamBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRamBox)).BeginInit();
            this.grbVersion.SuspendLayout();
            this.grbExperts.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.verPage.SuspendLayout();
            this.modsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // opendirBtn
            // 
            this.opendirBtn.Location = new System.Drawing.Point(486, 373);
            this.opendirBtn.Name = "opendirBtn";
            this.opendirBtn.Size = new System.Drawing.Size(92, 23);
            this.opendirBtn.TabIndex = 28;
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
            this.saveBtn.TabIndex = 25;
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
            this.tabControl1.Controls.Add(this.mainPage);
            this.tabControl1.Controls.Add(this.verPage);
            this.tabControl1.Controls.Add(this.modsPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 372);
            this.tabControl1.TabIndex = 33;
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.label10);
            this.mainPage.Controls.Add(this.label1);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Size = new System.Drawing.Size(660, 346);
            this.mainPage.TabIndex = 3;
            this.mainPage.Text = "mainPage";
            this.mainPage.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(238, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Things here are either broken or don\'t work at all!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is still very earlyt in development.";
            // 
            // verPage
            // 
            this.verPage.Controls.Add(this.otherBox);
            this.verPage.Controls.Add(this.preclassBox);
            this.verPage.Controls.Add(this.classicBox);
            this.verPage.Controls.Add(this.indevBox);
            this.verPage.Controls.Add(this.infdevBox);
            this.verPage.Controls.Add(this.alphaBox);
            this.verPage.Controls.Add(this.betaBox);
            this.verPage.Controls.Add(this.experimentBox);
            this.verPage.Controls.Add(this.snapshotBox);
            this.verPage.Controls.Add(this.releaseBox);
            this.verPage.Controls.Add(this.comboBox1);
            this.verPage.Controls.Add(this.listView2);
            this.verPage.Location = new System.Drawing.Point(4, 22);
            this.verPage.Name = "verPage";
            this.verPage.Size = new System.Drawing.Size(660, 346);
            this.verPage.TabIndex = 1;
            this.verPage.Text = "verPage";
            this.verPage.UseVisualStyleBackColor = true;
            // 
            // preclassBox
            // 
            this.preclassBox.AutoSize = true;
            this.preclassBox.Checked = true;
            this.preclassBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.preclassBox.Location = new System.Drawing.Point(517, 236);
            this.preclassBox.Name = "preclassBox";
            this.preclassBox.Size = new System.Drawing.Size(77, 17);
            this.preclassBox.TabIndex = 10;
            this.preclassBox.Text = "Pre-classic";
            this.preclassBox.UseVisualStyleBackColor = true;
            // 
            // indevBox
            // 
            this.indevBox.AutoSize = true;
            this.indevBox.Checked = true;
            this.indevBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.indevBox.Location = new System.Drawing.Point(517, 190);
            this.indevBox.Name = "indevBox";
            this.indevBox.Size = new System.Drawing.Size(53, 17);
            this.indevBox.TabIndex = 8;
            this.indevBox.Text = "Indev";
            this.indevBox.UseVisualStyleBackColor = true;
            // 
            // infdevBox
            // 
            this.infdevBox.AutoSize = true;
            this.infdevBox.Checked = true;
            this.infdevBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.infdevBox.Location = new System.Drawing.Point(517, 167);
            this.infdevBox.Name = "infdevBox";
            this.infdevBox.Size = new System.Drawing.Size(56, 17);
            this.infdevBox.TabIndex = 7;
            this.infdevBox.Text = "Infdev";
            this.infdevBox.UseVisualStyleBackColor = true;
            // 
            // releaseBox
            // 
            this.releaseBox.AutoSize = true;
            this.releaseBox.Checked = true;
            this.releaseBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.releaseBox.Location = new System.Drawing.Point(517, 52);
            this.releaseBox.Name = "releaseBox";
            this.releaseBox.Size = new System.Drawing.Size(65, 17);
            this.releaseBox.TabIndex = 2;
            this.releaseBox.Text = "Release";
            this.releaseBox.UseVisualStyleBackColor = true;
            this.releaseBox.CheckedChanged += new System.EventHandler(this.releaseBox_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Java Edition",
            "MinecraftEdu",
            "Xbox 360 Edition"});
            this.comboBox1.Location = new System.Drawing.Point(8, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(644, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.FullRowSelect = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.HideSelection = false;
            this.listView2.LabelWrap = false;
            this.listView2.Location = new System.Drawing.Point(8, 30);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(486, 313);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 66;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Released";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 42;
            // 
            // modsPage
            // 
            this.modsPage.Controls.Add(this.button10);
            this.modsPage.Controls.Add(this.button9);
            this.modsPage.Controls.Add(this.button8);
            this.modsPage.Controls.Add(this.button7);
            this.modsPage.Controls.Add(this.button6);
            this.modsPage.Controls.Add(this.button5);
            this.modsPage.Controls.Add(this.button4);
            this.modsPage.Controls.Add(this.button3);
            this.modsPage.Controls.Add(this.button2);
            this.modsPage.Controls.Add(this.button1);
            this.modsPage.Controls.Add(this.listView1);
            this.modsPage.Location = new System.Drawing.Point(4, 22);
            this.modsPage.Name = "modsPage";
            this.modsPage.Size = new System.Drawing.Size(660, 346);
            this.modsPage.TabIndex = 2;
            this.modsPage.Text = "modsPage";
            this.modsPage.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(535, 320);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(117, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "Open .minecraft";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(535, 173);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(117, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "Install ModLoader";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(535, 144);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(117, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Install Fabric";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(535, 32);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Move down";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(535, 61);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(535, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Move up";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(535, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Install Forge";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(535, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Replace minecraft.jar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add to minecraft.jar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(521, 340);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 89;
            // 
            // snapshotBox
            // 
            this.snapshotBox.AutoSize = true;
            this.snapshotBox.Checked = true;
            this.snapshotBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.snapshotBox.Location = new System.Drawing.Point(517, 75);
            this.snapshotBox.Name = "snapshotBox";
            this.snapshotBox.Size = new System.Drawing.Size(71, 17);
            this.snapshotBox.TabIndex = 3;
            this.snapshotBox.Text = "Snapshot";
            this.snapshotBox.UseVisualStyleBackColor = true;
            // 
            // experimentBox
            // 
            this.experimentBox.AutoSize = true;
            this.experimentBox.Checked = true;
            this.experimentBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.experimentBox.Location = new System.Drawing.Point(517, 98);
            this.experimentBox.Name = "experimentBox";
            this.experimentBox.Size = new System.Drawing.Size(86, 17);
            this.experimentBox.TabIndex = 4;
            this.experimentBox.Text = "Experimental";
            this.experimentBox.UseVisualStyleBackColor = true;
            // 
            // betaBox
            // 
            this.betaBox.AutoSize = true;
            this.betaBox.Checked = true;
            this.betaBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.betaBox.Location = new System.Drawing.Point(517, 121);
            this.betaBox.Name = "betaBox";
            this.betaBox.Size = new System.Drawing.Size(48, 17);
            this.betaBox.TabIndex = 5;
            this.betaBox.Text = "Beta";
            this.betaBox.UseVisualStyleBackColor = true;
            // 
            // alphaBox
            // 
            this.alphaBox.AutoSize = true;
            this.alphaBox.Checked = true;
            this.alphaBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alphaBox.Location = new System.Drawing.Point(517, 144);
            this.alphaBox.Name = "alphaBox";
            this.alphaBox.Size = new System.Drawing.Size(53, 17);
            this.alphaBox.TabIndex = 6;
            this.alphaBox.Text = "Alpha";
            this.alphaBox.UseVisualStyleBackColor = true;
            // 
            // classicBox
            // 
            this.classicBox.AutoSize = true;
            this.classicBox.Checked = true;
            this.classicBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.classicBox.Location = new System.Drawing.Point(517, 213);
            this.classicBox.Name = "classicBox";
            this.classicBox.Size = new System.Drawing.Size(59, 17);
            this.classicBox.TabIndex = 9;
            this.classicBox.Text = "Classic";
            this.classicBox.UseVisualStyleBackColor = true;
            // 
            // otherBox
            // 
            this.otherBox.AutoSize = true;
            this.otherBox.Checked = true;
            this.otherBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.otherBox.Location = new System.Drawing.Point(517, 259);
            this.otherBox.Name = "otherBox";
            this.otherBox.Size = new System.Drawing.Size(52, 17);
            this.otherBox.TabIndex = 11;
            this.otherBox.Text = "Other";
            this.otherBox.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(535, 212);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(117, 23);
            this.button10.TabIndex = 10;
            this.button10.Text = "Mod repositories";
            this.button10.UseVisualStyleBackColor = true;
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
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.verPage.ResumeLayout(false);
            this.verPage.PerformLayout();
            this.modsPage.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage verPage;
        private System.Windows.Forms.TabPage modsPage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox preclassBox;
        private System.Windows.Forms.CheckBox indevBox;
        private System.Windows.Forms.CheckBox infdevBox;
        private System.Windows.Forms.CheckBox releaseBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox otherBox;
        private System.Windows.Forms.CheckBox classicBox;
        private System.Windows.Forms.CheckBox alphaBox;
        private System.Windows.Forms.CheckBox betaBox;
        private System.Windows.Forms.CheckBox experimentBox;
        private System.Windows.Forms.CheckBox snapshotBox;
        private System.Windows.Forms.Button button10;
    }
}