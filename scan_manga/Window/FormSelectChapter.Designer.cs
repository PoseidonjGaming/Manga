namespace scan_manga
{
    partial class FormSelectChapter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectChapter));
            buttonDownload = new Button();
            comboBoxManga = new ComboBox();
            textBoxUrl = new TextBox();
            labelManga = new Label();
            labelChapter = new Label();
            textBoxNameChapter = new TextBox();
            labelNameChapter = new Label();
            cmbSource = new ComboBox();
            lblSource = new Label();
            SuspendLayout();
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(581, 72);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(75, 23);
            buttonDownload.TabIndex = 0;
            buttonDownload.Text = "Télécharger";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // comboBoxManga
            // 
            comboBoxManga.FormattingEnabled = true;
            comboBoxManga.Location = new Point(12, 27);
            comboBoxManga.Name = "comboBoxManga";
            comboBoxManga.Size = new Size(204, 23);
            comboBoxManga.TabIndex = 1;
            comboBoxManga.SelectedIndexChanged += comboBoxManga_SelectedIndexChanged;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(222, 28);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(353, 23);
            textBoxUrl.TabIndex = 2;
            // 
            // labelManga
            // 
            labelManga.AutoSize = true;
            labelManga.Location = new Point(12, 9);
            labelManga.Name = "labelManga";
            labelManga.Size = new Size(112, 15);
            labelManga.TabIndex = 3;
            labelManga.Text = "Sélection du manga";
            // 
            // labelChapter
            // 
            labelChapter.AutoSize = true;
            labelChapter.Location = new Point(222, 9);
            labelChapter.Name = "labelChapter";
            labelChapter.Size = new Size(85, 15);
            labelChapter.TabIndex = 4;
            labelChapter.Text = "Url du chapitre";
            // 
            // textBoxNameChapter
            // 
            textBoxNameChapter.Location = new Point(222, 72);
            textBoxNameChapter.Name = "textBoxNameChapter";
            textBoxNameChapter.Size = new Size(353, 23);
            textBoxNameChapter.TabIndex = 5;
            // 
            // labelNameChapter
            // 
            labelNameChapter.AutoSize = true;
            labelNameChapter.Location = new Point(222, 54);
            labelNameChapter.Name = "labelNameChapter";
            labelNameChapter.Size = new Size(97, 15);
            labelNameChapter.TabIndex = 6;
            labelNameChapter.Text = "Nom du chapitre";
            // 
            // cmbSource
            // 
            cmbSource.FormattingEnabled = true;
            cmbSource.Location = new Point(12, 73);
            cmbSource.Name = "cmbSource";
            cmbSource.Size = new Size(204, 23);
            cmbSource.TabIndex = 7;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(12, 54);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(121, 15);
            lblSource.TabIndex = 8;
            lblSource.Text = "Sélection de la source";
            // 
            // FormSelectChapter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(666, 108);
            Controls.Add(lblSource);
            Controls.Add(cmbSource);
            Controls.Add(labelNameChapter);
            Controls.Add(textBoxNameChapter);
            Controls.Add(labelChapter);
            Controls.Add(labelManga);
            Controls.Add(textBoxUrl);
            Controls.Add(comboBoxManga);
            Controls.Add(buttonDownload);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSelectChapter";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Télécharger un chapitre spécifique";
            Load += FormDownloadOneChapter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDownload;
        private ComboBox comboBoxManga;
        private TextBox textBoxUrl;
        private Label labelManga;
        private Label labelChapter;
        private TextBox textBoxNameChapter;
        private Label labelNameChapter;
        private ComboBox cmbSource;
        private Label lblSource;
    }
}