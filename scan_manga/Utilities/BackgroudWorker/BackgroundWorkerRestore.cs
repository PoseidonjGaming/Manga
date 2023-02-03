using scan_manga.Models;
using scan_manga.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackgroundWorkerRestore : BaseBackGroundWorker
    {
        private List<Manga> mangaList;
        private string root;
        private string nameChapter;
        private string pageName;
        private string nameManga;
        private readonly MangaUtility utility;

        public BackgroundWorkerRestore() : base()
        {
            Worker.DoWork += backgroundWorker_DoWork;
            Worker.ProgressChanged += backgroundWorker_ProgressChanged;
            utility = new();
            root = Settings.Default.Root;
        }

        public override void Load()
        {
            if (Settings.Default.Manga != null)
            {
                mangaList = Settings.Default.Manga;
            }

            if (Settings.Default.Root != string.Empty)
            {
                root = Settings.Default.Root;
            }
            progressBarManga.Maximum = mangaList.Count;
            Worker.RunWorkerAsync();
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Manga manga in mangaList)
            {
                if (Directory.Exists(utility.GetPath(root, "Manga", manga.Nom)))
                {
                    Directory.Delete(utility.GetPath(root, "Manga", manga.Nom), true);
                }
            }
            foreach (Manga manga in mangaList)
            {

                nameManga = manga.Nom;
                string[] chapters = Sort(Directory.GetDirectories(utility.GetPath(root, "Backup", manga.Nom)), manga.Nom + " Chapitre ", " ", false);
                foreach (string chapter in chapters)
                {
                    nameChapter = chapter;
                    CreateDirectory(utility.GetPath(root, "Manga", manga.Nom, chapter));
                    foreach (string page in Directory.GetFiles(utility.GetPath(root, "Backup", manga.Nom, chapter)))
                    {
                        string sourcePath = utility.GetPath(root, "Backup", manga.Nom, chapter, Path.GetFileName(page));
                        string targetPath = utility.GetPath(root, "Manga", manga.Nom, chapter, Path.GetFileName(page));
                        File.Copy(sourcePath, targetPath);
                        Worker.ReportProgress(0);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        protected override void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarManga.Value = Directory.GetDirectories(utility.GetPath(root, "Manga")).Length;
            progressBarChapter.Maximum = Directory.GetDirectories(utility.GetPath(root, "Backup", nameManga)).Length;
            progressBarChapter.Value = Directory.GetDirectories(utility.GetPath(root, "Manga", nameManga)).Length;
            progressBarPage.Maximum = Directory.GetFiles(utility.GetPath(root, "Backup", nameManga, nameChapter)).Length;
            progressBarPage.Value = Directory.GetFiles(utility.GetPath(root, "Manga", nameManga, nameChapter)).Length;

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

    }
}
