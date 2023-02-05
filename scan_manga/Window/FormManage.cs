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
        public FormManage()
        {
            InitializeComponent();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            foreach (Manga manga in Settings.Default.Manga)
            {
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
                foreach (string chapter in MangaUtility.GetChapters(" Chapitre ", cmbManga.Text + " Chapitre ", Settings.Default.Root, "Manga", cmbManga.Text))
                {
                    cmbChapter.Items.Add(Path.GetFileName(chapter));
                }
                if (cmbChapter.Items.Count > 0)
                {
                    cmbChapter.SelectedIndex = 0;
                }
                txtBoxTempManga.Text = cmbManga.Text;
            }
        }

        private void lstBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxPage.SelectedIndex != -1)
            {
                picturePage.ImageLocation = MangaUtility.GetPage(Directory.GetFiles(MangaUtility.GetPath(Settings.Default.Root, "Manga", cmbManga.Text, cmbChapter.Text)), lstBoxPage.Text);
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
                txtBoxTempChapter.Text = cmbChapter.Text;
            }
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangaUtility.Progress(new BackGroundZipper(cmbManga.Text));
        }
    }
}