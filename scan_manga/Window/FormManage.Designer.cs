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
            ((System.ComponentModel.ISupportInitialize)(this.picturePage)).BeginInit();
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
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 673);
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
    }
}