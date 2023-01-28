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
            this.buttonDownload = new System.Windows.Forms.Button();
            this.comboBoxManga = new System.Windows.Forms.ComboBox();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.labelManga = new System.Windows.Forms.Label();
            this.labelChapter = new System.Windows.Forms.Label();
            this.textBoxNameChapter = new System.Windows.Forms.TextBox();
            this.labelNameChapter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(852, 27);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Télécharger";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // comboBoxManga
            // 
            this.comboBoxManga.FormattingEnabled = true;
            this.comboBoxManga.Location = new System.Drawing.Point(12, 27);
            this.comboBoxManga.Name = "comboBoxManga";
            this.comboBoxManga.Size = new System.Drawing.Size(204, 23);
            this.comboBoxManga.TabIndex = 1;
            this.comboBoxManga.SelectedIndexChanged += new System.EventHandler(this.comboBoxManga_SelectedIndexChanged);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(222, 27);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(353, 23);
            this.textBoxUrl.TabIndex = 2;
            // 
            // labelManga
            // 
            this.labelManga.AutoSize = true;
            this.labelManga.Location = new System.Drawing.Point(12, 9);
            this.labelManga.Name = "labelManga";
            this.labelManga.Size = new System.Drawing.Size(112, 15);
            this.labelManga.TabIndex = 3;
            this.labelManga.Text = "Sélection du manga";
            // 
            // labelChapter
            // 
            this.labelChapter.AutoSize = true;
            this.labelChapter.Location = new System.Drawing.Point(222, 9);
            this.labelChapter.Name = "labelChapter";
            this.labelChapter.Size = new System.Drawing.Size(85, 15);
            this.labelChapter.TabIndex = 4;
            this.labelChapter.Text = "Url du chapitre";
            // 
            // textBoxNameChapter
            // 
            this.textBoxNameChapter.Location = new System.Drawing.Point(581, 27);
            this.textBoxNameChapter.Name = "textBoxNameChapter";
            this.textBoxNameChapter.Size = new System.Drawing.Size(265, 23);
            this.textBoxNameChapter.TabIndex = 5;
            // 
            // labelNameChapter
            // 
            this.labelNameChapter.AutoSize = true;
            this.labelNameChapter.Location = new System.Drawing.Point(581, 9);
            this.labelNameChapter.Name = "labelNameChapter";
            this.labelNameChapter.Size = new System.Drawing.Size(97, 15);
            this.labelNameChapter.TabIndex = 6;
            this.labelNameChapter.Text = "Nom du chapitre";
            // 
            // FormSelectChapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(938, 68);
            this.Controls.Add(this.labelNameChapter);
            this.Controls.Add(this.textBoxNameChapter);
            this.Controls.Add(this.labelChapter);
            this.Controls.Add(this.labelManga);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.comboBoxManga);
            this.Controls.Add(this.buttonDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectChapter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Télécharger un chapitre spécifique";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDownloadOneChapter_FormClosed);
            this.Load += new System.EventHandler(this.FormDownloadOneChapter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonDownload;
        private ComboBox comboBoxManga;
        private TextBox textBoxUrl;
        private Label labelManga;
        private Label labelChapter;
        private TextBox textBoxNameChapter;
        private Label labelNameChapter;
    }
}