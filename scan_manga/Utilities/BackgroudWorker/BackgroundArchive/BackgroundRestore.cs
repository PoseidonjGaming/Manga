using scan_manga.Models;
using scan_manga.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundArchive
{
    public class BackgroundRestore : BaseBackGroundWorker
    {
        private List<Manga> mangaList;
        private string nameManga;

        public BackgroundRestore() : base()
        {
            NameWindow = "Restore";
        }

        public override void Load()
        {
            if (Settings.Default.Manga != null)
            {
                mangaList = Settings.Default.Manga;
            }
            ProgressBarManga.Maximum = mangaList.Count;
            ProgressBarPage.Value=ProgressBarPage.Maximum;
            base.Load();
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Manga manga in mangaList)
            {
                MangaUtility.DeleteDirectory(MangaUtility.Root, "Manga", manga.Nom);
            }
            foreach (Manga manga in mangaList)
            {
                nameManga = manga.Nom;
                foreach (string chapter in MangaUtility.Get(MangaUtility.Root, "Backup", manga.Nom))
                {
                    MangaUtility.CreateDirectory(MangaUtility.Root, "Manga", manga.Nom, MangaUtility.GetName(chapter));
                    foreach (string page in MangaUtility.Get(MangaUtility.Root, "Backup", manga.Nom, MangaUtility.GetName(chapter)))
                    {
                        string sourcePath = MangaUtility.GetPath(MangaUtility.Root, "Backup", manga.Nom, MangaUtility.GetName(chapter), Path.GetFileName(page));
                        string targetPath = MangaUtility.GetPath(MangaUtility.Root, "Manga", manga.Nom, MangaUtility.GetName(chapter), Path.GetFileName(page));
                        File.Copy(sourcePath, targetPath);
                        
                    }
                    Worker.ReportProgress(0);
                    Thread.Sleep(100);
                }
            }
        }

        protected override void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarManga.Value = MangaUtility.Get(MangaUtility.Root, "Manga").Length;
            ProgressBarChapter.Maximum = MangaUtility.Get(MangaUtility.Root, "Backup", nameManga).Length;
            ProgressBarChapter.Value = MangaUtility.Get(MangaUtility.Root, "Manga", nameManga).Length;

            LabelChapter.Text = "Backup de " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum;
            LabelManga.Text = "Backup de " + ProgressBarManga.Value + "/" + ProgressBarManga.Maximum;
        }

        

    }
}
