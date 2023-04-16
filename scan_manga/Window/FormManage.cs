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
                foreach (string chapter in MangaUtility.GetSortedChapters(MangaUtility.Root, "Manga", cmbManga.Text))
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
                foreach (string page in MangaUtility.GetSortedPages(MangaUtility.Root, "Manga", cmbManga.Text, cmbChapter.Text))
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
            MangaUtility.Progress(new BackGroundZipper(cmbManga.Text), this);
        }

        private void rdButtonChapter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnAddChapter.Checked)
            {
                cmbAdd.Enabled = true;
                numericUpDownAdd.Enabled = true;
                txtBoxValue.Enabled = false;
            }
            else
            {
                cmbAdd.Enabled = false;
                numericUpDownAdd.Enabled = false;
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
                MangaUtility.CreateDirectory(MangaUtility.Temp, cmbAdd.Text, cmbAdd.Text + " Chapitre " + numericUpDownAdd.Value);
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
                numericUpDownUpdate.Enabled = true;
            }
            else
            {
                cmbChapterSel.Enabled = false;
                numericUpDownUpdate.Enabled = false;
            }
        }

        private void cmbMangaSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMangaSel.SelectedIndex != -1 && rdChapter.Checked)
            {
                cmbChapterSel.Items.Clear();
                cmbChapterSel.Items.AddRange(MangaUtility.GetSortedChapters(MangaUtility.Root, "Manga", cmbMangaSel.Text));
                cmbChapterSel.SelectedIndex = 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rdChapter.Checked)
            {
                if (cmbMangaSel.SelectedIndex != -1 && cmbChapterSel.SelectedIndex != -1)
                {
                    Directory.Move(MangaUtility.GetPath(
                        MangaUtility.Root, "Manga", cmbMangaSel.Text, cmbChapterSel.Text),
                       MangaUtility.GetPath(
                           MangaUtility.Root, "Manga", cmbMangaSel.Text,
                           cmbChapterSel.Text.Replace(cmbMangaSel.Text, txtBoxModif.Text)));
                    cmbMangaSel_SelectedIndexChanged(sender, e);
                }
            }
            else
            {
                Manga manga = MangaUtility.GetManga(cmbMangaSel.Text, MangaUtility.Mangas);
                manga.Nom = manga.Nom.Replace(cmbMangaSel.Text, txtBoxModif.Text);
                Settings.Default.Save();

                Directory.Move(
                    MangaUtility.GetPath(MangaUtility.Root, "Manga", cmbMangaSel.Text),
                    MangaUtility.GetPath(MangaUtility.Root, "Manga", txtBoxModif.Text)
                    );
                foreach (string chapter in MangaUtility.Get(MangaUtility.Root, "Manga", txtBoxModif.Text))
                {
                    if (MangaUtility.GetName(chapter).Contains(cmbMangaSel.Text))
                    {
                        Directory.Move(chapter,
                        MangaUtility.GetPath(MangaUtility.Root, "Manga", txtBoxModif.Text,
                        MangaUtility.GetName(chapter).Replace(cmbMangaSel.Text, txtBoxModif.Text)));
                    }

                }
            }
        }

        private void retéléchargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedIndex != -1)
            {
                Manga manga = MangaUtility.GetManga(cmbManga.Text, MangaUtility.Mangas);
                FormSelectChapter form = new(cmbManga.SelectedIndex, manga.Source.Replace("[num_chapitre]", (cmbChapter.SelectedIndex+1).ToString()), cmbChapter.Text);
                form.ShowDialog(this);
            }
        }
    }
}