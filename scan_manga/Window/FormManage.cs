using scan_manga.Models;
using scan_manga.Utilities;
using System.Data;

namespace scan_manga
{
    public partial class FormManage : Form
    {
        private List<Manga> mangas;
        public List<string> thrash;
        public List<Manga> newManga;
        private readonly string Root;
        private readonly MangaUtility utility;

        public FormManage()
        {
            InitializeComponent();
            Root = Properties.Settings.Default.Root;
            thrash = new();
            utility = new();
            newManga = new();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Manga != null)
            {
                mangas = Properties.Settings.Default.Manga;
            }

            foreach (Manga manga in mangas)
            {
                manga.Chapters.Clear();
                cmbManga.Items.Add(manga.Nom);
            }
            if (cmbManga.Items.Count > 0)
            {
                cmbManga.SelectedIndex = 0;
            }

        }

        private void cmbManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbManga.SelectedIndex != -1)
            {
                cmbChapter.Items.Clear();

                foreach (string chapter in utility.Sort(Directory.GetDirectories(utility.GetPath(Root, "Manga", cmbManga.Text)).ToList(), " Chapitre ", cmbManga.Text + " Chapitre ", false))
                {
                    cmbChapter.Items.Add(Path.GetFileName(chapter));
                }

                if (cmbChapter.Items.Count > 0)
                {
                    cmbChapter.SelectedIndex = 0;
                }
            }
        }

        private void cmbChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedIndex != -1)
            {
                txtBoxNewChapter.Text = cmbChapter.Text;
                lstBoxPage.Items.Clear();
                string dir = utility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text);
                foreach (string page in utility.Sort(Directory.GetFiles(dir).ToList(), "_", "page ", true))
                {
                    lstBoxPage.Items.Add(page);
                }
            }
        }
        private void lstBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxPage.SelectedIndex != -1)
            {
                string[] pages = Directory.GetFiles(utility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text));
                pictureBoxPage.ImageLocation = pages.Where(e => Path.GetFileNameWithoutExtension(e).Replace('_', ' ') == lstBoxPage.SelectedItem.ToString()).First();
            }
        }

        private void btnSuppChapter_Click(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedIndex != -1)
            {
                thrash.Add(cmbChapter.Text);
                PopulateThrash();
            }
        }

        private void PopulateThrash()
        {
            lstBoxThrash.Items.Clear();
            lstBoxThrash.Items.AddRange(utility.Sort(thrash, " Chapitre ", cmbManga.Text + " Chapitre ", false));
        }

        private void btnSuppManga_Click(object sender, EventArgs e)
        {
            foreach (string chapter in Directory.GetDirectories(utility.GetPath(Root, "Manga", cmbManga.Text)))
            {
                thrash.Add(Path.GetFileName(chapter));
            }
            PopulateThrash();
        }

        private void btnDoWork_Click(object sender, EventArgs e)
        {
            foreach (string chapter in thrash)
            {
                string[] strChapter = chapter.Split(" Chapitre ");
                Directory.Delete(utility.GetPath(Root, "Manga", strChapter[0], chapter), true);
                lstBoxThrash.Items.Clear();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = lstBoxThrash.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstBoxThrash.Items.RemoveAt(lstBoxThrash.SelectedIndices[i]);
                thrash.RemoveAt(lstBoxThrash.SelectedIndices[i]);
            }
        }

        private void btnAddChapter_Click(object sender, EventArgs e)
        {
            if (txtBoxNewChapter.Text != string.Empty)
            {
                Chapter chapter = new();
                Manga? manga = newManga.Where(e => comboBoxNewManga.Text != string.Empty && e.Nom == comboBoxNewManga.Text).FirstOrDefault();
                manga ??= new()
                {
                    Nom= cmbManga.Text,
                };
                manga.Chapters.Add(new()
                {
                    NameChapter = txtBoxNewChapter.Text
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedIndex != -1)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Move(fileDialog.FileName, utility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text, Path.GetFileName(fileDialog.FileName)));
                }
            }
            
        }
    }
}