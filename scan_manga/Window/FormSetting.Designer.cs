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
            lstBoxSources = new ListBox();
            btnAddSource = new Button();
            btnRemoveSource = new Button();
            SuspendLayout();
            // 
            // listBoxManga
            // 
            listBoxManga.FormattingEnabled = true;
            listBoxManga.ItemHeight = 15;
            listBoxManga.Location = new Point(14, 13);
            listBoxManga.Name = "listBoxManga";
            listBoxManga.Size = new Size(320, 184);
            listBoxManga.TabIndex = 0;
            listBoxManga.SelectedIndexChanged += listBoxManga_SelectedIndexChanged;
            // 
            // labelNameManga
            // 
            labelNameManga.AutoSize = true;
            labelNameManga.Location = new Point(13, 209);
            labelNameManga.Name = "labelNameManga";
            labelNameManga.Size = new Size(77, 15);
            labelNameManga.TabIndex = 1;
            labelNameManga.Text = "Nom manga:";
            // 
            // textBoxNameManga
            // 
            textBoxNameManga.Location = new Point(116, 206);
            textBoxNameManga.Name = "textBoxNameManga";
            textBoxNameManga.Size = new Size(215, 23);
            textBoxNameManga.TabIndex = 2;
            // 
            // textBoxCh1
            // 
            textBoxCh1.Location = new Point(450, 206);
            textBoxCh1.Name = "textBoxCh1";
            textBoxCh1.Size = new Size(219, 23);
            textBoxCh1.TabIndex = 3;
            // 
            // labelChapter1
            // 
            labelChapter1.AutoSize = true;
            labelChapter1.Location = new Point(337, 210);
            labelChapter1.Name = "labelChapter1";
            labelChapter1.Size = new Size(97, 15);
            labelChapter1.TabIndex = 4;
            labelChapter1.Text = "Url du chapitre 1:";
            // 
            // labelChapter2
            // 
            labelChapter2.AutoSize = true;
            labelChapter2.Location = new Point(336, 235);
            labelChapter2.Name = "labelChapter2";
            labelChapter2.Size = new Size(97, 15);
            labelChapter2.TabIndex = 5;
            labelChapter2.Text = "Url du chapitre 2:";
            // 
            // textBoxCh2
            // 
            textBoxCh2.Location = new Point(450, 232);
            textBoxCh2.Name = "textBoxCh2";
            textBoxCh2.Size = new Size(219, 23);
            textBoxCh2.TabIndex = 6;
            // 
            // buttonRoot
            // 
            buttonRoot.Location = new Point(13, 263);
            buttonRoot.Name = "buttonRoot";
            buttonRoot.Size = new Size(97, 23);
            buttonRoot.TabIndex = 7;
            buttonRoot.Text = "Sélection";
            buttonRoot.UseVisualStyleBackColor = true;
            buttonRoot.Click += buttonRoot_Click;
            // 
            // textBoxRoot
            // 
            textBoxRoot.Location = new Point(116, 263);
            textBoxRoot.Name = "textBoxRoot";
            textBoxRoot.ReadOnly = true;
            textBoxRoot.Size = new Size(217, 23);
            textBoxRoot.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(15, 234);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Ajouter";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonSup
            // 
            buttonSup.Location = new Point(257, 234);
            buttonSup.Name = "buttonSup";
            buttonSup.Size = new Size(75, 23);
            buttonSup.TabIndex = 13;
            buttonSup.Text = "Supprimer";
            buttonSup.UseVisualStyleBackColor = true;
            buttonSup.Click += buttonSup_Click;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(95, 234);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 14;
            buttonNew.Text = "Modifier";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonModif_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(177, 234);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 15;
            buttonClear.Text = "Vider";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // lstBoxSources
            // 
            lstBoxSources.FormattingEnabled = true;
            lstBoxSources.ItemHeight = 15;
            lstBoxSources.Location = new Point(338, 13);
            lstBoxSources.Margin = new Padding(3, 2, 3, 2);
            lstBoxSources.Name = "lstBoxSources";
            lstBoxSources.Size = new Size(331, 184);
            lstBoxSources.TabIndex = 16;
            lstBoxSources.SelectedIndexChanged += lstBoxSources_SelectedIndexChanged;
            // 
            // btnAddSource
            // 
            btnAddSource.Location = new Point(337, 264);
            btnAddSource.Margin = new Padding(3, 2, 3, 2);
            btnAddSource.Name = "btnAddSource";
            btnAddSource.Size = new Size(82, 23);
            btnAddSource.TabIndex = 17;
            btnAddSource.Text = "Ajouter Source";
            btnAddSource.UseVisualStyleBackColor = true;
            btnAddSource.Click += btnAddSource_Click;
            // 
            // btnRemoveSource
            // 
            btnRemoveSource.Location = new Point(425, 264);
            btnRemoveSource.Name = "btnRemoveSource";
            btnRemoveSource.Size = new Size(75, 23);
            btnRemoveSource.TabIndex = 18;
            btnRemoveSource.Text = "Supprimer";
            btnRemoveSource.UseVisualStyleBackColor = true;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(681, 297);
            Controls.Add(btnRemoveSource);
            Controls.Add(btnAddSource);
            Controls.Add(lstBoxSources);
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
        private ListBox lstBoxSources;
        private Button btnAddSource;
        private Button btnRemoveSource;
    }
}