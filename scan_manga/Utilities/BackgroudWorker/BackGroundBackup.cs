using scan_manga.Models;
using scan_manga.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundBackup : BaseBackGroundWorker
    {
        private List<Manga> mangaList;
        private string root;
        private string nameChapter;
        private string pageName;
        private string nameManga;
        private readonly MangaUtility utility;

        public BackGroundBackup() : base()
        {
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
                if (Directory.Exists(MangaUtility.GetPath(root, "Backup", manga.Nom)))
                {
                    Directory.Delete(MangaUtility.GetPath(root, "Backup", manga.Nom), true);
                }
            }
            foreach (Manga manga in mangaList)
            {

                nameManga = manga.Nom;
                string[] chapters = Sort(Directory.GetDirectories(MangaUtility.GetPath(root, "Manga", manga.Nom)), manga.Nom + " Chapitre ", " ", false);
                foreach (string chapter in chapters)
                {
                    nameChapter = chapter;
                    CreateDirectory(MangaUtility.GetPath(root, "Backup", manga.Nom, chapter));
                    foreach (string page in Directory.GetFiles(MangaUtility.GetPath(root, "Manga", manga.Nom, chapter)))
                    {
                        string sourcePath = MangaUtility.GetPath(root, "Manga", manga.Nom, chapter, Path.GetFileName(page));
                        string targetPath = MangaUtility.GetPath(root, "Backup", manga.Nom, chapter, Path.GetFileName(page));
                        File.Copy(sourcePath, targetPath);
                        Worker.ReportProgress(0);
                        Thread.Sleep(100);
                    }
                }
            }
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

        protected override void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarManga.Value = Directory.GetDirectories(MangaUtility.GetPath(root, "Backup")).Length;
            ProgressBarChapter.Maximum = Directory.GetDirectories(MangaUtility.GetPath(root, "Manga", nameManga)).Length;
            ProgressBarChapter.Value = Directory.GetDirectories(MangaUtility.GetPath(root, "Backup", nameManga)).Length;
            ProgressBarPage.Maximum = Directory.GetFiles(MangaUtility.GetPath(root, "Manga", nameManga, nameChapter)).Length;
            ProgressBarPage.Value = Directory.GetFiles(MangaUtility.GetPath(root, "Backup", nameManga, nameChapter)).Length;

            labelChapter.Text = "Backup de " + progressBarChapter.Value + "/" + progressBarChapter.Maximum;
            labelPage.Text = "Backup de " + progressBarPage.Value + "/" + progressBarPage.Maximum;
            labelManga.Text = "Backup de " + progressBarManga.Value + "/" + progressBarManga.Maximum;
        }
    }
}
