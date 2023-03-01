using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker;
using scan_manga.Properties;

namespace scan_manga.Window
{
    public partial class FormManage : Form
    {
        public FormManage()
        {
            InitializeComponent();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            foreach (Manga manga in Settings.Default.Manga)
            {
                cmbManga.Items.Add(manga.Nom);
                cmbMangaSel.Items.Add(manga.Nom);
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
                foreach (string chapter in MangaUtility.GetSortedChapters(" Chapitre ", cmbManga.Text + " Chapitre ", MangaUtility.Root, "Manga", cmbManga.Text))
                {
                    cmbChapter.Items.Add(chapter);
                }
                if (cmbChapter.Items.Count > 0)
                {
                    cmbChapter.SelectedIndex = 0;
                }
            }
        }

        private void lstBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxPage.SelectedIndex != -1)
            {
                picturePage.ImageLocation = MangaUtility.GetPage(lstBoxPage.Text, MangaUtility.Root, "Manga", cmbManga.Text, cmbChapter.Text);
            }
        }

        private void cmbChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedIndex != -1)
            {
                lstBoxPage.Items.Clear();
                foreach (string page in MangaUtility.GetPages(MangaUtility.Root, "Manga", cmbManga.Text, cmbChapter.Text))
                {
                    lstBoxPage.Items.Add(page);
                }
            }
        }

        private void cmbTempManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTempManga.SelectedIndex != -1)
            {
                cmbTempChapter.Items.Clear();
                cmbTempChapter.Items.AddRange(MangaUtility.GetSortedChapters(" Chapitre ", cmbTempManga.Text + " Chapitre ", MangaUtility.Temp, cmbTempManga.Text));
            }

        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangaUtility.Progress(new BackGroundZipper(cmbManga.Text));
        }

        private void rdButtonChapter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnAddChapter.Checked)
            {
                cmbAdd.Enabled = true;
                numericUpDown1.Enabled = true;
                txtBoxValue.Enabled = false;
            }
            else
            {
                cmbAdd.Enabled = false;
                numericUpDown1.Enabled = false;
                txtBoxValue.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rdBtnAddManga.Checked)
            {
                MangaUtility.CreateDirectory(MangaUtility.Temp, txtBoxValue.Text);

                RefreshManga(cmbAdd);
                RefreshManga(cmbTempManga);
            }
            else
            {
                MangaUtility.CreateDirectory(MangaUtility.Temp,cmbAdd.Text , cmbAdd.Text + " Chapitre " + numericUpDown1.Value);
            }

            txtBoxValue.Clear();
        }

        private static void RefreshManga(ComboBox cmb)
        {
            cmb.Items.Clear();
            foreach (string manga in MangaUtility.Get(MangaUtility.Temp))
            {
                cmb.Items.Add(MangaUtility.GetName(manga));
            }
        }

        private void rdChapter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdChapter.Checked)
            {
                cmbChapterSel.Enabled = true;
            }
            else
            {
                cmbChapterSel.Enabled = false;
            }
        }

        private void cmbMangaSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMangaSel.SelectedIndex != -1)
            {
                cmbChapterSel.Items.Clear();
                foreach (string chapter in MangaUtility.GetSortedChapters(" Chapitre ", cmbMangaSel.Text + " Chapitre ", Settings.Default.Root, "Manga", cmbManga.Text))
                {
                    cmbChapterSel.Items.Add(chapter);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rdChapter.Checked)
            {
                if (cmbChapterSel.SelectedIndex != -1 && cmbMangaSel.SelectedIndex != -1)
                {
                    MangaUtility.CreateDirectory(MangaUtility.Temp, cmbMangaSel.Text, txtBoxModif.Text);
                }

            }
            else
            {

            }
        }
    }
}