
namespace MCLauncher
{
    partial class InstanceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceManager));
            this.label1 = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dirCheck = new System.Windows.Forms.CheckBox();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.resCheck = new System.Windows.Forms.CheckBox();
            this.openCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dirBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxRamBox = new System.Windows.Forms.TextBox();
            this.ramCheck = new System.Windows.Forms.CheckBox();
            this.minRamBox = new System.Windows.Forms.TextBox();
            this.resBoxY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resBoxX = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.verBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.javaBtn = new System.Windows.Forms.Button();
            this.custjarBtn = new System.Windows.Forms.Button();
            this.methodBox = new System.Windows.Forms.ComboBox();
            this.custjarBox = new System.Windows.Forms.TextBox();
            this.custjarCheck = new System.Windows.Forms.CheckBox();
            this.methodCheck = new System.Windows.Forms.CheckBox();
            this.jvmCheck = new System.Windows.Forms.CheckBox();
            this.jvmBox = new System.Windows.Forms.TextBox();
            this.javaCheck = new System.Windows.Forms.CheckBox();
            this.javaBox = new System.Windows.Forms.TextBox();
            this.opendirBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.instmodBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile name:";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(575, 358);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 7;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(122, 13);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(516, 20);
            this.nameBox.TabIndex = 8;
            // 
            // dirCheck
            // 
            this.dirCheck.AutoSize = true;
            this.dirCheck.Location = new System.Drawing.Point(6, 41);
            this.dirCheck.Name = "dirCheck";
            this.dirCheck.Size = new System.Drawing.Size(107, 17);
            this.dirCheck.TabIndex = 11;
            this.dirCheck.Text = "Custom directory:";
            this.dirCheck.UseVisualStyleBackColor = true;
            this.dirCheck.CheckedChanged += new System.EventHandler(this.dirCheck_CheckedChanged);
            // 
            // dirBox
            // 
            this.dirBox.Enabled = false;
            this.dirBox.Location = new System.Drawing.Point(122, 39);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(476, 20);
            this.dirBox.TabIndex = 12;
            // 
            // resCheck
            // 
            this.resCheck.AutoSize = true;
            this.resCheck.Location = new System.Drawing.Point(6, 67);
            this.resCheck.Name = "resCheck";
            this.resCheck.Size = new System.Drawing.Size(112, 17);
            this.resCheck.TabIndex = 13;
            this.resCheck.Text = "Custom resolution:";
            this.resCheck.UseVisualStyleBackColor = true;
            this.resCheck.CheckedChanged += new System.EventHandler(this.resCheck_CheckedChanged);
            // 
            // openCheck
            // 
            this.openCheck.AutoSize = true;
            this.openCheck.Location = new System.Drawing.Point(6, 119);
            this.openCheck.Name = "openCheck";
            this.openCheck.Size = new System.Drawing.Size(140, 17);
            this.openCheck.TabIndex = 15;
            this.openCheck.Text = "Keep the launcher open";
            this.openCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dirBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maxRamBox);
            this.groupBox1.Controls.Add(this.ramCheck);
            this.groupBox1.Controls.Add(this.minRamBox);
            this.groupBox1.Controls.Add(this.resBoxY);
            this.groupBox1.Controls.Add(this.openCheck);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.dirBox);
            this.groupBox1.Controls.Add(this.resCheck);
            this.groupBox1.Controls.Add(this.resBoxX);
            this.groupBox1.Controls.Add(this.dirCheck);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 140);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile info";
            // 
            // dirBtn
            // 
            this.dirBtn.Enabled = false;
            this.dirBtn.Location = new System.Drawing.Point(604, 38);
            this.dirBtn.Name = "dirBtn";
            this.dirBtn.Size = new System.Drawing.Size(34, 20);
            this.dirBtn.TabIndex = 30;
            this.dirBtn.Text = "...";
            this.dirBtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Max:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Min:";
            // 
            // maxRamBox
            // 
            this.maxRamBox.Enabled = false;
            this.maxRamBox.Location = new System.Drawing.Point(426, 91);
            this.maxRamBox.Name = "maxRamBox";
            this.maxRamBox.Size = new System.Drawing.Size(212, 20);
            this.maxRamBox.TabIndex = 23;
            // 
            // ramCheck
            // 
            this.ramCheck.AutoSize = true;
            this.ramCheck.Location = new System.Drawing.Point(6, 93);
            this.ramCheck.Name = "ramCheck";
            this.ramCheck.Size = new System.Drawing.Size(66, 17);
            this.ramCheck.TabIndex = 22;
            this.ramCheck.Text = "Memory:";
            this.ramCheck.UseVisualStyleBackColor = true;
            this.ramCheck.CheckedChanged += new System.EventHandler(this.ramCheck_CheckedChanged);
            // 
            // minRamBox
            // 
            this.minRamBox.Enabled = false;
            this.minRamBox.Location = new System.Drawing.Point(156, 91);
            this.minRamBox.Name = "minRamBox";
            this.minRamBox.Size = new System.Drawing.Size(212, 20);
            this.minRamBox.TabIndex = 21;
            // 
            // resBoxY
            // 
            this.resBoxY.Enabled = false;
            this.resBoxY.Location = new System.Drawing.Point(392, 64);
            this.resBoxY.Name = "resBoxY";
            this.resBoxY.Size = new System.Drawing.Size(246, 20);
            this.resBoxY.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "x";
            // 
            // resBoxX
            // 
            this.resBoxX.Enabled = false;
            this.resBoxX.Location = new System.Drawing.Point(122, 65);
            this.resBoxX.Name = "resBoxX";
            this.resBoxX.Size = new System.Drawing.Size(246, 20);
            this.resBoxX.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.editionBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.verBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(644, 70);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Version selection";
            // 
            // editionBox
            // 
            this.editionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editionBox.FormattingEnabled = true;
            this.editionBox.Location = new System.Drawing.Point(122, 12);
            this.editionBox.Name = "editionBox";
            this.editionBox.Size = new System.Drawing.Size(516, 21);
            this.editionBox.TabIndex = 24;
            this.editionBox.SelectedIndexChanged += new System.EventHandler(this.editionBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Use version:";
            // 
            // verBox
            // 
            this.verBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.verBox.FormattingEnabled = true;
            this.verBox.Location = new System.Drawing.Point(122, 39);
            this.verBox.Name = "verBox";
            this.verBox.Size = new System.Drawing.Size(516, 21);
            this.verBox.TabIndex = 22;
            this.verBox.SelectedIndexChanged += new System.EventHandler(this.verBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Edition:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.javaBtn);
            this.groupBox3.Controls.Add(this.custjarBtn);
            this.groupBox3.Controls.Add(this.methodBox);
            this.groupBox3.Controls.Add(this.custjarBox);
            this.groupBox3.Controls.Add(this.custjarCheck);
            this.groupBox3.Controls.Add(this.methodCheck);
            this.groupBox3.Controls.Add(this.jvmCheck);
            this.groupBox3.Controls.Add(this.jvmBox);
            this.groupBox3.Controls.Add(this.javaCheck);
            this.groupBox3.Controls.Add(this.javaBox);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(644, 118);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "For experts";
            // 
            // javaBtn
            // 
            this.javaBtn.Enabled = false;
            this.javaBtn.Location = new System.Drawing.Point(604, 12);
            this.javaBtn.Name = "javaBtn";
            this.javaBtn.Size = new System.Drawing.Size(34, 20);
            this.javaBtn.TabIndex = 29;
            this.javaBtn.Text = "...";
            this.javaBtn.UseVisualStyleBackColor = true;
            // 
            // custjarBtn
            // 
            this.custjarBtn.Enabled = false;
            this.custjarBtn.Location = new System.Drawing.Point(604, 92);
            this.custjarBtn.Name = "custjarBtn";
            this.custjarBtn.Size = new System.Drawing.Size(34, 20);
            this.custjarBtn.TabIndex = 28;
            this.custjarBtn.Text = "...";
            this.custjarBtn.UseVisualStyleBackColor = true;
            // 
            // methodBox
            // 
            this.methodBox.Enabled = false;
            this.methodBox.FormattingEnabled = true;
            this.methodBox.Location = new System.Drawing.Point(122, 65);
            this.methodBox.Name = "methodBox";
            this.methodBox.Size = new System.Drawing.Size(516, 21);
            this.methodBox.TabIndex = 24;
            // 
            // custjarBox
            // 
            this.custjarBox.Enabled = false;
            this.custjarBox.Location = new System.Drawing.Point(122, 92);
            this.custjarBox.Name = "custjarBox";
            this.custjarBox.Size = new System.Drawing.Size(476, 20);
            this.custjarBox.TabIndex = 27;
            // 
            // custjarCheck
            // 
            this.custjarCheck.AutoSize = true;
            this.custjarCheck.Location = new System.Drawing.Point(6, 93);
            this.custjarCheck.Name = "custjarCheck";
            this.custjarCheck.Size = new System.Drawing.Size(87, 17);
            this.custjarCheck.TabIndex = 26;
            this.custjarCheck.Text = "Minecraft.jar:";
            this.custjarCheck.UseVisualStyleBackColor = true;
            this.custjarCheck.CheckedChanged += new System.EventHandler(this.custjarCheck_CheckedChanged);
            // 
            // methodCheck
            // 
            this.methodCheck.AutoSize = true;
            this.methodCheck.Location = new System.Drawing.Point(6, 67);
            this.methodCheck.Name = "methodCheck";
            this.methodCheck.Size = new System.Drawing.Size(103, 17);
            this.methodCheck.TabIndex = 25;
            this.methodCheck.Text = "Launch method:";
            this.methodCheck.UseVisualStyleBackColor = true;
            this.methodCheck.CheckedChanged += new System.EventHandler(this.methodCheck_CheckedChanged);
            // 
            // jvmCheck
            // 
            this.jvmCheck.AutoSize = true;
            this.jvmCheck.Location = new System.Drawing.Point(6, 41);
            this.jvmCheck.Name = "jvmCheck";
            this.jvmCheck.Size = new System.Drawing.Size(102, 17);
            this.jvmCheck.TabIndex = 23;
            this.jvmCheck.Text = "JVM arguments:";
            this.jvmCheck.UseVisualStyleBackColor = true;
            this.jvmCheck.CheckedChanged += new System.EventHandler(this.jvmCheck_CheckedChanged);
            // 
            // jvmBox
            // 
            this.jvmBox.Enabled = false;
            this.jvmBox.Location = new System.Drawing.Point(122, 39);
            this.jvmBox.Name = "jvmBox";
            this.jvmBox.Size = new System.Drawing.Size(516, 20);
            this.jvmBox.TabIndex = 22;
            // 
            // javaCheck
            // 
            this.javaCheck.AutoSize = true;
            this.javaCheck.Location = new System.Drawing.Point(6, 15);
            this.javaCheck.Name = "javaCheck";
            this.javaCheck.Size = new System.Drawing.Size(81, 17);
            this.javaCheck.TabIndex = 21;
            this.javaCheck.Text = "Java install:";
            this.javaCheck.UseVisualStyleBackColor = true;
            this.javaCheck.CheckedChanged += new System.EventHandler(this.javaCheck_CheckedChanged);
            // 
            // javaBox
            // 
            this.javaBox.Enabled = false;
            this.javaBox.Location = new System.Drawing.Point(122, 13);
            this.javaBox.Name = "javaBox";
            this.javaBox.Size = new System.Drawing.Size(476, 20);
            this.javaBox.TabIndex = 8;
            // 
            // opendirBtn
            // 
            this.opendirBtn.Location = new System.Drawing.Point(494, 358);
            this.opendirBtn.Name = "opendirBtn";
            this.opendirBtn.Size = new System.Drawing.Size(75, 23);
            this.opendirBtn.TabIndex = 25;
            this.opendirBtn.Text = "Open dir";
            this.opendirBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(18, 358);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 26;
            this.closeBtn.Text = "Cancel";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // instmodBtn
            // 
            this.instmodBtn.Location = new System.Drawing.Point(413, 358);
            this.instmodBtn.Name = "instmodBtn";
            this.instmodBtn.Size = new System.Drawing.Size(75, 23);
            this.instmodBtn.TabIndex = 27;
            this.instmodBtn.Text = "Install mod";
            this.instmodBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(575, 358);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 28;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // InstanceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 388);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.instmodBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.opendirBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.createBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstanceManager";
            this.Text = "Profile Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.CheckBox dirCheck;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.CheckBox resCheck;
        private System.Windows.Forms.CheckBox openCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox resBoxY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox resBoxX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox verBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox custjarBox;
        private System.Windows.Forms.CheckBox custjarCheck;
        private System.Windows.Forms.CheckBox methodCheck;
        private System.Windows.Forms.CheckBox jvmCheck;
        private System.Windows.Forms.TextBox jvmBox;
        private System.Windows.Forms.CheckBox javaCheck;
        private System.Windows.Forms.TextBox javaBox;
        private System.Windows.Forms.ComboBox methodBox;
        private System.Windows.Forms.Button opendirBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button instmodBtn;
        private System.Windows.Forms.ComboBox editionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maxRamBox;
        private System.Windows.Forms.CheckBox ramCheck;
        private System.Windows.Forms.TextBox minRamBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button dirBtn;
        private System.Windows.Forms.Button javaBtn;
        private System.Windows.Forms.Button custjarBtn;
    }
}