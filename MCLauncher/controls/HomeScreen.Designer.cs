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
            panel1 = new System.Windows.Forms.Panel();
            btnLogOut = new System.Windows.Forms.Button();
            lblLogInWarn = new System.Windows.Forms.Label();
            btnEditInst = new System.Windows.Forms.Button();
            btnNewInst = new System.Windows.Forms.Button();
            cmbInstaces = new System.Windows.Forms.ComboBox();
            lblSelInst = new System.Windows.Forms.Label();
            lblReady = new System.Windows.Forms.Label();
            lblWelcome = new System.Windows.Forms.Label();
            btnLogIn = new System.Windows.Forms.Button();
            btnPlay = new System.Windows.Forms.Button();
            webBrowser1 = new System.Windows.Forms.WebBrowser();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(lblLogInWarn);
            panel1.Controls.Add(btnEditInst);
            panel1.Controls.Add(btnNewInst);
            panel1.Controls.Add(cmbInstaces);
            panel1.Controls.Add(lblSelInst);
            panel1.Controls.Add(lblReady);
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(btnLogIn);
            panel1.Controls.Add(btnPlay);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 315);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(784, 72);
            panel1.TabIndex = 3;
            // 
            // btnLogOut
            // 
            btnLogOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnLogOut.Location = new System.Drawing.Point(593, 43);
            btnLogOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new System.Drawing.Size(88, 27);
            btnLogOut.TabIndex = 21;
            btnLogOut.Text = "btn.logOut";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // lblLogInWarn
            // 
            lblLogInWarn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblLogInWarn.BackColor = System.Drawing.Color.Transparent;
            lblLogInWarn.ForeColor = System.Drawing.Color.White;
            lblLogInWarn.Location = new System.Drawing.Point(185, 48);
            lblLogInWarn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLogInWarn.Name = "lblLogInWarn";
            lblLogInWarn.Size = new System.Drawing.Size(412, 15);
            lblLogInWarn.TabIndex = 20;
            lblLogInWarn.Text = "lbl.logInWarn";
            lblLogInWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditInst
            // 
            btnEditInst.Location = new System.Drawing.Point(103, 47);
            btnEditInst.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEditInst.Name = "btnEditInst";
            btnEditInst.Size = new System.Drawing.Size(89, 24);
            btnEditInst.TabIndex = 19;
            btnEditInst.Text = "btn.editInst";
            btnEditInst.UseVisualStyleBackColor = true;
            btnEditInst.Click += btnEditInst_Click;
            // 
            // btnNewInst
            // 
            btnNewInst.Location = new System.Drawing.Point(6, 47);
            btnNewInst.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewInst.Name = "btnNewInst";
            btnNewInst.Size = new System.Drawing.Size(90, 24);
            btnNewInst.TabIndex = 18;
            btnNewInst.Text = "btn.newInst";
            btnNewInst.UseVisualStyleBackColor = true;
            btnNewInst.Click += btnNewInst_Click;
            // 
            // cmbInstaces
            // 
            cmbInstaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbInstaces.FormattingEnabled = true;
            cmbInstaces.Location = new System.Drawing.Point(7, 22);
            cmbInstaces.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbInstaces.Name = "cmbInstaces";
            cmbInstaces.Size = new System.Drawing.Size(184, 23);
            cmbInstaces.TabIndex = 17;
            cmbInstaces.SelectedIndexChanged += cmbInstaces_SelectedIndexChanged;
            cmbInstaces.Click += cmbInstaces_Click;
            // 
            // lblSelInst
            // 
            lblSelInst.AutoSize = true;
            lblSelInst.BackColor = System.Drawing.Color.Transparent;
            lblSelInst.ForeColor = System.Drawing.Color.White;
            lblSelInst.Location = new System.Drawing.Point(4, 6);
            lblSelInst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSelInst.Name = "lblSelInst";
            lblSelInst.Size = new System.Drawing.Size(56, 15);
            lblSelInst.TabIndex = 15;
            lblSelInst.Text = "lbl.selInst";
            // 
            // lblReady
            // 
            lblReady.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblReady.BackColor = System.Drawing.Color.Transparent;
            lblReady.ForeColor = System.Drawing.Color.White;
            lblReady.Location = new System.Drawing.Point(434, 24);
            lblReady.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblReady.Name = "lblReady";
            lblReady.Size = new System.Drawing.Size(412, 15);
            lblReady.TabIndex = 14;
            lblReady.Text = "lbl.ready {gameVer}";
            lblReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblWelcome.BackColor = System.Drawing.Color.Transparent;
            lblWelcome.ForeColor = System.Drawing.Color.White;
            lblWelcome.Location = new System.Drawing.Point(499, 5);
            lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(281, 15);
            lblWelcome.TabIndex = 12;
            lblWelcome.Text = "lbl.welcome {playerName}";
            lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogIn
            // 
            btnLogIn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnLogIn.Location = new System.Drawing.Point(593, 43);
            btnLogIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new System.Drawing.Size(88, 27);
            btnLogIn.TabIndex = 1;
            btnLogIn.Text = "btn.logIn";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnPlay.Location = new System.Drawing.Point(349, 22);
            btnPlay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(88, 27);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "btn.play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // webBrowser1
            // 
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(0, 0);
            webBrowser1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            webBrowser1.MinimumSize = new System.Drawing.Size(23, 23);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new System.Drawing.Size(784, 315);
            webBrowser1.TabIndex = 0;
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DimGray;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(webBrowser1);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(784, 387);
            Name = "HomeScreen";
            Size = new System.Drawing.Size(784, 387);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnPlay;
        public System.Windows.Forms.ComboBox cmbInstaces;
        public System.Windows.Forms.Label lblSelInst;
        public System.Windows.Forms.Button btnEditInst;
        public System.Windows.Forms.Button btnNewInst;
        public System.Windows.Forms.Label lblLogInWarn;
        public System.Windows.Forms.Button btnLogOut;
        public System.Windows.Forms.Label lblWelcome;
        public System.Windows.Forms.Label lblReady;
        public System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
