namespace scan_manga
{
    partial class FormProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgress));
            progressBarPage = new ProgressBar();
            labelPage = new Label();
            labelChapter = new Label();
            progressBarChapter = new ProgressBar();
            labelManga = new Label();
            progressBarManga = new ProgressBar();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // progressBarPage
            // 
            progressBarPage.Location = new Point(12, 27);
            progressBarPage.Name = "progressBarPage";
            progressBarPage.Size = new Size(360, 23);
            progressBarPage.TabIndex = 0;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Location = new Point(12, 9);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(36, 15);
            labelPage.TabIndex = 1;
            labelPage.Text = "Page:";
            // 
            // labelChapter
            // 
            labelChapter.AutoSize = true;
            labelChapter.Location = new Point(12, 53);
            labelChapter.Name = "labelChapter";
            labelChapter.Size = new Size(55, 15);
            labelChapter.TabIndex = 2;
            labelChapter.Text = "Chapitre:";
            // 
            // progressBarChapter
            // 
            progressBarChapter.Location = new Point(12, 71);
            progressBarChapter.Name = "progressBarChapter";
            progressBarChapter.Size = new Size(360, 23);
            progressBarChapter.TabIndex = 3;
            // 
            // labelManga
            // 
            labelManga.AutoSize = true;
            labelManga.Location = new Point(12, 97);
            labelManga.Name = "labelManga";
            labelManga.Size = new Size(47, 15);
            labelManga.TabIndex = 4;
            labelManga.Text = "Manga:";
            // 
            // progressBarManga
            // 
            progressBarManga.Location = new Point(12, 115);
            progressBarManga.Name = "progressBarManga";
            progressBarManga.Size = new Size(360, 23);
            progressBarManga.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 144);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormProgress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(384, 178);
            Controls.Add(btnCancel);
            Controls.Add(progressBarManga);
            Controls.Add(labelManga);
            Controls.Add(progressBarChapter);
            Controls.Add(labelChapter);
            Controls.Add(labelPage);
            Controls.Add(progressBarPage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormProgress";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Archive";
            Load += FormArchive_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBarPage;
        private Label labelPage;
        private Label labelChapter;
        private ProgressBar progressBarChapter;
        private Label labelManga;
        private ProgressBar progressBarManga;
        private Button btnCancel;
    }
}