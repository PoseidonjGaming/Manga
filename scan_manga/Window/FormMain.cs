using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Properties;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker;
using scan_manga.Utilities.BackgroudWorker.BackgroundArchive;
using scan_manga.Window;
using System.Diagnostics;
using System.IO.Compression;

namespace scan_manga
{
    public partial class FormMain : Form
    {
        private List<Manga> mangaList = new();
        private string root;
        private Manga manga;
        private readonly List<Chapter> chapters;
        private int numChapitre;
        private readonly string tempdir;

        public FormMain()
        {
            InitializeComponent();
            
            labelChpater.Text = string.Empty;
            chapters = new();
            if (Settings.Default.Manga is not null)
            {
                mangaList = Settings.Default.Manga;
                comboBoxManga.Items.AddRange(Populate().ToArray());

            }
            if (Settings.Default.Root != string.Empty)
            {
                root = Settings.Default.Root;
                listBoxManga.Items.AddRange(Populate().ToArray());
            }
            tempdir= MangaUtility.GetPath(Directory.GetCurrentDirectory(), "Temp");
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxManga.Items.Clear();
            comboBoxManga.Items.AddRange(Populate().ToArray());

            listBoxManga.Items.Clear();
            listBoxManga.Items.AddRange(Populate().ToArray());
            MangaUtility.StartPack(Settings.Default.Root);
            root=Settings.Default.Root;
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
                listBoxChapter.Items.AddRange(MangaUtility.Sort(Directory.GetDirectories(MangaUtility.GetPath(root, "Manga", listBoxManga.Text)).ToList(),
                    listBoxManga.Text + " Chapitre ", listBoxManga.Text + " Chapitre ", false));
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
                labelChpater.Text = "Aucun chapitre n'a été trouvé";
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

                string dir = MangaUtility.GetPath(root, "Manga", listBoxManga.SelectedItem.ToString(), listBoxChapter.SelectedItem.ToString());
                comboBoxPage.Items.Clear();
                foreach (string chapter in Directory.GetFiles(dir))
                {
                    comboBoxPage.Items.Add(Path.GetFileNameWithoutExtension(chapter));
                }
            }
        }

        

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPage.SelectedIndex != -1 && listBoxManga.SelectedItems.Count == 1 && listBoxChapter.SelectedItems.Count == 1)
            {
                string dir = MangaUtility.GetPath(root, "Manga", listBoxManga.Text, listBoxChapter.Text);
                string page = Directory.GetFiles(dir).ToList().Find(e => Path.GetFileNameWithoutExtension(e) == comboBoxPage.SelectedItem.ToString().Replace(" ", "_"));
                pictureBoxPage.ImageLocation = page;
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
            foreach (string chapter in Directory.GetDirectories(tempdir))
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
            FormProgress formArchive = new(new BackgroundRestore());
            formArchive.ShowDialog(this);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(comboBoxManga.SelectedIndex!= -1)
            {
                Manga manga = mangaList.Where(e => e.Nom == comboBoxManga.Text).First();
                foreach (string chapter in Directory.GetDirectories(MangaUtility.GetPath(root, "Manga", manga.Nom)))
                {
                    MangaUtility.CreateDirectory(root, "Temp", manga.Nom);
                    ZipFile.CreateFromDirectory(MangaUtility.GetPath(root, "Manga", manga.Nom, Path.GetFileName(chapter)), MangaUtility.GetPath(root, "Temp", manga.Nom, Path.GetFileName(chapter) + ".zip"));
                }
            }
           
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string manga in Directory.GetDirectories("E:\\Drive\\Mon Drive\\Manga Scan"))
            {
                CreateDirectory(root + "\\Temp\\" + Path.GetFileName(manga));
                foreach (string chapter in Directory.GetFiles(manga))
                {
                    File.Copy(chapter, root + "\\Temp\\" + Path.GetFileName(manga) + "\\" + Path.GetFileName(chapter));

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
    }
}