namespace scan_manga
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            listBoxManga = new ListBox();
            labelNameManga = new Label();
            textBoxNameManga = new TextBox();
            textBoxCh1 = new TextBox();
            labelChapter1 = new Label();
            labelChapter2 = new Label();
            textBoxCh2 = new TextBox();
            buttonRoot = new Button();
            folderBrowserDialogRoot = new FolderBrowserDialog();
            textBoxRoot = new TextBox();
            buttonAdd = new Button();
            buttonSup = new Button();
            buttonNew = new Button();
            buttonClear = new Button();
            SuspendLayout();
            // 
            // listBoxManga
            // 
            listBoxManga.FormattingEnabled = true;
            listBoxManga.ItemHeight = 15;
            listBoxManga.Location = new Point(12, 12);
            listBoxManga.Name = "listBoxManga";
            listBoxManga.Size = new Size(320, 94);
            listBoxManga.TabIndex = 0;
            listBoxManga.SelectedIndexChanged += listBoxManga_SelectedIndexChanged;
            // 
            // labelNameManga
            // 
            labelNameManga.AutoSize = true;
            labelNameManga.Location = new Point(12, 115);
            labelNameManga.Name = "labelNameManga";
            labelNameManga.Size = new Size(77, 15);
            labelNameManga.TabIndex = 1;
            labelNameManga.Text = "Nom manga:";
            // 
            // textBoxNameManga
            // 
            textBoxNameManga.Location = new Point(115, 112);
            textBoxNameManga.Name = "textBoxNameManga";
            textBoxNameManga.Size = new Size(217, 23);
            textBoxNameManga.TabIndex = 2;
            // 
            // textBoxCh1
            // 
            textBoxCh1.Location = new Point(115, 141);
            textBoxCh1.Name = "textBoxCh1";
            textBoxCh1.Size = new Size(217, 23);
            textBoxCh1.TabIndex = 3;
            // 
            // labelChapter1
            // 
            labelChapter1.AutoSize = true;
            labelChapter1.Location = new Point(12, 144);
            labelChapter1.Name = "labelChapter1";
            labelChapter1.Size = new Size(97, 15);
            labelChapter1.TabIndex = 4;
            labelChapter1.Text = "Url du chapitre 1:";
            // 
            // labelChapter2
            // 
            labelChapter2.AutoSize = true;
            labelChapter2.Location = new Point(12, 173);
            labelChapter2.Name = "labelChapter2";
            labelChapter2.Size = new Size(97, 15);
            labelChapter2.TabIndex = 5;
            labelChapter2.Text = "Url du chapitre 2:";
            // 
            // textBoxCh2
            // 
            textBoxCh2.Location = new Point(115, 170);
            textBoxCh2.Name = "textBoxCh2";
            textBoxCh2.Size = new Size(217, 23);
            textBoxCh2.TabIndex = 6;
            // 
            // buttonRoot
            // 
            buttonRoot.Location = new Point(12, 228);
            buttonRoot.Name = "buttonRoot";
            buttonRoot.Size = new Size(97, 23);
            buttonRoot.TabIndex = 7;
            buttonRoot.Text = "Sélection";
            buttonRoot.UseVisualStyleBackColor = true;
            buttonRoot.Click += buttonRoot_Click;
            // 
            // textBoxRoot
            // 
            textBoxRoot.Location = new Point(113, 228);
            textBoxRoot.Name = "textBoxRoot";
            textBoxRoot.ReadOnly = true;
            textBoxRoot.Size = new Size(217, 23);
            textBoxRoot.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 199);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Ajouter";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonSup
            // 
            buttonSup.Location = new Point(255, 199);
            buttonSup.Name = "buttonSup";
            buttonSup.Size = new Size(75, 23);
            buttonSup.TabIndex = 13;
            buttonSup.Text = "Supprimer";
            buttonSup.UseVisualStyleBackColor = true;
            buttonSup.Click += buttonSup_Click;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(93, 199);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 14;
            buttonNew.Text = "Modifier";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonModif_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(174, 199);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 15;
            buttonClear.Text = "Vider";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(344, 263);
            Controls.Add(buttonClear);
            Controls.Add(buttonNew);
            Controls.Add(buttonSup);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxRoot);
            Controls.Add(buttonRoot);
            Controls.Add(textBoxCh2);
            Controls.Add(labelChapter2);
            Controls.Add(labelChapter1);
            Controls.Add(textBoxCh1);
            Controls.Add(textBoxNameManga);
            Controls.Add(labelNameManga);
            Controls.Add(listBoxManga);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxManga;
        private Label labelNameManga;
        private TextBox textBoxNameManga;
        private TextBox textBoxCh1;
        private Label labelChapter1;
        private Label labelChapter2;
        private TextBox textBoxCh2;
        private Button buttonRoot;
        private FolderBrowserDialog folderBrowserDialogRoot;
        private TextBox textBoxRoot;
        private Button buttonAdd;
        private Button buttonSup;
        private Button buttonNew;
        private Button buttonClear;
    }
}