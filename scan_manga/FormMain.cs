using HtmlAgilityPack;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace scan_manga
{
    public partial class FormMain : Form
    {
        private List<Manga> mangaList = new();
        private string root;
        private Manga manga;
        private readonly string tempdir;
        private readonly List<Chapter> chapters = new();
        private int numChapitre = 1;
        private string chapitre;
        private readonly MangaUtility utility;

        public FormMain()
        {
            InitializeComponent();
            utility = new();
            tempdir = Directory.GetCurrentDirectory() + "\\Temp";
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

            labelChpater.Text = string.Empty;

            if (Properties.Settings.Default.Manga is not null)
            {
                mangaList = Properties.Settings.Default.Manga;
                comboBoxManga.Items.AddRange(Populate().ToArray());

            }
            if (Properties.Settings.Default.Root != string.Empty)
            {
                root = Properties.Settings.Default.Root;
                listBoxManga.Items.AddRange(Populate().ToArray());
            }

        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxManga.Items.Clear();
            comboBoxManga.Items.AddRange(Populate().ToArray());

            listBoxManga.Items.Clear();
            listBoxManga.Items.AddRange(Populate().ToArray());
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
                listBoxChapter.Items.AddRange(sort(Directory.GetDirectories(utility.GetPath(root, "Manga", listBoxManga.Text)), listBoxManga.Text + " Chapitre ", " "));
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
                    string pathChapter = utility.GetPath(root, "Manga", manga.Nom, manga.Nom + " Chapitre " + numChapitre.ToString());
                    string pathTempChapter = utility.GetPath(tempdir, "Manga", manga.Nom, manga.Nom + " Chapitre " + numChapitre.ToString());
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
            if (Directory.Exists(utility.GetPath(root, "Manga",comboBoxManga.Text, comboBoxManga.Text + " Chapitre " + numChapitre)))
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
                FormDownload formDownload = new();
                formDownload.chapters = chapters;
                formDownload.nameManga = manga.Nom;

                formDownload.ShowDialog(this);
                chapters.Clear();
                numChapitre = 0;

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

                string dir = utility.GetPath(root, "Manga", listBoxManga.SelectedItem.ToString(), listBoxChapter.SelectedItem.ToString());
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
                string dir = utility.GetPath(root, "Manga", listBoxManga.Text, listBoxChapter.Text);
                string page = Directory.GetFiles(dir).ToList().Find(e => Path.GetFileNameWithoutExtension(e) == comboBoxPage.SelectedItem.ToString().Replace(" ", "_"));
                pictureBoxPage.ImageLocation = page;
            }
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxManga.SelectedIndex != -1)
            {
                clear();
                manga = mangaList.Find(e => e.Nom == comboBoxManga.Text);
                chapters.Clear();
                if (!backgroundWorkerScan.IsBusy)
                {
                    numChapitre = 1;
                    chapters.Clear();
                    backgroundWorkerScan.RunWorkerAsync();
                }
            }
        }

        private void clear()
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
            FormArchive formArchive = new("\\Manga\\", "\\Backup\\");
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
            FormArchive formArchive = new("\\Backup\\", "\\Manga\\");
            formArchive.ShowDialog(this);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string chapter in Directory.GetDirectories(root + "\\" + comboBoxManga.SelectedItem.ToString()))
            {
                CreateDirectory(root + "\\Temp\\" + comboBoxManga.SelectedItem.ToString() + "\\" + Path.GetFileName(chapter));
                foreach (string file in Directory.GetFiles(chapter))
                {
                    File.Copy(file, root + "\\Temp\\" + comboBoxManga.SelectedItem.ToString() + "\\" + Path.GetFileName(chapter) + "\\" + Path.GetFileName(file));
                }
            }
            Process.Start("powershell", "E:\\test_boucle.ps1");
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (string manga in Directory.GetDirectories("E:\\Drive\\Mon Drive\\Manga Scan"))
            //{
            //    CreateDirectory(root + "\\Temp\\" + Path.GetFileName(manga));
            //    foreach (string chapter in Directory.GetFiles(manga))
            //    {
            //        File.Copy(chapter, root + "\\Temp\\" + Path.GetFileName(manga) + "\\" + Path.GetFileName(chapter));

            //    }
            //}
            //Process.Start("powershell", "E:\\Manga Scan\\TestExtract.ps1");

            foreach (Manga manga in Properties.Settings.Default.Manga)
            {
                foreach (string chapter in Directory.GetDirectories(root + "\\" + manga.Nom))
                {
                    foreach (string page in Directory.GetFiles(chapter))
                    {
                        string pageName = Path.GetFileNameWithoutExtension(page);
                        int numPage = int.Parse(pageName.Split('_').Last());
                        string Ext = Path.GetExtension(page);
                        if (numPage < 10)
                        {
                            File.Move(page, root + "\\" + manga.Nom + "\\" + Path.GetFileName(chapter) + "\\page_0" + numPage.ToString() + Ext);
                        }
                    }
                }
            }

        }
    }
}