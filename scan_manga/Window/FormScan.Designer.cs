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
            cmbSource = new ComboBox();
            btnScan = new Button();
            lblSource = new Label();
            SuspendLayout();
            // 
            // cmbSource
            // 
            cmbSource.FormattingEnabled = true;
            cmbSource.Location = new Point(12, 26);
            cmbSource.Margin = new Padding(3, 2, 3, 2);
            cmbSource.Name = "cmbSource";
            cmbSource.Size = new Size(350, 23);
            cmbSource.TabIndex = 1;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(368, 27);
            btnScan.Margin = new Padding(3, 2, 3, 2);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(82, 22);
            btnScan.TabIndex = 2;
            btnScan.Text = "Scanner";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(12, 9);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(121, 15);
            lblSource.TabIndex = 3;
            lblSource.Text = "Sélection de la source";
            // 
            // FormScan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 61);
            Controls.Add(lblSource);
            Controls.Add(btnScan);
            Controls.Add(cmbSource);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormScan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormScan";
            Load += FormScan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbSource;
        private Button btnScan;
        private Label lblSource;
    }
}