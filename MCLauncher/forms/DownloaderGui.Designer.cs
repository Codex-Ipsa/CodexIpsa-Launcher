﻿namespace MCLauncher.forms
{
    partial class DownloaderGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloaderGui));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(81, 69);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "btn.Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressLabel.ForeColor = System.Drawing.Color.Black;
            this.ProgressLabel.Location = new System.Drawing.Point(12, 53);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(58, 13);
            this.ProgressLabel.TabIndex = 7;
            this.ProgressLabel.Text = "lbl.Loading";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "lbl.DlFiles";
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(12, 27);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(213, 23);
            this.progressBarDownload.TabIndex = 5;
            // 
            // DownloaderGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 102);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloaderGui";
            this.Text = "DownloaderGui";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarDownload;
    }
}