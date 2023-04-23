using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundUpload : BaseBackGroundWorker
    {
        private string manga;
        private int nbChapter;
        private int maxPage;
        private string chapter;

        public BackGroundUpload(string manga) : base()
        {
            NameWindow = "Upload";
            this.manga = manga;
        }

        public override void Load()
        {
            if (Directory.Exists(MangaUtility.GetPath(MangaUtility.RootTemp, manga)))
            {
                nbChapter = MangaUtility.Get(MangaUtility.RootTemp, manga).Length;
            }
            ProgressBarManga.Value = 1;
            ProgressBarManga.Maximum = 1;
            ProgressBarChapter.Maximum = MangaUtility.Get(MangaUtility.RootManga, manga).Length;
            ProgressBarPage.Value=ProgressBarPage.Maximum;
            base.Load();
        }

        protected override void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            foreach (string chapter in MangaUtility.GetSortedChapters(MangaUtility.RootManga, manga))
            {
                MangaUtility.CreateDirectory(MangaUtility.RootTemp, manga, chapter);
                this.chapter = chapter;
                maxPage = MangaUtility.Get(MangaUtility.RootManga, manga, chapter).Length;
                foreach (string page in MangaUtility.Get(MangaUtility.RootManga, manga, chapter))
                {
                    File.Copy(page, MangaUtility.GetPath(MangaUtility.RootTemp, manga, chapter, MangaUtility.GetName(page)), true);
                }
                Thread.Sleep(250);
                Worker.ReportProgress(0);
            }
            Process.Start("powershell.exe", "E:\\Manga` Scan\\test_boucle.ps1");
        }

        protected override void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            ProgressBarChapter.Value = MangaUtility.Get(MangaUtility.RootTemp, manga).Length;

            LabelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum + " téléchargées";
            LabelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum + " téléchargés";
            LabelManga.Text = "Manga: 1/1 téléchargés";
        }
    }
}
