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
            this.listBoxManga = new System.Windows.Forms.ListBox();
            this.labelNameManga = new System.Windows.Forms.Label();
            this.textBoxNameManga = new System.Windows.Forms.TextBox();
            this.textBoxCh1 = new System.Windows.Forms.TextBox();
            this.labelChapter1 = new System.Windows.Forms.Label();
            this.labelChapter2 = new System.Windows.Forms.Label();
            this.textBoxCh2 = new System.Windows.Forms.TextBox();
            this.buttonRoot = new System.Windows.Forms.Button();
            this.folderBrowserDialogRoot = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxRoot = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSup = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelToRemove = new System.Windows.Forms.Label();
            this.textBoxToRemove = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxManga
            // 
            this.listBoxManga.FormattingEnabled = true;
            this.listBoxManga.ItemHeight = 15;
            this.listBoxManga.Location = new System.Drawing.Point(12, 12);
            this.listBoxManga.Name = "listBoxManga";
            this.listBoxManga.Size = new System.Drawing.Size(320, 94);
            this.listBoxManga.TabIndex = 0;
            this.listBoxManga.SelectedIndexChanged += new System.EventHandler(this.listBoxManga_SelectedIndexChanged);
            // 
            // labelNameManga
            // 
            this.labelNameManga.AutoSize = true;
            this.labelNameManga.Location = new System.Drawing.Point(12, 115);
            this.labelNameManga.Name = "labelNameManga";
            this.labelNameManga.Size = new System.Drawing.Size(77, 15);
            this.labelNameManga.TabIndex = 1;
            this.labelNameManga.Text = "Nom manga:";
            // 
            // textBoxNameManga
            // 
            this.textBoxNameManga.Location = new System.Drawing.Point(115, 112);
            this.textBoxNameManga.Name = "textBoxNameManga";
            this.textBoxNameManga.Size = new System.Drawing.Size(217, 23);
            this.textBoxNameManga.TabIndex = 2;
            // 
            // textBoxCh1
            // 
            this.textBoxCh1.Location = new System.Drawing.Point(115, 141);
            this.textBoxCh1.Name = "textBoxCh1";
            this.textBoxCh1.Size = new System.Drawing.Size(217, 23);
            this.textBoxCh1.TabIndex = 3;
            // 
            // labelChapter1
            // 
            this.labelChapter1.AutoSize = true;
            this.labelChapter1.Location = new System.Drawing.Point(12, 144);
            this.labelChapter1.Name = "labelChapter1";
            this.labelChapter1.Size = new System.Drawing.Size(97, 15);
            this.labelChapter1.TabIndex = 4;
            this.labelChapter1.Text = "Url du chapitre 1:";
            // 
            // labelChapter2
            // 
            this.labelChapter2.AutoSize = true;
            this.labelChapter2.Location = new System.Drawing.Point(12, 173);
            this.labelChapter2.Name = "labelChapter2";
            this.labelChapter2.Size = new System.Drawing.Size(97, 15);
            this.labelChapter2.TabIndex = 5;
            this.labelChapter2.Text = "Url du chapitre 2:";
            // 
            // textBoxCh2
            // 
            this.textBoxCh2.Location = new System.Drawing.Point(115, 170);
            this.textBoxCh2.Name = "textBoxCh2";
            this.textBoxCh2.Size = new System.Drawing.Size(217, 23);
            this.textBoxCh2.TabIndex = 6;
            // 
            // buttonRoot
            // 
            this.buttonRoot.Location = new System.Drawing.Point(12, 257);
            this.buttonRoot.Name = "buttonRoot";
            this.buttonRoot.Size = new System.Drawing.Size(97, 23);
            this.buttonRoot.TabIndex = 7;
            this.buttonRoot.Text = "Sélection";
            this.buttonRoot.UseVisualStyleBackColor = true;
            this.buttonRoot.Click += new System.EventHandler(this.buttonRoot_Click);
            // 
            // textBoxRoot
            // 
            this.textBoxRoot.Location = new System.Drawing.Point(113, 257);
            this.textBoxRoot.Name = "textBoxRoot";
            this.textBoxRoot.ReadOnly = true;
            this.textBoxRoot.Size = new System.Drawing.Size(217, 23);
            this.textBoxRoot.TabIndex = 8;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 228);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Ajouter";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSup
            // 
            this.buttonSup.Location = new System.Drawing.Point(255, 228);
            this.buttonSup.Name = "buttonSup";
            this.buttonSup.Size = new System.Drawing.Size(75, 23);
            this.buttonSup.TabIndex = 13;
            this.buttonSup.Text = "Supprimer";
            this.buttonSup.UseVisualStyleBackColor = true;
            this.buttonSup.Click += new System.EventHandler(this.buttonSup_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(93, 228);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 14;
            this.buttonNew.Text = "Modifier";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonModif_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(174, 228);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 15;
            this.buttonClear.Text = "Vider";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelToRemove
            // 
            this.labelToRemove.AutoSize = true;
            this.labelToRemove.Location = new System.Drawing.Point(12, 202);
            this.labelToRemove.Name = "labelToRemove";
            this.labelToRemove.Size = new System.Drawing.Size(93, 15);
            this.labelToRemove.TabIndex = 16;
            this.labelToRemove.Text = "Chaine à retirer: ";
            // 
            // textBoxToRemove
            // 
            this.textBoxToRemove.Location = new System.Drawing.Point(116, 199);
            this.textBoxToRemove.Name = "textBoxToRemove";
            this.textBoxToRemove.Size = new System.Drawing.Size(216, 23);
            this.textBoxToRemove.TabIndex = 17;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 291);
            this.Controls.Add(this.textBoxToRemove);
            this.Controls.Add(this.labelToRemove);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.buttonSup);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxRoot);
            this.Controls.Add(this.buttonRoot);
            this.Controls.Add(this.textBoxCh2);
            this.Controls.Add(this.labelChapter2);
            this.Controls.Add(this.labelChapter1);
            this.Controls.Add(this.textBoxCh1);
            this.Controls.Add(this.textBoxNameManga);
            this.Controls.Add(this.labelNameManga);
            this.Controls.Add(this.listBoxManga);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label labelToRemove;
        private TextBox textBoxToRemove;
    }
}