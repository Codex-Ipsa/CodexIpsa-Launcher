namespace MCLauncher
{
    partial class HomeScreen
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblLogInWarn = new System.Windows.Forms.Label();
            this.btnEditInst = new System.Windows.Forms.Button();
            this.btnNewInst = new System.Windows.Forms.Button();
            this.cmbInstaces = new System.Windows.Forms.ComboBox();
            this.lblSelInst = new System.Windows.Forms.Label();
            this.lblReady = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pnlChangelog = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.lblLogInWarn);
            this.panel1.Controls.Add(this.btnEditInst);
            this.panel1.Controls.Add(this.btnNewInst);
            this.panel1.Controls.Add(this.cmbInstaces);
            this.panel1.Controls.Add(this.lblSelInst);
            this.panel1.Controls.Add(this.lblReady);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.btnLogIn);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 64);
            this.panel1.TabIndex = 3;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogOut.Location = new System.Drawing.Point(621, 39);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 21;
            this.btnLogOut.Text = "btn.logOut";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblLogInWarn
            // 
            this.lblLogInWarn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLogInWarn.BackColor = System.Drawing.Color.Transparent;
            this.lblLogInWarn.ForeColor = System.Drawing.Color.White;
            this.lblLogInWarn.Location = new System.Drawing.Point(214, 44);
            this.lblLogInWarn.Name = "lblLogInWarn";
            this.lblLogInWarn.Size = new System.Drawing.Size(353, 13);
            this.lblLogInWarn.TabIndex = 20;
            this.lblLogInWarn.Text = "lbl.logInWarn";
            this.lblLogInWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditInst
            // 
            this.btnEditInst.Location = new System.Drawing.Point(79, 41);
            this.btnEditInst.Name = "btnEditInst";
            this.btnEditInst.Size = new System.Drawing.Size(68, 21);
            this.btnEditInst.TabIndex = 19;
            this.btnEditInst.Text = "btn.editInst";
            this.btnEditInst.UseVisualStyleBackColor = true;
            this.btnEditInst.Click += new System.EventHandler(this.btnEditInst_Click);
            // 
            // btnNewInst
            // 
            this.btnNewInst.Location = new System.Drawing.Point(5, 41);
            this.btnNewInst.Name = "btnNewInst";
            this.btnNewInst.Size = new System.Drawing.Size(68, 21);
            this.btnNewInst.TabIndex = 18;
            this.btnNewInst.Text = "btn.newInst";
            this.btnNewInst.UseVisualStyleBackColor = true;
            this.btnNewInst.Click += new System.EventHandler(this.btnNewInst_Click);
            // 
            // cmbInstaces
            // 
            this.cmbInstaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstaces.FormattingEnabled = true;
            this.cmbInstaces.Location = new System.Drawing.Point(6, 19);
            this.cmbInstaces.Name = "cmbInstaces";
            this.cmbInstaces.Size = new System.Drawing.Size(142, 21);
            this.cmbInstaces.TabIndex = 17;
            this.cmbInstaces.SelectedIndexChanged += new System.EventHandler(this.cmbInstaces_SelectedIndexChanged);
            this.cmbInstaces.Click += new System.EventHandler(this.cmbInstaces_Click);
            // 
            // lblSelInst
            // 
            this.lblSelInst.AutoSize = true;
            this.lblSelInst.BackColor = System.Drawing.Color.Transparent;
            this.lblSelInst.ForeColor = System.Drawing.Color.White;
            this.lblSelInst.Location = new System.Drawing.Point(3, 5);
            this.lblSelInst.Name = "lblSelInst";
            this.lblSelInst.Size = new System.Drawing.Size(50, 13);
            this.lblSelInst.TabIndex = 15;
            this.lblSelInst.Text = "lbl.selInst";
            // 
            // lblReady
            // 
            this.lblReady.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblReady.BackColor = System.Drawing.Color.Transparent;
            this.lblReady.ForeColor = System.Drawing.Color.White;
            this.lblReady.Location = new System.Drawing.Point(484, 22);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(353, 13);
            this.lblReady.TabIndex = 14;
            this.lblReady.Text = "lbl.ready {gameVer}";
            this.lblReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(540, 5);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(241, 13);
            this.lblWelcome.TabIndex = 12;
            this.lblWelcome.Text = "lbl.welcome {playerName}";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogIn.Location = new System.Drawing.Point(621, 38);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 1;
            this.btnLogIn.Text = "btn.logIn";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlay.Location = new System.Drawing.Point(355, 20);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "btn.play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pnlChangelog
            // 
            this.pnlChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChangelog.BackColor = System.Drawing.Color.Transparent;
            this.pnlChangelog.Location = new System.Drawing.Point(0, 0);
            this.pnlChangelog.Margin = new System.Windows.Forms.Padding(2);
            this.pnlChangelog.Name = "pnlChangelog";
            this.pnlChangelog.Size = new System.Drawing.Size(784, 325);
            this.pnlChangelog.TabIndex = 4;
            this.pnlChangelog.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlChangelog_Scroll);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.pnlChangelog);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(784, 387);
            this.Name = "HomeScreen";
            this.Size = new System.Drawing.Size(784, 387);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Label lblSelInst;
        private System.Windows.Forms.Button btnEditInst;
        private System.Windows.Forms.Button btnNewInst;
        private System.Windows.Forms.ComboBox cmbInstaces;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblLogInWarn;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel pnlChangelog;
    }
}
