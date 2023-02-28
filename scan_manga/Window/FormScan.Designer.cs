namespace scan_manga.Window
{
    partial class FormScan
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
            cmbManga = new ComboBox();
            cmbSource = new ComboBox();
            btnScan = new Button();
            SuspendLayout();
            // 
            // cmbManga
            // 
            cmbManga.FormattingEnabled = true;
            cmbManga.Location = new Point(12, 12);
            cmbManga.Name = "cmbManga";
            cmbManga.Size = new Size(200, 28);
            cmbManga.TabIndex = 0;
            // 
            // cmbSource
            // 
            cmbSource.FormattingEnabled = true;
            cmbSource.Location = new Point(218, 12);
            cmbSource.Name = "cmbSource";
            cmbSource.Size = new Size(400, 28);
            cmbSource.TabIndex = 1;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(624, 11);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(94, 29);
            btnScan.TabIndex = 2;
            btnScan.Text = "Scanner";
            btnScan.UseVisualStyleBackColor = true;
            // 
            // FormScan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 53);
            Controls.Add(btnScan);
            Controls.Add(cmbSource);
            Controls.Add(cmbManga);
            Name = "FormScan";
            Text = "FormScan";
            Load += FormScan_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbManga;
        private ComboBox cmbSource;
        private Button btnScan;
    }
}