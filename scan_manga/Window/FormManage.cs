using scan_manga.Models;
using scan_manga.Properties;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga.Window
{
    public partial class FormManage : Form
    {
        private List<Manga> tempManga;
        public FormManage()
        {
            InitializeComponent();
            tempManga = new();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            foreach (Manga manga in Settings.Default.Manga)
            {
                cmbManga.Items.Add(manga.Nom);
                cmbAdd.Items.Add(manga.Nom);
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
                foreach (string chapter in MangaUtility.GetSortedChapters(" Chapitre ", cmbManga.Text + " Chapitre ", Settings.Default.Root, "Manga", cmbManga.Text))
                {
                    cmbChapter.Items.Add(Path.GetFileName(chapter));
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
                picturePage.ImageLocation = MangaUtility.GetPage(lstBoxPage.Text, Settings.Default.Root, "Manga", cmbManga.Text, cmbChapter.Text);
            }
        }

        private void cmbChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedIndex != -1)
            {
                lstBoxPage.Items.Clear();
                foreach (string page in MangaUtility.GetPages(Settings.Default.Root, "Manga", cmbManga.Text, cmbChapter.Text))
                {
                    lstBoxPage.Items.Add(page);
                }
            }
        }

        private void cmbTempManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTempManga.SelectedIndex != -1)
            {
                Manga manga = MangaUtility.GetManga(cmbTempManga.Text, tempManga);
                foreach (Chapter chapter in manga.Chapters)
                {
                    cmbTempChapter.Items.Add(chapter.NameChapter);
                }
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
                tempManga.Add(new()
                {
                    Nom = txtBoxValue.Text,
                });
                txtBoxValue.Clear();
                RefreshManga(cmbAdd);
                RefreshManga(cmbTempManga);
            }
            if (rdBtnAddChapter.Checked)
            {
                Manga manga = MangaUtility.GetManga(cmbAdd.Text, tempManga);
                manga.Chapters.Add(new()
                {
                    NameChapter = cmbAdd.Text + " Chapitre " + numericUpDown1.Value
                });
            }
        }

        private void RefreshManga(ComboBox cmb)
        {
            cmb.Items.Clear();
            foreach (Manga manga in tempManga)
            {
                cmb.Items.Add(manga.Nom);
            }
        }

       
    }
}