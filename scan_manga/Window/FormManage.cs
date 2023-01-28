using HtmlAgilityPack;
using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public List<string> thrash;
        private readonly string Root;
        private readonly MangaUtility utility;

        public FormManage()
        {
            InitializeComponent();
            Root = Properties.Settings.Default.Root;
            thrash = new();
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
                foreach (string chapter in Directory.GetDirectories(utility.GetPath(Root, "Manga", cmbManga.Text)))
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = lstBoxThrash.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstBoxThrash.Items.RemoveAt(lstBoxThrash.SelectedIndices[i]);
                thrash.RemoveAt(lstBoxThrash.SelectedIndices[i]);
            }
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] dirTempManga=new string[3]{ Root, "Temp", cmbManga.Text};
            //utility.CreaterDirectory(dirTempManga);
            foreach(string chapter in Directory.GetDirectories(utility.GetPath(Root, "Manga", cmbManga.Text)))
            {
                MessageBox.Show(chapter);
            }

        }
    }
}