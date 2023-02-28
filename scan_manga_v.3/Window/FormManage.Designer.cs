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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManage));
            picturePage = new PictureBox();
            cmbManga = new ComboBox();
            cmbChapter = new ComboBox();
            lstBoxPage = new ListBox();
            lstBoxThrash = new ListBox();
            btnThrashManga = new Button();
            btnThrashChapter = new Button();
            cmbTempManga = new ComboBox();
            cmbTempChapter = new ComboBox();
            lstBoxTempPage = new ListBox();
            grpBoxAdd = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            cmbAdd = new ComboBox();
            btnAdd = new Button();
            rdBtnAddChapter = new RadioButton();
            rdBtnAddManga = new RadioButton();
            txtBoxValue = new TextBox();
            uploadToolStripMenuItem = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            grpBoxUpdate = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)picturePage).BeginInit();
            grpBoxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // picturePage
            // 
            picturePage.Location = new Point(12, 120);
            picturePage.Margin = new Padding(3, 2, 3, 2);
            picturePage.Name = "picturePage";
            picturePage.Size = new Size(394, 541);
            picturePage.SizeMode = PictureBoxSizeMode.StretchImage;
            picturePage.TabIndex = 0;
            picturePage.TabStop = false;
            // 
            // cmbManga
            // 
            cmbManga.FormattingEnabled = true;
            cmbManga.Location = new Point(412, 120);
            cmbManga.Name = "cmbManga";
            cmbManga.Size = new Size(225, 23);
            cmbManga.TabIndex = 1;
            cmbManga.SelectedIndexChanged += cmbManga_SelectedIndexChanged;
            // 
            // cmbChapter
            // 
            cmbChapter.FormattingEnabled = true;
            cmbChapter.Location = new Point(412, 149);
            cmbChapter.Name = "cmbChapter";
            cmbChapter.Size = new Size(225, 23);
            cmbChapter.TabIndex = 2;
            cmbChapter.SelectedIndexChanged += cmbChapter_SelectedIndexChanged;
            // 
            // lstBoxPage
            // 
            lstBoxPage.FormattingEnabled = true;
            lstBoxPage.ItemHeight = 15;
            lstBoxPage.Location = new Point(412, 178);
            lstBoxPage.Name = "lstBoxPage";
            lstBoxPage.Size = new Size(225, 304);
            lstBoxPage.TabIndex = 3;
            lstBoxPage.SelectedIndexChanged += lstBoxPage_SelectedIndexChanged;
            // 
            // lstBoxThrash
            // 
            lstBoxThrash.FormattingEnabled = true;
            lstBoxThrash.ItemHeight = 15;
            lstBoxThrash.Location = new Point(412, 492);
            lstBoxThrash.Name = "lstBoxThrash";
            lstBoxThrash.Size = new Size(660, 169);
            lstBoxThrash.TabIndex = 4;
            // 
            // btnThrashManga
            // 
            btnThrashManga.AutoSize = true;
            btnThrashManga.Location = new Point(643, 120);
            btnThrashManga.Name = "btnThrashManga";
            btnThrashManga.Size = new Size(179, 25);
            btnThrashManga.TabIndex = 6;
            btnThrashManga.Text = "Mettre le manga à la corbeille";
            btnThrashManga.UseVisualStyleBackColor = true;
            // 
            // btnThrashChapter
            // 
            btnThrashChapter.AutoSize = true;
            btnThrashChapter.Location = new Point(643, 151);
            btnThrashChapter.Name = "btnThrashChapter";
            btnThrashChapter.Size = new Size(179, 25);
            btnThrashChapter.TabIndex = 7;
            btnThrashChapter.Text = "Mettre le chapitre à la corbeille";
            btnThrashChapter.UseVisualStyleBackColor = true;
            // 
            // cmbTempManga
            // 
            cmbTempManga.FormattingEnabled = true;
            cmbTempManga.Location = new Point(828, 124);
            cmbTempManga.Name = "cmbTempManga";
            cmbTempManga.Size = new Size(244, 23);
            cmbTempManga.TabIndex = 8;
            cmbTempManga.SelectedIndexChanged += cmbTempManga_SelectedIndexChanged;
            // 
            // cmbTempChapter
            // 
            cmbTempChapter.FormattingEnabled = true;
            cmbTempChapter.Location = new Point(828, 149);
            cmbTempChapter.Name = "cmbTempChapter";
            cmbTempChapter.Size = new Size(244, 23);
            cmbTempChapter.TabIndex = 9;
            // 
            // lstBoxTempPage
            // 
            lstBoxTempPage.FormattingEnabled = true;
            lstBoxTempPage.ItemHeight = 15;
            lstBoxTempPage.Location = new Point(828, 178);
            lstBoxTempPage.Name = "lstBoxTempPage";
            lstBoxTempPage.Size = new Size(244, 304);
            lstBoxTempPage.TabIndex = 10;
            // 
            // grpBoxAdd
            // 
            grpBoxAdd.Controls.Add(numericUpDown1);
            grpBoxAdd.Controls.Add(cmbAdd);
            grpBoxAdd.Controls.Add(btnAdd);
            grpBoxAdd.Controls.Add(rdBtnAddChapter);
            grpBoxAdd.Controls.Add(rdBtnAddManga);
            grpBoxAdd.Controls.Add(txtBoxValue);
            grpBoxAdd.Location = new Point(205, 27);
            grpBoxAdd.Name = "grpBoxAdd";
            grpBoxAdd.Size = new Size(377, 87);
            grpBoxAdd.TabIndex = 11;
            grpBoxAdd.TabStop = false;
            grpBoxAdd.Text = "Ajouter";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(250, 47);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(38, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbAdd
            // 
            cmbAdd.Enabled = false;
            cmbAdd.FormattingEnabled = true;
            cmbAdd.Location = new Point(6, 47);
            cmbAdd.Name = "cmbAdd";
            cmbAdd.Size = new Size(238, 23);
            cmbAdd.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(294, 45);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(77, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Ajouter";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // rdBtnAddChapter
            // 
            rdBtnAddChapter.AutoSize = true;
            rdBtnAddChapter.CheckAlign = ContentAlignment.MiddleRight;
            rdBtnAddChapter.Location = new Point(74, 22);
            rdBtnAddChapter.Name = "rdBtnAddChapter";
            rdBtnAddChapter.Size = new Size(70, 19);
            rdBtnAddChapter.TabIndex = 2;
            rdBtnAddChapter.Text = "Chapitre";
            rdBtnAddChapter.UseVisualStyleBackColor = true;
            rdBtnAddChapter.CheckedChanged += rdButtonChapter_CheckedChanged;
            // 
            // rdBtnAddManga
            // 
            rdBtnAddManga.AutoSize = true;
            rdBtnAddManga.CheckAlign = ContentAlignment.MiddleRight;
            rdBtnAddManga.Checked = true;
            rdBtnAddManga.Location = new Point(6, 22);
            rdBtnAddManga.Name = "rdBtnAddManga";
            rdBtnAddManga.Size = new Size(62, 19);
            rdBtnAddManga.TabIndex = 1;
            rdBtnAddManga.TabStop = true;
            rdBtnAddManga.Text = "Manga";
            rdBtnAddManga.UseVisualStyleBackColor = true;
            // 
            // txtBoxValue
            // 
            txtBoxValue.Location = new Point(150, 18);
            txtBoxValue.Name = "txtBoxValue";
            txtBoxValue.Size = new Size(221, 23);
            txtBoxValue.TabIndex = 0;
            // 
            // uploadToolStripMenuItem
            // 
            uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            uploadToolStripMenuItem.Size = new Size(57, 20);
            uploadToolStripMenuItem.Text = "Upload";
            uploadToolStripMenuItem.Click += uploadToolStripMenuItem_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { uploadToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1084, 24);
            menuStrip.TabIndex = 5;
            menuStrip.Text = "menuStrip1";
            // 
            // grpBoxUpdate
            // 
            grpBoxUpdate.Location = new Point(588, 27);
            grpBoxUpdate.Name = "grpBoxUpdate";
            grpBoxUpdate.Size = new Size(410, 87);
            grpBoxUpdate.TabIndex = 12;
            grpBoxUpdate.TabStop = false;
            grpBoxUpdate.Text = "Modifier/Supprimer";
            // 
            // FormManage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1084, 672);
            Controls.Add(grpBoxUpdate);
            Controls.Add(grpBoxAdd);
            Controls.Add(lstBoxTempPage);
            Controls.Add(cmbTempChapter);
            Controls.Add(cmbTempManga);
            Controls.Add(btnThrashChapter);
            Controls.Add(btnThrashManga);
            Controls.Add(lstBoxThrash);
            Controls.Add(lstBoxPage);
            Controls.Add(cmbChapter);
            Controls.Add(cmbManga);
            Controls.Add(picturePage);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormManage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormManage";
            Load += FormManage_Load;
            ((System.ComponentModel.ISupportInitialize)picturePage).EndInit();
            grpBoxAdd.ResumeLayout(false);
            grpBoxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private RadioButton rdBtnAddChapter;
        private RadioButton rdBtnAddManga;
        private TextBox txtBoxValue;
        private ToolStripMenuItem uploadToolStripMenuItem;
        private MenuStrip menuStrip;
        private NumericUpDown numericUpDown1;
        private GroupBox grpBoxUpdate;
    }
}