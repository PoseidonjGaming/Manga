﻿namespace scan_manga
{
    partial class FormArchive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArchive));
            this.progressBarPage = new System.Windows.Forms.ProgressBar();
            this.labelPage = new System.Windows.Forms.Label();
            this.labelChapter = new System.Windows.Forms.Label();
            this.progressBarChapter = new System.Windows.Forms.ProgressBar();
            this.labelManga = new System.Windows.Forms.Label();
            this.progressBarManga = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBarPage
            // 
            this.progressBarPage.Location = new System.Drawing.Point(12, 27);
            this.progressBarPage.Name = "progressBarPage";
            this.progressBarPage.Size = new System.Drawing.Size(360, 23);
            this.progressBarPage.TabIndex = 0;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(12, 9);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(36, 15);
            this.labelPage.TabIndex = 1;
            this.labelPage.Text = "Page:";
            // 
            // labelChapter
            // 
            this.labelChapter.AutoSize = true;
            this.labelChapter.Location = new System.Drawing.Point(12, 53);
            this.labelChapter.Name = "labelChapter";
            this.labelChapter.Size = new System.Drawing.Size(55, 15);
            this.labelChapter.TabIndex = 2;
            this.labelChapter.Text = "Chapitre:";
            // 
            // progressBarChapter
            // 
            this.progressBarChapter.Location = new System.Drawing.Point(12, 71);
            this.progressBarChapter.Name = "progressBarChapter";
            this.progressBarChapter.Size = new System.Drawing.Size(360, 23);
            this.progressBarChapter.TabIndex = 3;
            // 
            // labelManga
            // 
            this.labelManga.AutoSize = true;
            this.labelManga.Location = new System.Drawing.Point(12, 97);
            this.labelManga.Name = "labelManga";
            this.labelManga.Size = new System.Drawing.Size(47, 15);
            this.labelManga.TabIndex = 4;
            this.labelManga.Text = "Manga:";
            // 
            // progressBarManga
            // 
            this.progressBarManga.Location = new System.Drawing.Point(12, 115);
            this.progressBarManga.Name = "progressBarManga";
            this.progressBarManga.Size = new System.Drawing.Size(360, 23);
            this.progressBarManga.TabIndex = 5;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // FormArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 153);
            this.Controls.Add(this.progressBarManga);
            this.Controls.Add(this.labelManga);
            this.Controls.Add(this.progressBarChapter);
            this.Controls.Add(this.labelChapter);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.progressBarPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArchive";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Archive";
            this.Load += new System.EventHandler(this.FormArchive_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressBar progressBarPage;
        private Label labelPage;
        private Label labelChapter;
        private ProgressBar progressBarChapter;
        private Label labelManga;
        private ProgressBar progressBarManga;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}