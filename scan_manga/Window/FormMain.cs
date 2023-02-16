using HtmlAgilityPack;
using scan_manga.Models;
using scan_manga.Properties;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker;
using scan_manga.Window;
using System.Diagnostics;
using System.IO.Compression;

namespace scan_manga
{
    public partial class FormMain : Form
    {
        private List<Manga> mangaList = new();
        private readonly string root;
        private Manga manga;
        private readonly string tempdir;
        private readonly List<Chapter> chapters = new();
        private int numChapitre = 1;
        private string chapitre;

        public FormMain()
        {
            InitializeComponent();
            tempdir = MangaUtility.GetPath(Directory.GetCurrentDirectory(),"Temp");
            labelChpater.Text = string.Empty;
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
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxManga.Items.Clear();
            comboBoxManga.Items.AddRange(Populate().ToArray());

            listBoxManga.Items.Clear();
            listBoxManga.Items.AddRange(Populate().ToArray());
            MangaUtility.StartPack(Settings.Default.Root);
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
                listBoxChapter.Items.AddRange(sort(Directory.GetDirectories(MangaUtility.GetPath(root, "Manga", listBoxManga.Text)), listBoxManga.Text + " Chapitre ", " "));
            }
        }

        private void backgroundWorkerScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            string source = manga.Source;
            bool isChapterExist;

            try
            {
                HttpClient client = new();
                var result = client.GetAsync(source.Replace("[num_chapitre]", "1")).Result;
                if (result.IsSuccessStatusCode)
                {
                    isChapterExist = true;
                }
                else
                {
                    isChapterExist = false;
                }
            }
            catch
            {
                isChapterExist = false;
            }

            if (isChapterExist)
            {

                do
                {
                    string pathChapter = MangaUtility.GetPath(root, "Manga", manga.Nom, manga.Nom + " Chapitre " + numChapitre.ToString());
                    string pathTempChapter = MangaUtility.GetPath(tempdir, "Manga", manga.Nom, manga.Nom + " Chapitre " + numChapitre.ToString());
                    string url = source.Replace("[num_chapitre]", numChapitre.ToString());

                    if (!Directory.Exists(pathChapter))
                    {

                        List<string> listScanTemp = new();
                        try
                        {
                            HttpClient client = new();
                            var result = client.GetAsync(source.Replace("[num_chapitre]", numChapitre.ToString())).Result;
                            if (result.IsSuccessStatusCode)
                            {
                                isChapterExist = true;
                                try
                                {
                                    HtmlWeb web = new();

                                    var doc = web.Load(url);
                                    var nodes = doc.DocumentNode.Descendants("img");

                                    foreach (HtmlNode node in nodes)
                                    {

                                        if (node.Attributes["data-src"] != null)
                                        {
                                            listScanTemp.Add(node.Attributes["data-src"].Value);
                                        }
                                        else
                                        {
                                            listScanTemp.Add(node.Attributes["src"].Value);
                                        }
                                    }
                                    chapters.Add(new Chapter(manga.Nom + " Chapitre " + numChapitre.ToString(),
                                        listScanTemp));
                                    isChapterExist = true;


                                }
                                catch
                                {

                                    isChapterExist = false;


                                }
                            }
                            else
                            {
                                isChapterExist = false;
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }

                    backgroundWorkerScan.ReportProgress(chapters.Count);

                    Thread.Sleep(100);
                    numChapitre++;
                } while (isChapterExist);
                numChapitre = 0;
            }



        }

        private void backgroundWorkerScan_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (Directory.Exists(MangaUtility.GetPath(root, "Manga", comboBoxManga.Text, comboBoxManga.Text + " Chapitre " + numChapitre)))
            {
                labelChpater.Text = "Le Chapitre " + numChapitre.ToString() + " de " + manga.Nom + " est déjà possédé";
            }
            else if (e.ProgressPercentage > 0)
            {
                if (chapters.Last().NameChapter == manga.Nom + " Chapitre " + numChapitre.ToString())
                {
                    labelChpater.Text = "Le Chapitre " + numChapitre.ToString() + " de " + manga.Nom + " a été trouvé";
                }

            }

        }

        private void backgroundWorkerScan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (chapters.Count != 0)
            {
                numChapitre = 0;
                FormDownload formDownload = new()
                {
                    chapters = chapters,
                    nameManga = manga.Nom
                };

                formDownload.ShowDialog(this);
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

        private string[] sort(string[] listIn, string toAdd, string split)
        {
            List<float> numChapter = new List<float>();
            List<string> listOut = new List<string>();
            foreach (string chapter in listIn)
            {
                string strNum = Path.GetFileNameWithoutExtension(chapter).Split(split)[^1];
                if (chapter.Contains('.'))
                {
                    strNum = strNum.Replace('.', ',');
                }

                numChapter.Add(float.Parse(strNum));
            }


            numChapter.Sort();
            foreach (float num in numChapter)
            {
                string strNum = num.ToString();
                if (strNum.Contains(','))
                {
                    strNum = strNum.Replace(',', '.');
                }
                listOut.Add(toAdd + strNum);
            }
            return listOut.ToArray();
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
                Clear();
                manga = mangaList.Where(e => e.Nom == comboBoxManga.Text).First();
                chapters.Clear();
                if (!backgroundWorkerScan.IsBusy)
                {
                    numChapitre = 1;
                    chapters.Clear();
                    backgroundWorkerScan.RunWorkerAsync();
                }
            }
        }

        private void Clear()
        {
            foreach (string chapter in Directory.GetDirectories(tempdir))
            {
                Directory.Delete(chapter, true);
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
            FormProgress formArchive = new(new BackgroundWorkerRestore());
            formArchive.ShowDialog(this);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manga manga = mangaList.Where(e => e.Nom == comboBoxManga.Text).First();
            foreach (string chapter in Directory.GetDirectories(MangaUtility.GetPath(root, "Manga", manga.Nom)))
            {
                MangaUtility.CreateDirectory(root, "Temp", manga.Nom);
                ZipFile.CreateFromDirectory(MangaUtility.GetPath(root, "Manga", manga.Nom, Path.GetFileName(chapter)), MangaUtility.GetPath(root, "Temp", manga.Nom, Path.GetFileName(chapter) + ".zip"));
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
    }
}