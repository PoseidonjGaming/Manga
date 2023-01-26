using HtmlAgilityPack;
using scan_manga.Utilities;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace scan_manga
{
    public partial class FormDownload : Form
    {


        public List<Chapter> chapters = new List<Chapter>();
        private List<Chapter> chaptersToDownload = new List<Chapter>();
        private Chapter tempChapter;
        private string pathTemp = Properties.Settings.Default.Root + "\\Temp";
        private string temp = Directory.GetCurrentDirectory() + "\\Temp";
        public string nameManga;
        private int maxPage;
        private string nameChapter;
        private int oldNbPage;
        private bool isCancelled;
        private readonly MangaUtility utility;

        public FormDownload()
        {
            InitializeComponent();
            utility = new();
        }

        private void FormDownload_Load(object sender, EventArgs e)
        {
            foreach (Chapter chapter in chapters)
            {
                listBoxTempChapter.Items.Add(chapter.NameChapter);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            foreach (string item in listBoxTempChapter.SelectedItems)
            {

                Chapter chapter = chapters.Find(e => e.NameChapter == item.ToString());
                Chapter chapterToDownload = chaptersToDownload.Find(e => e.NameChapter == item.ToString());
                if (chapter != null && chapterToDownload == null)
                {
                    Chapter newChapter = new Chapter();
                    newChapter.NameChapter = chapter.NameChapter;
                    newChapter.ListScan = chapter.ListScan;
                    newChapter.FirstScan = chapter.FirstScan;
                    chaptersToDownload.Add(newChapter);
                    listBoxChapter.Items.Add(newChapter.NameChapter);
                }
            }

        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            Chapter chapterToDownload = chaptersToDownload[listBoxChapter.SelectedIndex];
            for (int i = listBoxChapter.SelectedIndices.Count - 1; i >= 0; i--)
            {
                chaptersToDownload.RemoveAt(listBoxChapter.SelectedIndices[i]);
                listBoxChapter.Items.RemoveAt(listBoxChapter.SelectedIndices[i]);
            }
        }

        private void listBoxTempChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTempChapter.SelectedIndex != -1 && listBoxTempChapter.SelectedItems.Count == 1)
            {
                Chapter chapter = chapters[listBoxTempChapter.SelectedIndex];
                if (listBoxTempChapter.SelectedIndex < chapter.ListScan.Count)
                {
                    pictureBoxScan.ImageLocation = chapter.FirstScan;
                }
                listBoxChapter.SelectedItems.Clear();
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (chaptersToDownload.Count > 0)
            {
                progressBarChapter.Value = 1;
                progressBarChapter.Maximum = chaptersToDownload.Count;

                progressBarPage.Value = 1;
                chaptersToDownload[0].ListScan = Verif(chaptersToDownload[0].ListScan);
                progressBarPage.Maximum = chaptersToDownload[0].ListScan.Count;

                labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum;
                labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum;
                pictureBoxScan.ImageLocation = string.Empty;
                backgroundWorkerDownload.RunWorkerAsync();
            }
        }

        private void backgroundWorkerDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Chapter chapter in chaptersToDownload)
            {
                tempChapter = chapter;
                chapter.ListScan = Verif(chapter.ListScan);
                maxPage = chapter.ListScan.Count;
                WebClient client = new();
                CreateDirectory(utility.GetPath(temp, chapter.NameChapter));
                foreach (string page in chapter.ListScan)
                {
                    try
                    {
                        client.DownloadFile(page, utility.GetPath(temp, chapter.NameChapter, Path.GetFileName(page)));
                        if (backgroundWorkerDownload.CancellationPending)
                        {
                            backgroundWorkerDownload.Dispose();
                            client.Dispose();
                            e.Cancel = true;
                            break;
                        }
                    }
                    catch
                    {

                    }

                    backgroundWorkerDownload.ReportProgress(0);
                    Thread.Sleep(100);
                }
                backgroundWorkerDownload.ReportProgress(0);
            }
        }

        private void backgroundWorkerDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarChapter.Value = Directory.GetDirectories(temp).Length;
            progressBarPage.Maximum = maxPage;

            if (Directory.Exists(temp + "\\" + tempChapter.NameChapter))
            {
                progressBarPage.Value = Directory.GetFiles(temp + "\\" + tempChapter.NameChapter).Length;
            }
            else
            {
                progressBarPage.Value = 0;
            }

            labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum + " téléchargées";
            labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum + " téléchargés";
        }

        private void backgroundWorkerDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (!isCancelled)
            {
                progressBarChapter.Maximum = chaptersToDownload.Count;
                progressBarPage.Maximum = chaptersToDownload[0].ListScan.Count;

                progressBarChapter.Value = 0;
                progressBarPage.Value = 0;


                labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum;
                labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum;

                backgroundWorkerCopy.RunWorkerAsync();

            }


        }

        private void buttonSelectAllTemp_Click(object sender, EventArgs e)
        {
            Select(listBoxTempChapter, true);
        }

        private void buttonUnSelectAllTemp_Click(object sender, EventArgs e)
        {
            Select(listBoxTempChapter, false);
        }
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            Select(listBoxChapter, true);
        }

        private void buttonUnSelectAll_Click(object sender, EventArgs e)
        {
            Select(listBoxChapter, false);
        }

        private void listBoxChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxChapter.SelectedIndex != -1 && listBoxChapter.SelectedItems.Count == 1)
            {
                Chapter chapter = chaptersToDownload.Find(e => e.NameChapter == listBoxChapter.SelectedItem.ToString());

                pictureBoxScan.ImageLocation = chapter.FirstScan;
                listBoxTempChapter.SelectedItems.Clear();

            }
        }


        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private void Select(ListBox listBox, bool selectType)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetSelected(i, selectType);
            }
        }

        private string GetNbFiles(string path)
        {
            int nbPage = +1;
            if (nbPage < 10)
            {
                return "0" + nbPage.ToString();
            }
            else
            {
                return nbPage.ToString();
            }
        }

        private void backgroundWorkerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateDirectory(pathTemp + "\\" + nameManga);
            oldNbPage = Directory.GetDirectories(pathTemp + "\\" + nameManga).Length;
            foreach (string strChapter in Directory.GetDirectories(temp))
            {
                nameChapter = Path.GetFileName(strChapter);
                CreateDirectory(Properties.Settings.Default.Root + "\\Temp\\" + nameManga + "\\" + nameChapter);
                CreateDirectory(Properties.Settings.Default.Root + "\\Manga\\" + nameManga + "\\" + nameChapter);
                Chapter chapter = chaptersToDownload.Where(e => e.NameChapter == nameChapter).First();
                foreach (string page in Directory.GetFiles(strChapter))
                {
                    int numPage = chapter.ListScan.IndexOf(chapter.ListScan.Where(e => Path.GetFileNameWithoutExtension(e) == Path.GetFileNameWithoutExtension(page)).First()) + 1;
                    if (numPage < 10)
                    {
                        File.Copy(page, Properties.Settings.Default.Root + "\\Manga\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_0" + numPage + Path.GetExtension(page));
                        File.Copy(page, Properties.Settings.Default.Root + "\\Temp\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_0" + numPage + Path.GetExtension(page));
                    }
                    else
                    {
                        File.Copy(page, Properties.Settings.Default.Root + "\\Manga\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_" + numPage + Path.GetExtension(page));
                        File.Copy(page, Properties.Settings.Default.Root + "\\Temp\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_" + numPage + Path.GetExtension(page));
                    }
                    if (backgroundWorkerCopy.CancellationPending)
                    {
                        backgroundWorkerCopy.Dispose();
                        e.Cancel = true;
                        break;
                    }

                    backgroundWorkerCopy.ReportProgress(0);
                    Thread.Sleep(100);
                }
                backgroundWorkerCopy.ReportProgress(0);
            }
        }

        private void backgroundWorkerCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string dirTempManga = utility.GetPath(pathTemp, nameManga);
            string dirTemp = utility.GetPath(temp, nameChapter);
            string dirManga = utility.GetPath(pathTemp, nameManga, nameChapter);

            progressBarChapter.Maximum = Directory.GetDirectories(temp).Length;
            progressBarChapter.Value = Directory.GetDirectories(dirTempManga).Length - oldNbPage;

            progressBarPage.Value = Directory.GetFiles(dirManga).Length;
            progressBarPage.Maximum = Directory.GetFiles(dirTemp).Length;

            labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum + " copiées";
            labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum + " copiés";
        }

        private void backgroundWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private List<string> Verif(List<string> listIn)
        {
            List<string> list = new();
            foreach (string item in listIn)
            {

                if ((!Path.GetFileNameWithoutExtension(item).Contains("captcha")
                    && !Path.GetFileNameWithoutExtension(item).Contains("google")
                    && !Path.GetFileNameWithoutExtension(item).Contains("go")))
                {
                    list.Add(item);
                }
            }

            return list;
        }

        private void FormDownload_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundWorkerCopy.CancelAsync();
            backgroundWorkerDownload.CancelAsync();

            foreach (string chapter in Directory.GetDirectories(temp))
            {
                utility.DeleteDirectory(chapter);
                utility.DeleteDirectory(pathTemp, nameManga);
                utility.DeleteDirectory(Properties.Settings.Default.Root, "Manga", nameManga, Path.GetFileNameWithoutExtension(chapter));
            }
        }

        private void buttonOpenTemp_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", temp);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //progressBarChapter.Maximum = 222;
            //progressBarPage.Maximum = 81;
            //backgroundWorkerCopy.RunWorkerAsync();
        }


    }
}
