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
            this.cmbManga = new System.Windows.Forms.ComboBox();
            this.cmbChapter = new System.Windows.Forms.ComboBox();
            this.lstBoxPage = new System.Windows.Forms.ListBox();
            this.lstBoxThrash = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThrashManga = new System.Windows.Forms.Button();
            this.btnThrashChapter = new System.Windows.Forms.Button();
            this.cmbTempManga = new System.Windows.Forms.ComboBox();
            this.cmbTempChapter = new System.Windows.Forms.ComboBox();
            this.lstBoxTempPage = new System.Windows.Forms.ListBox();
            this.txtBoxTempManga = new System.Windows.Forms.TextBox();
            this.btnAddManga = new System.Windows.Forms.Button();
            this.btnSupManga = new System.Windows.Forms.Button();
            this.btnAddChapter = new System.Windows.Forms.Button();
            this.txtBoxTempChapter = new System.Windows.Forms.TextBox();
            this.btnSupTempChapter = new System.Windows.Forms.Button();
            this.btnAddPage = new System.Windows.Forms.Button();
            this.txtBoxTempPage = new System.Windows.Forms.TextBox();
            this.btnSupPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturePage)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // picturePage
            // 
            this.picturePage.Location = new System.Drawing.Point(12, 27);
            this.picturePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturePage.Name = "picturePage";
            this.picturePage.Size = new System.Drawing.Size(394, 537);
            this.picturePage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePage.TabIndex = 0;
            this.picturePage.TabStop = false;
            // 
            // cmbManga
            // 
            this.cmbManga.FormattingEnabled = true;
            this.cmbManga.Location = new System.Drawing.Point(412, 27);
            this.cmbManga.Name = "cmbManga";
            this.cmbManga.Size = new System.Drawing.Size(225, 23);
            this.cmbManga.TabIndex = 1;
            this.cmbManga.SelectedIndexChanged += new System.EventHandler(this.cmbManga_SelectedIndexChanged);
            // 
            // cmbChapter
            // 
            this.cmbChapter.FormattingEnabled = true;
            this.cmbChapter.Location = new System.Drawing.Point(412, 56);
            this.cmbChapter.Name = "cmbChapter";
            this.cmbChapter.Size = new System.Drawing.Size(225, 23);
            this.cmbChapter.TabIndex = 2;
            this.cmbChapter.SelectedIndexChanged += new System.EventHandler(this.cmbChapter_SelectedIndexChanged);
            // 
            // lstBoxPage
            // 
            this.lstBoxPage.FormattingEnabled = true;
            this.lstBoxPage.ItemHeight = 15;
            this.lstBoxPage.Location = new System.Drawing.Point(412, 85);
            this.lstBoxPage.Name = "lstBoxPage";
            this.lstBoxPage.Size = new System.Drawing.Size(225, 274);
            this.lstBoxPage.TabIndex = 3;
            this.lstBoxPage.SelectedIndexChanged += new System.EventHandler(this.lstBoxPage_SelectedIndexChanged);
            // 
            // lstBoxThrash
            // 
            this.lstBoxThrash.FormattingEnabled = true;
            this.lstBoxThrash.ItemHeight = 15;
            this.lstBoxThrash.Location = new System.Drawing.Point(412, 454);
            this.lstBoxThrash.Name = "lstBoxThrash";
            this.lstBoxThrash.Size = new System.Drawing.Size(660, 199);
            this.lstBoxThrash.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // btnThrashManga
            // 
            this.btnThrashManga.AutoSize = true;
            this.btnThrashManga.Location = new System.Drawing.Point(643, 25);
            this.btnThrashManga.Name = "btnThrashManga";
            this.btnThrashManga.Size = new System.Drawing.Size(179, 25);
            this.btnThrashManga.TabIndex = 6;
            this.btnThrashManga.Text = "Mettre le manga à la corbeille";
            this.btnThrashManga.UseVisualStyleBackColor = true;
            // 
            // btnThrashChapter
            // 
            this.btnThrashChapter.AutoSize = true;
            this.btnThrashChapter.Location = new System.Drawing.Point(643, 54);
            this.btnThrashChapter.Name = "btnThrashChapter";
            this.btnThrashChapter.Size = new System.Drawing.Size(179, 25);
            this.btnThrashChapter.TabIndex = 7;
            this.btnThrashChapter.Text = "Mettre le chapitre à la corbeille";
            this.btnThrashChapter.UseVisualStyleBackColor = true;
            // 
            // cmbTempManga
            // 
            this.cmbTempManga.FormattingEnabled = true;
            this.cmbTempManga.Location = new System.Drawing.Point(828, 27);
            this.cmbTempManga.Name = "cmbTempManga";
            this.cmbTempManga.Size = new System.Drawing.Size(244, 23);
            this.cmbTempManga.TabIndex = 8;
            // 
            // cmbTempChapter
            // 
            this.cmbTempChapter.FormattingEnabled = true;
            this.cmbTempChapter.Location = new System.Drawing.Point(828, 56);
            this.cmbTempChapter.Name = "cmbTempChapter";
            this.cmbTempChapter.Size = new System.Drawing.Size(244, 23);
            this.cmbTempChapter.TabIndex = 9;
            // 
            // lstBoxTempPage
            // 
            this.lstBoxTempPage.FormattingEnabled = true;
            this.lstBoxTempPage.ItemHeight = 15;
            this.lstBoxTempPage.Location = new System.Drawing.Point(828, 85);
            this.lstBoxTempPage.Name = "lstBoxTempPage";
            this.lstBoxTempPage.Size = new System.Drawing.Size(244, 274);
            this.lstBoxTempPage.TabIndex = 10;
            // 
            // txtBoxTempManga
            // 
            this.txtBoxTempManga.Location = new System.Drawing.Point(412, 396);
            this.txtBoxTempManga.Name = "txtBoxTempManga";
            this.txtBoxTempManga.Size = new System.Drawing.Size(112, 23);
            this.txtBoxTempManga.TabIndex = 11;
            // 
            // btnAddManga
            // 
            this.btnAddManga.AutoSize = true;
            this.btnAddManga.Location = new System.Drawing.Point(412, 365);
            this.btnAddManga.Name = "btnAddManga";
            this.btnAddManga.Size = new System.Drawing.Size(112, 25);
            this.btnAddManga.TabIndex = 12;
            this.btnAddManga.Text = "Ajouter Manga";
            this.btnAddManga.UseVisualStyleBackColor = true;
            // 
            // btnSupManga
            // 
            this.btnSupManga.AutoSize = true;
            this.btnSupManga.Location = new System.Drawing.Point(412, 425);
            this.btnSupManga.Name = "btnSupManga";
            this.btnSupManga.Size = new System.Drawing.Size(112, 25);
            this.btnSupManga.TabIndex = 13;
            this.btnSupManga.Text = "Supprimer Manga";
            this.btnSupManga.UseVisualStyleBackColor = true;
            // 
            // btnAddChapter
            // 
            this.btnAddChapter.AutoSize = true;
            this.btnAddChapter.Location = new System.Drawing.Point(530, 365);
            this.btnAddChapter.Name = "btnAddChapter";
            this.btnAddChapter.Size = new System.Drawing.Size(192, 25);
            this.btnAddChapter.TabIndex = 14;
            this.btnAddChapter.Text = "Ajouter chapitre";
            this.btnAddChapter.UseVisualStyleBackColor = true;
            // 
            // txtBoxTempChapter
            // 
            this.txtBoxTempChapter.Location = new System.Drawing.Point(530, 396);
            this.txtBoxTempChapter.Name = "txtBoxTempChapter";
            this.txtBoxTempChapter.Size = new System.Drawing.Size(192, 23);
            this.txtBoxTempChapter.TabIndex = 15;
            // 
            // btnSupTempChapter
            // 
            this.btnSupTempChapter.Location = new System.Drawing.Point(530, 425);
            this.btnSupTempChapter.Name = "btnSupTempChapter";
            this.btnSupTempChapter.Size = new System.Drawing.Size(192, 23);
            this.btnSupTempChapter.TabIndex = 16;
            this.btnSupTempChapter.Text = "Supprimer Chapitre";
            this.btnSupTempChapter.UseVisualStyleBackColor = true;
            // 
            // btnAddPage
            // 
            this.btnAddPage.AutoSize = true;
            this.btnAddPage.Location = new System.Drawing.Point(728, 365);
            this.btnAddPage.Name = "btnAddPage";
            this.btnAddPage.Size = new System.Drawing.Size(101, 25);
            this.btnAddPage.TabIndex = 17;
            this.btnAddPage.Text = "Ajouter Page";
            this.btnAddPage.UseVisualStyleBackColor = true;
            // 
            // txtBoxTempPage
            // 
            this.txtBoxTempPage.Location = new System.Drawing.Point(728, 396);
            this.txtBoxTempPage.Name = "txtBoxTempPage";
            this.txtBoxTempPage.Size = new System.Drawing.Size(101, 23);
            this.txtBoxTempPage.TabIndex = 18;
            // 
            // btnSupPage
            // 
            this.btnSupPage.AutoSize = true;
            this.btnSupPage.Location = new System.Drawing.Point(728, 424);
            this.btnSupPage.Name = "btnSupPage";
            this.btnSupPage.Size = new System.Drawing.Size(101, 25);
            this.btnSupPage.TabIndex = 19;
            this.btnSupPage.Text = "Supprimer Page";
            this.btnSupPage.UseVisualStyleBackColor = true;
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1084, 672);
            this.Controls.Add(this.btnSupPage);
            this.Controls.Add(this.txtBoxTempPage);
            this.Controls.Add(this.btnAddPage);
            this.Controls.Add(this.btnSupTempChapter);
            this.Controls.Add(this.txtBoxTempChapter);
            this.Controls.Add(this.btnAddChapter);
            this.Controls.Add(this.btnSupManga);
            this.Controls.Add(this.btnAddManga);
            this.Controls.Add(this.txtBoxTempManga);
            this.Controls.Add(this.lstBoxTempPage);
            this.Controls.Add(this.cmbTempChapter);
            this.Controls.Add(this.cmbTempManga);
            this.Controls.Add(this.btnThrashChapter);
            this.Controls.Add(this.btnThrashManga);
            this.Controls.Add(this.lstBoxThrash);
            this.Controls.Add(this.lstBoxPage);
            this.Controls.Add(this.cmbChapter);
            this.Controls.Add(this.cmbManga);
            this.Controls.Add(this.picturePage);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormManage";
            this.Load += new System.EventHandler(this.FormManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturePage)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picturePage;
        private ComboBox cmbManga;
        private ComboBox cmbChapter;
        private ListBox lstBoxPage;
        private ListBox lstBoxThrash;
        private MenuStrip menuStrip;
        private ToolStripMenuItem uploadToolStripMenuItem;
        private Button btnThrashManga;
        private Button btnThrashChapter;
        private ComboBox cmbTempManga;
        private ComboBox cmbTempChapter;
        private ListBox lstBoxTempPage;
        private TextBox txtBoxTempManga;
        private Button btnAddManga;
        private Button btnSupManga;
        private Button btnAddChapter;
        private TextBox txtBoxTempChapter;
        private Button btnSupTempChapter;
        private Button btnAddPage;
        private TextBox txtBoxTempPage;
        private Button btnSupPage;
    }
}