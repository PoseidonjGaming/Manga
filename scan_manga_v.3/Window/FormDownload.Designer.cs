namespace scan_manga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownload));
            listBoxChapter = new ListBox();
            listBoxChapterDownload = new ListBox();
            buttonSupp = new Button();
            buttonDownload = new Button();
            buttonSelectAllTemp = new Button();
            buttonUnSelectAllTemp = new Button();
            buttonSelectAll = new Button();
            buttonUnSelectAll = new Button();
            pictureBoxScan = new PictureBox();
            buttonAdd = new Button();
            buttonOpenTemp = new Button();
            btnDLAll = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScan).BeginInit();
            SuspendLayout();
            // 
            // listBoxChapter
            // 
            listBoxChapter.FormattingEnabled = true;
            listBoxChapter.ItemHeight = 15;
            listBoxChapter.Location = new Point(378, 12);
            listBoxChapter.Name = "listBoxChapter";
            listBoxChapter.SelectionMode = SelectionMode.MultiExtended;
            listBoxChapter.Size = new Size(217, 529);
            listBoxChapter.TabIndex = 1;
            listBoxChapter.SelectedIndexChanged += listBoxTempChapter_SelectedIndexChanged;
            // 
            // listBoxChapterDownload
            // 
            listBoxChapterDownload.FormattingEnabled = true;
            listBoxChapterDownload.ItemHeight = 15;
            listBoxChapterDownload.Location = new Point(787, 8);
            listBoxChapterDownload.Name = "listBoxChapterDownload";
            listBoxChapterDownload.SelectionMode = SelectionMode.MultiExtended;
            listBoxChapterDownload.Size = new Size(211, 529);
            listBoxChapterDownload.TabIndex = 2;
            listBoxChapterDownload.SelectedIndexChanged += listBoxChapter_SelectedIndexChanged;
            // 
            // buttonSupp
            // 
            buttonSupp.Location = new Point(601, 157);
            buttonSupp.Name = "buttonSupp";
            buttonSupp.Size = new Size(180, 23);
            buttonSupp.TabIndex = 4;
            buttonSupp.Text = "Supprimer le chapitre";
            buttonSupp.UseVisualStyleBackColor = true;
            buttonSupp.Click += buttonSupp_Click;
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(601, 311);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(180, 23);
            buttonDownload.TabIndex = 9;
            buttonDownload.Text = "Download";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // buttonSelectAllTemp
            // 
            buttonSelectAllTemp.Location = new Point(601, 70);
            buttonSelectAllTemp.Name = "buttonSelectAllTemp";
            buttonSelectAllTemp.Size = new Size(180, 23);
            buttonSelectAllTemp.TabIndex = 10;
            buttonSelectAllTemp.Text = "Tout Sélectionner";
            buttonSelectAllTemp.UseVisualStyleBackColor = true;
            buttonSelectAllTemp.Click += buttonSelectAllTemp_Click;
            // 
            // buttonUnSelectAllTemp
            // 
            buttonUnSelectAllTemp.Location = new Point(601, 99);
            buttonUnSelectAllTemp.Name = "buttonUnSelectAllTemp";
            buttonUnSelectAllTemp.Size = new Size(180, 23);
            buttonUnSelectAllTemp.TabIndex = 11;
            buttonUnSelectAllTemp.Text = "Tout Désélectionner";
            buttonUnSelectAllTemp.UseVisualStyleBackColor = true;
            buttonUnSelectAllTemp.Click += buttonUnSelectAllTemp_Click;
            // 
            // buttonSelectAll
            // 
            buttonSelectAll.Location = new Point(601, 186);
            buttonSelectAll.Name = "buttonSelectAll";
            buttonSelectAll.Size = new Size(180, 23);
            buttonSelectAll.TabIndex = 12;
            buttonSelectAll.Text = "Tout Sélectionner";
            buttonSelectAll.UseVisualStyleBackColor = true;
            buttonSelectAll.Click += buttonSelectAll_Click;
            // 
            // buttonUnSelectAll
            // 
            buttonUnSelectAll.Location = new Point(601, 215);
            buttonUnSelectAll.Name = "buttonUnSelectAll";
            buttonUnSelectAll.Size = new Size(180, 23);
            buttonUnSelectAll.TabIndex = 13;
            buttonUnSelectAll.Text = "Tout Désélectionner";
            buttonUnSelectAll.UseVisualStyleBackColor = true;
            buttonUnSelectAll.Click += buttonUnSelectAll_Click;
            // 
            // pictureBoxScan
            // 
            pictureBoxScan.ImageLocation = "";
            pictureBoxScan.Location = new Point(12, 12);
            pictureBoxScan.Name = "pictureBoxScan";
            pictureBoxScan.Size = new Size(360, 529);
            pictureBoxScan.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxScan.TabIndex = 14;
            pictureBoxScan.TabStop = false;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(601, 128);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(180, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Ajouter le chapitre";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonOpenTemp
            // 
            buttonOpenTemp.Location = new Point(601, 12);
            buttonOpenTemp.Name = "buttonOpenTemp";
            buttonOpenTemp.Size = new Size(180, 23);
            buttonOpenTemp.TabIndex = 23;
            buttonOpenTemp.Text = "Ouvrir le dossier temporaire";
            buttonOpenTemp.UseVisualStyleBackColor = true;
            buttonOpenTemp.Click += buttonOpenTemp_Click;
            // 
            // btnDLAll
            // 
            btnDLAll.Location = new Point(601, 340);
            btnDLAll.Name = "btnDLAll";
            btnDLAll.Size = new Size(180, 23);
            btnDLAll.TabIndex = 24;
            btnDLAll.Text = "Download All";
            btnDLAll.UseVisualStyleBackColor = true;
            btnDLAll.Click += btnDLAll_Click;
            // 
            // FormDownload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1010, 561);
            Controls.Add(btnDLAll);
            Controls.Add(buttonOpenTemp);
            Controls.Add(pictureBoxScan);
            Controls.Add(buttonUnSelectAll);
            Controls.Add(buttonSelectAll);
            Controls.Add(buttonUnSelectAllTemp);
            Controls.Add(buttonSelectAllTemp);
            Controls.Add(buttonDownload);
            Controls.Add(buttonSupp);
            Controls.Add(buttonAdd);
            Controls.Add(listBoxChapterDownload);
            Controls.Add(listBoxChapter);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDownload";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Download";
            FormClosed += FormDownload_FormClosed;
            Load += FormDownload_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxScan).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBoxChapter;
        private ListBox listBoxChapterDownload;
        private Button buttonSupp;
        private Button buttonDownload;
        private Button buttonSelectAllTemp;
        private Button buttonUnSelectAllTemp;
        private Button buttonSelectAll;
        private Button buttonUnSelectAll;
        private PictureBox pictureBoxScan;
        private Button buttonAdd;
        private Button buttonOpenTemp;
        private Button btnCopier;
        private Button btnDLAll;
    }
}