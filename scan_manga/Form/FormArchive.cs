using Newtonsoft.Json;
using scan_manga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga
{
    public partial class FormArchive : Form
    {
        private List<Manga> mangaList;
        private int maxPages;
        private int maxChapters;
        private string root;
        private string nameChapter;
        private string pageName;
        private string nameManga;

        private readonly string SourcePath;
        private readonly string TargetPath;
        public FormArchive(string sourcePath, string targetPath)
        {
            InitializeComponent();
            SourcePath = sourcePath;
            TargetPath = targetPath;
        }
        private void FormArchive_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Manga != null)
            {
                mangaList = Properties.Settings.Default.Manga;
            }

            if (Properties.Settings.Default.Root != string.Empty)
            {
                root = Properties.Settings.Default.Root;
            }
            progressBarManga.Maximum = mangaList.Count;
            backgroundWorker.RunWorkerAsync();

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach(Manga manga in mangaList)
            {
                if (Directory.Exists(root + TargetPath + manga.Nom))
                {
                    Directory.Delete(root + TargetPath + manga.Nom, true);
                }
            }
            foreach (Manga manga in mangaList)
            {
                
                nameManga = manga.Nom;
                string[] chapters = Sort(Directory.GetDirectories(root + SourcePath + manga.Nom), manga.Nom + " Chapitre ", " ", false);
                foreach (string chapter in chapters)
                {
                    nameChapter = chapter;
                    string[] pages = Sort(Directory.GetFiles(root + SourcePath + manga.Nom + "\\" + chapter), "page_", "_", true);
                    string[] pagesWithExt = Directory.GetFiles(root + SourcePath + manga.Nom + "\\" + chapter);
                    CreateDirectory(root + TargetPath + manga.Nom + "\\" + chapter);
                    foreach (string page in pages)
                    {
                        string pageWithExt = pagesWithExt.Where(p => Path.GetFileNameWithoutExtension(p) == Path.GetFileNameWithoutExtension(page)).First();
                        File.Copy(root + SourcePath + manga.Nom + "\\" + chapter + "\\" + Path.GetFileName(pageWithExt), root + TargetPath + manga.Nom + "\\" + chapter + "\\" + Path.GetFileName(pageWithExt));
                        backgroundWorker.ReportProgress(0);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarManga.Value = Directory.GetDirectories(root + "\\" + TargetPath).Length;
            progressBarChapter.Maximum = Directory.GetDirectories(root + "\\" + SourcePath + "\\" + nameManga).Length;
            progressBarChapter.Value = Directory.GetDirectories(root + "\\" + TargetPath + "\\" + nameManga).Length;
            progressBarPage.Maximum = Directory.GetFiles(root + "\\" + SourcePath + "\\" + nameManga + "\\" + nameChapter).Length;
            progressBarPage.Value = Directory.GetFiles(root + TargetPath + nameManga + "\\" + nameChapter).Length;

            labelChapter.Text = "Backup de " + progressBarChapter.Value + "/" + progressBarChapter.Maximum;
            labelPage.Text = "Backup de " + progressBarPage.Value + "/" + progressBarPage.Maximum;
            labelManga.Text = "Backup de " + progressBarManga.Value + "/" + progressBarManga.Maximum;
        }
        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string[] Sort(string[] listIn, string toAdd, string split, bool page)
        {
            List<float> numChapter = new List<float>();
            List<string> listOut = new List<string>();
            foreach (string chapter in listIn)
            {
                string strNum = Path.GetFileName(chapter).Split(split)[^1];

                if (chapter.Contains('.'))
                {

                    strNum = strNum.Replace('.', ',');
                }

                if (float.TryParse(strNum, out float fl))
                {
                    numChapter.Add(fl);
                }
                else
                {
                    numChapter.Add(float.Parse(strNum.Split(',')[0]));
                }

            }


            numChapter.Sort();
            foreach (float num in numChapter)
            {
                string strNum = num.ToString();
                if (strNum.Contains(','))
                {
                    strNum = strNum.Replace(',', '.');
                }

                if (num < 10 && page)
                {
                    listOut.Add(toAdd + "0" + strNum);
                }
                else
                {
                    listOut.Add(toAdd + strNum);
                }

            }
            return listOut.ToArray();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
