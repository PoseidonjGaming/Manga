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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listBoxManga = new System.Windows.Forms.ListBox();
            this.listBoxChapter = new System.Windows.Forms.ListBox();
            this.comboBoxManga = new System.Windows.Forms.ComboBox();
            this.labelChpater = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.téléchargementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charcherUnChapitreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxPage = new System.Windows.Forms.PictureBox();
            this.comboBoxPage = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxManga
            // 
            this.listBoxManga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxManga.FormattingEnabled = true;
            this.listBoxManga.ItemHeight = 15;
            this.listBoxManga.Location = new System.Drawing.Point(12, 56);
            this.listBoxManga.Name = "listBoxManga";
            this.listBoxManga.Size = new System.Drawing.Size(340, 619);
            this.listBoxManga.TabIndex = 0;
            this.listBoxManga.SelectedIndexChanged += new System.EventHandler(this.listBoxManga_SelectedValueChanged);
            // 
            // listBoxChapter
            // 
            this.listBoxChapter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxChapter.FormattingEnabled = true;
            this.listBoxChapter.ItemHeight = 15;
            this.listBoxChapter.Location = new System.Drawing.Point(874, 56);
            this.listBoxChapter.Name = "listBoxChapter";
            this.listBoxChapter.Size = new System.Drawing.Size(340, 619);
            this.listBoxChapter.TabIndex = 1;
            this.listBoxChapter.SelectedIndexChanged += new System.EventHandler(this.listBoxChapter_SelectedIndexChanged);
            // 
            // comboBoxManga
            // 
            this.comboBoxManga.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxManga.FormattingEnabled = true;
            this.comboBoxManga.Location = new System.Drawing.Point(12, 27);
            this.comboBoxManga.Name = "comboBoxManga";
            this.comboBoxManga.Size = new System.Drawing.Size(340, 23);
            this.comboBoxManga.Sorted = true;
            this.comboBoxManga.TabIndex = 4;
            // 
            // labelChpater
            // 
            this.labelChpater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChpater.AutoSize = true;
            this.labelChpater.Location = new System.Drawing.Point(874, 30);
            this.labelChpater.Name = "labelChpater";
            this.labelChpater.Size = new System.Drawing.Size(38, 15);
            this.labelChpater.TabIndex = 5;
            this.labelChpater.Text = "label1";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.téléchargementToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.extractToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1226, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.archiveToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.optionToolStripMenuItem.Text = "Option";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.manageToolStripMenuItem.Text = "Manage";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.restaurationToolStripMenuItem,
            this.importExportToolStripMenuItem});
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.archiveToolStripMenuItem.Text = "Archive";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // restaurationToolStripMenuItem
            // 
            this.restaurationToolStripMenuItem.Name = "restaurationToolStripMenuItem";
            this.restaurationToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.restaurationToolStripMenuItem.Text = "Restauration";
            this.restaurationToolStripMenuItem.Click += new System.EventHandler(this.restaurationToolStripMenuItem_Click);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // téléchargementToolStripMenuItem
            // 
            this.téléchargementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scannerToolStripMenuItem,
            this.charcherUnChapitreToolStripMenuItem});
            this.téléchargementToolStripMenuItem.Name = "téléchargementToolStripMenuItem";
            this.téléchargementToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.téléchargementToolStripMenuItem.Text = "Téléchargement";
            // 
            // scannerToolStripMenuItem
            // 
            this.scannerToolStripMenuItem.Name = "scannerToolStripMenuItem";
            this.scannerToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.scannerToolStripMenuItem.Text = "Chercher tous les chapitres";
            this.scannerToolStripMenuItem.Click += new System.EventHandler(this.scannerToolStripMenuItem_Click);
            // 
            // charcherUnChapitreToolStripMenuItem
            // 
            this.charcherUnChapitreToolStripMenuItem.Name = "charcherUnChapitreToolStripMenuItem";
            this.charcherUnChapitreToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.charcherUnChapitreToolStripMenuItem.Text = "Charcher un chapitre";
            this.charcherUnChapitreToolStripMenuItem.Click += new System.EventHandler(this.charcherUnChapitreToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.extractToolStripMenuItem.Text = "Extract";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // pictureBoxPage
            // 
            this.pictureBoxPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPage.Location = new System.Drawing.Point(358, 56);
            this.pictureBoxPage.Name = "pictureBoxPage";
            this.pictureBoxPage.Size = new System.Drawing.Size(510, 619);
            this.pictureBoxPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPage.TabIndex = 9;
            this.pictureBoxPage.TabStop = false;
            // 
            // comboBoxPage
            // 
            this.comboBoxPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPage.FormattingEnabled = true;
            this.comboBoxPage.IntegralHeight = false;
            this.comboBoxPage.Location = new System.Drawing.Point(358, 27);
            this.comboBoxPage.Name = "comboBoxPage";
            this.comboBoxPage.Size = new System.Drawing.Size(510, 23);
            this.comboBoxPage.Sorted = true;
            this.comboBoxPage.TabIndex = 10;
            this.comboBoxPage.SelectedIndexChanged += new System.EventHandler(this.comboBoxPage_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 681);
            this.Controls.Add(this.comboBoxPage);
            this.Controls.Add(this.pictureBoxPage);
            this.Controls.Add(this.labelChpater);
            this.Controls.Add(this.comboBoxManga);
            this.Controls.Add(this.listBoxChapter);
            this.Controls.Add(this.listBoxManga);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manga Library";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBoxManga;
        private ListBox listBoxChapter;
        private ComboBox comboBoxManga;
        private Label labelChpater;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem optionToolStripMenuItem;
        private ToolStripMenuItem manageToolStripMenuItem;
        private PictureBox pictureBoxPage;
        private ComboBox comboBoxPage;
        private ToolStripMenuItem téléchargementToolStripMenuItem;
        private ToolStripMenuItem scannerToolStripMenuItem;
        private ToolStripMenuItem charcherUnChapitreToolStripMenuItem;
        private ToolStripMenuItem archiveToolStripMenuItem;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem restaurationToolStripMenuItem;
        private ToolStripMenuItem uploadToolStripMenuItem;
        private ToolStripMenuItem extractToolStripMenuItem;
        private ToolStripMenuItem importExportToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
    }
}