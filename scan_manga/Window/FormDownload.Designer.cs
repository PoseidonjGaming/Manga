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
            this.listBoxChapter = new System.Windows.Forms.ListBox();
            this.listBoxChapterDownload = new System.Windows.Forms.ListBox();
            this.buttonSupp = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonSelectAllTemp = new System.Windows.Forms.Button();
            this.buttonUnSelectAllTemp = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonUnSelectAll = new System.Windows.Forms.Button();
            this.pictureBoxScan = new System.Windows.Forms.PictureBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOpenTemp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxChapter
            // 
            this.listBoxChapter.FormattingEnabled = true;
            this.listBoxChapter.ItemHeight = 15;
            this.listBoxChapter.Location = new System.Drawing.Point(378, 12);
            this.listBoxChapter.Name = "listBoxChapter";
            this.listBoxChapter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxChapter.Size = new System.Drawing.Size(217, 529);
            this.listBoxChapter.TabIndex = 1;
            this.listBoxChapter.SelectedIndexChanged += new System.EventHandler(this.listBoxTempChapter_SelectedIndexChanged);
            // 
            // listBoxChapterDownload
            // 
            this.listBoxChapterDownload.FormattingEnabled = true;
            this.listBoxChapterDownload.ItemHeight = 15;
            this.listBoxChapterDownload.Location = new System.Drawing.Point(787, 8);
            this.listBoxChapterDownload.Name = "listBoxChapterDownload";
            this.listBoxChapterDownload.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxChapterDownload.Size = new System.Drawing.Size(211, 529);
            this.listBoxChapterDownload.TabIndex = 2;
            this.listBoxChapterDownload.SelectedIndexChanged += new System.EventHandler(this.listBoxChapter_SelectedIndexChanged);
            // 
            // buttonSupp
            // 
            this.buttonSupp.Location = new System.Drawing.Point(601, 157);
            this.buttonSupp.Name = "buttonSupp";
            this.buttonSupp.Size = new System.Drawing.Size(180, 23);
            this.buttonSupp.TabIndex = 4;
            this.buttonSupp.Text = "Supprimer le chapitre";
            this.buttonSupp.UseVisualStyleBackColor = true;
            this.buttonSupp.Click += new System.EventHandler(this.buttonSupp_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(601, 311);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(180, 23);
            this.buttonDownload.TabIndex = 9;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonSelectAllTemp
            // 
            this.buttonSelectAllTemp.Location = new System.Drawing.Point(601, 70);
            this.buttonSelectAllTemp.Name = "buttonSelectAllTemp";
            this.buttonSelectAllTemp.Size = new System.Drawing.Size(180, 23);
            this.buttonSelectAllTemp.TabIndex = 10;
            this.buttonSelectAllTemp.Text = "Tout Sélectionner";
            this.buttonSelectAllTemp.UseVisualStyleBackColor = true;
            this.buttonSelectAllTemp.Click += new System.EventHandler(this.buttonSelectAllTemp_Click);
            // 
            // buttonUnSelectAllTemp
            // 
            this.buttonUnSelectAllTemp.Location = new System.Drawing.Point(601, 99);
            this.buttonUnSelectAllTemp.Name = "buttonUnSelectAllTemp";
            this.buttonUnSelectAllTemp.Size = new System.Drawing.Size(180, 23);
            this.buttonUnSelectAllTemp.TabIndex = 11;
            this.buttonUnSelectAllTemp.Text = "Tout Désélectionner";
            this.buttonUnSelectAllTemp.UseVisualStyleBackColor = true;
            this.buttonUnSelectAllTemp.Click += new System.EventHandler(this.buttonUnSelectAllTemp_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(601, 186);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(180, 23);
            this.buttonSelectAll.TabIndex = 12;
            this.buttonSelectAll.Text = "Tout Sélectionner";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonUnSelectAll
            // 
            this.buttonUnSelectAll.Location = new System.Drawing.Point(601, 215);
            this.buttonUnSelectAll.Name = "buttonUnSelectAll";
            this.buttonUnSelectAll.Size = new System.Drawing.Size(180, 23);
            this.buttonUnSelectAll.TabIndex = 13;
            this.buttonUnSelectAll.Text = "Tout Désélectionner";
            this.buttonUnSelectAll.UseVisualStyleBackColor = true;
            this.buttonUnSelectAll.Click += new System.EventHandler(this.buttonUnSelectAll_Click);
            // 
            // pictureBoxScan
            // 
            this.pictureBoxScan.ImageLocation = "";
            this.pictureBoxScan.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxScan.Name = "pictureBoxScan";
            this.pictureBoxScan.Size = new System.Drawing.Size(360, 529);
            this.pictureBoxScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScan.TabIndex = 14;
            this.pictureBoxScan.TabStop = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(601, 128);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(180, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Ajouter le chapitre";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOpenTemp
            // 
            this.buttonOpenTemp.Location = new System.Drawing.Point(601, 12);
            this.buttonOpenTemp.Name = "buttonOpenTemp";
            this.buttonOpenTemp.Size = new System.Drawing.Size(180, 23);
            this.buttonOpenTemp.TabIndex = 23;
            this.buttonOpenTemp.Text = "Ouvrir le dossier temporaire";
            this.buttonOpenTemp.UseVisualStyleBackColor = true;
            this.buttonOpenTemp.Click += new System.EventHandler(this.buttonOpenTemp_Click);
            // 
            // FormDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1010, 561);
            this.Controls.Add(this.buttonOpenTemp);
            this.Controls.Add(this.pictureBoxScan);
            this.Controls.Add(this.buttonUnSelectAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonUnSelectAllTemp);
            this.Controls.Add(this.buttonSelectAllTemp);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonSupp);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxChapterDownload);
            this.Controls.Add(this.listBoxChapter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDownload_FormClosed);
            this.Load += new System.EventHandler(this.FormDownload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).EndInit();
            this.ResumeLayout(false);

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
    }
}