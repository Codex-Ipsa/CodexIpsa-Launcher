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
            this.ipsaPage = new System.Windows.Forms.TabPage();
            this.eduPage = new System.Windows.Forms.TabPage();
            this.xboxPage = new System.Windows.Forms.TabPage();
            this.forgePage = new System.Windows.Forms.TabPage();
            this.fabricPage = new System.Windows.Forms.TabPage();
            this.risugamiPage = new System.Windows.Forms.TabPage();
            this.quiltPage = new System.Windows.Forms.TabPage();
            this.neoforgePage = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
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
            this.iconBtn = new System.Windows.Forms.Button();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.chkUseDemo = new System.Windows.Forms.CheckBox();
            this.chkProxy = new System.Windows.Forms.CheckBox();
            this.chkMulti = new System.Windows.Forms.CheckBox();
            this.aftBox = new System.Windows.Forms.TextBox();
            this.lblAftCmd = new System.Windows.Forms.Label();
            this.befBox = new System.Windows.Forms.TextBox();
            this.lblBefCmd = new System.Windows.Forms.Label();
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
            this.button2 = new System.Windows.Forms.Button();
            this.lblReso = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.vanillaPage.SuspendLayout();
            this.grbForExp.SuspendLayout();
            this.grbGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.vanillaPage);
            this.tabControl1.Controls.Add(this.ipsaPage);
            this.tabControl1.Controls.Add(this.eduPage);
            this.tabControl1.Controls.Add(this.xboxPage);
            this.tabControl1.Controls.Add(this.forgePage);
            this.tabControl1.Controls.Add(this.fabricPage);
            this.tabControl1.Controls.Add(this.risugamiPage);
            this.tabControl1.Controls.Add(this.quiltPage);
            this.tabControl1.Controls.Add(this.neoforgePage);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 18);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(362, 375);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // vanillaPage
            // 
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
            this.vanillaPage.Location = new System.Drawing.Point(4, 40);
            this.vanillaPage.Name = "vanillaPage";
            this.vanillaPage.Size = new System.Drawing.Size(354, 331);
            this.vanillaPage.TabIndex = 0;
            this.vanillaPage.Text = "Vanilla";
            this.vanillaPage.UseVisualStyleBackColor = true;
            // 
            // vanillaExperimental
            // 
            this.vanillaExperimental.AutoSize = true;
            this.vanillaExperimental.Checked = true;
            this.vanillaExperimental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vanillaExperimental.Location = new System.Drawing.Point(210, 309);
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
            this.vanillaSnapshot.Location = new System.Drawing.Point(133, 309);
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
            this.vanillaRelease.Location = new System.Drawing.Point(62, 309);
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
            this.vanillaBeta.Location = new System.Drawing.Point(8, 309);
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
            this.vanillaAlpha.Location = new System.Drawing.Point(277, 286);
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
            this.vanillaInfdev.Location = new System.Drawing.Point(215, 286);
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
            this.vanillaIndev.Location = new System.Drawing.Point(156, 286);
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
            this.vanillaClassic.Location = new System.Drawing.Point(91, 286);
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
            this.vanillaPreclassic.Location = new System.Drawing.Point(8, 286);
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
            this.vanillaList.Size = new System.Drawing.Size(348, 277);
            this.vanillaList.TabIndex = 0;
            this.vanillaList.UseCompatibleStateImageBehavior = false;
            this.vanillaList.View = System.Windows.Forms.View.Details;
            this.vanillaList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.vanillaList_ColumnWidthChanging);
            // 
            // ipsaPage
            // 
            this.ipsaPage.ImageIndex = 1;
            this.ipsaPage.Location = new System.Drawing.Point(4, 40);
            this.ipsaPage.Name = "ipsaPage";
            this.ipsaPage.Size = new System.Drawing.Size(354, 331);
            this.ipsaPage.TabIndex = 1;
            this.ipsaPage.Text = "Codex-Ipsa Mods";
            this.ipsaPage.UseVisualStyleBackColor = true;
            // 
            // eduPage
            // 
            this.eduPage.ImageIndex = 0;
            this.eduPage.Location = new System.Drawing.Point(4, 40);
            this.eduPage.Name = "eduPage";
            this.eduPage.Size = new System.Drawing.Size(354, 331);
            this.eduPage.TabIndex = 5;
            this.eduPage.Text = "MinecraftEdu";
            this.eduPage.UseVisualStyleBackColor = true;
            // 
            // xboxPage
            // 
            this.xboxPage.ImageIndex = 0;
            this.xboxPage.Location = new System.Drawing.Point(4, 40);
            this.xboxPage.Name = "xboxPage";
            this.xboxPage.Size = new System.Drawing.Size(354, 331);
            this.xboxPage.TabIndex = 4;
            this.xboxPage.Text = "Xbox 360";
            this.xboxPage.UseVisualStyleBackColor = true;
            // 
            // forgePage
            // 
            this.forgePage.ImageIndex = 2;
            this.forgePage.Location = new System.Drawing.Point(4, 40);
            this.forgePage.Name = "forgePage";
            this.forgePage.Size = new System.Drawing.Size(354, 331);
            this.forgePage.TabIndex = 2;
            this.forgePage.Text = "Forge";
            this.forgePage.UseVisualStyleBackColor = true;
            // 
            // fabricPage
            // 
            this.fabricPage.ImageIndex = 3;
            this.fabricPage.Location = new System.Drawing.Point(4, 40);
            this.fabricPage.Name = "fabricPage";
            this.fabricPage.Size = new System.Drawing.Size(354, 331);
            this.fabricPage.TabIndex = 3;
            this.fabricPage.Text = "Fabric";
            this.fabricPage.UseVisualStyleBackColor = true;
            // 
            // risugamiPage
            // 
            this.risugamiPage.ImageIndex = 0;
            this.risugamiPage.Location = new System.Drawing.Point(4, 40);
            this.risugamiPage.Name = "risugamiPage";
            this.risugamiPage.Size = new System.Drawing.Size(354, 331);
            this.risugamiPage.TabIndex = 6;
            this.risugamiPage.Text = "ModLoader";
            this.risugamiPage.UseVisualStyleBackColor = true;
            // 
            // quiltPage
            // 
            this.quiltPage.ImageIndex = 4;
            this.quiltPage.Location = new System.Drawing.Point(4, 40);
            this.quiltPage.Name = "quiltPage";
            this.quiltPage.Size = new System.Drawing.Size(354, 331);
            this.quiltPage.TabIndex = 7;
            this.quiltPage.Text = "Quilt";
            this.quiltPage.UseVisualStyleBackColor = true;
            // 
            // neoforgePage
            // 
            this.neoforgePage.ImageIndex = 5;
            this.neoforgePage.Location = new System.Drawing.Point(4, 40);
            this.neoforgePage.Name = "neoforgePage";
            this.neoforgePage.Size = new System.Drawing.Size(354, 331);
            this.neoforgePage.TabIndex = 8;
            this.neoforgePage.Text = "NeoForge";
            this.neoforgePage.UseVisualStyleBackColor = true;
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.grbForExp.Location = new System.Drawing.Point(366, 210);
            this.grbForExp.Name = "grbForExp";
            this.grbForExp.Size = new System.Drawing.Size(425, 124);
            this.grbForExp.TabIndex = 29;
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
            // 
            // assetIndexBtn
            // 
            this.assetIndexBtn.Location = new System.Drawing.Point(378, 97);
            this.assetIndexBtn.Name = "assetIndexBtn";
            this.assetIndexBtn.Size = new System.Drawing.Size(43, 20);
            this.assetIndexBtn.TabIndex = 35;
            this.assetIndexBtn.Text = "...";
            this.assetIndexBtn.UseVisualStyleBackColor = true;
            // 
            // assetIndexBox
            // 
            this.assetIndexBox.Location = new System.Drawing.Point(106, 98);
            this.assetIndexBox.Name = "assetIndexBox";
            this.assetIndexBox.Size = new System.Drawing.Size(266, 20);
            this.assetIndexBox.TabIndex = 34;
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
            // 
            // classBox
            // 
            this.classBox.Location = new System.Drawing.Point(106, 72);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(315, 20);
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
            // 
            // jsonBtn
            // 
            this.jsonBtn.Location = new System.Drawing.Point(378, 46);
            this.jsonBtn.Name = "jsonBtn";
            this.jsonBtn.Size = new System.Drawing.Size(43, 20);
            this.jsonBtn.TabIndex = 31;
            this.jsonBtn.Text = "...";
            this.jsonBtn.UseVisualStyleBackColor = true;
            // 
            // jsonBox
            // 
            this.jsonBox.Location = new System.Drawing.Point(106, 46);
            this.jsonBox.Name = "jsonBox";
            this.jsonBox.Size = new System.Drawing.Size(266, 20);
            this.jsonBox.TabIndex = 30;
            // 
            // javaBox
            // 
            this.javaBox.Location = new System.Drawing.Point(106, 19);
            this.javaBox.Name = "javaBox";
            this.javaBox.Size = new System.Drawing.Size(266, 20);
            this.javaBox.TabIndex = 27;
            // 
            // javaBtn
            // 
            this.javaBtn.Location = new System.Drawing.Point(378, 18);
            this.javaBtn.Name = "javaBtn";
            this.javaBtn.Size = new System.Drawing.Size(43, 20);
            this.javaBtn.TabIndex = 28;
            this.javaBtn.Text = "...";
            this.javaBtn.UseVisualStyleBackColor = true;
            // 
            // grbGame
            // 
            this.grbGame.Controls.Add(this.iconBtn);
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
            this.grbGame.Controls.Add(this.button2);
            this.grbGame.Controls.Add(this.lblReso);
            this.grbGame.Controls.Add(this.nameBox);
            this.grbGame.Controls.Add(this.dirBox);
            this.grbGame.Location = new System.Drawing.Point(366, 2);
            this.grbGame.Name = "grbGame";
            this.grbGame.Size = new System.Drawing.Size(425, 202);
            this.grbGame.TabIndex = 28;
            this.grbGame.TabStop = false;
            this.grbGame.Text = "grb.Game";
            // 
            // iconBtn
            // 
            this.iconBtn.Location = new System.Drawing.Point(6, 19);
            this.iconBtn.Name = "iconBtn";
            this.iconBtn.Size = new System.Drawing.Size(50, 50);
            this.iconBtn.TabIndex = 25;
            this.iconBtn.Text = "(icon)";
            this.iconBtn.UseVisualStyleBackColor = true;
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(188, 175);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(77, 17);
            this.chkOffline.TabIndex = 23;
            this.chkOffline.Text = "chk.Offline";
            this.chkOffline.UseVisualStyleBackColor = true;
            // 
            // chkUseDemo
            // 
            this.chkUseDemo.AutoSize = true;
            this.chkUseDemo.Location = new System.Drawing.Point(88, 175);
            this.chkUseDemo.Name = "chkUseDemo";
            this.chkUseDemo.Size = new System.Drawing.Size(94, 17);
            this.chkUseDemo.TabIndex = 22;
            this.chkUseDemo.Text = "chk.UseDemo";
            this.chkUseDemo.UseVisualStyleBackColor = true;
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
            // chkMulti
            // 
            this.chkMulti.AutoSize = true;
            this.chkMulti.Location = new System.Drawing.Point(271, 175);
            this.chkMulti.Name = "chkMulti";
            this.chkMulti.Size = new System.Drawing.Size(69, 17);
            this.chkMulti.TabIndex = 24;
            this.chkMulti.Text = "chk.Multi";
            this.chkMulti.UseVisualStyleBackColor = true;
            // 
            // aftBox
            // 
            this.aftBox.Location = new System.Drawing.Point(99, 149);
            this.aftBox.Name = "aftBox";
            this.aftBox.Size = new System.Drawing.Size(318, 20);
            this.aftBox.TabIndex = 20;
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
            // befBox
            // 
            this.befBox.Location = new System.Drawing.Point(99, 123);
            this.befBox.Name = "befBox";
            this.befBox.Size = new System.Drawing.Size(318, 20);
            this.befBox.TabIndex = 19;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "x";
            // 
            // lblProfName
            // 
            this.lblProfName.AutoSize = true;
            this.lblProfName.Location = new System.Drawing.Point(62, 22);
            this.lblProfName.Name = "lblProfName";
            this.lblProfName.Size = new System.Drawing.Size(67, 13);
            this.lblProfName.TabIndex = 3;
            this.lblProfName.Text = "lbl.ProfName";
            // 
            // lblGameDir
            // 
            this.lblGameDir.AutoSize = true;
            this.lblGameDir.Location = new System.Drawing.Point(62, 49);
            this.lblGameDir.Name = "lblGameDir";
            this.lblGameDir.Size = new System.Drawing.Size(61, 13);
            this.lblGameDir.TabIndex = 5;
            this.lblGameDir.Text = "lbl.GameDir";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 20);
            this.button2.TabIndex = 14;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
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
            this.nameBox.Location = new System.Drawing.Point(154, 19);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(263, 20);
            this.nameBox.TabIndex = 12;
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(154, 45);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(218, 20);
            this.dirBox.TabIndex = 13;
            // 
            // NewInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 379);
            this.Controls.Add(this.grbForExp);
            this.Controls.Add(this.grbGame);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewInstance";
            this.Text = "Profile editor";
            this.tabControl1.ResumeLayout(false);
            this.vanillaPage.ResumeLayout(false);
            this.vanillaPage.PerformLayout();
            this.grbForExp.ResumeLayout(false);
            this.grbForExp.PerformLayout();
            this.grbGame.ResumeLayout(false);
            this.grbGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage vanillaPage;
        private System.Windows.Forms.TabPage ipsaPage;
        private System.Windows.Forms.TabPage forgePage;
        private System.Windows.Forms.TabPage fabricPage;
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
        private System.Windows.Forms.Button iconBtn;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.CheckBox chkUseDemo;
        private System.Windows.Forms.CheckBox chkProxy;
        private System.Windows.Forms.CheckBox chkMulti;
        private System.Windows.Forms.TextBox aftBox;
        private System.Windows.Forms.Label lblAftCmd;
        private System.Windows.Forms.TextBox befBox;
        private System.Windows.Forms.Label lblBefCmd;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblReso;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.TabPage eduPage;
        private System.Windows.Forms.TabPage risugamiPage;
        private System.Windows.Forms.TabPage quiltPage;
        private System.Windows.Forms.TabPage neoforgePage;
        private System.Windows.Forms.ImageList imageList1;
    }
}