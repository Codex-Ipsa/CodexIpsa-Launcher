namespace MCLauncher.forms
{
    partial class Profile
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkClassic = new System.Windows.Forms.CheckBox();
            this.checkIndev = new System.Windows.Forms.CheckBox();
            this.checkInfdev = new System.Windows.Forms.CheckBox();
            this.checkAlpha = new System.Windows.Forms.CheckBox();
            this.checkBeta = new System.Windows.Forms.CheckBox();
            this.checkRelease = new System.Windows.Forms.CheckBox();
            this.checkSnapshot = new System.Windows.Forms.CheckBox();
            this.checkExperimental = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkPreClassic = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(328, 355);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "btn.Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(446, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(342, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profile name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(446, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(287, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Game directory";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(739, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(739, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 20);
            this.button2.TabIndex = 9;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Java location";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(446, 171);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(287, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(446, 65);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(150, 20);
            this.textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(638, 65);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(150, 20);
            this.textBox5.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Resolution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Memory";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(446, 91);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(150, 20);
            this.numericUpDown1.TabIndex = 15;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(638, 93);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(150, 20);
            this.numericUpDown2.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Max";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "After command";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(446, 145);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(342, 20);
            this.textBox6.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(346, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Before command";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(446, 119);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(342, 20);
            this.textBox7.TabIndex = 21;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(349, 222);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Launch in offline mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(349, 245);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(187, 17);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "Use skin and sound proxy (<1.5.2)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(349, 199);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(91, 17);
            this.checkBox3.TabIndex = 25;
            this.checkBox3.Text = "Launch demo";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkClassic
            // 
            this.checkClassic.AutoSize = true;
            this.checkClassic.Checked = true;
            this.checkClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkClassic.Location = new System.Drawing.Point(95, 373);
            this.checkClassic.Name = "checkClassic";
            this.checkClassic.Size = new System.Drawing.Size(59, 17);
            this.checkClassic.TabIndex = 26;
            this.checkClassic.Text = "Classic";
            this.checkClassic.UseVisualStyleBackColor = true;
            this.checkClassic.CheckedChanged += new System.EventHandler(this.checkClassic_CheckedChanged);
            // 
            // checkIndev
            // 
            this.checkIndev.AutoSize = true;
            this.checkIndev.Checked = true;
            this.checkIndev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIndev.Location = new System.Drawing.Point(160, 373);
            this.checkIndev.Name = "checkIndev";
            this.checkIndev.Size = new System.Drawing.Size(53, 17);
            this.checkIndev.TabIndex = 27;
            this.checkIndev.Text = "Indev";
            this.checkIndev.UseVisualStyleBackColor = true;
            this.checkIndev.CheckedChanged += new System.EventHandler(this.checkIndev_CheckedChanged);
            // 
            // checkInfdev
            // 
            this.checkInfdev.AutoSize = true;
            this.checkInfdev.Checked = true;
            this.checkInfdev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkInfdev.Location = new System.Drawing.Point(219, 373);
            this.checkInfdev.Name = "checkInfdev";
            this.checkInfdev.Size = new System.Drawing.Size(56, 17);
            this.checkInfdev.TabIndex = 28;
            this.checkInfdev.Text = "Infdev";
            this.checkInfdev.UseVisualStyleBackColor = true;
            this.checkInfdev.CheckedChanged += new System.EventHandler(this.checkInfdev_CheckedChanged);
            // 
            // checkAlpha
            // 
            this.checkAlpha.AutoSize = true;
            this.checkAlpha.Checked = true;
            this.checkAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAlpha.Location = new System.Drawing.Point(281, 373);
            this.checkAlpha.Name = "checkAlpha";
            this.checkAlpha.Size = new System.Drawing.Size(53, 17);
            this.checkAlpha.TabIndex = 29;
            this.checkAlpha.Text = "Alpha";
            this.checkAlpha.UseVisualStyleBackColor = true;
            this.checkAlpha.CheckedChanged += new System.EventHandler(this.checkAlpha_CheckedChanged);
            // 
            // checkBeta
            // 
            this.checkBeta.AutoSize = true;
            this.checkBeta.Checked = true;
            this.checkBeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBeta.Location = new System.Drawing.Point(12, 399);
            this.checkBeta.Name = "checkBeta";
            this.checkBeta.Size = new System.Drawing.Size(48, 17);
            this.checkBeta.TabIndex = 30;
            this.checkBeta.Text = "Beta";
            this.checkBeta.UseVisualStyleBackColor = true;
            this.checkBeta.CheckedChanged += new System.EventHandler(this.checkBeta_CheckedChanged);
            // 
            // checkRelease
            // 
            this.checkRelease.AutoSize = true;
            this.checkRelease.Checked = true;
            this.checkRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRelease.Location = new System.Drawing.Point(66, 399);
            this.checkRelease.Name = "checkRelease";
            this.checkRelease.Size = new System.Drawing.Size(65, 17);
            this.checkRelease.TabIndex = 31;
            this.checkRelease.Text = "Release";
            this.checkRelease.UseVisualStyleBackColor = true;
            this.checkRelease.CheckedChanged += new System.EventHandler(this.checkRelease_CheckedChanged);
            // 
            // checkSnapshot
            // 
            this.checkSnapshot.AutoSize = true;
            this.checkSnapshot.Checked = true;
            this.checkSnapshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSnapshot.Location = new System.Drawing.Point(137, 399);
            this.checkSnapshot.Name = "checkSnapshot";
            this.checkSnapshot.Size = new System.Drawing.Size(71, 17);
            this.checkSnapshot.TabIndex = 32;
            this.checkSnapshot.Text = "Snapshot";
            this.checkSnapshot.UseVisualStyleBackColor = true;
            this.checkSnapshot.CheckedChanged += new System.EventHandler(this.checkSnapshot_CheckedChanged);
            // 
            // checkExperimental
            // 
            this.checkExperimental.AutoSize = true;
            this.checkExperimental.Checked = true;
            this.checkExperimental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExperimental.Location = new System.Drawing.Point(214, 399);
            this.checkExperimental.Name = "checkExperimental";
            this.checkExperimental.Size = new System.Drawing.Size(86, 17);
            this.checkExperimental.TabIndex = 33;
            this.checkExperimental.Text = "Experimental";
            this.checkExperimental.UseVisualStyleBackColor = true;
            this.checkExperimental.CheckedChanged += new System.EventHandler(this.checkExperimental_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(632, 422);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 34;
            this.button3.Text = "btn.OpenDir";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(551, 422);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 35;
            this.button4.Text = "btn.Delete";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 422);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 36;
            this.button5.Text = "btn.Mods";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // checkPreClassic
            // 
            this.checkPreClassic.AutoSize = true;
            this.checkPreClassic.Checked = true;
            this.checkPreClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPreClassic.Location = new System.Drawing.Point(12, 373);
            this.checkPreClassic.Name = "checkPreClassic";
            this.checkPreClassic.Size = new System.Drawing.Size(77, 17);
            this.checkPreClassic.TabIndex = 37;
            this.checkPreClassic.Text = "Pre-classic";
            this.checkPreClassic.UseVisualStyleBackColor = true;
            this.checkPreClassic.CheckedChanged += new System.EventHandler(this.checkPreClassic_CheckedChanged);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.checkPreClassic);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkExperimental);
            this.Controls.Add(this.checkSnapshot);
            this.Controls.Add(this.checkRelease);
            this.Controls.Add(this.checkBeta);
            this.Controls.Add(this.checkAlpha);
            this.Controls.Add(this.checkInfdev);
            this.Controls.Add(this.checkIndev);
            this.Controls.Add(this.checkClassic);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listView1);
            this.Name = "Profile";
            this.Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkClassic;
        private System.Windows.Forms.CheckBox checkIndev;
        private System.Windows.Forms.CheckBox checkInfdev;
        private System.Windows.Forms.CheckBox checkAlpha;
        private System.Windows.Forms.CheckBox checkBeta;
        private System.Windows.Forms.CheckBox checkRelease;
        private System.Windows.Forms.CheckBox checkSnapshot;
        private System.Windows.Forms.CheckBox checkExperimental;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkPreClassic;
    }
}