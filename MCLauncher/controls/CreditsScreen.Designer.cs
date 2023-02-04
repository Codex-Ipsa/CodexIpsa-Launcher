namespace MCLauncher.controls
{
    partial class CreditsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsScreen));
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDejvossIpsa = new System.Windows.Forms.LinkLabel();
            this.lblSpecialThanks = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblLauncherBy = new System.Windows.Forms.Label();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.Transparent;
            this.pnlCenter.Controls.Add(this.panel1);
            this.pnlCenter.Controls.Add(this.lblDejvossIpsa);
            this.pnlCenter.Controls.Add(this.lblSpecialThanks);
            this.pnlCenter.Controls.Add(this.lblTeam);
            this.pnlCenter.Controls.Add(this.lblCopyright);
            this.pnlCenter.Controls.Add(this.lblLauncherBy);
            this.pnlCenter.Location = new System.Drawing.Point(228, 92);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(341, 193);
            this.pnlCenter.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(20, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 32);
            this.panel1.TabIndex = 19;
            // 
            // lblDejvossIpsa
            // 
            this.lblDejvossIpsa.ActiveLinkColor = System.Drawing.Color.White;
            this.lblDejvossIpsa.AutoSize = true;
            this.lblDejvossIpsa.BackColor = System.Drawing.Color.Transparent;
            this.lblDejvossIpsa.LinkColor = System.Drawing.Color.White;
            this.lblDejvossIpsa.Location = new System.Drawing.Point(68, 61);
            this.lblDejvossIpsa.Name = "lblDejvossIpsa";
            this.lblDejvossIpsa.Size = new System.Drawing.Size(76, 13);
            this.lblDejvossIpsa.TabIndex = 18;
            this.lblDejvossIpsa.TabStop = true;
            this.lblDejvossIpsa.Text = "lbl.dejvossIpsa";
            this.lblDejvossIpsa.VisitedLinkColor = System.Drawing.Color.White;
            this.lblDejvossIpsa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDejvossIpsa_LinkClicked);
            // 
            // lblSpecialThanks
            // 
            this.lblSpecialThanks.AutoSize = true;
            this.lblSpecialThanks.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecialThanks.ForeColor = System.Drawing.Color.White;
            this.lblSpecialThanks.Location = new System.Drawing.Point(173, 93);
            this.lblSpecialThanks.Name = "lblSpecialThanks";
            this.lblSpecialThanks.Size = new System.Drawing.Size(89, 13);
            this.lblSpecialThanks.TabIndex = 17;
            this.lblSpecialThanks.Text = "lbl.specialThanks";
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblTeam.ForeColor = System.Drawing.Color.White;
            this.lblTeam.Location = new System.Drawing.Point(20, 93);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(43, 13);
            this.lblTeam.TabIndex = 13;
            this.lblTeam.Text = "lbl.team";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.ForeColor = System.Drawing.Color.White;
            this.lblCopyright.Location = new System.Drawing.Point(248, 61);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(63, 13);
            this.lblCopyright.TabIndex = 12;
            this.lblCopyright.Text = "lbl.copyright";
            // 
            // lblLauncherBy
            // 
            this.lblLauncherBy.AutoSize = true;
            this.lblLauncherBy.BackColor = System.Drawing.Color.Transparent;
            this.lblLauncherBy.ForeColor = System.Drawing.Color.White;
            this.lblLauncherBy.Location = new System.Drawing.Point(68, 48);
            this.lblLauncherBy.Name = "lblLauncherBy";
            this.lblLauncherBy.Size = new System.Drawing.Size(73, 13);
            this.lblLauncherBy.TabIndex = 11;
            this.lblLauncherBy.Text = "lbl.launcherBy";
            // 
            // CreditsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.pnlCenter);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(784, 387);
            this.Name = "CreditsScreen";
            this.Size = new System.Drawing.Size(784, 387);
            this.pnlCenter.ResumeLayout(false);
            this.pnlCenter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.LinkLabel lblDejvossIpsa;
        public System.Windows.Forms.Label lblSpecialThanks;
        public System.Windows.Forms.Label lblTeam;
        public System.Windows.Forms.Label lblCopyright;
        public System.Windows.Forms.Label lblLauncherBy;
    }
}
