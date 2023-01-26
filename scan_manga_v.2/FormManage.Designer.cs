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
            this.listBoxPage = new System.Windows.Forms.ListBox();
            this.pictureBoxPage = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.comboBoxManga = new System.Windows.Forms.ComboBox();
            this.listBoxNew = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSup = new System.Windows.Forms.Button();
            this.comboBoxChapter = new System.Windows.Forms.ComboBox();
            this.listBoxNewChapter = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxPage
            // 
            this.listBoxPage.FormattingEnabled = true;
            this.listBoxPage.ItemHeight = 15;
            this.listBoxPage.Location = new System.Drawing.Point(457, 41);
            this.listBoxPage.Name = "listBoxPage";
            this.listBoxPage.Size = new System.Drawing.Size(208, 244);
            this.listBoxPage.TabIndex = 0;
            this.listBoxPage.SelectedIndexChanged += new System.EventHandler(this.listBoxPage_SelectedIndexChanged);
            // 
            // pictureBoxPage
            // 
            this.pictureBoxPage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxPage.Name = "pictureBoxPage";
            this.pictureBoxPage.Size = new System.Drawing.Size(435, 592);
            this.pictureBoxPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPage.TabIndex = 1;
            this.pictureBoxPage.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(538, 289);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 23);
            this.textBox1.TabIndex = 2;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(457, 289);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 3;
            this.buttonNew.Text = "Nouveau";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // comboBoxManga
            // 
            this.comboBoxManga.FormattingEnabled = true;
            this.comboBoxManga.Location = new System.Drawing.Point(457, 12);
            this.comboBoxManga.Name = "comboBoxManga";
            this.comboBoxManga.Size = new System.Drawing.Size(208, 23);
            this.comboBoxManga.TabIndex = 4;
            this.comboBoxManga.SelectedIndexChanged += new System.EventHandler(this.comboBoxManga_SelectedIndexChanged);
            // 
            // listBoxNew
            // 
            this.listBoxNew.FormattingEnabled = true;
            this.listBoxNew.ItemHeight = 15;
            this.listBoxNew.Location = new System.Drawing.Point(671, 41);
            this.listBoxNew.Name = "listBoxNew";
            this.listBoxNew.Size = new System.Drawing.Size(268, 244);
            this.listBoxNew.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(671, 291);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Ajouter";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSup
            // 
            this.buttonSup.Location = new System.Drawing.Point(752, 291);
            this.buttonSup.Name = "buttonSup";
            this.buttonSup.Size = new System.Drawing.Size(75, 23);
            this.buttonSup.TabIndex = 7;
            this.buttonSup.Text = "Supprimer";
            this.buttonSup.UseVisualStyleBackColor = true;
            // 
            // comboBoxChapter
            // 
            this.comboBoxChapter.FormattingEnabled = true;
            this.comboBoxChapter.Location = new System.Drawing.Point(671, 12);
            this.comboBoxChapter.Name = "comboBoxChapter";
            this.comboBoxChapter.Size = new System.Drawing.Size(268, 23);
            this.comboBoxChapter.TabIndex = 8;
            this.comboBoxChapter.SelectedIndexChanged += new System.EventHandler(this.comboBoxChapter_SelectedIndexChanged);
            // 
            // listBoxNewChapter
            // 
            this.listBoxNewChapter.FormattingEnabled = true;
            this.listBoxNewChapter.ItemHeight = 15;
            this.listBoxNewChapter.Location = new System.Drawing.Point(457, 319);
            this.listBoxNewChapter.Name = "listBoxNewChapter";
            this.listBoxNewChapter.Size = new System.Drawing.Size(482, 124);
            this.listBoxNewChapter.TabIndex = 9;
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 616);
            this.Controls.Add(this.listBoxNewChapter);
            this.Controls.Add(this.comboBoxChapter);
            this.Controls.Add(this.buttonSup);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxNew);
            this.Controls.Add(this.comboBoxManga);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBoxPage);
            this.Controls.Add(this.listBoxPage);
            this.Name = "FormManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormManage_FormClosed);
            this.Load += new System.EventHandler(this.FormManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBoxPage;
        private PictureBox pictureBoxPage;
        private TextBox textBox1;
        private Button buttonNew;
        private ComboBox comboBoxManga;
        private ListBox listBoxNew;
        private Button buttonAdd;
        private Button buttonSup;
        private ComboBox comboBoxChapter;
        private ListBox listBoxNewChapter;
    }
}