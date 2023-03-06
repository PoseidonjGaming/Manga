using scan_manga.Models;
using scan_manga.Properties;
using System.ComponentModel;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundArchive
{
    public class BackgroundRestore : BaseBackGroundWorker
    {
        private string nameManga;

        public BackgroundRestore() : base()
        {
            NameWindow = "Restore";
        }

        public override void Load()
        {
            ProgressBarManga.Maximum = MangaUtility.Mangas.Count;
            ProgressBarPage.Value = ProgressBarPage.Maximum;
            base.Load();
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string manga in MangaUtility.Get(MangaUtility.Root, "Manga"))
            {
                MangaUtility.DeleteDirectory(manga);
            }
            foreach (Manga manga in MangaUtility.Mangas)
            {
                nameManga = manga.Nom;
                foreach (string chapter in MangaUtility.Get(MangaUtility.Root, "Backup", manga.Nom))
                {
                    MangaUtility.CreateDirectory(MangaUtility.Root, "Manga", manga.Nom, MangaUtility.GetName(chapter));
                    foreach (string page in MangaUtility.Get(chapter))
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
