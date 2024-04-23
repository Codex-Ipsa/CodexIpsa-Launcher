namespace MCLauncher.forms
{
    partial class NewInstance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewInstance));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.vanillaPage = new System.Windows.Forms.TabPage();
            this.vanillaExperimental = new System.Windows.Forms.CheckBox();
            this.vanillaSnapshot = new System.Windows.Forms.CheckBox();
            this.vanillaRelease = new System.Windows.Forms.CheckBox();
            this.vanillaBeta = new System.Windows.Forms.CheckBox();
            this.vanillaAlpha = new System.Windows.Forms.CheckBox();
            this.vanillaInfdev = new System.Windows.Forms.CheckBox();
            this.vanillaIndev = new System.Windows.Forms.CheckBox();
            this.vanillaClassic = new System.Windows.Forms.CheckBox();
            this.vanillaPreclassic = new System.Windows.Forms.CheckBox();
            this.vanillaList = new System.Windows.Forms.ListView();
            this.eduPage = new System.Windows.Forms.TabPage();
            this.eduList = new System.Windows.Forms.ListView();
            this.xboxPage = new System.Windows.Forms.TabPage();
            this.xboxList = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveBtn = new System.Windows.Forms.Button();
            this.grbForExp = new System.Windows.Forms.GroupBox();
            this.chkAssetIndex = new System.Windows.Forms.CheckBox();
            this.assetIndexBtn = new System.Windows.Forms.Button();
            this.assetIndexBox = new System.Windows.Forms.TextBox();
            this.chkCustJava = new System.Windows.Forms.CheckBox();
            this.chkCustJson = new System.Windows.Forms.CheckBox();
            this.classBox = new System.Windows.Forms.TextBox();
            this.chkClasspath = new System.Windows.Forms.CheckBox();
            this.jsonBtn = new System.Windows.Forms.Button();
            this.jsonBox = new System.Windows.Forms.TextBox();
            this.javaBox = new System.Windows.Forms.TextBox();
            this.javaBtn = new System.Windows.Forms.Button();
            this.grbGame = new System.Windows.Forms.GroupBox();
            this.lblGameArgs = new System.Windows.Forms.Label();
            this.gameArgsBox = new System.Windows.Forms.TextBox();
            this.lblJvmArgs = new System.Windows.Forms.Label();
            this.jvmArgsBox = new System.Windows.Forms.TextBox();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.chkUseDemo = new System.Windows.Forms.CheckBox();
            this.chkProxy = new System.Windows.Forms.CheckBox();
            this.chkMulti = new System.Windows.Forms.CheckBox();
            this.ramMaxBox = new System.Windows.Forms.NumericUpDown();
            this.ramMinBox = new System.Windows.Forms.NumericUpDown();
            this.lblMemMin = new System.Windows.Forms.Label();
            this.lblMemMax = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.resXBox = new System.Windows.Forms.TextBox();
            this.resYBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProfName = new System.Windows.Forms.Label();
            this.lblGameDir = new System.Windows.Forms.Label();
            this.dirBtn = new System.Windows.Forms.Button();
            this.lblReso = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.grbXbox = new System.Windows.Forms.GroupBox();
            this.chkXboxDemo = new System.Windows.Forms.CheckBox();
            this.lblXboxProfName = new System.Windows.Forms.Label();
            this.xboxNameBox = new System.Windows.Forms.TextBox();
            this.chkLatest = new System.Windows.Forms.CheckBox();
            this.chkLatestSnapshot = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.vanillaPage.SuspendLayout();
            this.eduPage.SuspendLayout();
            this.xboxPage.SuspendLayout();
            this.grbForExp.SuspendLayout();
            this.grbGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).BeginInit();
            this.grbXbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.vanillaPage);
            this.tabControl1.Controls.Add(this.eduPage);
            this.tabControl1.Controls.Add(this.xboxPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(366, 386);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // vanillaPage
            // 
            this.vanillaPage.Controls.Add(this.chkLatestSnapshot);
            this.vanillaPage.Controls.Add(this.chkLatest);
            this.vanillaPage.Controls.Add(this.vanillaExperimental);
            this.vanillaPage.Controls.Add(this.vanillaSnapshot);
            this.vanillaPage.Controls.Add(this.vanillaRelease);
            this.vanillaPage.Controls.Add(this.vanillaBeta);
            this.vanillaPage.Controls.Add(this.vanillaAlpha);
            this.vanillaPage.Controls.Add(this.vanillaInfdev);
            this.vanillaPage.Controls.Add(this.vanillaIndev);
            this.vanillaPage.Controls.Add(this.vanillaClassic);
            this.vanillaPage.Controls.Add(this.vanillaPreclassic);
            this.vanillaPage.Controls.Add(this.vanillaList);
            this.vanillaPage.ImageIndex = 0;
            this.vanillaPage.Location = new System.Drawing.Point(4, 22);
            this.vanillaPage.Name = "vanillaPage";
            this.vanillaPage.Size = new System.Drawing.Size(358, 360);
            this.vanillaPage.TabIndex = 0;
            this.vanillaPage.Text = "Vanilla";
            this.vanillaPage.UseVisualStyleBackColor = true;
            // 
            // vanillaExperimental
            // 
            this.vanillaExperimental.AutoSize = true;
            this.vanillaExperimental.Checked = true;
            this.vanillaExperimental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaExperimental.Location = new System.Drawing.Point(208, 315);
            this.vanillaExperimental.Name = "vanillaExperimental";
            this.vanillaExperimental.Size = new System.Drawing.Size(86, 17);
            this.vanillaExperimental.TabIndex = 9;
            this.vanillaExperimental.Text = "Experimental";
            this.vanillaExperimental.UseVisualStyleBackColor = true;
            this.vanillaExperimental.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaSnapshot
            // 
            this.vanillaSnapshot.AutoSize = true;
            this.vanillaSnapshot.Checked = true;
            this.vanillaSnapshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaSnapshot.Location = new System.Drawing.Point(131, 315);
            this.vanillaSnapshot.Name = "vanillaSnapshot";
            this.vanillaSnapshot.Size = new System.Drawing.Size(71, 17);
            this.vanillaSnapshot.TabIndex = 8;
            this.vanillaSnapshot.Text = "Snapshot";
            this.vanillaSnapshot.UseVisualStyleBackColor = true;
            this.vanillaSnapshot.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaRelease
            // 
            this.vanillaRelease.AutoSize = true;
            this.vanillaRelease.Checked = true;
            this.vanillaRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaRelease.Location = new System.Drawing.Point(60, 315);
            this.vanillaRelease.Name = "vanillaRelease";
            this.vanillaRelease.Size = new System.Drawing.Size(65, 17);
            this.vanillaRelease.TabIndex = 7;
            this.vanillaRelease.Text = "Release";
            this.vanillaRelease.UseVisualStyleBackColor = true;
            this.vanillaRelease.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaBeta
            // 
            this.vanillaBeta.AutoSize = true;
            this.vanillaBeta.Checked = true;
            this.vanillaBeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaBeta.Location = new System.Drawing.Point(6, 315);
            this.vanillaBeta.Name = "vanillaBeta";
            this.vanillaBeta.Size = new System.Drawing.Size(48, 17);
            this.vanillaBeta.TabIndex = 6;
            this.vanillaBeta.Text = "Beta";
            this.vanillaBeta.UseVisualStyleBackColor = true;
            this.vanillaBeta.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaAlpha
            // 
            this.vanillaAlpha.AutoSize = true;
            this.vanillaAlpha.Checked = true;
            this.vanillaAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaAlpha.Location = new System.Drawing.Point(275, 295);
            this.vanillaAlpha.Name = "vanillaAlpha";
            this.vanillaAlpha.Size = new System.Drawing.Size(53, 17);
            this.vanillaAlpha.TabIndex = 5;
            this.vanillaAlpha.Text = "Alpha";
            this.vanillaAlpha.UseVisualStyleBackColor = true;
            this.vanillaAlpha.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaInfdev
            // 
            this.vanillaInfdev.AutoSize = true;
            this.vanillaInfdev.Checked = true;
            this.vanillaInfdev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaInfdev.Location = new System.Drawing.Point(213, 295);
            this.vanillaInfdev.Name = "vanillaInfdev";
            this.vanillaInfdev.Size = new System.Drawing.Size(56, 17);
            this.vanillaInfdev.TabIndex = 4;
            this.vanillaInfdev.Text = "Infdev";
            this.vanillaInfdev.UseVisualStyleBackColor = true;
            this.vanillaInfdev.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaIndev
            // 
            this.vanillaIndev.AutoSize = true;
            this.vanillaIndev.Checked = true;
            this.vanillaIndev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaIndev.Location = new System.Drawing.Point(154, 295);
            this.vanillaIndev.Name = "vanillaIndev";
            this.vanillaIndev.Size = new System.Drawing.Size(53, 17);
            this.vanillaIndev.TabIndex = 3;
            this.vanillaIndev.Text = "Indev";
            this.vanillaIndev.UseVisualStyleBackColor = true;
            this.vanillaIndev.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaClassic
            // 
            this.vanillaClassic.AutoSize = true;
            this.vanillaClassic.Checked = true;
            this.vanillaClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaClassic.Location = new System.Drawing.Point(89, 295);
            this.vanillaClassic.Name = "vanillaClassic";
            this.vanillaClassic.Size = new System.Drawing.Size(59, 17);
            this.vanillaClassic.TabIndex = 2;
            this.vanillaClassic.Text = "Classic";
            this.vanillaClassic.UseVisualStyleBackColor = true;
            this.vanillaClassic.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaPreclassic
            // 
            this.vanillaPreclassic.AutoSize = true;
            this.vanillaPreclassic.Checked = true;
            this.vanillaPreclassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaPreclassic.Location = new System.Drawing.Point(6, 295);
            this.vanillaPreclassic.Name = "vanillaPreclassic";
            this.vanillaPreclassic.Size = new System.Drawing.Size(77, 17);
            this.vanillaPreclassic.TabIndex = 1;
            this.vanillaPreclassic.Text = "Pre-classic";
            this.vanillaPreclassic.UseVisualStyleBackColor = true;
            this.vanillaPreclassic.CheckedChanged += new System.EventHandler(this.vanillaBoxes_CheckedChanged);
            // 
            // vanillaList
            // 
            this.vanillaList.FullRowSelect = true;
            this.vanillaList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.vanillaList.HideSelection = false;
            this.vanillaList.Location = new System.Drawing.Point(3, 3);
            this.vanillaList.MultiSelect = false;
            this.vanillaList.Name = "vanillaList";
            this.vanillaList.Size = new System.Drawing.Size(348, 287);
            this.vanillaList.TabIndex = 0;
            this.vanillaList.UseCompatibleStateImageBehavior = false;
            this.vanillaList.View = System.Windows.Forms.View.Details;
            this.vanillaList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.vanillaList_ColumnWidthChanging);
            this.vanillaList.SelectedIndexChanged += new System.EventHandler(this.vanillaList_SelectedIndexChanged);
            // 
            // eduPage
            // 
            this.eduPage.Controls.Add(this.eduList);
            this.eduPage.ImageIndex = 0;
            this.eduPage.Location = new System.Drawing.Point(4, 22);
            this.eduPage.Name = "eduPage";
            this.eduPage.Size = new System.Drawing.Size(358, 389);
            this.eduPage.TabIndex = 5;
            this.eduPage.Text = "MinecraftEdu";
            this.eduPage.UseVisualStyleBackColor = true;
            // 
            // eduList
            // 
            this.eduList.FullRowSelect = true;
            this.eduList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.eduList.HideSelection = false;
            this.eduList.Location = new System.Drawing.Point(3, 3);
            this.eduList.MultiSelect = false;
            this.eduList.Name = "eduList";
            this.eduList.Size = new System.Drawing.Size(348, 333);
            this.eduList.TabIndex = 1;
            this.eduList.UseCompatibleStateImageBehavior = false;
            this.eduList.View = System.Windows.Forms.View.Details;
            this.eduList.SelectedIndexChanged += new System.EventHandler(this.eduList_SelectedIndexChanged);
            // 
            // xboxPage
            // 
            this.xboxPage.Controls.Add(this.xboxList);
            this.xboxPage.ImageIndex = 6;
            this.xboxPage.Location = new System.Drawing.Point(4, 22);
            this.xboxPage.Name = "xboxPage";
            this.xboxPage.Size = new System.Drawing.Size(358, 389);
            this.xboxPage.TabIndex = 4;
            this.xboxPage.Text = "Xbox 360";
            this.xboxPage.UseVisualStyleBackColor = true;
            // 
            // xboxList
            // 
            this.xboxList.FullRowSelect = true;
            this.xboxList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.xboxList.HideSelection = false;
            this.xboxList.Location = new System.Drawing.Point(3, 3);
            this.xboxList.MultiSelect = false;
            this.xboxList.Name = "xboxList";
            this.xboxList.Size = new System.Drawing.Size(348, 333);
            this.xboxList.TabIndex = 2;
            this.xboxList.UseCompatibleStateImageBehavior = false;
            this.xboxList.View = System.Windows.Forms.View.Details;
            this.xboxList.SelectedIndexChanged += new System.EventHandler(this.xboxList_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grass.png");
            this.imageList1.Images.SetKeyName(1, "ipsa.png");
            this.imageList1.Images.SetKeyName(2, "forge.png");
            this.imageList1.Images.SetKeyName(3, "fabric.png");
            this.imageList1.Images.SetKeyName(4, "quilt.png");
            this.imageList1.Images.SetKeyName(5, "neoforge.png");
            this.imageList1.Images.SetKeyName(6, "xbox360.png");
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(716, 357);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Create";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.button1_Click);
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
            this.grbForExp.Location = new System.Drawing.Point(366, 226);
            this.grbForExp.Name = "grbForExp";
            this.grbForExp.Size = new System.Drawing.Size(425, 125);
            this.grbForExp.TabIndex = 29;
            this.grbForExp.TabStop = false;
            this.grbForExp.Text = "grb.ForExp";
            // 
            // chkAssetIndex
            // 
            this.chkAssetIndex.AutoSize = true;
            this.chkAssetIndex.Location = new System.Drawing.Point(6, 100);
            this.chkAssetIndex.Name = "chkAssetIndex";
            this.chkAssetIndex.Size = new System.Drawing.Size(99, 17);
            this.chkAssetIndex.TabIndex = 36;
            this.chkAssetIndex.Text = "chk.AssetIndex";
            this.chkAssetIndex.UseVisualStyleBackColor = true;
            this.chkAssetIndex.CheckedChanged += new System.EventHandler(this.chkAssetIndex_CheckedChanged);
            // 
            // assetIndexBtn
            // 
            this.assetIndexBtn.Location = new System.Drawing.Point(378, 98);
            this.assetIndexBtn.Name = "assetIndexBtn";
            this.assetIndexBtn.Size = new System.Drawing.Size(39, 20);
            this.assetIndexBtn.TabIndex = 35;
            this.assetIndexBtn.Text = "...";
            this.assetIndexBtn.UseVisualStyleBackColor = true;
            this.assetIndexBtn.Click += new System.EventHandler(this.assetIndexBtn_Click);
            // 
            // assetIndexBox
            // 
            this.assetIndexBox.Location = new System.Drawing.Point(99, 98);
            this.assetIndexBox.Name = "assetIndexBox";
            this.assetIndexBox.Size = new System.Drawing.Size(273, 20);
            this.assetIndexBox.TabIndex = 34;
            this.assetIndexBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.assetIndexBox_MouseMove);
            // 
            // chkCustJava
            // 
            this.chkCustJava.AutoSize = true;
            this.chkCustJava.Location = new System.Drawing.Point(6, 74);
            this.chkCustJava.Name = "chkCustJava";
            this.chkCustJava.Size = new System.Drawing.Size(91, 17);
            this.chkCustJava.TabIndex = 26;
            this.chkCustJava.Text = "chk.CustJava";
            this.chkCustJava.UseVisualStyleBackColor = true;
            this.chkCustJava.CheckedChanged += new System.EventHandler(this.chkCustJava_CheckedChanged);
            // 
            // chkCustJson
            // 
            this.chkCustJson.AutoSize = true;
            this.chkCustJson.Location = new System.Drawing.Point(6, 48);
            this.chkCustJson.Name = "chkCustJson";
            this.chkCustJson.Size = new System.Drawing.Size(90, 17);
            this.chkCustJson.TabIndex = 29;
            this.chkCustJson.Text = "chk.CustJson";
            this.chkCustJson.UseVisualStyleBackColor = true;
            this.chkCustJson.CheckedChanged += new System.EventHandler(this.chkCustJson_CheckedChanged);
            // 
            // classBox
            // 
            this.classBox.Location = new System.Drawing.Point(99, 20);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(318, 20);
            this.classBox.TabIndex = 33;
            // 
            // chkClasspath
            // 
            this.chkClasspath.AutoSize = true;
            this.chkClasspath.Location = new System.Drawing.Point(6, 22);
            this.chkClasspath.Name = "chkClasspath";
            this.chkClasspath.Size = new System.Drawing.Size(93, 17);
            this.chkClasspath.TabIndex = 32;
            this.chkClasspath.Text = "chk.Classpath";
            this.chkClasspath.UseVisualStyleBackColor = true;
            this.chkClasspath.CheckedChanged += new System.EventHandler(this.chkClasspath_CheckedChanged);
            // 
            // jsonBtn
            // 
            this.jsonBtn.Location = new System.Drawing.Point(378, 46);
            this.jsonBtn.Name = "jsonBtn";
            this.jsonBtn.Size = new System.Drawing.Size(39, 20);
            this.jsonBtn.TabIndex = 31;
            this.jsonBtn.Text = "...";
            this.jsonBtn.UseVisualStyleBackColor = true;
            this.jsonBtn.Click += new System.EventHandler(this.jsonBtn_Click);
            // 
            // jsonBox
            // 
            this.jsonBox.Location = new System.Drawing.Point(99, 46);
            this.jsonBox.Name = "jsonBox";
            this.jsonBox.Size = new System.Drawing.Size(273, 20);
            this.jsonBox.TabIndex = 30;
            this.jsonBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.jsonBox_MouseMove);
            // 
            // javaBox
            // 
            this.javaBox.Location = new System.Drawing.Point(99, 72);
            this.javaBox.Name = "javaBox";
            this.javaBox.Size = new System.Drawing.Size(273, 20);
            this.javaBox.TabIndex = 27;
            // 
            // javaBtn
            // 
            this.javaBtn.Location = new System.Drawing.Point(378, 72);
            this.javaBtn.Name = "javaBtn";
            this.javaBtn.Size = new System.Drawing.Size(39, 20);
            this.javaBtn.TabIndex = 28;
            this.javaBtn.Text = "...";
            this.javaBtn.UseVisualStyleBackColor = true;
            this.javaBtn.Click += new System.EventHandler(this.javaBtn_Click);
            // 
            // grbGame
            // 
            this.grbGame.BackColor = System.Drawing.SystemColors.Control;
            this.grbGame.Controls.Add(this.lblGameArgs);
            this.grbGame.Controls.Add(this.gameArgsBox);
            this.grbGame.Controls.Add(this.lblJvmArgs);
            this.grbGame.Controls.Add(this.jvmArgsBox);
            this.grbGame.Controls.Add(this.chkOffline);
            this.grbGame.Controls.Add(this.chkUseDemo);
            this.grbGame.Controls.Add(this.chkProxy);
            this.grbGame.Controls.Add(this.chkMulti);
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
            this.grbGame.Controls.Add(this.dirBtn);
            this.grbGame.Controls.Add(this.lblReso);
            this.grbGame.Controls.Add(this.nameBox);
            this.grbGame.Controls.Add(this.dirBox);
            this.grbGame.Location = new System.Drawing.Point(366, 2);
            this.grbGame.Name = "grbGame";
            this.grbGame.Size = new System.Drawing.Size(425, 218);
            this.grbGame.TabIndex = 28;
            this.grbGame.TabStop = false;
            this.grbGame.Text = "grb.Game";
            // 
            // lblGameArgs
            // 
            this.lblGameArgs.AutoSize = true;
            this.lblGameArgs.Location = new System.Drawing.Point(6, 152);
            this.lblGameArgs.Name = "lblGameArgs";
            this.lblGameArgs.Size = new System.Drawing.Size(67, 13);
            this.lblGameArgs.TabIndex = 28;
            this.lblGameArgs.Text = "lbl.gameArgs";
            // 
            // gameArgsBox
            // 
            this.gameArgsBox.Location = new System.Drawing.Point(99, 149);
            this.gameArgsBox.Name = "gameArgsBox";
            this.gameArgsBox.Size = new System.Drawing.Size(318, 20);
            this.gameArgsBox.TabIndex = 27;
            // 
            // lblJvmArgs
            // 
            this.lblJvmArgs.AutoSize = true;
            this.lblJvmArgs.Location = new System.Drawing.Point(6, 126);
            this.lblJvmArgs.Name = "lblJvmArgs";
            this.lblJvmArgs.Size = new System.Drawing.Size(57, 13);
            this.lblJvmArgs.TabIndex = 26;
            this.lblJvmArgs.Text = "lbl.jvmArgs";
            // 
            // jvmArgsBox
            // 
            this.jvmArgsBox.Location = new System.Drawing.Point(99, 123);
            this.jvmArgsBox.Name = "jvmArgsBox";
            this.jvmArgsBox.Size = new System.Drawing.Size(318, 20);
            this.jvmArgsBox.TabIndex = 25;
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(6, 195);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(77, 17);
            this.chkOffline.TabIndex = 23;
            this.chkOffline.Text = "chk.Offline";
            this.chkOffline.UseVisualStyleBackColor = true;
            // 
            // chkUseDemo
            // 
            this.chkUseDemo.AutoSize = true;
            this.chkUseDemo.Location = new System.Drawing.Point(237, 172);
            this.chkUseDemo.Name = "chkUseDemo";
            this.chkUseDemo.Size = new System.Drawing.Size(94, 17);
            this.chkUseDemo.TabIndex = 22;
            this.chkUseDemo.Text = "chk.UseDemo";
            this.chkUseDemo.UseVisualStyleBackColor = true;
            // 
            // chkProxy
            // 
            this.chkProxy.AutoSize = true;
            this.chkProxy.Location = new System.Drawing.Point(6, 172);
            this.chkProxy.Name = "chkProxy";
            this.chkProxy.Size = new System.Drawing.Size(73, 17);
            this.chkProxy.TabIndex = 21;
            this.chkProxy.Text = "chk.Proxy";
            this.chkProxy.UseVisualStyleBackColor = true;
            // 
            // chkMulti
            // 
            this.chkMulti.AutoSize = true;
            this.chkMulti.Location = new System.Drawing.Point(237, 195);
            this.chkMulti.Name = "chkMulti";
            this.chkMulti.Size = new System.Drawing.Size(69, 17);
            this.chkMulti.TabIndex = 24;
            this.chkMulti.Text = "chk.Multi";
            this.chkMulti.UseVisualStyleBackColor = true;
            // 
            // ramMaxBox
            // 
            this.ramMaxBox.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMaxBox.Location = new System.Drawing.Point(99, 97);
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
            this.ramMaxBox.Size = new System.Drawing.Size(140, 20);
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
            this.ramMinBox.Location = new System.Drawing.Point(277, 97);
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
            this.ramMinBox.Size = new System.Drawing.Size(140, 20);
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
            this.lblMemMin.Location = new System.Drawing.Point(246, 99);
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
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Location = new System.Drawing.Point(6, 99);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(43, 13);
            this.lblMem.TabIndex = 14;
            this.lblMem.Text = "lbl.Mem";
            // 
            // resXBox
            // 
            this.resXBox.Location = new System.Drawing.Point(99, 71);
            this.resXBox.Name = "resXBox";
            this.resXBox.Size = new System.Drawing.Size(140, 20);
            this.resXBox.TabIndex = 15;
            // 
            // resYBox
            // 
            this.resYBox.Location = new System.Drawing.Point(277, 71);
            this.resYBox.Name = "resYBox";
            this.resYBox.Size = new System.Drawing.Size(140, 20);
            this.resYBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "x";
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
            // lblGameDir
            // 
            this.lblGameDir.AutoSize = true;
            this.lblGameDir.Location = new System.Drawing.Point(6, 48);
            this.lblGameDir.Name = "lblGameDir";
            this.lblGameDir.Size = new System.Drawing.Size(61, 13);
            this.lblGameDir.TabIndex = 5;
            this.lblGameDir.Text = "lbl.GameDir";
            // 
            // dirBtn
            // 
            this.dirBtn.Location = new System.Drawing.Point(378, 45);
            this.dirBtn.Name = "dirBtn";
            this.dirBtn.Size = new System.Drawing.Size(39, 20);
            this.dirBtn.TabIndex = 14;
            this.dirBtn.Text = "...";
            this.dirBtn.UseVisualStyleBackColor = true;
            this.dirBtn.Click += new System.EventHandler(this.dirBtn_Click);
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
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(99, 19);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(318, 20);
            this.nameBox.TabIndex = 12;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(99, 45);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(273, 20);
            this.dirBox.TabIndex = 13;
            // 
            // grbXbox
            // 
            this.grbXbox.BackColor = System.Drawing.SystemColors.Control;
            this.grbXbox.Controls.Add(this.chkXboxDemo);
            this.grbXbox.Controls.Add(this.lblXboxProfName);
            this.grbXbox.Controls.Add(this.xboxNameBox);
            this.grbXbox.Location = new System.Drawing.Point(366, 2);
            this.grbXbox.Name = "grbXbox";
            this.grbXbox.Size = new System.Drawing.Size(425, 71);
            this.grbXbox.TabIndex = 29;
            this.grbXbox.TabStop = false;
            this.grbXbox.Text = "grb.Xbox";
            this.grbXbox.Visible = false;
            // 
            // chkXboxDemo
            // 
            this.chkXboxDemo.AutoSize = true;
            this.chkXboxDemo.Location = new System.Drawing.Point(9, 47);
            this.chkXboxDemo.Name = "chkXboxDemo";
            this.chkXboxDemo.Size = new System.Drawing.Size(99, 17);
            this.chkXboxDemo.TabIndex = 23;
            this.chkXboxDemo.Text = "chk.XboxDemo";
            this.chkXboxDemo.UseVisualStyleBackColor = true;
            // 
            // lblXboxProfName
            // 
            this.lblXboxProfName.AutoSize = true;
            this.lblXboxProfName.Location = new System.Drawing.Point(6, 22);
            this.lblXboxProfName.Name = "lblXboxProfName";
            this.lblXboxProfName.Size = new System.Drawing.Size(91, 13);
            this.lblXboxProfName.TabIndex = 3;
            this.lblXboxProfName.Text = "lbl.XboxProfName";
            // 
            // xboxNameBox
            // 
            this.xboxNameBox.Location = new System.Drawing.Point(99, 19);
            this.xboxNameBox.Name = "xboxNameBox";
            this.xboxNameBox.Size = new System.Drawing.Size(318, 20);
            this.xboxNameBox.TabIndex = 12;
            this.xboxNameBox.TextChanged += new System.EventHandler(this.xboxNameBox_TextChanged);
            // 
            // chkLatest
            // 
            this.chkLatest.AutoSize = true;
            this.chkLatest.Location = new System.Drawing.Point(6, 335);
            this.chkLatest.Name = "chkLatest";
            this.chkLatest.Size = new System.Drawing.Size(168, 17);
            this.chkLatest.TabIndex = 10;
            this.chkLatest.Text = "Choose latest \'release\' version";
            this.chkLatest.UseVisualStyleBackColor = true;
            this.chkLatest.CheckedChanged += new System.EventHandler(this.chkLatest_CheckedChanged);
            // 
            // chkLatestSnapshot
            // 
            this.chkLatestSnapshot.AutoSize = true;
            this.chkLatestSnapshot.Location = new System.Drawing.Point(178, 335);
            this.chkLatestSnapshot.Name = "chkLatestSnapshot";
            this.chkLatestSnapshot.Size = new System.Drawing.Size(177, 17);
            this.chkLatestSnapshot.TabIndex = 11;
            this.chkLatestSnapshot.Text = "Choose latest \'snapshot\' version";
            this.chkLatestSnapshot.UseVisualStyleBackColor = true;
            this.chkLatestSnapshot.CheckedChanged += new System.EventHandler(this.chkLatestSnapshot_CheckedChanged);
            // 
            // NewInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 386);
            this.Controls.Add(this.grbForExp);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grbGame);
            this.Controls.Add(this.grbXbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewInstance";
            this.Text = "Profile editor";
            this.tabControl1.ResumeLayout(false);
            this.vanillaPage.ResumeLayout(false);
            this.vanillaPage.PerformLayout();
            this.eduPage.ResumeLayout(false);
            this.xboxPage.ResumeLayout(false);
            this.grbForExp.ResumeLayout(false);
            this.grbForExp.PerformLayout();
            this.grbGame.ResumeLayout(false);
            this.grbGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).EndInit();
            this.grbXbox.ResumeLayout(false);
            this.grbXbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TabPage vanillaPage;
        private System.Windows.Forms.TabPage xboxPage;
        private System.Windows.Forms.ListView vanillaList;
        private System.Windows.Forms.CheckBox vanillaExperimental;
        private System.Windows.Forms.CheckBox vanillaSnapshot;
        private System.Windows.Forms.CheckBox vanillaRelease;
        private System.Windows.Forms.CheckBox vanillaBeta;
        private System.Windows.Forms.CheckBox vanillaAlpha;
        private System.Windows.Forms.CheckBox vanillaInfdev;
        private System.Windows.Forms.CheckBox vanillaIndev;
        private System.Windows.Forms.CheckBox vanillaClassic;
        private System.Windows.Forms.CheckBox vanillaPreclassic;
        private System.Windows.Forms.GroupBox grbForExp;
        private System.Windows.Forms.CheckBox chkAssetIndex;
        private System.Windows.Forms.Button assetIndexBtn;
        private System.Windows.Forms.TextBox assetIndexBox;
        private System.Windows.Forms.CheckBox chkCustJava;
        private System.Windows.Forms.CheckBox chkCustJson;
        private System.Windows.Forms.TextBox classBox;
        private System.Windows.Forms.CheckBox chkClasspath;
        private System.Windows.Forms.Button jsonBtn;
        private System.Windows.Forms.TextBox jsonBox;
        private System.Windows.Forms.TextBox javaBox;
        private System.Windows.Forms.Button javaBtn;
        private System.Windows.Forms.GroupBox grbGame;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.CheckBox chkUseDemo;
        private System.Windows.Forms.CheckBox chkProxy;
        private System.Windows.Forms.CheckBox chkMulti;
        private System.Windows.Forms.NumericUpDown ramMaxBox;
        private System.Windows.Forms.NumericUpDown ramMinBox;
        private System.Windows.Forms.Label lblMemMin;
        private System.Windows.Forms.Label lblMemMax;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.TextBox resXBox;
        private System.Windows.Forms.TextBox resYBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProfName;
        private System.Windows.Forms.Label lblGameDir;
        private System.Windows.Forms.Button dirBtn;
        private System.Windows.Forms.Label lblReso;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.TabPage eduPage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView eduList;
        private System.Windows.Forms.ListView xboxList;
        private System.Windows.Forms.GroupBox grbXbox;
        private System.Windows.Forms.CheckBox chkXboxDemo;
        private System.Windows.Forms.Label lblXboxProfName;
        private System.Windows.Forms.TextBox xboxNameBox;
        private System.Windows.Forms.Label lblJvmArgs;
        private System.Windows.Forms.TextBox jvmArgsBox;
        private System.Windows.Forms.Label lblGameArgs;
        private System.Windows.Forms.TextBox gameArgsBox;
        private System.Windows.Forms.CheckBox chkLatest;
        private System.Windows.Forms.CheckBox chkLatestSnapshot;
    }
}