namespace scan_manga
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxManga = new System.Windows.Forms.ListBox();
            this.listBoxChapter = new System.Windows.Forms.ListBox();
            this.buttonOption = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.comboBoxManga = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerScan = new System.ComponentModel.BackgroundWorker();
            this.labelChpater = new System.Windows.Forms.Label();
            this.buttonManage = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxManga
            // 
            this.listBoxManga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxManga.FormattingEnabled = true;
            this.listBoxManga.ItemHeight = 15;
            this.listBoxManga.Location = new System.Drawing.Point(12, 12);
            this.listBoxManga.Name = "listBoxManga";
            this.listBoxManga.Size = new System.Drawing.Size(350, 649);
            this.listBoxManga.TabIndex = 0;
            this.listBoxManga.SelectedValueChanged += new System.EventHandler(this.listBoxManga_SelectedValueChanged);
            // 
            // listBoxChapter
            // 
            this.listBoxChapter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxChapter.FormattingEnabled = true;
            this.listBoxChapter.ItemHeight = 15;
            this.listBoxChapter.Location = new System.Drawing.Point(368, 12);
            this.listBoxChapter.Name = "listBoxChapter";
            this.listBoxChapter.Size = new System.Drawing.Size(885, 274);
            this.listBoxChapter.TabIndex = 1;
            // 
            // buttonOption
            // 
            this.buttonOption.Location = new System.Drawing.Point(368, 292);
            this.buttonOption.Name = "buttonOption";
            this.buttonOption.Size = new System.Drawing.Size(75, 23);
            this.buttonOption.TabIndex = 2;
            this.buttonOption.Text = "Option";
            this.buttonOption.UseVisualStyleBackColor = true;
            this.buttonOption.Click += new System.EventHandler(this.buttonOption_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(449, 292);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 3;
            this.buttonScan.Text = "Scanner";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // comboBoxManga
            // 
            this.comboBoxManga.FormattingEnabled = true;
            this.comboBoxManga.Location = new System.Drawing.Point(530, 293);
            this.comboBoxManga.Name = "comboBoxManga";
            this.comboBoxManga.Size = new System.Drawing.Size(180, 23);
            this.comboBoxManga.Sorted = true;
            this.comboBoxManga.TabIndex = 4;
            // 
            // backgroundWorkerScan
            // 
            this.backgroundWorkerScan.WorkerReportsProgress = true;
            this.backgroundWorkerScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerScan_DoWork);
            this.backgroundWorkerScan.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerScan_ProgressChanged);
            this.backgroundWorkerScan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerScan_RunWorkerCompleted);
            // 
            // labelChpater
            // 
            this.labelChpater.AutoSize = true;
            this.labelChpater.Location = new System.Drawing.Point(716, 296);
            this.labelChpater.Name = "labelChpater";
            this.labelChpater.Size = new System.Drawing.Size(38, 15);
            this.labelChpater.TabIndex = 5;
            this.labelChpater.Text = "label1";
            // 
            // buttonManage
            // 
            this.buttonManage.Location = new System.Drawing.Point(368, 321);
            this.buttonManage.Name = "buttonManage";
            this.buttonManage.Size = new System.Drawing.Size(75, 23);
            this.buttonManage.TabIndex = 6;
            this.buttonManage.Text = "Manage";
            this.buttonManage.UseVisualStyleBackColor = true;
            this.buttonManage.Click += new System.EventHandler(this.buttonManage_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(449, 321);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 7;
            this.buttonRename.Text = "Renommer";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.buttonManage);
            this.Controls.Add(this.labelChpater);
            this.Controls.Add(this.comboBoxManga);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.buttonOption);
            this.Controls.Add(this.listBoxChapter);
            this.Controls.Add(this.listBoxManga);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manga Library";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBoxManga;
        private ListBox listBoxChapter;
        private Button buttonOption;
        private Button buttonScan;
        private ComboBox comboBoxManga;
        private System.ComponentModel.BackgroundWorker backgroundWorkerScan;
        private Label labelChpater;
        private Button buttonManage;
        private Button buttonRename;
    }
}