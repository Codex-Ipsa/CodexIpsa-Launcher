namespace MCLauncher.forms
{
    partial class EditInstance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditInstance));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabMods = new System.Windows.Forms.TabPage();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabMods);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 410);
            this.tabControl1.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.SystemColors.Control;
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Size = new System.Drawing.Size(796, 384);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "tab.home";
            // 
            // tabMods
            // 
            this.tabMods.BackColor = System.Drawing.SystemColors.Control;
            this.tabMods.Location = new System.Drawing.Point(4, 22);
            this.tabMods.Name = "tabMods";
            this.tabMods.Size = new System.Drawing.Size(787, 384);
            this.tabMods.TabIndex = 1;
            this.tabMods.Text = "tab.mods";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "grass.png");
            this.imageList2.Images.SetKeyName(1, "ipsa.png");
            this.imageList2.Images.SetKeyName(2, "forge.png");
            this.imageList2.Images.SetKeyName(3, "fabric.png");
            this.imageList2.Images.SetKeyName(4, "quilt.png");
            this.imageList2.Images.SetKeyName(5, "neoforge.png");
            this.imageList2.Images.SetKeyName(6, "xbox360.png");
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
            this.imageList1.Images.SetKeyName(6, "xbox360.png");
            // 
            // EditInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 410);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditInstance";
            this.Text = "Profile editor";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabMods;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}