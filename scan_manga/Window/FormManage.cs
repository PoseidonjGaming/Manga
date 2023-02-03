using scan_manga.Models;
using scan_manga.Properties;
using scan_manga.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga.Window
{
    public partial class FormManage : Form
    {
        private List<Manga> mangas;
        public List<string> thrash;
        public List<Manga> newManga;
        private readonly string Root;

        public FormManage()
        {
            InitializeComponent();
            Root = Properties.Settings.Default.Root;
            thrash = new();
            newManga = new();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            foreach (Manga manga in Settings.Default.Manga)
            {
                cmbBoxManga.Items.Add(manga.Nom);
            }
            if (cmbBoxManga.Items.Count > 0)
            {
                cmbBoxManga.SelectedIndex = 0;
            }
        }

        private void cmbBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxManga.SelectedIndex != -1)
            {
                cmbChapter.Items.Clear();

                foreach (string chapter in MangaUtility.Sort(Directory.GetDirectories(MangaUtility.GetPath(Root, "Manga", cmbManga.Text)).ToList(), " Chapitre ", cmbManga.Text + " Chapitre ", false))
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
                txtBoxNewPage.Text = cmbChapter.Text;
                lstBoxPage.Items.Clear();
                string dir = MangaUtility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text);
                foreach (string page in MangaUtility.Sort(Directory.GetFiles(dir).ToList(), "_", "page ", true))
                {
                    lstBoxPage.Items.Add(page);
                }
            }
        }
        private void lstBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxPage.SelectedIndex != -1)
            {
                pictureBoxPage.ImageLocation = MangaUtility.GetPage(Directory.GetFiles(MangaUtility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text)), lstBoxPage.Text);
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
            lstBoxThrash.Items.AddRange(MangaUtility.Sort(thrash, " Chapitre ", cmbManga.Text + " Chapitre ", false));
        }

        private void btnSuppManga_Click(object sender, EventArgs e)
        {
            foreach (string chapter in Directory.GetDirectories(MangaUtility.GetPath(Root, "Manga", cmbManga.Text)))
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
                Directory.Delete(MangaUtility.GetPath(Root, "Manga", strChapter[0], chapter), true);
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedIndex != -1)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Move(fileDialog.FileName, MangaUtility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text, Path.GetFileName(fileDialog.FileName)));
                }
            }

        }

        private void btnAddPage_Click(object sender, EventArgs e)
        {
            if (txtBoxNewPage.Text != string.Empty)
            {

                Page page = new(MangaUtility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text, listBoxNewPage.Text),
                    MangaUtility.GetPath(Root, "Manga", cmbManga.Text, cmbChapter.Text, txtBoxNewPage.Text));
                
                Manga? manga = newManga.Where(e => comboBoxNewManga.Text != string.Empty && e.Nom == comboBoxNewManga.Text).FirstOrDefault();
                manga ??= new()
                {
                    Nom = cmbManga.Text,
                };
                Chapter? chapter = manga.Chapters.Where(e => e.NameChapter==comboBoxNewChapter.Text).First();
                chapter ??= new()
                {
                    NameChapter = cmbManga.Text
                };
                manga.Chapters.Add(chapter);

                newManga.Add(manga);
                PopulateNewManga();
            }
        }

        private void PopulateNewManga()
        {
            if (newManga.Count > 0)
            {
                comboBoxNewManga.Items.Clear();
                foreach (Manga manga in newManga)
                {
                    comboBoxNewManga.Items.Add(manga.Nom);
                }
                PopulateNewChapter(newManga.First());
            }

        }

        private void PopulateNewChapter(Manga manga)
        {
            comboBoxNewChapter.Items.Clear();
            foreach (Chapter chapter in manga.Chapters)
            {
                comboBoxNewChapter.Items.Add(chapter.NameChapter);
            }
        }

        private void comboBoxNewManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNewManga.SelectedIndex != -1)
            {
                Manga manga = newManga.Where(e => e.Nom == comboBoxNewManga.Text).First();
                PopulateNewChapter(manga);
            }
        }

        private void comboBoxNewChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNewChapter.SelectedIndex != -1)
            {
                Manga manga = newManga.Where(e => e.Nom == comboBoxNewManga.Text).First();
                Chapter chapter = manga.Chapters.Where(e => e.NameChapter == comboBoxNewChapter.Text).First();
                foreach (Page page in chapter.Pages)
                {
                    listBoxNewPage.Items.Add(Path.GetFileName(page.NewPage));
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listBoxNewPage.SelectedIndex != -1)
            {
                Manga manga = MangaUtility.GetManga(comboBoxNewManga.Text, newManga);
                Chapter chapter = MangaUtility.GetChapter(comboBoxNewChapter.Text, manga.Chapters);

                Page tempPage1 = chapter.Pages[listBoxNewPage.Items.IndexOf(listBoxNewPage.SelectedIndex)];
                MessageBox.Show(tempPage1.OldPage);
            }
        }
    }
}
