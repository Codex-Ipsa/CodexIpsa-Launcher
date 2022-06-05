
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
            this.label1 = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dirCheck = new System.Windows.Forms.CheckBox();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.resCheck = new System.Windows.Forms.CheckBox();
            this.openCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resBoxY = new System.Windows.Forms.TextBox();
            this.resBoxX = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.editionBox = new System.Windows.Forms.TextBox();
            this.verBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.javaBox = new System.Windows.Forms.TextBox();
            this.javaCheck = new System.Windows.Forms.CheckBox();
            this.jvmBox = new System.Windows.Forms.TextBox();
            this.jvmCheck = new System.Windows.Forms.CheckBox();
            this.methodCheck = new System.Windows.Forms.CheckBox();
            this.custjarCheck = new System.Windows.Forms.CheckBox();
            this.custjarBox = new System.Windows.Forms.TextBox();
            this.methodBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.createBtn.Location = new System.Drawing.Point(575, 331);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 7;
            this.createBtn.Text = "Save";
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
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(122, 39);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(516, 20);
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
            // 
            // openCheck
            // 
            this.openCheck.AutoSize = true;
            this.openCheck.Location = new System.Drawing.Point(6, 93);
            this.openCheck.Name = "openCheck";
            this.openCheck.Size = new System.Drawing.Size(140, 17);
            this.openCheck.TabIndex = 15;
            this.openCheck.Text = "Keep the launcher open";
            this.openCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resBoxY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.openCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.dirBox);
            this.groupBox1.Controls.Add(this.resCheck);
            this.groupBox1.Controls.Add(this.resBoxX);
            this.groupBox1.Controls.Add(this.dirCheck);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 113);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile info";
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
            // resBoxY
            // 
            this.resBoxY.Location = new System.Drawing.Point(392, 64);
            this.resBoxY.Name = "resBoxY";
            this.resBoxY.Size = new System.Drawing.Size(246, 20);
            this.resBoxY.TabIndex = 20;
            // 
            // resBoxX
            // 
            this.resBoxX.Location = new System.Drawing.Point(122, 65);
            this.resBoxX.Name = "resBoxX";
            this.resBoxX.Size = new System.Drawing.Size(246, 20);
            this.resBoxX.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.verBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.editionBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(644, 70);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Version selection";
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
            // editionBox
            // 
            this.editionBox.Location = new System.Drawing.Point(122, 13);
            this.editionBox.Name = "editionBox";
            this.editionBox.Size = new System.Drawing.Size(516, 20);
            this.editionBox.TabIndex = 8;
            // 
            // verBox
            // 
            this.verBox.FormattingEnabled = true;
            this.verBox.Location = new System.Drawing.Point(122, 39);
            this.verBox.Name = "verBox";
            this.verBox.Size = new System.Drawing.Size(516, 21);
            this.verBox.TabIndex = 22;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.methodBox);
            this.groupBox3.Controls.Add(this.custjarBox);
            this.groupBox3.Controls.Add(this.custjarCheck);
            this.groupBox3.Controls.Add(this.methodCheck);
            this.groupBox3.Controls.Add(this.jvmCheck);
            this.groupBox3.Controls.Add(this.jvmBox);
            this.groupBox3.Controls.Add(this.javaCheck);
            this.groupBox3.Controls.Add(this.javaBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(644, 118);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "For experts";
            // 
            // javaBox
            // 
            this.javaBox.Location = new System.Drawing.Point(122, 13);
            this.javaBox.Name = "javaBox";
            this.javaBox.Size = new System.Drawing.Size(516, 20);
            this.javaBox.TabIndex = 8;
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
            // 
            // jvmBox
            // 
            this.jvmBox.Location = new System.Drawing.Point(122, 39);
            this.jvmBox.Name = "jvmBox";
            this.jvmBox.Size = new System.Drawing.Size(516, 20);
            this.jvmBox.TabIndex = 22;
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
            // 
            // custjarBox
            // 
            this.custjarBox.Location = new System.Drawing.Point(122, 91);
            this.custjarBox.Name = "custjarBox";
            this.custjarBox.Size = new System.Drawing.Size(516, 20);
            this.custjarBox.TabIndex = 27;
            // 
            // methodBox
            // 
            this.methodBox.FormattingEnabled = true;
            this.methodBox.Location = new System.Drawing.Point(122, 65);
            this.methodBox.Name = "methodBox";
            this.methodBox.Size = new System.Drawing.Size(516, 21);
            this.methodBox.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Open dir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(413, 331);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Install mod";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // InstanceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 362);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.createBtn);
            this.Name = "InstanceManager";
            this.Text = "InstanceManager";
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
        private System.Windows.Forms.TextBox editionBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox custjarBox;
        private System.Windows.Forms.CheckBox custjarCheck;
        private System.Windows.Forms.CheckBox methodCheck;
        private System.Windows.Forms.CheckBox jvmCheck;
        private System.Windows.Forms.TextBox jvmBox;
        private System.Windows.Forms.CheckBox javaCheck;
        private System.Windows.Forms.TextBox javaBox;
        private System.Windows.Forms.ComboBox methodBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}