namespace scan_manga
{
    partial class FormManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManage));
            this.pictureBoxPage = new System.Windows.Forms.PictureBox();
            this.cmbManga = new System.Windows.Forms.ComboBox();
            this.cmbChapter = new System.Windows.Forms.ComboBox();
            this.lstBoxPage = new System.Windows.Forms.ListBox();
            this.btnSuppChapter = new System.Windows.Forms.Button();
            this.lstBoxThrash = new System.Windows.Forms.ListBox();
            this.btnSuppManga = new System.Windows.Forms.Button();
            this.btnDoWork = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPage
            // 
            this.pictureBoxPage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxPage.Name = "pictureBoxPage";
            this.pictureBoxPage.Size = new System.Drawing.Size(400, 598);
            this.pictureBoxPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPage.TabIndex = 0;
            this.pictureBoxPage.TabStop = false;
            // 
            // cmbManga
            // 
            this.cmbManga.FormattingEnabled = true;
            this.cmbManga.Location = new System.Drawing.Point(418, 12);
            this.cmbManga.Name = "cmbManga";
            this.cmbManga.Size = new System.Drawing.Size(270, 23);
            this.cmbManga.TabIndex = 1;
            this.cmbManga.SelectedIndexChanged += new System.EventHandler(this.cmbManga_SelectedIndexChanged);
            // 
            // cmbChapter
            // 
            this.cmbChapter.FormattingEnabled = true;
            this.cmbChapter.Location = new System.Drawing.Point(418, 41);
            this.cmbChapter.Name = "cmbChapter";
            this.cmbChapter.Size = new System.Drawing.Size(270, 23);
            this.cmbChapter.TabIndex = 2;
            this.cmbChapter.SelectedIndexChanged += new System.EventHandler(this.cmbChapter_SelectedIndexChanged);
            // 
            // lstBoxPage
            // 
            this.lstBoxPage.FormattingEnabled = true;
            this.lstBoxPage.ItemHeight = 15;
            this.lstBoxPage.Location = new System.Drawing.Point(418, 70);
            this.lstBoxPage.Name = "lstBoxPage";
            this.lstBoxPage.Size = new System.Drawing.Size(270, 304);
            this.lstBoxPage.TabIndex = 3;
            this.lstBoxPage.SelectedIndexChanged += new System.EventHandler(this.lstBoxPage_SelectedIndexChanged);
            // 
            // btnSuppChapter
            // 
            this.btnSuppChapter.AutoSize = true;
            this.btnSuppChapter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSuppChapter.Location = new System.Drawing.Point(694, 43);
            this.btnSuppChapter.Name = "btnSuppChapter";
            this.btnSuppChapter.Size = new System.Drawing.Size(179, 25);
            this.btnSuppChapter.TabIndex = 4;
            this.btnSuppChapter.Text = "Mettre le chapitre à la corbeille";
            this.btnSuppChapter.UseVisualStyleBackColor = true;
            this.btnSuppChapter.Click += new System.EventHandler(this.btnSuppChapter_Click);
            // 
            // lstBoxThrash
            // 
            this.lstBoxThrash.FormattingEnabled = true;
            this.lstBoxThrash.ItemHeight = 15;
            this.lstBoxThrash.Location = new System.Drawing.Point(418, 410);
            this.lstBoxThrash.Name = "lstBoxThrash";
            this.lstBoxThrash.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxThrash.Size = new System.Drawing.Size(615, 199);
            this.lstBoxThrash.TabIndex = 5;
            // 
            // btnSuppManga
            // 
            this.btnSuppManga.AutoSize = true;
            this.btnSuppManga.Location = new System.Drawing.Point(694, 12);
            this.btnSuppManga.Name = "btnSuppManga";
            this.btnSuppManga.Size = new System.Drawing.Size(179, 25);
            this.btnSuppManga.TabIndex = 6;
            this.btnSuppManga.Text = "Mettre le manga à la corbeille";
            this.btnSuppManga.UseVisualStyleBackColor = true;
            this.btnSuppManga.Click += new System.EventHandler(this.btnSuppManga_Click);
            // 
            // btnDoWork
            // 
            this.btnDoWork.AutoSize = true;
            this.btnDoWork.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDoWork.Location = new System.Drawing.Point(418, 381);
            this.btnDoWork.Name = "btnDoWork";
            this.btnDoWork.Size = new System.Drawing.Size(157, 25);
            this.btnDoWork.TabIndex = 7;
            this.btnDoWork.Text = "Effectuer les modifications";
            this.btnDoWork.UseVisualStyleBackColor = true;
            this.btnDoWork.Click += new System.EventHandler(this.btnDoWork_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(581, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 622);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDoWork);
            this.Controls.Add(this.btnSuppManga);
            this.Controls.Add(this.lstBoxThrash);
            this.Controls.Add(this.btnSuppChapter);
            this.Controls.Add(this.lstBoxPage);
            this.Controls.Add(this.cmbChapter);
            this.Controls.Add(this.cmbManga);
            this.Controls.Add(this.pictureBoxPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage";
            this.Load += new System.EventHandler(this.FormManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxPage;
        private ComboBox cmbManga;
        private ComboBox cmbChapter;
        private ListBox lstBoxPage;
        private Button btnSuppChapter;
        private ListBox lstBoxThrash;
        private Button btnSuppManga;
        private Button btnDoWork;
        private Button btnCancel;
    }
}