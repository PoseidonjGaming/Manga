﻿namespace scan_manga
{
    partial class FormDownload
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
            this.backgroundWorkerDownload = new System.ComponentModel.BackgroundWorker();
            this.listBoxTempChapter = new System.Windows.Forms.ListBox();
            this.listBoxChapter = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSupp = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.progressBarPage = new System.Windows.Forms.ProgressBar();
            this.labelChapter = new System.Windows.Forms.Label();
            this.progressBarChapter = new System.Windows.Forms.ProgressBar();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonSelectAllTemp = new System.Windows.Forms.Button();
            this.buttonUnSelectAllTemp = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonUnSelectAll = new System.Windows.Forms.Button();
            this.backgroundWorkerCopy = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxScan = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorkerDownload
            // 
            this.backgroundWorkerDownload.WorkerReportsProgress = true;
            this.backgroundWorkerDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownload_DoWork);
            this.backgroundWorkerDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDownload_ProgressChanged);
            this.backgroundWorkerDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDownload_RunWorkerCompleted);
            // 
            // listBoxTempChapter
            // 
            this.listBoxTempChapter.FormattingEnabled = true;
            this.listBoxTempChapter.ItemHeight = 15;
            this.listBoxTempChapter.Location = new System.Drawing.Point(378, 12);
            this.listBoxTempChapter.Name = "listBoxTempChapter";
            this.listBoxTempChapter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTempChapter.Size = new System.Drawing.Size(250, 289);
            this.listBoxTempChapter.TabIndex = 1;
            this.listBoxTempChapter.SelectedIndexChanged += new System.EventHandler(this.listBoxTempChapter_SelectedIndexChanged);
            // 
            // listBoxChapter
            // 
            this.listBoxChapter.FormattingEnabled = true;
            this.listBoxChapter.ItemHeight = 15;
            this.listBoxChapter.Location = new System.Drawing.Point(738, 12);
            this.listBoxChapter.Name = "listBoxChapter";
            this.listBoxChapter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxChapter.Size = new System.Drawing.Size(227, 289);
            this.listBoxChapter.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(634, 130);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(98, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Ajouter >>";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSupp
            // 
            this.buttonSupp.Location = new System.Drawing.Point(634, 159);
            this.buttonSupp.Name = "buttonSupp";
            this.buttonSupp.Size = new System.Drawing.Size(98, 23);
            this.buttonSupp.TabIndex = 4;
            this.buttonSupp.Text = "<< Ajouter";
            this.buttonSupp.UseVisualStyleBackColor = true;
            this.buttonSupp.Click += new System.EventHandler(this.buttonSupp_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(378, 333);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(36, 15);
            this.labelPage.TabIndex = 5;
            this.labelPage.Text = "Page:";
            // 
            // progressBarPage
            // 
            this.progressBarPage.Location = new System.Drawing.Point(378, 351);
            this.progressBarPage.Name = "progressBarPage";
            this.progressBarPage.Size = new System.Drawing.Size(587, 23);
            this.progressBarPage.Step = 1;
            this.progressBarPage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarPage.TabIndex = 6;
            // 
            // labelChapter
            // 
            this.labelChapter.AutoSize = true;
            this.labelChapter.Location = new System.Drawing.Point(378, 377);
            this.labelChapter.Name = "labelChapter";
            this.labelChapter.Size = new System.Drawing.Size(55, 15);
            this.labelChapter.TabIndex = 7;
            this.labelChapter.Text = "Chapitre:";
            // 
            // progressBarChapter
            // 
            this.progressBarChapter.Location = new System.Drawing.Point(378, 395);
            this.progressBarChapter.Name = "progressBarChapter";
            this.progressBarChapter.Size = new System.Drawing.Size(587, 23);
            this.progressBarChapter.Step = 1;
            this.progressBarChapter.TabIndex = 8;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(378, 307);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(115, 23);
            this.buttonDownload.TabIndex = 9;
            this.buttonDownload.Text = "Tout télécharger";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonSelectAllTemp
            // 
            this.buttonSelectAllTemp.Location = new System.Drawing.Point(634, 12);
            this.buttonSelectAllTemp.Name = "buttonSelectAllTemp";
            this.buttonSelectAllTemp.Size = new System.Drawing.Size(98, 53);
            this.buttonSelectAllTemp.TabIndex = 10;
            this.buttonSelectAllTemp.Text = "Tout Sélectionner";
            this.buttonSelectAllTemp.UseVisualStyleBackColor = true;
            this.buttonSelectAllTemp.Click += new System.EventHandler(this.buttonSelectAllTemp_Click);
            // 
            // buttonUnSelectAllTemp
            // 
            this.buttonUnSelectAllTemp.Location = new System.Drawing.Point(634, 71);
            this.buttonUnSelectAllTemp.Name = "buttonUnSelectAllTemp";
            this.buttonUnSelectAllTemp.Size = new System.Drawing.Size(98, 53);
            this.buttonUnSelectAllTemp.TabIndex = 11;
            this.buttonUnSelectAllTemp.Text = "Tout Désélectionner";
            this.buttonUnSelectAllTemp.UseVisualStyleBackColor = true;
            this.buttonUnSelectAllTemp.Click += new System.EventHandler(this.buttonUnSelectAllTemp_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(634, 188);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(98, 53);
            this.buttonSelectAll.TabIndex = 12;
            this.buttonSelectAll.Text = "Tout Sélectionner";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonUnSelectAll
            // 
            this.buttonUnSelectAll.Location = new System.Drawing.Point(634, 247);
            this.buttonUnSelectAll.Name = "buttonUnSelectAll";
            this.buttonUnSelectAll.Size = new System.Drawing.Size(98, 53);
            this.buttonUnSelectAll.TabIndex = 13;
            this.buttonUnSelectAll.Text = "Tout Désélectionner";
            this.buttonUnSelectAll.UseVisualStyleBackColor = true;
            this.buttonUnSelectAll.Click += new System.EventHandler(this.buttonUnSelectAll_Click);
            // 
            // backgroundWorkerCopy
            // 
            this.backgroundWorkerCopy.WorkerReportsProgress = true;
            this.backgroundWorkerCopy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCopy_DoWork);
            this.backgroundWorkerCopy.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCopy_ProgressChanged);
            this.backgroundWorkerCopy.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCopy_RunWorkerCompleted);
            // 
            // pictureBoxScan
            // 
            this.pictureBoxScan.ImageLocation = "";
            this.pictureBoxScan.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxScan.Name = "pictureBoxScan";
            this.pictureBoxScan.Size = new System.Drawing.Size(360, 537);
            this.pictureBoxScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScan.TabIndex = 14;
            this.pictureBoxScan.TabStop = false;
            // 
            // FormDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(975, 561);
            this.Controls.Add(this.pictureBoxScan);
            this.Controls.Add(this.buttonUnSelectAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonUnSelectAllTemp);
            this.Controls.Add(this.buttonSelectAllTemp);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.progressBarChapter);
            this.Controls.Add(this.labelChapter);
            this.Controls.Add(this.progressBarPage);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.buttonSupp);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxChapter);
            this.Controls.Add(this.listBoxTempChapter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download";
            this.Load += new System.EventHandler(this.FormDownload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerDownload;
        private ListBox listBoxTempChapter;
        private ListBox listBoxChapter;
        private Button buttonAdd;
        private Button buttonSupp;
        private Label labelPage;
        private ProgressBar progressBarPage;
        private Label labelChapter;
        private ProgressBar progressBarChapter;
        private Button buttonDownload;
        private Button buttonSelectAllTemp;
        private Button buttonUnSelectAllTemp;
        private Button buttonSelectAll;
        private Button buttonUnSelectAll;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCopy;
        private PictureBox pictureBoxScan;
    }
}