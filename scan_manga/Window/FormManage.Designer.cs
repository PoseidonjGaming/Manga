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
            this.listBoxNewPage = new System.Windows.Forms.ListBox();
            this.comboBoxNewManga = new System.Windows.Forms.ComboBox();
            this.comboBoxNewChapter = new System.Windows.Forms.ComboBox();
            this.btnAddChapter = new System.Windows.Forms.Button();
            this.txtBoxNewPage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddPage = new System.Windows.Forms.Button();
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
            this.btnSuppChapter.Location = new System.Drawing.Point(694, 41);
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
            this.lstBoxThrash.Size = new System.Drawing.Size(731, 199);
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
            this.btnDoWork.Location = new System.Drawing.Point(418, 380);
            this.btnDoWork.Name = "btnDoWork";
            this.btnDoWork.Size = new System.Drawing.Size(157, 25);
            this.btnDoWork.TabIndex = 7;
            this.btnDoWork.Text = "Effectuer les modifications";
            this.btnDoWork.UseVisualStyleBackColor = true;
            this.btnDoWork.Click += new System.EventHandler(this.btnDoWork_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(581, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listBoxNewPage
            // 
            this.listBoxNewPage.FormattingEnabled = true;
            this.listBoxNewPage.ItemHeight = 15;
            this.listBoxNewPage.Location = new System.Drawing.Point(879, 70);
            this.listBoxNewPage.Name = "listBoxNewPage";
            this.listBoxNewPage.Size = new System.Drawing.Size(270, 304);
            this.listBoxNewPage.TabIndex = 9;
            // 
            // comboBoxNewManga
            // 
            this.comboBoxNewManga.FormattingEnabled = true;
            this.comboBoxNewManga.Location = new System.Drawing.Point(879, 12);
            this.comboBoxNewManga.Name = "comboBoxNewManga";
            this.comboBoxNewManga.Size = new System.Drawing.Size(270, 23);
            this.comboBoxNewManga.TabIndex = 10;
            this.comboBoxNewManga.SelectedIndexChanged += new System.EventHandler(this.comboBoxNewManga_SelectedIndexChanged);
            // 
            // comboBoxNewChapter
            // 
            this.comboBoxNewChapter.FormattingEnabled = true;
            this.comboBoxNewChapter.Location = new System.Drawing.Point(879, 41);
            this.comboBoxNewChapter.Name = "comboBoxNewChapter";
            this.comboBoxNewChapter.Size = new System.Drawing.Size(270, 23);
            this.comboBoxNewChapter.TabIndex = 11;
            this.comboBoxNewChapter.SelectedIndexChanged += new System.EventHandler(this.comboBoxNewChapter_SelectedIndexChanged);
            // 
            // btnAddChapter
            // 
            this.btnAddChapter.Location = new System.Drawing.Point(694, 93);
            this.btnAddChapter.Name = "btnAddChapter";
            this.btnAddChapter.Size = new System.Drawing.Size(179, 23);
            this.btnAddChapter.TabIndex = 12;
            this.btnAddChapter.Text = "Ajouter un chapter";
            this.btnAddChapter.UseVisualStyleBackColor = true;
            this.btnAddChapter.Click += new System.EventHandler(this.btnAddChapter_Click);
            // 
            // txtBoxNewPage
            // 
            this.txtBoxNewPage.Location = new System.Drawing.Point(694, 122);
            this.txtBoxNewPage.Name = "txtBoxNewPage";
            this.txtBoxNewPage.Size = new System.Drawing.Size(179, 23);
            this.txtBoxNewPage.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddPage
            // 
            this.btnAddPage.Location = new System.Drawing.Point(694, 151);
            this.btnAddPage.Name = "btnAddPage";
            this.btnAddPage.Size = new System.Drawing.Size(179, 23);
            this.btnAddPage.TabIndex = 15;
            this.btnAddPage.Text = "Add page";
            this.btnAddPage.UseVisualStyleBackColor = true;
            this.btnAddPage.Click += new System.EventHandler(this.btnAddPage_Click);
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 622);
            this.Controls.Add(this.btnAddPage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBoxNewPage);
            this.Controls.Add(this.btnAddChapter);
            this.Controls.Add(this.comboBoxNewChapter);
            this.Controls.Add(this.comboBoxNewManga);
            this.Controls.Add(this.listBoxNewPage);
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
        private ListBox listBoxNewPage;
        private ComboBox comboBoxNewManga;
        private ComboBox comboBoxNewChapter;
        private Button btnAddChapter;
        private TextBox txtBoxNewPage;
        private Button button1;
        private Button btnAddPage;
    }
}