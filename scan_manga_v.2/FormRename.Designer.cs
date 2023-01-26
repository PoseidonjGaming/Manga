namespace scan_manga
{
    partial class FormRename
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
            this.pictureBoxScan = new System.Windows.Forms.PictureBox();
            this.comboBoxChapter = new System.Windows.Forms.ComboBox();
            this.buttonSup = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listBoxRename = new System.Windows.Forms.ListBox();
            this.comboBoxManga = new System.Windows.Forms.ComboBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.textBoxRename = new System.Windows.Forms.TextBox();
            this.listBoxPage = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.progressBarPage = new System.Windows.Forms.ProgressBar();
            this.progressBarChapter = new System.Windows.Forms.ProgressBar();
            this.labelPage = new System.Windows.Forms.Label();
            this.labelChapter = new System.Windows.Forms.Label();
            this.backgroundWorkerRename = new System.ComponentModel.BackgroundWorker();
            this.progressBarManga = new System.Windows.Forms.ProgressBar();
            this.labelManga = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxScan
            // 
            this.pictureBoxScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxScan.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxScan.Name = "pictureBoxScan";
            this.pictureBoxScan.Size = new System.Drawing.Size(421, 592);
            this.pictureBoxScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScan.TabIndex = 0;
            this.pictureBoxScan.TabStop = false;
            // 
            // comboBoxChapter
            // 
            this.comboBoxChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChapter.FormattingEnabled = true;
            this.comboBoxChapter.Location = new System.Drawing.Point(657, 12);
            this.comboBoxChapter.Name = "comboBoxChapter";
            this.comboBoxChapter.Size = new System.Drawing.Size(208, 23);
            this.comboBoxChapter.TabIndex = 16;
            this.comboBoxChapter.SelectedIndexChanged += new System.EventHandler(this.comboBoxChapter_SelectedIndexChanged);
            // 
            // buttonSup
            // 
            this.buttonSup.Location = new System.Drawing.Point(738, 291);
            this.buttonSup.Name = "buttonSup";
            this.buttonSup.Size = new System.Drawing.Size(75, 23);
            this.buttonSup.TabIndex = 15;
            this.buttonSup.Text = "Supprimer";
            this.buttonSup.UseVisualStyleBackColor = true;
            this.buttonSup.Click += new System.EventHandler(this.buttonSup_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(657, 291);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Ajouter";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // listBoxRename
            // 
            this.listBoxRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRename.FormattingEnabled = true;
            this.listBoxRename.ItemHeight = 15;
            this.listBoxRename.Location = new System.Drawing.Point(657, 41);
            this.listBoxRename.Name = "listBoxRename";
            this.listBoxRename.Size = new System.Drawing.Size(208, 244);
            this.listBoxRename.TabIndex = 13;
            // 
            // comboBoxManga
            // 
            this.comboBoxManga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxManga.FormattingEnabled = true;
            this.comboBoxManga.Location = new System.Drawing.Point(443, 12);
            this.comboBoxManga.Name = "comboBoxManga";
            this.comboBoxManga.Size = new System.Drawing.Size(208, 23);
            this.comboBoxManga.Sorted = true;
            this.comboBoxManga.TabIndex = 12;
            this.comboBoxManga.SelectedIndexChanged += new System.EventHandler(this.comboBoxManga_SelectedIndexChanged);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(443, 291);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 11;
            this.buttonRename.Text = "Renomer";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // textBoxRename
            // 
            this.textBoxRename.Location = new System.Drawing.Point(520, 292);
            this.textBoxRename.Name = "textBoxRename";
            this.textBoxRename.Size = new System.Drawing.Size(127, 23);
            this.textBoxRename.TabIndex = 10;
            // 
            // listBoxPage
            // 
            this.listBoxPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPage.FormattingEnabled = true;
            this.listBoxPage.ItemHeight = 15;
            this.listBoxPage.Location = new System.Drawing.Point(443, 41);
            this.listBoxPage.Name = "listBoxPage";
            this.listBoxPage.Size = new System.Drawing.Size(208, 244);
            this.listBoxPage.TabIndex = 9;
            this.listBoxPage.SelectedIndexChanged += new System.EventHandler(this.listBoxPage_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(443, 320);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Enregistrer";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // progressBarPage
            // 
            this.progressBarPage.Location = new System.Drawing.Point(443, 364);
            this.progressBarPage.Name = "progressBarPage";
            this.progressBarPage.Size = new System.Drawing.Size(422, 23);
            this.progressBarPage.TabIndex = 18;
            // 
            // progressBarChapter
            // 
            this.progressBarChapter.Location = new System.Drawing.Point(443, 408);
            this.progressBarChapter.Name = "progressBarChapter";
            this.progressBarChapter.Size = new System.Drawing.Size(422, 23);
            this.progressBarChapter.TabIndex = 19;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(443, 346);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(36, 15);
            this.labelPage.TabIndex = 20;
            this.labelPage.Text = "Page:";
            // 
            // labelChapter
            // 
            this.labelChapter.AutoSize = true;
            this.labelChapter.Location = new System.Drawing.Point(443, 390);
            this.labelChapter.Name = "labelChapter";
            this.labelChapter.Size = new System.Drawing.Size(55, 15);
            this.labelChapter.TabIndex = 21;
            this.labelChapter.Text = "Chapitre:";
            // 
            // backgroundWorkerRename
            // 
            this.backgroundWorkerRename.WorkerReportsProgress = true;
            this.backgroundWorkerRename.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRename_DoWork);
            this.backgroundWorkerRename.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerRename_ProgressChanged);
            this.backgroundWorkerRename.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRename_RunWorkerCompleted);
            // 
            // progressBarManga
            // 
            this.progressBarManga.Location = new System.Drawing.Point(443, 452);
            this.progressBarManga.Name = "progressBarManga";
            this.progressBarManga.Size = new System.Drawing.Size(422, 23);
            this.progressBarManga.TabIndex = 22;
            // 
            // labelManga
            // 
            this.labelManga.AutoSize = true;
            this.labelManga.Location = new System.Drawing.Point(443, 434);
            this.labelManga.Name = "labelManga";
            this.labelManga.Size = new System.Drawing.Size(44, 15);
            this.labelManga.TabIndex = 23;
            this.labelManga.Text = "Manga";
            // 
            // FormRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 616);
            this.Controls.Add(this.labelManga);
            this.Controls.Add(this.progressBarManga);
            this.Controls.Add(this.labelChapter);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.progressBarChapter);
            this.Controls.Add(this.progressBarPage);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxChapter);
            this.Controls.Add(this.buttonSup);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxRename);
            this.Controls.Add(this.comboBoxManga);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.textBoxRename);
            this.Controls.Add(this.listBoxPage);
            this.Controls.Add(this.pictureBoxScan);
            this.Name = "FormRename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Changement de nom des pages";
            this.Load += new System.EventHandler(this.FormRename_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxScan;
        private ComboBox comboBoxChapter;
        private Button buttonSup;
        private Button buttonAdd;
        private ListBox listBoxRename;
        private ComboBox comboBoxManga;
        private Button buttonRename;
        private TextBox textBoxRename;
        private ListBox listBoxPage;
        private Button buttonSave;
        private ProgressBar progressBarPage;
        private ProgressBar progressBarChapter;
        private Label labelPage;
        private Label labelChapter;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRename;
        private ProgressBar progressBarManga;
        private Label labelManga;
    }
}