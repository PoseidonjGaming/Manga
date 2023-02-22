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
            this.btnThrashManga = new System.Windows.Forms.Button();
            this.btnThrashChapter = new System.Windows.Forms.Button();
            this.cmbTempManga = new System.Windows.Forms.ComboBox();
            this.cmbTempChapter = new System.Windows.Forms.ComboBox();
            this.lstBoxTempPage = new System.Windows.Forms.ListBox();
            this.grpBoxAdd = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cmbAdd = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rdButtonChapter = new System.Windows.Forms.RadioButton();
            this.rdButtonManga = new System.Windows.Forms.RadioButton();
            this.txtBoxValue = new System.Windows.Forms.TextBox();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.grpBoxUpdate = new System.Windows.Forms.GroupBox();
            this.rdButtonChapterUpdate = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picturePage)).BeginInit();
            this.grpBoxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.grpBoxUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // picturePage
            // 
            this.picturePage.Location = new System.Drawing.Point(12, 120);
            this.picturePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturePage.Name = "picturePage";
            this.picturePage.Size = new System.Drawing.Size(394, 533);
            this.picturePage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePage.TabIndex = 0;
            this.picturePage.TabStop = false;
            // 
            // cmbManga
            // 
            this.cmbManga.FormattingEnabled = true;
            this.cmbManga.Location = new System.Drawing.Point(412, 120);
            this.cmbManga.Name = "cmbManga";
            this.cmbManga.Size = new System.Drawing.Size(225, 23);
            this.cmbManga.TabIndex = 1;
            this.cmbManga.SelectedIndexChanged += new System.EventHandler(this.cmbManga_SelectedIndexChanged);
            // 
            // cmbChapter
            // 
            this.cmbChapter.FormattingEnabled = true;
            this.cmbChapter.Location = new System.Drawing.Point(412, 149);
            this.cmbChapter.Name = "cmbChapter";
            this.cmbChapter.Size = new System.Drawing.Size(225, 23);
            this.cmbChapter.TabIndex = 2;
            this.cmbChapter.SelectedIndexChanged += new System.EventHandler(this.cmbChapter_SelectedIndexChanged);
            // 
            // lstBoxPage
            // 
            this.lstBoxPage.FormattingEnabled = true;
            this.lstBoxPage.ItemHeight = 15;
            this.lstBoxPage.Location = new System.Drawing.Point(412, 178);
            this.lstBoxPage.Name = "lstBoxPage";
            this.lstBoxPage.Size = new System.Drawing.Size(225, 304);
            this.lstBoxPage.TabIndex = 3;
            this.lstBoxPage.SelectedIndexChanged += new System.EventHandler(this.lstBoxPage_SelectedIndexChanged);
            // 
            // lstBoxThrash
            // 
            this.lstBoxThrash.FormattingEnabled = true;
            this.lstBoxThrash.ItemHeight = 15;
            this.lstBoxThrash.Location = new System.Drawing.Point(412, 484);
            this.lstBoxThrash.Name = "lstBoxThrash";
            this.lstBoxThrash.Size = new System.Drawing.Size(660, 169);
            this.lstBoxThrash.TabIndex = 4;
            // 
            // btnThrashManga
            // 
            this.btnThrashManga.AutoSize = true;
            this.btnThrashManga.Location = new System.Drawing.Point(643, 120);
            this.btnThrashManga.Name = "btnThrashManga";
            this.btnThrashManga.Size = new System.Drawing.Size(179, 25);
            this.btnThrashManga.TabIndex = 6;
            this.btnThrashManga.Text = "Mettre le manga à la corbeille";
            this.btnThrashManga.UseVisualStyleBackColor = true;
            // 
            // btnThrashChapter
            // 
            this.btnThrashChapter.AutoSize = true;
            this.btnThrashChapter.Location = new System.Drawing.Point(643, 151);
            this.btnThrashChapter.Name = "btnThrashChapter";
            this.btnThrashChapter.Size = new System.Drawing.Size(179, 25);
            this.btnThrashChapter.TabIndex = 7;
            this.btnThrashChapter.Text = "Mettre le chapitre à la corbeille";
            this.btnThrashChapter.UseVisualStyleBackColor = true;
            // 
            // cmbTempManga
            // 
            this.cmbTempManga.FormattingEnabled = true;
            this.cmbTempManga.Location = new System.Drawing.Point(828, 120);
            this.cmbTempManga.Name = "cmbTempManga";
            this.cmbTempManga.Size = new System.Drawing.Size(244, 23);
            this.cmbTempManga.TabIndex = 8;
            this.cmbTempManga.SelectedIndexChanged += new System.EventHandler(this.cmbTempManga_SelectedIndexChanged);
            // 
            // cmbTempChapter
            // 
            this.cmbTempChapter.FormattingEnabled = true;
            this.cmbTempChapter.Location = new System.Drawing.Point(828, 153);
            this.cmbTempChapter.Name = "cmbTempChapter";
            this.cmbTempChapter.Size = new System.Drawing.Size(244, 23);
            this.cmbTempChapter.TabIndex = 9;
            // 
            // lstBoxTempPage
            // 
            this.lstBoxTempPage.FormattingEnabled = true;
            this.lstBoxTempPage.ItemHeight = 15;
            this.lstBoxTempPage.Location = new System.Drawing.Point(828, 182);
            this.lstBoxTempPage.Name = "lstBoxTempPage";
            this.lstBoxTempPage.Size = new System.Drawing.Size(244, 304);
            this.lstBoxTempPage.TabIndex = 10;
            // 
            // grpBoxAdd
            // 
            this.grpBoxAdd.Controls.Add(this.numericUpDown1);
            this.grpBoxAdd.Controls.Add(this.cmbAdd);
            this.grpBoxAdd.Controls.Add(this.btnAdd);
            this.grpBoxAdd.Controls.Add(this.rdButtonChapter);
            this.grpBoxAdd.Controls.Add(this.rdButtonManga);
            this.grpBoxAdd.Controls.Add(this.txtBoxValue);
            this.grpBoxAdd.Location = new System.Drawing.Point(205, 27);
            this.grpBoxAdd.Name = "grpBoxAdd";
            this.grpBoxAdd.Size = new System.Drawing.Size(377, 87);
            this.grpBoxAdd.TabIndex = 11;
            this.grpBoxAdd.TabStop = false;
            this.grpBoxAdd.Text = "Ajouter";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(250, 47);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 23);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbAdd
            // 
            this.cmbAdd.Enabled = false;
            this.cmbAdd.FormattingEnabled = true;
            this.cmbAdd.Location = new System.Drawing.Point(6, 47);
            this.cmbAdd.Name = "cmbAdd";
            this.cmbAdd.Size = new System.Drawing.Size(238, 23);
            this.cmbAdd.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(294, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rdButtonChapter
            // 
            this.rdButtonChapter.AutoSize = true;
            this.rdButtonChapter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdButtonChapter.Location = new System.Drawing.Point(74, 22);
            this.rdButtonChapter.Name = "rdButtonChapter";
            this.rdButtonChapter.Size = new System.Drawing.Size(70, 19);
            this.rdButtonChapter.TabIndex = 2;
            this.rdButtonChapter.Text = "Chapitre";
            this.rdButtonChapter.UseVisualStyleBackColor = true;
            this.rdButtonChapter.CheckedChanged += new System.EventHandler(this.rdButtonChapter_CheckedChanged);
            // 
            // rdButtonManga
            // 
            this.rdButtonManga.AutoSize = true;
            this.rdButtonManga.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdButtonManga.Checked = true;
            this.rdButtonManga.Location = new System.Drawing.Point(6, 22);
            this.rdButtonManga.Name = "rdButtonManga";
            this.rdButtonManga.Size = new System.Drawing.Size(62, 19);
            this.rdButtonManga.TabIndex = 1;
            this.rdButtonManga.TabStop = true;
            this.rdButtonManga.Text = "Manga";
            this.rdButtonManga.UseVisualStyleBackColor = true;
            // 
            // txtBoxValue
            // 
            this.txtBoxValue.Location = new System.Drawing.Point(150, 18);
            this.txtBoxValue.Name = "txtBoxValue";
            this.txtBoxValue.Size = new System.Drawing.Size(221, 23);
            this.txtBoxValue.TabIndex = 0;
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
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
            // grpBoxUpdate
            // 
            this.grpBoxUpdate.Controls.Add(this.rdButtonChapterUpdate);
            this.grpBoxUpdate.Location = new System.Drawing.Point(588, 27);
            this.grpBoxUpdate.Name = "grpBoxUpdate";
            this.grpBoxUpdate.Size = new System.Drawing.Size(344, 87);
            this.grpBoxUpdate.TabIndex = 12;
            this.grpBoxUpdate.TabStop = false;
            this.grpBoxUpdate.Text = "Modifier";
            // 
            // rdButtonChapterUpdate
            // 
            this.rdButtonChapterUpdate.AutoSize = true;
            this.rdButtonChapterUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdButtonChapterUpdate.Location = new System.Drawing.Point(6, 22);
            this.rdButtonChapterUpdate.Name = "rdButtonChapterUpdate";
            this.rdButtonChapterUpdate.Size = new System.Drawing.Size(70, 19);
            this.rdButtonChapterUpdate.TabIndex = 0;
            this.rdButtonChapterUpdate.TabStop = true;
            this.rdButtonChapterUpdate.Text = "Chapitre";
            this.rdButtonChapterUpdate.UseVisualStyleBackColor = true;
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1084, 672);
            this.Controls.Add(this.grpBoxUpdate);
            this.Controls.Add(this.grpBoxAdd);
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
            this.grpBoxAdd.ResumeLayout(false);
            this.grpBoxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpBoxUpdate.ResumeLayout(false);
            this.grpBoxUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picturePage;
        private ComboBox cmbManga;
        private ComboBox cmbChapter;
        private ListBox lstBoxPage;
        private ListBox lstBoxThrash;
        private Button btnThrashManga;
        private Button btnThrashChapter;
        private ComboBox cmbTempManga;
        private ComboBox cmbTempChapter;
        private ListBox lstBoxTempPage;
        private GroupBox grpBoxAdd;
        private ComboBox cmbAdd;
        private Button btnAdd;
        private RadioButton rdButtonChapter;
        private RadioButton rdButtonManga;
        private TextBox txtBoxValue;
        private ToolStripMenuItem uploadToolStripMenuItem;
        private MenuStrip menuStrip;
        private NumericUpDown numericUpDown1;
        private GroupBox grpBoxUpdate;
        private RadioButton rdButtonChapterUpdate;
    }
}