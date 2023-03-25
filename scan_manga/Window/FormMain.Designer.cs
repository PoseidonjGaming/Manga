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
            listBoxManga = new ListBox();
            listBoxChapter = new ListBox();
            comboBoxManga = new ComboBox();
            menuStrip = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            optionToolStripMenuItem = new ToolStripMenuItem();
            manageToolStripMenuItem = new ToolStripMenuItem();
            archiveToolStripMenuItem = new ToolStripMenuItem();
            backupToolStripMenuItem = new ToolStripMenuItem();
            restaurationToolStripMenuItem = new ToolStripMenuItem();
            importExportToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            téléchargementToolStripMenuItem = new ToolStripMenuItem();
            scannerToolStripMenuItem = new ToolStripMenuItem();
            charcherUnChapitreToolStripMenuItem = new ToolStripMenuItem();
            uploadToolStripMenuItem = new ToolStripMenuItem();
            extractToolStripMenuItem = new ToolStripMenuItem();
            pictureBoxPage = new PictureBox();
            comboBoxPage = new ComboBox();
            testToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPage).BeginInit();
            SuspendLayout();
            // 
            // listBoxManga
            // 
            listBoxManga.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxManga.FormattingEnabled = true;
            listBoxManga.ItemHeight = 15;
            listBoxManga.Location = new Point(12, 56);
            listBoxManga.Name = "listBoxManga";
            listBoxManga.Size = new Size(340, 619);
            listBoxManga.Sorted = true;
            listBoxManga.TabIndex = 0;
            listBoxManga.SelectedIndexChanged += listBoxManga_SelectedValueChanged;
            // 
            // listBoxChapter
            // 
            listBoxChapter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBoxChapter.FormattingEnabled = true;
            listBoxChapter.ItemHeight = 15;
            listBoxChapter.Location = new Point(874, 27);
            listBoxChapter.Name = "listBoxChapter";
            listBoxChapter.Size = new Size(340, 649);
            listBoxChapter.TabIndex = 1;
            listBoxChapter.SelectedIndexChanged += listBoxChapter_SelectedIndexChanged;
            // 
            // comboBoxManga
            // 
            comboBoxManga.AutoCompleteMode = AutoCompleteMode.Append;
            comboBoxManga.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxManga.FormattingEnabled = true;
            comboBoxManga.Location = new Point(12, 27);
            comboBoxManga.Name = "comboBoxManga";
            comboBoxManga.Size = new Size(340, 23);
            comboBoxManga.Sorted = true;
            comboBoxManga.TabIndex = 4;
            comboBoxManga.KeyUp += comboBoxManga_KeyUp;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = SystemColors.ControlLightLight;
            menuStrip.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, téléchargementToolStripMenuItem, uploadToolStripMenuItem, extractToolStripMenuItem, testToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1226, 24);
            menuStrip.TabIndex = 8;
            menuStrip.Text = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionToolStripMenuItem, manageToolStripMenuItem, archiveToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            optionToolStripMenuItem.Size = new Size(117, 22);
            optionToolStripMenuItem.Text = "Option";
            optionToolStripMenuItem.Click += optionToolStripMenuItem_Click;
            // 
            // manageToolStripMenuItem
            // 
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(117, 22);
            manageToolStripMenuItem.Text = "Manage";
            manageToolStripMenuItem.Click += manageToolStripMenuItem_Click;
            // 
            // archiveToolStripMenuItem
            // 
            archiveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupToolStripMenuItem, restaurationToolStripMenuItem, importExportToolStripMenuItem });
            archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            archiveToolStripMenuItem.Size = new Size(117, 22);
            archiveToolStripMenuItem.Text = "Archive";
            // 
            // backupToolStripMenuItem
            // 
            backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            backupToolStripMenuItem.Size = new Size(149, 22);
            backupToolStripMenuItem.Text = "Backup";
            backupToolStripMenuItem.Click += backupToolStripMenuItem_Click;
            // 
            // restaurationToolStripMenuItem
            // 
            restaurationToolStripMenuItem.Name = "restaurationToolStripMenuItem";
            restaurationToolStripMenuItem.Size = new Size(149, 22);
            restaurationToolStripMenuItem.Text = "Restauration";
            restaurationToolStripMenuItem.Click += restaurationToolStripMenuItem_Click;
            // 
            // importExportToolStripMenuItem
            // 
            importExportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem, importToolStripMenuItem });
            importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            importExportToolStripMenuItem.Size = new Size(149, 22);
            importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(110, 22);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(110, 22);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // téléchargementToolStripMenuItem
            // 
            téléchargementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scannerToolStripMenuItem, charcherUnChapitreToolStripMenuItem });
            téléchargementToolStripMenuItem.Name = "téléchargementToolStripMenuItem";
            téléchargementToolStripMenuItem.Size = new Size(103, 20);
            téléchargementToolStripMenuItem.Text = "Téléchargement";
            // 
            // scannerToolStripMenuItem
            // 
            scannerToolStripMenuItem.Name = "scannerToolStripMenuItem";
            scannerToolStripMenuItem.Size = new Size(216, 22);
            scannerToolStripMenuItem.Text = "Chercher tous les chapitres";
            scannerToolStripMenuItem.Click += scannerToolStripMenuItem_Click;
            // 
            // charcherUnChapitreToolStripMenuItem
            // 
            charcherUnChapitreToolStripMenuItem.Name = "charcherUnChapitreToolStripMenuItem";
            charcherUnChapitreToolStripMenuItem.Size = new Size(216, 22);
            charcherUnChapitreToolStripMenuItem.Text = "Charcher un chapitre";
            charcherUnChapitreToolStripMenuItem.Click += charcherUnChapitreToolStripMenuItem_Click;
            // 
            // uploadToolStripMenuItem
            // 
            uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            uploadToolStripMenuItem.Size = new Size(57, 20);
            uploadToolStripMenuItem.Text = "Upload";
            uploadToolStripMenuItem.Click += uploadToolStripMenuItem_Click;
            // 
            // extractToolStripMenuItem
            // 
            extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            extractToolStripMenuItem.Size = new Size(55, 20);
            extractToolStripMenuItem.Text = "Extract";
            extractToolStripMenuItem.Click += extractToolStripMenuItem_Click;
            // 
            // pictureBoxPage
            // 
            pictureBoxPage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxPage.Location = new Point(358, 56);
            pictureBoxPage.Name = "pictureBoxPage";
            pictureBoxPage.Size = new Size(510, 619);
            pictureBoxPage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPage.TabIndex = 9;
            pictureBoxPage.TabStop = false;
            // 
            // comboBoxPage
            // 
            comboBoxPage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxPage.FormattingEnabled = true;
            comboBoxPage.IntegralHeight = false;
            comboBoxPage.Location = new Point(358, 27);
            comboBoxPage.Name = "comboBoxPage";
            comboBoxPage.Size = new Size(510, 23);
            comboBoxPage.Sorted = true;
            comboBoxPage.TabIndex = 10;
            comboBoxPage.SelectedIndexChanged += comboBoxPage_SelectedIndexChanged;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(39, 20);
            testToolStripMenuItem.Text = "Test";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 681);
            Controls.Add(comboBoxPage);
            Controls.Add(pictureBoxPage);
            Controls.Add(comboBoxManga);
            Controls.Add(listBoxChapter);
            Controls.Add(listBoxManga);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manga Library";
            FormClosed += FormMain_FormClosed;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxManga;
        private ListBox listBoxChapter;
        private ComboBox comboBoxManga;
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
        private ToolStripMenuItem testToolStripMenuItem;
    }
}