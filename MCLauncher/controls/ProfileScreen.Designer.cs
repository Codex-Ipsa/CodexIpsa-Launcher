﻿namespace MCLauncher.controls
{
    partial class ProfileScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileScreen));
            this.listView1 = new System.Windows.Forms.ListView();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.versionLbl = new System.Windows.Forms.Label();
            this.playBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.instanceLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(630, 381);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // iconPanel
            // 
            this.iconPanel.BackColor = System.Drawing.Color.Transparent;
            this.iconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPanel.Location = new System.Drawing.Point(667, 21);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(85, 85);
            this.iconPanel.TabIndex = 1;
            // 
            // versionLbl
            // 
            this.versionLbl.BackColor = System.Drawing.Color.Transparent;
            this.versionLbl.ForeColor = System.Drawing.Color.White;
            this.versionLbl.Location = new System.Drawing.Point(639, 109);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(142, 27);
            this.versionLbl.TabIndex = 2;
            this.versionLbl.Text = "Ready to play\r\nVERSION";
            this.versionLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(667, 167);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(85, 23);
            this.playBtn.TabIndex = 3;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(667, 196);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(85, 23);
            this.editBtn.TabIndex = 4;
            this.editBtn.Text = "Edit profile";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(667, 361);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(85, 23);
            this.newBtn.TabIndex = 5;
            this.newBtn.Text = "New profile";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(667, 225);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(85, 23);
            this.exportBtn.TabIndex = 6;
            this.exportBtn.Text = "Export profile";
            this.exportBtn.UseVisualStyleBackColor = true;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(667, 332);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(85, 23);
            this.importBtn.TabIndex = 7;
            this.importBtn.Text = "Import profile";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(639, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Time played:\r\n00:00:00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instanceLbl
            // 
            this.instanceLbl.BackColor = System.Drawing.Color.Transparent;
            this.instanceLbl.ForeColor = System.Drawing.Color.White;
            this.instanceLbl.Location = new System.Drawing.Point(639, 3);
            this.instanceLbl.Name = "instanceLbl";
            this.instanceLbl.Size = new System.Drawing.Size(142, 15);
            this.instanceLbl.TabIndex = 9;
            this.instanceLbl.Text = "INSTANCE";
            this.instanceLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProfileScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.instanceLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.iconPanel);
            this.Controls.Add(this.listView1);
            this.Name = "ProfileScreen";
            this.Size = new System.Drawing.Size(784, 387);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel iconPanel;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label instanceLbl;
    }
}
