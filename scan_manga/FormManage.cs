using HtmlAgilityPack;
using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace scan_manga
{
    public partial class FormManage : Form
    {
        private List<Manga> mangas;
        private List<Manga> tempManga;
        public List<string> thrash;
        private string Root;
        private MangaUtility utility;

        public FormManage()
        {
            InitializeComponent();
            Root = Properties.Settings.Default.Root;
            thrash = new();
            tempManga = new();
            utility = new();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Manga != null)
            {
                mangas = Properties.Settings.Default.Manga;
            }

            foreach (Manga manga in mangas)
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
                Manga manga = mangas[cmbManga.SelectedIndex];
                foreach (string chapter in utility.Sort(utility.SetChapters(manga.Chapters), " ", manga.Nom + " Chapitre ", false))
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
                lstBoxPage.Items.Clear();
                Manga manga = mangas[cmbManga.SelectedIndex];
                Chapter chapter = manga.Chapters[cmbChapter.SelectedIndex];
                foreach (string page in utility.Sort(chapter.ListScan, "_", "page ", true))
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
            Manga manga = mangas.Where(e => e.Nom == cmbManga.Text).First();
            MessageBox.Show(manga.Chapters.Count.ToString());
            foreach (Chapter chapter in manga.Chapters)
            {
                thrash.Add(Path.GetFileName(chapter.NameChapter));
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


        private Manga SearchManga(string search)
        {
            return tempManga.Where(e => e.Nom == search).First();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = lstBoxThrash.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstBoxThrash.Items.RemoveAt(lstBoxThrash.SelectedIndices[i]);
                thrash.RemoveAt(lstBoxThrash.SelectedIndices[i]);
            }
        }
    }
}