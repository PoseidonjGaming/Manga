namespace scan_manga.Window
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
            this.picturePage = new System.Windows.Forms.PictureBox();
            this.cmbBoxManga = new System.Windows.Forms.ComboBox();
            this.cmbBoxChapter = new System.Windows.Forms.ComboBox();
            this.lstBoxPage = new System.Windows.Forms.ListBox();
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
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).BeginInit();
            this.SuspendLayout();
            // 
            // picturePage
            // 
            this.picturePage.Location = new System.Drawing.Point(12, 12);
            this.picturePage.Name = "picturePage";
            this.picturePage.Size = new System.Drawing.Size(450, 649);
            this.picturePage.TabIndex = 0;
            this.picturePage.TabStop = false;
            // 
            // cmbBoxManga
            // 
            this.cmbBoxManga.FormattingEnabled = true;
            this.cmbBoxManga.Location = new System.Drawing.Point(468, 12);
            this.cmbBoxManga.Name = "cmbBoxManga";
            this.cmbBoxManga.Size = new System.Drawing.Size(225, 28);
            this.cmbBoxManga.TabIndex = 1;
            this.cmbBoxManga.SelectedIndexChanged += new System.EventHandler(this.cmbBoxManga_SelectedIndexChanged);
            // 
            // cmbBoxChapter
            // 
            this.cmbBoxChapter.FormattingEnabled = true;
            this.cmbBoxChapter.Location = new System.Drawing.Point(468, 46);
            this.cmbBoxChapter.Name = "cmbBoxChapter";
            this.cmbBoxChapter.Size = new System.Drawing.Size(225, 28);
            this.cmbBoxChapter.TabIndex = 2;
            // 
            // lstBoxPage
            // 
            this.lstBoxPage.FormattingEnabled = true;
            this.lstBoxPage.ItemHeight = 20;
            this.lstBoxPage.Location = new System.Drawing.Point(468, 80);
            this.lstBoxPage.Name = "lstBoxPage";
            this.lstBoxPage.Size = new System.Drawing.Size(225, 324);
            this.lstBoxPage.TabIndex = 3;
            // 
            // lstBoxThrash
            // 
            this.lstBoxThrash.FormattingEnabled = true;
            this.lstBoxThrash.ItemHeight = 20;
            this.lstBoxThrash.Location = new System.Drawing.Point(468, 417);
            this.lstBoxThrash.Name = "lstBoxThrash";
            this.lstBoxThrash.Size = new System.Drawing.Size(772, 244);
            this.lstBoxThrash.TabIndex = 4;
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
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(879, 381);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 16;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(960, 380);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 17;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 622);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
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
            this.Controls.Add(this.lstBoxPage);
            this.Controls.Add(this.cmbBoxChapter);
            this.Controls.Add(this.cmbBoxManga);
            this.Controls.Add(this.picturePage);
            this.Name = "FormManage";
            this.Text = "FormManage";
            this.Load += new System.EventHandler(this.FormManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturePage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picturePage;
        private ComboBox cmbBoxManga;
        private ComboBox cmbBoxChapter;
        private ListBox lstBoxPage;
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
        private Button btnUp;
        private Button btnDown;
    }
}