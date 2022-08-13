namespace MCLauncher
{
    partial class HomeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeWindow));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditInst = new System.Windows.Forms.Button();
            this.btnNewInst = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gameVerLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Top;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1045, 395);
            this.webBrowser1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.btnEditInst);
            this.panel1.Controls.Add(this.btnNewInst);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gameVerLabel);
            this.panel1.Controls.Add(this.playerNameLabel);
            this.panel1.Controls.Add(this.btnLogIn);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 397);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 79);
            this.panel1.TabIndex = 3;
            // 
            // btnEditInst
            // 
            this.btnEditInst.Location = new System.Drawing.Point(107, 49);
            this.btnEditInst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditInst.Name = "btnEditInst";
            this.btnEditInst.Size = new System.Drawing.Size(91, 26);
            this.btnEditInst.TabIndex = 19;
            this.btnEditInst.Text = "btn.editprof";
            this.btnEditInst.UseVisualStyleBackColor = true;
            // 
            // btnNewInst
            // 
            this.btnNewInst.Location = new System.Drawing.Point(8, 49);
            this.btnNewInst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewInst.Name = "btnNewInst";
            this.btnNewInst.Size = new System.Drawing.Size(91, 26);
            this.btnNewInst.TabIndex = 18;
            this.btnNewInst.Text = "btn.newprof";
            this.btnNewInst.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 23);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 24);
            this.comboBox1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "lbl.selprof";
            // 
            // gameVerLabel
            // 
            this.gameVerLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gameVerLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameVerLabel.ForeColor = System.Drawing.Color.White;
            this.gameVerLabel.Location = new System.Drawing.Point(645, 27);
            this.gameVerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameVerLabel.Name = "gameVerLabel";
            this.gameVerLabel.Size = new System.Drawing.Size(471, 16);
            this.gameVerLabel.TabIndex = 14;
            this.gameVerLabel.Text = "lbl.ready {gameVer}";
            this.gameVerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.playerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerNameLabel.ForeColor = System.Drawing.Color.White;
            this.playerNameLabel.Location = new System.Drawing.Point(720, 6);
            this.playerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(321, 16);
            this.playerNameLabel.TabIndex = 12;
            this.playerNameLabel.Text = "lbl.welcome {playerName}";
            this.playerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(828, 47);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(100, 28);
            this.btnLogIn.TabIndex = 1;
            this.btnLogIn.Text = "btn.logIn";
            this.btnLogIn.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(473, 25);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 28);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "btn.play";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // HomeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HomeWindow";
            this.Size = new System.Drawing.Size(1045, 476);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label gameVerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditInst;
        private System.Windows.Forms.Button btnNewInst;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnLogIn;
    }
}
