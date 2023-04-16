using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker.BackgroundArchive;
using scan_manga.Window;
using scan_manga.Properties;
using System.Diagnostics;
using System.IO.Compression;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Security.Policy;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System;

namespace scan_manga
{
    public partial class FormMain : Form
    {
        private Manga manga;
        private readonly List<Chapter> chapters;

        public FormMain()
        {
            InitializeComponent();

            chapters = new();

            if (!MangaUtility.Root.Equals(string.Empty))
            {
                listBoxManga.Items.AddRange(Populate());
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {

            listBoxManga.Items.Clear();
            listBoxManga.Items.AddRange(Populate());
            MangaUtility.StartPack();
        }

        private static string[] Populate()
        {
            List<string> list = new();
            foreach (Manga manga in MangaUtility.Mangas)
            {
                list.Add(manga.Nom);
            }
            return list.ToArray();
        }



        private void listBoxManga_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                listBoxChapter.Items.Clear();
                listBoxChapter.Items.AddRange(MangaUtility.GetSortedChapters(MangaUtility.Root, "Manga", listBoxManga.Text));
            }
        }


        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSetting settingsForm = new();
            settingsForm.FormClosed += Settings_FormClosed;
            settingsForm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManage formManage = new();
            formManage.ShowDialog();
        }

        private void listBoxChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxChapter.SelectedIndex != -1 && listBoxManga.SelectedItems.Count > 0)
            {
                comboBoxPage.Items.Clear();
                comboBoxPage.Items.AddRange(MangaUtility.GetSortedPages(MangaUtility.Root, "Manga", listBoxManga.Text, listBoxChapter.Text));
            }
        }



        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPage.SelectedIndex != -1 && listBoxManga.SelectedItems.Count == 1 && listBoxChapter.SelectedItems.Count == 1)
            {
                pictureBoxPage.ImageLocation = MangaUtility.GetPage(comboBoxPage.Text, MangaUtility.Root, "Manga", listBoxManga.Text, listBoxChapter.Text);
            }
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                manga = MangaUtility.GetManga(listBoxManga.Text, MangaUtility.Mangas);
                MangaUtility.Scan(manga, true, this);
            }
        }



        private void charcherUnChapitreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectChapter formDownload = new();
            formDownload.ShowDialog(this);
        }



        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (string chapter in MangaUtility.Get(MangaUtility.Temp))
            {
                MangaUtility.DeleteDirectory(chapter);
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProgress formArchive = new(new BackGroundBackup());
            formArchive.ShowDialog(this);
        }

        private void restaurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangaUtility.Progress(new BackgroundRestore(), this);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                Manga manga = MangaUtility.GetManga(listBoxManga.Text, MangaUtility.Mangas);
                foreach (string chapter in MangaUtility.Get(MangaUtility.Root, "Manga", manga.Nom))
                {
                    MangaUtility.CreateDirectory(MangaUtility.Root, "Temp", manga.Nom, MangaUtility.GetName(chapter));
                    foreach (string page in MangaUtility.Get(chapter))
                    {
                        File.Copy(page, MangaUtility.GetPath(MangaUtility.Root, "Temp", manga.Nom, MangaUtility.GetName(chapter), MangaUtility.GetName(page)));
                    }

                }
            }

        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string manga in MangaUtility.Get("E:", "Drive", "Mon Drive", "Manga Scan"))
            {
                MangaUtility.CreateDirectory(MangaUtility.Root, "Temp", Path.GetFileName(manga));
                foreach (string chapter in Directory.GetFiles(manga))
                {
                    File.Copy(chapter, MangaUtility.GetPath(MangaUtility.Root, Path.GetFileName(manga), Path.GetFileName(chapter)));

                }
            }
            Process.Start("powershell", "E:\\Manga Scan\\TestExtract.ps1");

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                FileName = "exportManga.json",
                Filter = "File JSON|*json",
                Title = "Exportation des Mangas"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fileDialog.FileName,
                    JsonConvert.SerializeObject(Settings.Default.Manga, Formatting.Indented));
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.Manga = JsonConvert.DeserializeObject<List<Manga>>(File.ReadAllText(fileDialog.FileName));
                Settings.Default.Save();
            }

        }

        private void comboBoxManga_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                manga = MangaUtility.GetManga(listBoxManga.Text, MangaUtility.Mangas);
                MangaUtility.Scan(manga, true, this);
            }
        }
    }
}