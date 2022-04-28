
namespace MCLauncher
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.demoCheckBox = new System.Windows.Forms.CheckBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericXMX = new System.Windows.Forms.NumericUpDown();
            this.numericXMS = new System.Windows.Forms.NumericUpDown();
            this.creditsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericXMX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericXMS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game addons";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Launcher settings";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Enabled = false;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(22, 86);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(136, 17);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Launcher beta program";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // demoCheckBox
            // 
            this.demoCheckBox.AutoSize = true;
            this.demoCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.demoCheckBox.Enabled = false;
            this.demoCheckBox.ForeColor = System.Drawing.Color.White;
            this.demoCheckBox.Location = new System.Drawing.Point(182, 33);
            this.demoCheckBox.Name = "demoCheckBox";
            this.demoCheckBox.Size = new System.Drawing.Size(107, 17);
            this.demoCheckBox.TabIndex = 5;
            this.demoCheckBox.Text = "Demo (12w16a+)";
            this.demoCheckBox.UseVisualStyleBackColor = false;
            this.demoCheckBox.CheckedChanged += new System.EventHandler(this.demoCheckBox_CheckedChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(22, 109);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.Text = "Apply";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Xmx:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Xms:";
            // 
            // numericXMX
            // 
            this.numericXMX.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericXMX.Location = new System.Drawing.Point(55, 34);
            this.numericXMX.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericXMX.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericXMX.Name = "numericXMX";
            this.numericXMX.Size = new System.Drawing.Size(69, 20);
            this.numericXMX.TabIndex = 11;
            this.numericXMX.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericXMX.ValueChanged += new System.EventHandler(this.numericXMX_ValueChanged);
            // 
            // numericXMS
            // 
            this.numericXMS.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericXMS.Location = new System.Drawing.Point(55, 60);
            this.numericXMS.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericXMS.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericXMS.Name = "numericXMS";
            this.numericXMS.Size = new System.Drawing.Size(69, 20);
            this.numericXMS.TabIndex = 12;
            this.numericXMS.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericXMS.ValueChanged += new System.EventHandler(this.numericXMS_ValueChanged);
            // 
            // creditsBtn
            // 
            this.creditsBtn.Location = new System.Drawing.Point(225, 109);
            this.creditsBtn.Name = "creditsBtn";
            this.creditsBtn.Size = new System.Drawing.Size(75, 23);
            this.creditsBtn.TabIndex = 13;
            this.creditsBtn.Text = "Credits";
            this.creditsBtn.UseVisualStyleBackColor = true;
            this.creditsBtn.Click += new System.EventHandler(this.creditsBtn_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(312, 144);
            this.Controls.Add(this.creditsBtn);
            this.Controls.Add(this.numericXMS);
            this.Controls.Add(this.numericXMX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.demoCheckBox);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericXMX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericXMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox demoCheckBox;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericXMX;
        private System.Windows.Forms.NumericUpDown numericXMS;
        private System.Windows.Forms.Button creditsBtn;
    }
}