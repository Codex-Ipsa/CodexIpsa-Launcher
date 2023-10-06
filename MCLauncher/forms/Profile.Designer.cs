namespace MCLauncher.forms
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.listView1 = new System.Windows.Forms.ListView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.lblProfName = new System.Windows.Forms.Label();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.lblGameDir = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.javaBtn = new System.Windows.Forms.Button();
            this.javaBox = new System.Windows.Forms.TextBox();
            this.resXBox = new System.Windows.Forms.TextBox();
            this.resYBox = new System.Windows.Forms.TextBox();
            this.lblReso = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.ramMaxBox = new System.Windows.Forms.NumericUpDown();
            this.ramMinBox = new System.Windows.Forms.NumericUpDown();
            this.lblMemMin = new System.Windows.Forms.Label();
            this.lblMemMax = new System.Windows.Forms.Label();
            this.lblAftCmd = new System.Windows.Forms.Label();
            this.aftBox = new System.Windows.Forms.TextBox();
            this.lblBefCmd = new System.Windows.Forms.Label();
            this.befBox = new System.Windows.Forms.TextBox();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.chkProxy = new System.Windows.Forms.CheckBox();
            this.chkUseDemo = new System.Windows.Forms.CheckBox();
            this.checkClassic = new System.Windows.Forms.CheckBox();
            this.checkIndev = new System.Windows.Forms.CheckBox();
            this.checkInfdev = new System.Windows.Forms.CheckBox();
            this.checkAlpha = new System.Windows.Forms.CheckBox();
            this.checkBeta = new System.Windows.Forms.CheckBox();
            this.checkRelease = new System.Windows.Forms.CheckBox();
            this.checkSnapshot = new System.Windows.Forms.CheckBox();
            this.checkExperimental = new System.Windows.Forms.CheckBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.checkPreClassic = new System.Windows.Forms.CheckBox();
            this.jsonBox = new System.Windows.Forms.TextBox();
            this.jsonBtn = new System.Windows.Forms.Button();
            this.chkMulti = new System.Windows.Forms.CheckBox();
            this.grbForExp = new System.Windows.Forms.GroupBox();
            this.chkAssetIndex = new System.Windows.Forms.CheckBox();
            this.assetIndexBtn = new System.Windows.Forms.Button();
            this.assetIndexBox = new System.Windows.Forms.TextBox();
            this.chkCustJava = new System.Windows.Forms.CheckBox();
            this.chkCustJson = new System.Windows.Forms.CheckBox();
            this.classBox = new System.Windows.Forms.TextBox();
            this.chkClasspath = new System.Windows.Forms.CheckBox();
            this.grbGame = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.javaPanel = new System.Windows.Forms.Panel();
            this.editionBox = new System.Windows.Forms.ComboBox();
            this.xboxPanel = new System.Windows.Forms.Panel();
            this.grbXboxGame = new System.Windows.Forms.GroupBox();
            this.chkXboxDemo = new System.Windows.Forms.CheckBox();
            this.xboxNameBox = new System.Windows.Forms.TextBox();
            this.lblXboxProfName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRepos = new System.Windows.Forms.Button();
            this.btnOpenDotMc = new System.Windows.Forms.Button();
            this.btnMLoader = new System.Windows.Forms.Button();
            this.btnFabric = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnForge = new System.Windows.Forms.Button();
            this.btnReplaceJar = new System.Windows.Forms.Button();
            this.btnAddToJar = new System.Windows.Forms.Button();
            this.modView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).BeginInit();
            this.grbForExp.SuspendLayout();
            this.grbGame.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.javaPanel.SuspendLayout();
            this.xboxPanel.SuspendLayout();
            this.grbXboxGame.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 33);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(328, 301);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(693, 363);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(91, 23);
            this.saveBtn.TabIndex = 36;
            this.saveBtn.Text = "btn.Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(100, 19);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(333, 20);
            this.nameBox.TabIndex = 12;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // lblProfName
            // 
            this.lblProfName.AutoSize = true;
            this.lblProfName.Location = new System.Drawing.Point(6, 22);
            this.lblProfName.Name = "lblProfName";
            this.lblProfName.Size = new System.Drawing.Size(67, 13);
            this.lblProfName.TabIndex = 3;
            this.lblProfName.Text = "lbl.ProfName";
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(100, 45);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(287, 20);
            this.dirBox.TabIndex = 13;
            this.dirBox.TextChanged += new System.EventHandler(this.DirBox_TextChanged);
            // 
            // lblGameDir
            // 
            this.lblGameDir.AutoSize = true;
            this.lblGameDir.Location = new System.Drawing.Point(6, 49);
            this.lblGameDir.Name = "lblGameDir";
            this.lblGameDir.Size = new System.Drawing.Size(61, 13);
            this.lblGameDir.TabIndex = 5;
            this.lblGameDir.Text = "lbl.GameDir";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 20);
            this.button1.TabIndex = 14;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // javaBtn
            // 
            this.javaBtn.Location = new System.Drawing.Point(390, 19);
            this.javaBtn.Name = "javaBtn";
            this.javaBtn.Size = new System.Drawing.Size(43, 20);
            this.javaBtn.TabIndex = 28;
            this.javaBtn.Text = "...";
            this.javaBtn.UseVisualStyleBackColor = true;
            this.javaBtn.Click += new System.EventHandler(this.JavaBtn_Click);
            // 
            // javaBox
            // 
            this.javaBox.Location = new System.Drawing.Point(106, 19);
            this.javaBox.Name = "javaBox";
            this.javaBox.Size = new System.Drawing.Size(278, 20);
            this.javaBox.TabIndex = 27;
            this.javaBox.TextChanged += new System.EventHandler(this.JavaBox_TextChanged);
            // 
            // resXBox
            // 
            this.resXBox.Location = new System.Drawing.Point(101, 71);
            this.resXBox.Name = "resXBox";
            this.resXBox.Size = new System.Drawing.Size(150, 20);
            this.resXBox.TabIndex = 15;
            // 
            // resYBox
            // 
            this.resYBox.Location = new System.Drawing.Point(283, 71);
            this.resYBox.Name = "resYBox";
            this.resYBox.Size = new System.Drawing.Size(150, 20);
            this.resYBox.TabIndex = 16;
            // 
            // lblReso
            // 
            this.lblReso.AutoSize = true;
            this.lblReso.Location = new System.Drawing.Point(6, 74);
            this.lblReso.Name = "lblReso";
            this.lblReso.Size = new System.Drawing.Size(45, 13);
            this.lblReso.TabIndex = 12;
            this.lblReso.Text = "lbl.Reso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "x";
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Location = new System.Drawing.Point(6, 99);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(43, 13);
            this.lblMem.TabIndex = 14;
            this.lblMem.Text = "lbl.Mem";
            // 
            // ramMaxBox
            // 
            this.ramMaxBox.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMaxBox.Location = new System.Drawing.Point(100, 97);
            this.ramMaxBox.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.ramMaxBox.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMaxBox.Name = "ramMaxBox";
            this.ramMaxBox.Size = new System.Drawing.Size(150, 20);
            this.ramMaxBox.TabIndex = 17;
            this.ramMaxBox.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMaxBox.ValueChanged += new System.EventHandler(this.ramMaxBox_ValueChanged);
            // 
            // ramMinBox
            // 
            this.ramMinBox.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMinBox.Location = new System.Drawing.Point(282, 97);
            this.ramMinBox.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.ramMinBox.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMinBox.Name = "ramMinBox";
            this.ramMinBox.Size = new System.Drawing.Size(150, 20);
            this.ramMinBox.TabIndex = 18;
            this.ramMinBox.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMinBox.ValueChanged += new System.EventHandler(this.ramMinBox_ValueChanged);
            // 
            // lblMemMin
            // 
            this.lblMemMin.AutoSize = true;
            this.lblMemMin.Location = new System.Drawing.Point(257, 99);
            this.lblMemMin.Name = "lblMemMin";
            this.lblMemMin.Size = new System.Drawing.Size(60, 13);
            this.lblMemMin.TabIndex = 17;
            this.lblMemMin.Text = "lbl.MemMin";
            // 
            // lblMemMax
            // 
            this.lblMemMax.AutoSize = true;
            this.lblMemMax.Location = new System.Drawing.Point(67, 99);
            this.lblMemMax.Name = "lblMemMax";
            this.lblMemMax.Size = new System.Drawing.Size(63, 13);
            this.lblMemMax.TabIndex = 18;
            this.lblMemMax.Text = "lbl.MemMax";
            // 
            // lblAftCmd
            // 
            this.lblAftCmd.AutoSize = true;
            this.lblAftCmd.Location = new System.Drawing.Point(6, 152);
            this.lblAftCmd.Name = "lblAftCmd";
            this.lblAftCmd.Size = new System.Drawing.Size(54, 13);
            this.lblAftCmd.TabIndex = 20;
            this.lblAftCmd.Text = "lbl.AftCmd";
            // 
            // aftBox
            // 
            this.aftBox.Location = new System.Drawing.Point(99, 149);
            this.aftBox.Name = "aftBox";
            this.aftBox.Size = new System.Drawing.Size(333, 20);
            this.aftBox.TabIndex = 20;
            // 
            // lblBefCmd
            // 
            this.lblBefCmd.AutoSize = true;
            this.lblBefCmd.Location = new System.Drawing.Point(6, 126);
            this.lblBefCmd.Name = "lblBefCmd";
            this.lblBefCmd.Size = new System.Drawing.Size(57, 13);
            this.lblBefCmd.TabIndex = 22;
            this.lblBefCmd.Text = "lbl.BefCmd";
            // 
            // befBox
            // 
            this.befBox.Location = new System.Drawing.Point(99, 123);
            this.befBox.Name = "befBox";
            this.befBox.Size = new System.Drawing.Size(333, 20);
            this.befBox.TabIndex = 19;
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(9, 201);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(77, 17);
            this.chkOffline.TabIndex = 23;
            this.chkOffline.Text = "chk.Offline";
            this.chkOffline.UseVisualStyleBackColor = true;
            // 
            // chkProxy
            // 
            this.chkProxy.AutoSize = true;
            this.chkProxy.Location = new System.Drawing.Point(9, 177);
            this.chkProxy.Name = "chkProxy";
            this.chkProxy.Size = new System.Drawing.Size(73, 17);
            this.chkProxy.TabIndex = 21;
            this.chkProxy.Text = "chk.Proxy";
            this.chkProxy.UseVisualStyleBackColor = true;
            // 
            // chkUseDemo
            // 
            this.chkUseDemo.AutoSize = true;
            this.chkUseDemo.Location = new System.Drawing.Point(282, 179);
            this.chkUseDemo.Name = "chkUseDemo";
            this.chkUseDemo.Size = new System.Drawing.Size(94, 17);
            this.chkUseDemo.TabIndex = 22;
            this.chkUseDemo.Text = "chk.UseDemo";
            this.chkUseDemo.UseVisualStyleBackColor = true;
            // 
            // checkClassic
            // 
            this.checkClassic.AutoSize = true;
            this.checkClassic.Checked = true;
            this.checkClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkClassic.Location = new System.Drawing.Point(8, 358);
            this.checkClassic.Name = "checkClassic";
            this.checkClassic.Size = new System.Drawing.Size(59, 17);
            this.checkClassic.TabIndex = 3;
            this.checkClassic.Text = "Classic";
            this.checkClassic.UseVisualStyleBackColor = true;
            this.checkClassic.CheckedChanged += new System.EventHandler(this.checkClassic_CheckedChanged);
            // 
            // checkIndev
            // 
            this.checkIndev.AutoSize = true;
            this.checkIndev.Checked = true;
            this.checkIndev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIndev.Location = new System.Drawing.Point(91, 340);
            this.checkIndev.Name = "checkIndev";
            this.checkIndev.Size = new System.Drawing.Size(53, 17);
            this.checkIndev.TabIndex = 5;
            this.checkIndev.Text = "Indev";
            this.checkIndev.UseVisualStyleBackColor = true;
            this.checkIndev.CheckedChanged += new System.EventHandler(this.checkIndev_CheckedChanged);
            // 
            // checkInfdev
            // 
            this.checkInfdev.AutoSize = true;
            this.checkInfdev.Checked = true;
            this.checkInfdev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkInfdev.Location = new System.Drawing.Point(91, 358);
            this.checkInfdev.Name = "checkInfdev";
            this.checkInfdev.Size = new System.Drawing.Size(56, 17);
            this.checkInfdev.TabIndex = 4;
            this.checkInfdev.Text = "Infdev";
            this.checkInfdev.UseVisualStyleBackColor = true;
            this.checkInfdev.CheckedChanged += new System.EventHandler(this.checkInfdev_CheckedChanged);
            // 
            // checkAlpha
            // 
            this.checkAlpha.AutoSize = true;
            this.checkAlpha.Checked = true;
            this.checkAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAlpha.Location = new System.Drawing.Point(156, 340);
            this.checkAlpha.Name = "checkAlpha";
            this.checkAlpha.Size = new System.Drawing.Size(53, 17);
            this.checkAlpha.TabIndex = 6;
            this.checkAlpha.Text = "Alpha";
            this.checkAlpha.UseVisualStyleBackColor = true;
            this.checkAlpha.CheckedChanged += new System.EventHandler(this.checkAlpha_CheckedChanged);
            // 
            // checkBeta
            // 
            this.checkBeta.AutoSize = true;
            this.checkBeta.Checked = true;
            this.checkBeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBeta.Location = new System.Drawing.Point(156, 358);
            this.checkBeta.Name = "checkBeta";
            this.checkBeta.Size = new System.Drawing.Size(48, 17);
            this.checkBeta.TabIndex = 7;
            this.checkBeta.Text = "Beta";
            this.checkBeta.UseVisualStyleBackColor = true;
            this.checkBeta.CheckedChanged += new System.EventHandler(this.checkBeta_CheckedChanged);
            // 
            // checkRelease
            // 
            this.checkRelease.AutoSize = true;
            this.checkRelease.Checked = true;
            this.checkRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRelease.Location = new System.Drawing.Point(218, 340);
            this.checkRelease.Name = "checkRelease";
            this.checkRelease.Size = new System.Drawing.Size(65, 17);
            this.checkRelease.TabIndex = 8;
            this.checkRelease.Text = "Release";
            this.checkRelease.UseVisualStyleBackColor = true;
            this.checkRelease.CheckedChanged += new System.EventHandler(this.checkRelease_CheckedChanged);
            // 
            // checkSnapshot
            // 
            this.checkSnapshot.AutoSize = true;
            this.checkSnapshot.Checked = true;
            this.checkSnapshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSnapshot.Location = new System.Drawing.Point(218, 358);
            this.checkSnapshot.Name = "checkSnapshot";
            this.checkSnapshot.Size = new System.Drawing.Size(71, 17);
            this.checkSnapshot.TabIndex = 9;
            this.checkSnapshot.Text = "Snapshot";
            this.checkSnapshot.UseVisualStyleBackColor = true;
            this.checkSnapshot.CheckedChanged += new System.EventHandler(this.checkSnapshot_CheckedChanged);
            // 
            // checkExperimental
            // 
            this.checkExperimental.AutoSize = true;
            this.checkExperimental.Checked = true;
            this.checkExperimental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExperimental.Location = new System.Drawing.Point(289, 356);
            this.checkExperimental.Name = "checkExperimental";
            this.checkExperimental.Size = new System.Drawing.Size(86, 17);
            this.checkExperimental.TabIndex = 10;
            this.checkExperimental.Text = "Experimental";
            this.checkExperimental.UseVisualStyleBackColor = true;
            this.checkExperimental.CheckedChanged += new System.EventHandler(this.checkExperimental_CheckedChanged);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(499, 363);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(91, 23);
            this.openBtn.TabIndex = 35;
            this.openBtn.Text = "btn.OpenDir";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(596, 363);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(91, 23);
            this.deleteBtn.TabIndex = 34;
            this.deleteBtn.Text = "btn.Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // checkPreClassic
            // 
            this.checkPreClassic.AutoSize = true;
            this.checkPreClassic.Checked = true;
            this.checkPreClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPreClassic.Location = new System.Drawing.Point(8, 340);
            this.checkPreClassic.Name = "checkPreClassic";
            this.checkPreClassic.Size = new System.Drawing.Size(77, 17);
            this.checkPreClassic.TabIndex = 2;
            this.checkPreClassic.Text = "Pre-classic";
            this.checkPreClassic.UseVisualStyleBackColor = true;
            this.checkPreClassic.CheckedChanged += new System.EventHandler(this.checkPreClassic_CheckedChanged);
            // 
            // jsonBox
            // 
            this.jsonBox.Location = new System.Drawing.Point(106, 46);
            this.jsonBox.Name = "jsonBox";
            this.jsonBox.Size = new System.Drawing.Size(278, 20);
            this.jsonBox.TabIndex = 30;
            this.jsonBox.TextChanged += new System.EventHandler(this.JsonBox_TextChanged);
            this.jsonBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.jsonBox_MouseMove);
            // 
            // jsonBtn
            // 
            this.jsonBtn.Location = new System.Drawing.Point(390, 45);
            this.jsonBtn.Name = "jsonBtn";
            this.jsonBtn.Size = new System.Drawing.Size(43, 20);
            this.jsonBtn.TabIndex = 31;
            this.jsonBtn.Text = "...";
            this.jsonBtn.UseVisualStyleBackColor = true;
            this.jsonBtn.Click += new System.EventHandler(this.JsonBtn_Click);
            // 
            // chkMulti
            // 
            this.chkMulti.AutoSize = true;
            this.chkMulti.Location = new System.Drawing.Point(282, 201);
            this.chkMulti.Name = "chkMulti";
            this.chkMulti.Size = new System.Drawing.Size(69, 17);
            this.chkMulti.TabIndex = 24;
            this.chkMulti.Text = "chk.Multi";
            this.chkMulti.UseVisualStyleBackColor = true;
            // 
            // grbForExp
            // 
            this.grbForExp.Controls.Add(this.chkAssetIndex);
            this.grbForExp.Controls.Add(this.assetIndexBtn);
            this.grbForExp.Controls.Add(this.assetIndexBox);
            this.grbForExp.Controls.Add(this.chkCustJava);
            this.grbForExp.Controls.Add(this.chkCustJson);
            this.grbForExp.Controls.Add(this.classBox);
            this.grbForExp.Controls.Add(this.chkClasspath);
            this.grbForExp.Controls.Add(this.jsonBtn);
            this.grbForExp.Controls.Add(this.jsonBox);
            this.grbForExp.Controls.Add(this.javaBox);
            this.grbForExp.Controls.Add(this.javaBtn);
            this.grbForExp.Location = new System.Drawing.Point(5, 227);
            this.grbForExp.Name = "grbForExp";
            this.grbForExp.Size = new System.Drawing.Size(439, 124);
            this.grbForExp.TabIndex = 25;
            this.grbForExp.TabStop = false;
            this.grbForExp.Text = "grb.ForExp";
            // 
            // chkAssetIndex
            // 
            this.chkAssetIndex.AutoSize = true;
            this.chkAssetIndex.Location = new System.Drawing.Point(9, 100);
            this.chkAssetIndex.Name = "chkAssetIndex";
            this.chkAssetIndex.Size = new System.Drawing.Size(99, 17);
            this.chkAssetIndex.TabIndex = 36;
            this.chkAssetIndex.Text = "chk.AssetIndex";
            this.chkAssetIndex.UseVisualStyleBackColor = true;
            this.chkAssetIndex.CheckedChanged += new System.EventHandler(this.chkAssetIndex_CheckedChanged);
            // 
            // assetIndexBtn
            // 
            this.assetIndexBtn.Location = new System.Drawing.Point(390, 97);
            this.assetIndexBtn.Name = "assetIndexBtn";
            this.assetIndexBtn.Size = new System.Drawing.Size(43, 20);
            this.assetIndexBtn.TabIndex = 35;
            this.assetIndexBtn.Text = "...";
            this.assetIndexBtn.UseVisualStyleBackColor = true;
            this.assetIndexBtn.Click += new System.EventHandler(this.assetIndexBtn_Click);
            // 
            // assetIndexBox
            // 
            this.assetIndexBox.Location = new System.Drawing.Point(106, 98);
            this.assetIndexBox.Name = "assetIndexBox";
            this.assetIndexBox.Size = new System.Drawing.Size(278, 20);
            this.assetIndexBox.TabIndex = 34;
            this.assetIndexBox.TextChanged += new System.EventHandler(this.assetIndexBox_TextChanged);
            this.assetIndexBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.assetIndexBox_MouseMove);
            // 
            // chkCustJava
            // 
            this.chkCustJava.AutoSize = true;
            this.chkCustJava.Location = new System.Drawing.Point(9, 19);
            this.chkCustJava.Name = "chkCustJava";
            this.chkCustJava.Size = new System.Drawing.Size(91, 17);
            this.chkCustJava.TabIndex = 26;
            this.chkCustJava.Text = "chk.CustJava";
            this.chkCustJava.UseVisualStyleBackColor = true;
            this.chkCustJava.CheckedChanged += new System.EventHandler(this.javaCheck_CheckedChanged);
            // 
            // chkCustJson
            // 
            this.chkCustJson.AutoSize = true;
            this.chkCustJson.Location = new System.Drawing.Point(9, 48);
            this.chkCustJson.Name = "chkCustJson";
            this.chkCustJson.Size = new System.Drawing.Size(90, 17);
            this.chkCustJson.TabIndex = 29;
            this.chkCustJson.Text = "chk.CustJson";
            this.chkCustJson.UseVisualStyleBackColor = true;
            this.chkCustJson.CheckedChanged += new System.EventHandler(this.jsonCheck_CheckedChanged);
            // 
            // classBox
            // 
            this.classBox.Location = new System.Drawing.Point(106, 72);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(326, 20);
            this.classBox.TabIndex = 33;
            // 
            // chkClasspath
            // 
            this.chkClasspath.AutoSize = true;
            this.chkClasspath.Location = new System.Drawing.Point(9, 74);
            this.chkClasspath.Name = "chkClasspath";
            this.chkClasspath.Size = new System.Drawing.Size(93, 17);
            this.chkClasspath.TabIndex = 32;
            this.chkClasspath.Text = "chk.Classpath";
            this.chkClasspath.UseVisualStyleBackColor = true;
            this.chkClasspath.CheckedChanged += new System.EventHandler(this.classCheck_CheckedChanged);
            // 
            // grbGame
            // 
            this.grbGame.Controls.Add(this.chkOffline);
            this.grbGame.Controls.Add(this.chkUseDemo);
            this.grbGame.Controls.Add(this.chkProxy);
            this.grbGame.Controls.Add(this.chkMulti);
            this.grbGame.Controls.Add(this.aftBox);
            this.grbGame.Controls.Add(this.lblAftCmd);
            this.grbGame.Controls.Add(this.befBox);
            this.grbGame.Controls.Add(this.lblBefCmd);
            this.grbGame.Controls.Add(this.ramMaxBox);
            this.grbGame.Controls.Add(this.ramMinBox);
            this.grbGame.Controls.Add(this.lblMemMin);
            this.grbGame.Controls.Add(this.lblMemMax);
            this.grbGame.Controls.Add(this.lblMem);
            this.grbGame.Controls.Add(this.resXBox);
            this.grbGame.Controls.Add(this.resYBox);
            this.grbGame.Controls.Add(this.label5);
            this.grbGame.Controls.Add(this.lblProfName);
            this.grbGame.Controls.Add(this.lblGameDir);
            this.grbGame.Controls.Add(this.button1);
            this.grbGame.Controls.Add(this.lblReso);
            this.grbGame.Controls.Add(this.nameBox);
            this.grbGame.Controls.Add(this.dirBox);
            this.grbGame.Location = new System.Drawing.Point(5, 3);
            this.grbGame.Name = "grbGame";
            this.grbGame.Size = new System.Drawing.Size(439, 224);
            this.grbGame.TabIndex = 11;
            this.grbGame.TabStop = false;
            this.grbGame.Text = "grb.Game";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 420);
            this.tabControl1.TabIndex = 45;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.javaPanel);
            this.tabPage1.Controls.Add(this.editionBox);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.saveBtn);
            this.tabPage1.Controls.Add(this.openBtn);
            this.tabPage1.Controls.Add(this.deleteBtn);
            this.tabPage1.Controls.Add(this.checkPreClassic);
            this.tabPage1.Controls.Add(this.checkIndev);
            this.tabPage1.Controls.Add(this.checkBeta);
            this.tabPage1.Controls.Add(this.checkRelease);
            this.tabPage1.Controls.Add(this.checkSnapshot);
            this.tabPage1.Controls.Add(this.checkExperimental);
            this.tabPage1.Controls.Add(this.checkClassic);
            this.tabPage1.Controls.Add(this.checkInfdev);
            this.tabPage1.Controls.Add(this.checkAlpha);
            this.tabPage1.Controls.Add(this.xboxPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // javaPanel
            // 
            this.javaPanel.Controls.Add(this.grbForExp);
            this.javaPanel.Controls.Add(this.grbGame);
            this.javaPanel.Location = new System.Drawing.Point(340, 6);
            this.javaPanel.Name = "javaPanel";
            this.javaPanel.Size = new System.Drawing.Size(452, 351);
            this.javaPanel.TabIndex = 25;
            // 
            // editionBox
            // 
            this.editionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editionBox.FormattingEnabled = true;
            this.editionBox.Items.AddRange(new object[] {
            "Java Edition",
            "MinecraftEdu",
            "Xbox 360 Edition"});
            this.editionBox.Location = new System.Drawing.Point(8, 6);
            this.editionBox.Name = "editionBox";
            this.editionBox.Size = new System.Drawing.Size(326, 21);
            this.editionBox.TabIndex = 0;
            this.editionBox.SelectedIndexChanged += new System.EventHandler(this.editionBox_SelectedIndexChanged);
            // 
            // xboxPanel
            // 
            this.xboxPanel.Controls.Add(this.grbXboxGame);
            this.xboxPanel.Location = new System.Drawing.Point(340, 6);
            this.xboxPanel.Name = "xboxPanel";
            this.xboxPanel.Size = new System.Drawing.Size(452, 328);
            this.xboxPanel.TabIndex = 26;
            this.xboxPanel.Visible = false;
            // 
            // grbXboxGame
            // 
            this.grbXboxGame.Controls.Add(this.chkXboxDemo);
            this.grbXboxGame.Controls.Add(this.xboxNameBox);
            this.grbXboxGame.Controls.Add(this.lblXboxProfName);
            this.grbXboxGame.Location = new System.Drawing.Point(5, 3);
            this.grbXboxGame.Name = "grbXboxGame";
            this.grbXboxGame.Size = new System.Drawing.Size(439, 76);
            this.grbXboxGame.TabIndex = 11;
            this.grbXboxGame.TabStop = false;
            this.grbXboxGame.Text = "grb.Game";
            // 
            // chkXboxDemo
            // 
            this.chkXboxDemo.AutoSize = true;
            this.chkXboxDemo.Location = new System.Drawing.Point(9, 47);
            this.chkXboxDemo.Name = "chkXboxDemo";
            this.chkXboxDemo.Size = new System.Drawing.Size(75, 17);
            this.chkXboxDemo.TabIndex = 21;
            this.chkXboxDemo.Text = "chk.Demo";
            this.chkXboxDemo.UseVisualStyleBackColor = true;
            // 
            // xboxNameBox
            // 
            this.xboxNameBox.Location = new System.Drawing.Point(100, 19);
            this.xboxNameBox.Name = "xboxNameBox";
            this.xboxNameBox.Size = new System.Drawing.Size(333, 20);
            this.xboxNameBox.TabIndex = 14;
            this.xboxNameBox.TextChanged += new System.EventHandler(this.xboxNameBox_TextChanged);
            // 
            // lblXboxProfName
            // 
            this.lblXboxProfName.AutoSize = true;
            this.lblXboxProfName.Location = new System.Drawing.Point(6, 24);
            this.lblXboxProfName.Name = "lblXboxProfName";
            this.lblXboxProfName.Size = new System.Drawing.Size(67, 13);
            this.lblXboxProfName.TabIndex = 13;
            this.lblXboxProfName.Text = "lbl.ProfName";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRepos);
            this.tabPage2.Controls.Add(this.btnOpenDotMc);
            this.tabPage2.Controls.Add(this.btnMLoader);
            this.tabPage2.Controls.Add(this.btnFabric);
            this.tabPage2.Controls.Add(this.btnMoveDown);
            this.tabPage2.Controls.Add(this.btnRemove);
            this.tabPage2.Controls.Add(this.btnMoveUp);
            this.tabPage2.Controls.Add(this.btnForge);
            this.tabPage2.Controls.Add(this.btnReplaceJar);
            this.tabPage2.Controls.Add(this.btnAddToJar);
            this.tabPage2.Controls.Add(this.modView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mods";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRepos
            // 
            this.btnRepos.Location = new System.Drawing.Point(667, 225);
            this.btnRepos.Name = "btnRepos";
            this.btnRepos.Size = new System.Drawing.Size(117, 23);
            this.btnRepos.TabIndex = 21;
            this.btnRepos.Text = "btn.Repos";
            this.btnRepos.UseVisualStyleBackColor = true;
            this.btnRepos.Click += new System.EventHandler(this.btnRepo_Click);
            // 
            // btnOpenDotMc
            // 
            this.btnOpenDotMc.Location = new System.Drawing.Point(667, 332);
            this.btnOpenDotMc.Name = "btnOpenDotMc";
            this.btnOpenDotMc.Size = new System.Drawing.Size(117, 23);
            this.btnOpenDotMc.TabIndex = 20;
            this.btnOpenDotMc.Text = "btn.OpenDotMc";
            this.btnOpenDotMc.UseVisualStyleBackColor = true;
            this.btnOpenDotMc.Click += new System.EventHandler(this.btnOpenDotMc_Click);
            // 
            // btnMLoader
            // 
            this.btnMLoader.Enabled = false;
            this.btnMLoader.Location = new System.Drawing.Point(667, 171);
            this.btnMLoader.Name = "btnMLoader";
            this.btnMLoader.Size = new System.Drawing.Size(117, 23);
            this.btnMLoader.TabIndex = 19;
            this.btnMLoader.Text = "btn.MLoader";
            this.btnMLoader.UseVisualStyleBackColor = true;
            // 
            // btnFabric
            // 
            this.btnFabric.Enabled = false;
            this.btnFabric.Location = new System.Drawing.Point(667, 142);
            this.btnFabric.Name = "btnFabric";
            this.btnFabric.Size = new System.Drawing.Size(117, 23);
            this.btnFabric.TabIndex = 18;
            this.btnFabric.Text = "btn.Fabric";
            this.btnFabric.UseVisualStyleBackColor = true;
            this.btnFabric.Click += new System.EventHandler(this.btnFabric_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(667, 35);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(117, 23);
            this.btnMoveDown.TabIndex = 17;
            this.btnMoveDown.Text = "btn.MoveDown";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(667, 64);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(117, 23);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "btn.Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(667, 6);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(117, 23);
            this.btnMoveUp.TabIndex = 15;
            this.btnMoveUp.Text = "btn.MoveUp";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnForge
            // 
            this.btnForge.Enabled = false;
            this.btnForge.Location = new System.Drawing.Point(667, 113);
            this.btnForge.Name = "btnForge";
            this.btnForge.Size = new System.Drawing.Size(117, 23);
            this.btnForge.TabIndex = 14;
            this.btnForge.Text = "btn.Forge";
            this.btnForge.UseVisualStyleBackColor = true;
            this.btnForge.Click += new System.EventHandler(this.btnForge_Click);
            // 
            // btnReplaceJar
            // 
            this.btnReplaceJar.Location = new System.Drawing.Point(667, 283);
            this.btnReplaceJar.Name = "btnReplaceJar";
            this.btnReplaceJar.Size = new System.Drawing.Size(117, 23);
            this.btnReplaceJar.TabIndex = 13;
            this.btnReplaceJar.Text = "btn.ReplaceJar";
            this.btnReplaceJar.UseVisualStyleBackColor = true;
            this.btnReplaceJar.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnAddToJar
            // 
            this.btnAddToJar.Location = new System.Drawing.Point(667, 254);
            this.btnAddToJar.Name = "btnAddToJar";
            this.btnAddToJar.Size = new System.Drawing.Size(117, 23);
            this.btnAddToJar.TabIndex = 12;
            this.btnAddToJar.Text = "btn.AddToJar";
            this.btnAddToJar.UseVisualStyleBackColor = true;
            this.btnAddToJar.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // modView
            // 
            this.modView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader3});
            this.modView.FullRowSelect = true;
            this.modView.HideSelection = false;
            this.modView.Location = new System.Drawing.Point(6, 6);
            this.modView.MultiSelect = false;
            this.modView.Name = "modView";
            this.modView.Size = new System.Drawing.Size(655, 369);
            this.modView.TabIndex = 11;
            this.modView.UseCompatibleStateImageBehavior = false;
            this.modView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Config";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Update";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Profile";
            this.Text = "Profile manager";
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).EndInit();
            this.grbForExp.ResumeLayout(false);
            this.grbForExp.PerformLayout();
            this.grbGame.ResumeLayout(false);
            this.grbGame.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.javaPanel.ResumeLayout(false);
            this.xboxPanel.ResumeLayout(false);
            this.grbXboxGame.ResumeLayout(false);
            this.grbXboxGame.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label lblProfName;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.Label lblGameDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button javaBtn;
        private System.Windows.Forms.TextBox javaBox;
        private System.Windows.Forms.TextBox resXBox;
        private System.Windows.Forms.TextBox resYBox;
        private System.Windows.Forms.Label lblReso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.NumericUpDown ramMaxBox;
        private System.Windows.Forms.NumericUpDown ramMinBox;
        private System.Windows.Forms.Label lblMemMin;
        private System.Windows.Forms.Label lblMemMax;
        private System.Windows.Forms.Label lblAftCmd;
        private System.Windows.Forms.TextBox aftBox;
        private System.Windows.Forms.Label lblBefCmd;
        private System.Windows.Forms.TextBox befBox;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.CheckBox chkProxy;
        private System.Windows.Forms.CheckBox chkUseDemo;
        private System.Windows.Forms.CheckBox checkClassic;
        private System.Windows.Forms.CheckBox checkIndev;
        private System.Windows.Forms.CheckBox checkInfdev;
        private System.Windows.Forms.CheckBox checkAlpha;
        private System.Windows.Forms.CheckBox checkBeta;
        private System.Windows.Forms.CheckBox checkRelease;
        private System.Windows.Forms.CheckBox checkSnapshot;
        private System.Windows.Forms.CheckBox checkExperimental;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.CheckBox checkPreClassic;
        private System.Windows.Forms.TextBox jsonBox;
        private System.Windows.Forms.Button jsonBtn;
        private System.Windows.Forms.CheckBox chkMulti;
        private System.Windows.Forms.GroupBox grbForExp;
        private System.Windows.Forms.GroupBox grbGame;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRepos;
        private System.Windows.Forms.Button btnOpenDotMc;
        private System.Windows.Forms.Button btnMLoader;
        private System.Windows.Forms.Button btnFabric;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnForge;
        private System.Windows.Forms.Button btnReplaceJar;
        private System.Windows.Forms.Button btnAddToJar;
        private System.Windows.Forms.ListView modView;
        private System.Windows.Forms.TextBox classBox;
        private System.Windows.Forms.CheckBox chkClasspath;
        private System.Windows.Forms.CheckBox chkCustJava;
        private System.Windows.Forms.CheckBox chkCustJson;
        private System.Windows.Forms.ComboBox editionBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel javaPanel;
        private System.Windows.Forms.Panel xboxPanel;
        private System.Windows.Forms.GroupBox grbXboxGame;
        private System.Windows.Forms.CheckBox chkXboxDemo;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox chkAssetIndex;
        private System.Windows.Forms.Button assetIndexBtn;
        private System.Windows.Forms.TextBox assetIndexBox;
        private System.Windows.Forms.TextBox xboxNameBox;
        private System.Windows.Forms.Label lblXboxProfName;
    }
}