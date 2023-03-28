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
            this.listView1 = new System.Windows.Forms.ListView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.javaBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.javaBox = new System.Windows.Forms.TextBox();
            this.resXBox = new System.Windows.Forms.TextBox();
            this.resYBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ramMaxBox = new System.Windows.Forms.NumericUpDown();
            this.ramMinBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.aftBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.befBox = new System.Windows.Forms.TextBox();
            this.offlineCheck = new System.Windows.Forms.CheckBox();
            this.proxyCheck = new System.Windows.Forms.CheckBox();
            this.demoCheck = new System.Windows.Forms.CheckBox();
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
            this.modsBtn = new System.Windows.Forms.Button();
            this.checkPreClassic = new System.Windows.Forms.CheckBox();
            this.jsonBox = new System.Windows.Forms.TextBox();
            this.jsonBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mpCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(328, 355);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(713, 422);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "btn.Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(446, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(342, 20);
            this.nameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profile name";
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(446, 39);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(287, 20);
            this.dirBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Game directory";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(739, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // javaBtn
            // 
            this.javaBtn.Location = new System.Drawing.Point(739, 170);
            this.javaBtn.Name = "javaBtn";
            this.javaBtn.Size = new System.Drawing.Size(49, 20);
            this.javaBtn.TabIndex = 9;
            this.javaBtn.Text = "...";
            this.javaBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Java location";
            // 
            // javaBox
            // 
            this.javaBox.Location = new System.Drawing.Point(446, 171);
            this.javaBox.Name = "javaBox";
            this.javaBox.Size = new System.Drawing.Size(287, 20);
            this.javaBox.TabIndex = 7;
            // 
            // resXBox
            // 
            this.resXBox.Location = new System.Drawing.Point(446, 65);
            this.resXBox.Name = "resXBox";
            this.resXBox.Size = new System.Drawing.Size(150, 20);
            this.resXBox.TabIndex = 10;
            // 
            // resYBox
            // 
            this.resYBox.Location = new System.Drawing.Point(638, 65);
            this.resYBox.Name = "resYBox";
            this.resYBox.Size = new System.Drawing.Size(150, 20);
            this.resYBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Resolution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Memory";
            // 
            // ramMaxBox
            // 
            this.ramMaxBox.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ramMaxBox.Location = new System.Drawing.Point(446, 91);
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
            this.ramMaxBox.TabIndex = 15;
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
            this.ramMinBox.Location = new System.Drawing.Point(638, 93);
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
            this.ramMinBox.TabIndex = 16;
            this.ramMinBox.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Max";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "After command";
            // 
            // aftBox
            // 
            this.aftBox.Location = new System.Drawing.Point(446, 145);
            this.aftBox.Name = "aftBox";
            this.aftBox.Size = new System.Drawing.Size(342, 20);
            this.aftBox.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(346, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Before command";
            // 
            // befBox
            // 
            this.befBox.Location = new System.Drawing.Point(446, 119);
            this.befBox.Name = "befBox";
            this.befBox.Size = new System.Drawing.Size(342, 20);
            this.befBox.TabIndex = 21;
            // 
            // offlineCheck
            // 
            this.offlineCheck.AutoSize = true;
            this.offlineCheck.Location = new System.Drawing.Point(349, 248);
            this.offlineCheck.Name = "offlineCheck";
            this.offlineCheck.Size = new System.Drawing.Size(133, 17);
            this.offlineCheck.TabIndex = 23;
            this.offlineCheck.Text = "Launch in offline mode";
            this.offlineCheck.UseVisualStyleBackColor = true;
            // 
            // proxyCheck
            // 
            this.proxyCheck.AutoSize = true;
            this.proxyCheck.Location = new System.Drawing.Point(349, 271);
            this.proxyCheck.Name = "proxyCheck";
            this.proxyCheck.Size = new System.Drawing.Size(193, 17);
            this.proxyCheck.TabIndex = 24;
            this.proxyCheck.Text = "Use skin and sound proxy (<=1.5.2)";
            this.proxyCheck.UseVisualStyleBackColor = true;
            // 
            // demoCheck
            // 
            this.demoCheck.AutoSize = true;
            this.demoCheck.Location = new System.Drawing.Point(349, 225);
            this.demoCheck.Name = "demoCheck";
            this.demoCheck.Size = new System.Drawing.Size(150, 17);
            this.demoCheck.TabIndex = 25;
            this.demoCheck.Text = "Launch demo (>=12w16a)";
            this.demoCheck.UseVisualStyleBackColor = true;
            // 
            // checkClassic
            // 
            this.checkClassic.AutoSize = true;
            this.checkClassic.Checked = true;
            this.checkClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkClassic.Location = new System.Drawing.Point(95, 373);
            this.checkClassic.Name = "checkClassic";
            this.checkClassic.Size = new System.Drawing.Size(59, 17);
            this.checkClassic.TabIndex = 26;
            this.checkClassic.Text = "Classic";
            this.checkClassic.UseVisualStyleBackColor = true;
            this.checkClassic.CheckedChanged += new System.EventHandler(this.checkClassic_CheckedChanged);
            // 
            // checkIndev
            // 
            this.checkIndev.AutoSize = true;
            this.checkIndev.Checked = true;
            this.checkIndev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIndev.Location = new System.Drawing.Point(160, 373);
            this.checkIndev.Name = "checkIndev";
            this.checkIndev.Size = new System.Drawing.Size(53, 17);
            this.checkIndev.TabIndex = 27;
            this.checkIndev.Text = "Indev";
            this.checkIndev.UseVisualStyleBackColor = true;
            this.checkIndev.CheckedChanged += new System.EventHandler(this.checkIndev_CheckedChanged);
            // 
            // checkInfdev
            // 
            this.checkInfdev.AutoSize = true;
            this.checkInfdev.Checked = true;
            this.checkInfdev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkInfdev.Location = new System.Drawing.Point(219, 373);
            this.checkInfdev.Name = "checkInfdev";
            this.checkInfdev.Size = new System.Drawing.Size(56, 17);
            this.checkInfdev.TabIndex = 28;
            this.checkInfdev.Text = "Infdev";
            this.checkInfdev.UseVisualStyleBackColor = true;
            this.checkInfdev.CheckedChanged += new System.EventHandler(this.checkInfdev_CheckedChanged);
            // 
            // checkAlpha
            // 
            this.checkAlpha.AutoSize = true;
            this.checkAlpha.Checked = true;
            this.checkAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAlpha.Location = new System.Drawing.Point(281, 373);
            this.checkAlpha.Name = "checkAlpha";
            this.checkAlpha.Size = new System.Drawing.Size(53, 17);
            this.checkAlpha.TabIndex = 29;
            this.checkAlpha.Text = "Alpha";
            this.checkAlpha.UseVisualStyleBackColor = true;
            this.checkAlpha.CheckedChanged += new System.EventHandler(this.checkAlpha_CheckedChanged);
            // 
            // checkBeta
            // 
            this.checkBeta.AutoSize = true;
            this.checkBeta.Checked = true;
            this.checkBeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBeta.Location = new System.Drawing.Point(12, 399);
            this.checkBeta.Name = "checkBeta";
            this.checkBeta.Size = new System.Drawing.Size(48, 17);
            this.checkBeta.TabIndex = 30;
            this.checkBeta.Text = "Beta";
            this.checkBeta.UseVisualStyleBackColor = true;
            this.checkBeta.CheckedChanged += new System.EventHandler(this.checkBeta_CheckedChanged);
            // 
            // checkRelease
            // 
            this.checkRelease.AutoSize = true;
            this.checkRelease.Checked = true;
            this.checkRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRelease.Location = new System.Drawing.Point(66, 399);
            this.checkRelease.Name = "checkRelease";
            this.checkRelease.Size = new System.Drawing.Size(65, 17);
            this.checkRelease.TabIndex = 31;
            this.checkRelease.Text = "Release";
            this.checkRelease.UseVisualStyleBackColor = true;
            this.checkRelease.CheckedChanged += new System.EventHandler(this.checkRelease_CheckedChanged);
            // 
            // checkSnapshot
            // 
            this.checkSnapshot.AutoSize = true;
            this.checkSnapshot.Checked = true;
            this.checkSnapshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSnapshot.Location = new System.Drawing.Point(137, 399);
            this.checkSnapshot.Name = "checkSnapshot";
            this.checkSnapshot.Size = new System.Drawing.Size(71, 17);
            this.checkSnapshot.TabIndex = 32;
            this.checkSnapshot.Text = "Snapshot";
            this.checkSnapshot.UseVisualStyleBackColor = true;
            this.checkSnapshot.CheckedChanged += new System.EventHandler(this.checkSnapshot_CheckedChanged);
            // 
            // checkExperimental
            // 
            this.checkExperimental.AutoSize = true;
            this.checkExperimental.Checked = true;
            this.checkExperimental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExperimental.Location = new System.Drawing.Point(214, 399);
            this.checkExperimental.Name = "checkExperimental";
            this.checkExperimental.Size = new System.Drawing.Size(86, 17);
            this.checkExperimental.TabIndex = 33;
            this.checkExperimental.Text = "Experimental";
            this.checkExperimental.UseVisualStyleBackColor = true;
            this.checkExperimental.CheckedChanged += new System.EventHandler(this.checkExperimental_CheckedChanged);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(632, 422);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 34;
            this.openBtn.Text = "btn.OpenDir";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(551, 422);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 35;
            this.deleteBtn.Text = "btn.Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // modsBtn
            // 
            this.modsBtn.Location = new System.Drawing.Point(12, 422);
            this.modsBtn.Name = "modsBtn";
            this.modsBtn.Size = new System.Drawing.Size(75, 23);
            this.modsBtn.TabIndex = 36;
            this.modsBtn.Text = "btn.Mods";
            this.modsBtn.UseVisualStyleBackColor = true;
            // 
            // checkPreClassic
            // 
            this.checkPreClassic.AutoSize = true;
            this.checkPreClassic.Checked = true;
            this.checkPreClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPreClassic.Location = new System.Drawing.Point(12, 373);
            this.checkPreClassic.Name = "checkPreClassic";
            this.checkPreClassic.Size = new System.Drawing.Size(77, 17);
            this.checkPreClassic.TabIndex = 37;
            this.checkPreClassic.Text = "Pre-classic";
            this.checkPreClassic.UseVisualStyleBackColor = true;
            this.checkPreClassic.CheckedChanged += new System.EventHandler(this.checkPreClassic_CheckedChanged);
            // 
            // jsonBox
            // 
            this.jsonBox.Location = new System.Drawing.Point(446, 197);
            this.jsonBox.Name = "jsonBox";
            this.jsonBox.Size = new System.Drawing.Size(287, 20);
            this.jsonBox.TabIndex = 38;
            // 
            // jsonBtn
            // 
            this.jsonBtn.Location = new System.Drawing.Point(739, 197);
            this.jsonBtn.Name = "jsonBtn";
            this.jsonBtn.Size = new System.Drawing.Size(49, 20);
            this.jsonBtn.TabIndex = 39;
            this.jsonBtn.Text = "...";
            this.jsonBtn.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(346, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Launch JSON";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(626, 406);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Work in progress - UNFINISHED";
            // 
            // mpCheck
            // 
            this.mpCheck.AutoSize = true;
            this.mpCheck.Location = new System.Drawing.Point(349, 294);
            this.mpCheck.Name = "mpCheck";
            this.mpCheck.Size = new System.Drawing.Size(105, 17);
            this.mpCheck.TabIndex = 42;
            this.mpCheck.Text = "Force multiplayer";
            this.mpCheck.UseVisualStyleBackColor = true;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.mpCheck);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.jsonBtn);
            this.Controls.Add(this.jsonBox);
            this.Controls.Add(this.checkPreClassic);
            this.Controls.Add(this.modsBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.checkExperimental);
            this.Controls.Add(this.checkSnapshot);
            this.Controls.Add(this.checkRelease);
            this.Controls.Add(this.checkBeta);
            this.Controls.Add(this.checkAlpha);
            this.Controls.Add(this.checkInfdev);
            this.Controls.Add(this.checkIndev);
            this.Controls.Add(this.checkClassic);
            this.Controls.Add(this.demoCheck);
            this.Controls.Add(this.proxyCheck);
            this.Controls.Add(this.offlineCheck);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.befBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.aftBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ramMinBox);
            this.Controls.Add(this.ramMaxBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resYBox);
            this.Controls.Add(this.resXBox);
            this.Controls.Add(this.javaBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.javaBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dirBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.listView1);
            this.Name = "Profile";
            this.Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)(this.ramMaxBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramMinBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button javaBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox javaBox;
        private System.Windows.Forms.TextBox resXBox;
        private System.Windows.Forms.TextBox resYBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ramMaxBox;
        private System.Windows.Forms.NumericUpDown ramMinBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox aftBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox befBox;
        private System.Windows.Forms.CheckBox offlineCheck;
        private System.Windows.Forms.CheckBox proxyCheck;
        private System.Windows.Forms.CheckBox demoCheck;
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
        private System.Windows.Forms.Button modsBtn;
        private System.Windows.Forms.CheckBox checkPreClassic;
        private System.Windows.Forms.TextBox jsonBox;
        private System.Windows.Forms.Button jsonBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox mpCheck;
    }
}