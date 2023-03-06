using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker.BackgroundArchive;
using scan_manga.Window;
using scan_manga.Properties;
using System.Diagnostics;
using System.IO.Compression;

namespace scan_manga
{
    public partial class FormMain : Form
    {
        private List<Manga> mangaList = new();
        private Manga manga;
        private readonly List<Chapter> chapters;
        private int numChapitre;

        public FormMain()
        {
            InitializeComponent();

            chapters = new();
            if (Settings.Default.Manga is not null)
            {
                mangaList = Settings.Default.Manga;
                comboBoxManga.Items.AddRange(Populate().ToArray());

            }
            if (Settings.Default.Root != string.Empty)
            {
                listBoxManga.Items.AddRange(Populate().ToArray());
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxManga.Items.Clear();
            comboBoxManga.Items.AddRange(Populate().ToArray());

            listBoxManga.Items.Clear();
            listBoxManga.Items.AddRange(Populate().ToArray());
            MangaUtility.StartPack();
        }

        private List<string> Populate()
        {
            List<string> list = new();
            foreach (Manga manga in mangaList)
            {
                list.Add(manga.Nom);
            }
            return list;
        }



        private void listBoxManga_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                listBoxChapter.Items.Clear();
                listBoxChapter.Items.AddRange(MangaUtility.GetSortedChapters(MangaUtility.Root, "Manga", listBoxManga.Text));
            }
        }



        private void backgroundWorkerScan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (chapters.Count != 0)
            {
                numChapitre = 0;



                chapters.Clear();
            }
            else
            {
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
                MessageBox.Show(MangaUtility.GetPage(comboBoxPage.Text, MangaUtility.Root, "Manga", listBoxManga.Text, listBoxChapter.Text));
                pictureBoxPage.ImageLocation = MangaUtility.GetPage(comboBoxPage.Text, MangaUtility.Root, "Manga", listBoxManga.Text, listBoxChapter.Text);
            }
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxManga.SelectedIndex != -1)
            {

                manga = MangaUtility.GetManga(comboBoxManga.Text, mangaList);
                chapters.Clear();
                MangaUtility.Scan(manga, true);
            }
        }



        private void charcherUnChapitreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectChapter formDownload = new();
            formDownload.ShowDialog(this);
        }



        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (string chapter in Directory.GetDirectories(MangaUtility.Temp))
            {
                Directory.Delete(chapter, true);
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProgress formArchive = new(new BackGroundBackup());
            formArchive.ShowDialog(this);
        }
        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void restaurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangaUtility.Progress(new BackgroundRestore());
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxManga.SelectedIndex != -1)
            {
                Manga manga = MangaUtility.GetManga(comboBoxManga.Text,MangaUtility.Mangas);
                foreach (string chapter in MangaUtility.Get(MangaUtility.Root, "Manga", manga.Nom))
                {
                    MangaUtility.CreateDirectory(MangaUtility.Root, "Temp", manga.Nom, MangaUtility.GetName(chapter));
                    foreach(string page  in MangaUtility.Get(chapter))
                    {
                        File.Copy(page, MangaUtility.GetPath(MangaUtility.Root,"Temp",manga.Nom,MangaUtility.GetName(chapter),MangaUtility.GetName(page)));
                    }
                    
                }
            }

        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string manga in Directory.GetDirectories("E:\\Drive\\Mon Drive\\Manga Scan"))
            {
                CreateDirectory(MangaUtility.GetPath(MangaUtility.Root, "Temp", Path.GetFileName(manga)));
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
    }
}