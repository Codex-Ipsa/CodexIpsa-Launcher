namespace MCLauncher.forms
{
    partial class NewInstance
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.vanillaPage = new System.Windows.Forms.TabPage();
            this.ipsaPage = new System.Windows.Forms.TabPage();
            this.forgePage = new System.Windows.Forms.TabPage();
            this.fabricPage = new System.Windows.Forms.TabPage();
            this.xboxPage = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.vanillaPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.vanillaPage);
            this.tabControl1.Controls.Add(this.ipsaPage);
            this.tabControl1.Controls.Add(this.forgePage);
            this.tabControl1.Controls.Add(this.fabricPage);
            this.tabControl1.Controls.Add(this.xboxPage);
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 352);
            this.tabControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // vanillaPage
            // 
            this.vanillaPage.Controls.Add(this.listView1);
            this.vanillaPage.Location = new System.Drawing.Point(4, 22);
            this.vanillaPage.Name = "vanillaPage";
            this.vanillaPage.Size = new System.Drawing.Size(793, 326);
            this.vanillaPage.TabIndex = 0;
            this.vanillaPage.Text = "Vanilla";
            this.vanillaPage.UseVisualStyleBackColor = true;
            // 
            // ipsaPage
            // 
            this.ipsaPage.Location = new System.Drawing.Point(4, 22);
            this.ipsaPage.Name = "ipsaPage";
            this.ipsaPage.Size = new System.Drawing.Size(791, 326);
            this.ipsaPage.TabIndex = 1;
            this.ipsaPage.Text = "Codex-Ipsa Mods";
            this.ipsaPage.UseVisualStyleBackColor = true;
            // 
            // forgePage
            // 
            this.forgePage.Location = new System.Drawing.Point(4, 22);
            this.forgePage.Name = "forgePage";
            this.forgePage.Size = new System.Drawing.Size(791, 326);
            this.forgePage.TabIndex = 2;
            this.forgePage.Text = "Forge";
            this.forgePage.UseVisualStyleBackColor = true;
            // 
            // fabricPage
            // 
            this.fabricPage.Location = new System.Drawing.Point(4, 22);
            this.fabricPage.Name = "fabricPage";
            this.fabricPage.Size = new System.Drawing.Size(791, 326);
            this.fabricPage.TabIndex = 3;
            this.fabricPage.Text = "Fabric";
            this.fabricPage.UseVisualStyleBackColor = true;
            // 
            // xboxPage
            // 
            this.xboxPage.Location = new System.Drawing.Point(4, 22);
            this.xboxPage.Name = "xboxPage";
            this.xboxPage.Size = new System.Drawing.Size(791, 326);
            this.xboxPage.TabIndex = 4;
            this.xboxPage.Text = "Xbox 360";
            this.xboxPage.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(303, 310);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(690, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Instance name:";
            // 
            // NewInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "NewInstance";
            this.Text = "NewInstance";
            this.tabControl1.ResumeLayout(false);
            this.vanillaPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage vanillaPage;
        private System.Windows.Forms.TabPage ipsaPage;
        private System.Windows.Forms.TabPage forgePage;
        private System.Windows.Forms.TabPage fabricPage;
        private System.Windows.Forms.TabPage xboxPage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}