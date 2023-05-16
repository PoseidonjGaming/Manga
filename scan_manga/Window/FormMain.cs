using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker.BackgroundArchive;
using scan_manga.Window;
using scan_manga.Properties;
using System.IO.Compression;
using scan_manga.Utilities.BackgroudWorker;
using Microsoft.Toolkit.Uwp.Notifications;

namespace scan_manga
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

        }

        private void Settings_FormClosed(object? sender, FormClosedEventArgs? e)
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
                Manga manga = MangaUtility.GetManga(listBoxManga.Text, MangaUtility.Mangas);
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
            MangaUtility.Progress(new BackGroundBackup(), this);
        }

        private void restaurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangaUtility.Progress(new BackgroundRestore(), this);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                MangaUtility.Progress(new BackGroundUpload(listBoxManga.Text), this);
            }

        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (string manga in MangaUtility.Get("E:", "Drive", "Mon Drive", "Manga Scan"))
            //{
            //    MangaUtility.CreateDirectory(MangaUtility.Root, "Temp", Path.GetFileName(manga));
            //    foreach (string chapter in Directory.GetFiles(manga))
            //    {
            //        File.Copy(chapter, MangaUtility.GetPath(MangaUtility.Root, Path.GetFileName(manga), Path.GetFileName(chapter)));
            //    }
            //}
            //Process.Start("powershell", MangaUtility.GetPath("E:", "Manga Scan", "TestExtract.ps1"));
            FolderBrowserDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MangaUtility.CreateDirectory(MangaUtility.RootTemp, MangaUtility.GetName(dialog.SelectedPath));
                foreach (string path in MangaUtility.Get(dialog.SelectedPath))
                {
                    if (Path.GetExtension(path) == ".zip")
                    {
                        //File.Copy(path,
                        //    MangaUtility.GetPath(MangaUtility.RootTemp,
                        //    Path.GetFileName(dialog.SelectedPath), MangaUtility.GetName(path)));
                        ZipFile.ExtractToDirectory(path,
                            MangaUtility.GetPath(MangaUtility.RootManga,
                            MangaUtility.GetName(dialog.SelectedPath)));
                    }
                }
            }

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
            OpenFileDialog fileDialog = new();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Manga>? mangas = JsonConvert.DeserializeObject<List<Manga>>(File.ReadAllText(fileDialog.FileName));
                if (mangas != null)
                {
                    MangaUtility.Save(MangaUtility.Root, mangas);
                    listBoxManga.Items.Clear();
                    listBoxManga.Items.AddRange(Populate());
                }

            }

        }

        private void comboBoxManga_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                MangaUtility.Scan(MangaUtility.GetManga(listBoxManga.Text, MangaUtility.Mangas), true, this);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new ToastContentBuilder()
            //.AddText("Andrew sent you a picture")
            //.AddText("Check this out, The Enchantments in Washington!")
            //.Show();
            foreach(string chapter in MangaUtility.Get(MangaUtility.RootManga, listBoxManga.Text))
            {
                if(MangaUtility.Get(chapter).Length == 0)
                {
                    MessageBox.Show(chapter);
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (MangaUtility.Mangas != null)
            {
                listBoxManga.Items.AddRange(Populate());
            }
        }
    }
}