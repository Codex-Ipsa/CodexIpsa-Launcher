namespace MCLauncher.controls
{
    partial class XboxProfile
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
            this.grbGame = new System.Windows.Forms.GroupBox();
            this.chkProxy = new System.Windows.Forms.CheckBox();
            this.grbGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGame
            // 
            this.grbGame.Controls.Add(this.chkProxy);
            this.grbGame.Location = new System.Drawing.Point(4, 3);
            this.grbGame.Name = "grbGame";
            this.grbGame.Size = new System.Drawing.Size(439, 46);
            this.grbGame.TabIndex = 27;
            this.grbGame.TabStop = false;
            this.grbGame.Text = "grb.Game";
            // 
            // chkProxy
            // 
            this.chkProxy.AutoSize = true;
            this.chkProxy.Location = new System.Drawing.Point(6, 19);
            this.chkProxy.Name = "chkProxy";
            this.chkProxy.Size = new System.Drawing.Size(75, 17);
            this.chkProxy.TabIndex = 21;
            this.chkProxy.Text = "chk.Demo";
            this.chkProxy.UseVisualStyleBackColor = true;
            // 
            // XboxProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbGame);
            this.Name = "XboxProfile";
            this.Size = new System.Drawing.Size(446, 332);
            this.grbGame.ResumeLayout(false);
            this.grbGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGame;
        private System.Windows.Forms.CheckBox chkProxy;
    }
}
