namespace MCLauncher.forms
{
    partial class AssetsDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetsDownloader));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lblDlFiles = new System.Windows.Forms.Label();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(81, 69);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "btn.Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.ForeColor = System.Drawing.Color.Black;
            this.lblLoading.Location = new System.Drawing.Point(12, 53);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(58, 13);
            this.lblLoading.TabIndex = 11;
            this.lblLoading.Text = "lbl.Loading";
            // 
            // lblDlFiles
            // 
            this.lblDlFiles.AutoSize = true;
            this.lblDlFiles.BackColor = System.Drawing.Color.Transparent;
            this.lblDlFiles.ForeColor = System.Drawing.Color.Black;
            this.lblDlFiles.Location = new System.Drawing.Point(12, 11);
            this.lblDlFiles.Name = "lblDlFiles";
            this.lblDlFiles.Size = new System.Drawing.Size(51, 13);
            this.lblDlFiles.TabIndex = 10;
            this.lblDlFiles.Text = "lbl.DlFiles";
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(12, 27);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(213, 23);
            this.progressBarDownload.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // AssetsDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 102);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.lblDlFiles);
            this.Controls.Add(this.progressBarDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssetsDownloader";
            this.Text = "Downloading files...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblDlFiles;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}