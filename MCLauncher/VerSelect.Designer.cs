
namespace MCLauncher
{
    partial class VerSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerSelect));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.javaEdBtn = new System.Windows.Forms.Button();
            this.x360EdBtn = new System.Windows.Forms.Button();
            this.javaModBtn = new System.Windows.Forms.Button();
            this.ps3EdBtn = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.javaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vanillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xbox360ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playstation3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bedrockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Loading..."});
            this.listBox1.Location = new System.Drawing.Point(12, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(237, 277);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // javaEdBtn
            // 
            this.javaEdBtn.Location = new System.Drawing.Point(12, 290);
            this.javaEdBtn.Name = "javaEdBtn";
            this.javaEdBtn.Size = new System.Drawing.Size(75, 20);
            this.javaEdBtn.TabIndex = 3;
            this.javaEdBtn.Text = "Java Edition";
            this.javaEdBtn.UseVisualStyleBackColor = true;
            this.javaEdBtn.Visible = false;
            this.javaEdBtn.Click += new System.EventHandler(this.javaEdBtn_Click);
            // 
            // x360EdBtn
            // 
            this.x360EdBtn.Location = new System.Drawing.Point(153, 290);
            this.x360EdBtn.Name = "x360EdBtn";
            this.x360EdBtn.Size = new System.Drawing.Size(75, 20);
            this.x360EdBtn.TabIndex = 4;
            this.x360EdBtn.Text = "X360 Edition";
            this.x360EdBtn.UseVisualStyleBackColor = true;
            this.x360EdBtn.Visible = false;
            this.x360EdBtn.Click += new System.EventHandler(this.x360EdBtn_Click);
            // 
            // javaModBtn
            // 
            this.javaModBtn.Location = new System.Drawing.Point(45, 290);
            this.javaModBtn.Name = "javaModBtn";
            this.javaModBtn.Size = new System.Drawing.Size(75, 20);
            this.javaModBtn.TabIndex = 5;
            this.javaModBtn.Text = "Java Mods";
            this.javaModBtn.UseVisualStyleBackColor = true;
            this.javaModBtn.Visible = false;
            this.javaModBtn.Click += new System.EventHandler(this.javaModBtn_Click);
            // 
            // ps3EdBtn
            // 
            this.ps3EdBtn.Location = new System.Drawing.Point(93, 290);
            this.ps3EdBtn.Name = "ps3EdBtn";
            this.ps3EdBtn.Size = new System.Drawing.Size(75, 20);
            this.ps3EdBtn.TabIndex = 6;
            this.ps3EdBtn.Text = "PS3 Edition";
            this.ps3EdBtn.UseVisualStyleBackColor = true;
            this.ps3EdBtn.Visible = false;
            this.ps3EdBtn.Click += new System.EventHandler(this.ps3EdBtn_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(174, 325);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Visible = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Location = new System.Drawing.Point(12, 326);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(75, 22);
            this.infoBtn.TabIndex = 11;
            this.infoBtn.Text = "Info";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Visible = false;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.javaToolStripMenuItem,
            this.legacyConsoleToolStripMenuItem,
            this.bedrockToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(260, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // javaToolStripMenuItem
            // 
            this.javaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vanillaToolStripMenuItem,
            this.modsToolStripMenuItem});
            this.javaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.javaToolStripMenuItem.Name = "javaToolStripMenuItem";
            this.javaToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.javaToolStripMenuItem.Text = "Java";
            // 
            // vanillaToolStripMenuItem
            // 
            this.vanillaToolStripMenuItem.Name = "vanillaToolStripMenuItem";
            this.vanillaToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.vanillaToolStripMenuItem.Text = "Vanilla";
            this.vanillaToolStripMenuItem.Click += new System.EventHandler(this.vanillaToolStripMenuItem_Click);
            // 
            // modsToolStripMenuItem
            // 
            this.modsToolStripMenuItem.Name = "modsToolStripMenuItem";
            this.modsToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.modsToolStripMenuItem.Text = "Mods";
            this.modsToolStripMenuItem.Click += new System.EventHandler(this.modsToolStripMenuItem_Click);
            // 
            // legacyConsoleToolStripMenuItem
            // 
            this.legacyConsoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xbox360ToolStripMenuItem,
            this.playstation3ToolStripMenuItem});
            this.legacyConsoleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.legacyConsoleToolStripMenuItem.Name = "legacyConsoleToolStripMenuItem";
            this.legacyConsoleToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.legacyConsoleToolStripMenuItem.Text = "Legacy Consoles";
            // 
            // xbox360ToolStripMenuItem
            // 
            this.xbox360ToolStripMenuItem.Name = "xbox360ToolStripMenuItem";
            this.xbox360ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.xbox360ToolStripMenuItem.Text = "Xbox 360";
            this.xbox360ToolStripMenuItem.Click += new System.EventHandler(this.xbox360ToolStripMenuItem_Click);
            // 
            // playstation3ToolStripMenuItem
            // 
            this.playstation3ToolStripMenuItem.Name = "playstation3ToolStripMenuItem";
            this.playstation3ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.playstation3ToolStripMenuItem.Text = "Playstation 3";
            this.playstation3ToolStripMenuItem.Click += new System.EventHandler(this.playstation3ToolStripMenuItem_Click);
            // 
            // bedrockToolStripMenuItem
            // 
            this.bedrockToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.bedrockToolStripMenuItem.Name = "bedrockToolStripMenuItem";
            this.bedrockToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.bedrockToolStripMenuItem.Text = "Bedrock";
            // 
            // VerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(260, 360);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.ps3EdBtn);
            this.Controls.Add(this.javaModBtn);
            this.Controls.Add(this.x360EdBtn);
            this.Controls.Add(this.javaEdBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerSelect";
            this.Text = "Select version";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button javaEdBtn;
        private System.Windows.Forms.Button x360EdBtn;
        private System.Windows.Forms.Button javaModBtn;
        private System.Windows.Forms.Button ps3EdBtn;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem javaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vanillaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legacyConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xbox360ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playstation3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bedrockToolStripMenuItem;
    }
}