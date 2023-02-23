using HtmlAgilityPack;
using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga
{
    public partial class FormSelectChapter : Form
    {
        public List<Chapter> chapter = new();
        public FormSelectChapter()
        {
            InitializeComponent();
        }

        private void FormDownloadOneChapter_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Manga != null)
            {
                foreach (Manga manga in Properties.Settings.Default.Manga)
                {
                    comboBoxManga.Items.Add(manga.Nom);
                }
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            //MangaUtility.Progress(new BackGroundScan());
            Close();

        }



        private void FormDownloadOneChapter_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (chapter.Count != 0)
            {
                FormDownload formDownload = new(chapter, comboBoxManga.Text);
                formDownload.ShowDialog(this.Parent);
            }


        }

        private void comboBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxNameChapter.Text = comboBoxManga.Text + " Chapitre ";
        }
    }
}
