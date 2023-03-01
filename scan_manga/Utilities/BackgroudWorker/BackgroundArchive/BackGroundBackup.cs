using scan_manga.Models;
using scan_manga.Properties;
using System.ComponentModel;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundArchive
{
    public class BackGroundBackup : BaseBackGroundWorker
    {
        private List<Manga> mangaList;
        private string nameChapter;
        private string nameManga;

        public BackGroundBackup() : base()
        {
            NameWindow = "Backup";
        }

        public override void Load()
        {
            if (Settings.Default.Manga != null)
            {
                mangaList = Settings.Default.Manga;
            }

            ProgressBarManga.Maximum = mangaList.Count;
            ProgressBarPage.Value = ProgressBarPage.Maximum;
            base.Load();
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Manga manga in mangaList)
            {
                MangaUtility.DeleteDirectory(MangaUtility.Root, "Backup", manga.Nom);
            }
            foreach (Manga manga in mangaList)
            {
                nameManga = manga.Nom;
                foreach (string chapter in MangaUtility.Get(MangaUtility.Root, "Manga", manga.Nom))
                {
                    nameChapter = chapter;
                    MangaUtility.CreateDirectory(MangaUtility.Root, "Backup", manga.Nom, MangaUtility.GetName(chapter));
                    foreach (string page in MangaUtility.Get(MangaUtility.Root, "Manga", manga.Nom, MangaUtility.GetName(chapter)))
                    {
                        if (Worker.CancellationPending)
                        {
                            Worker.Dispose();
                            e.Cancel = true;
                            isCancelled = true;
                            return;
                        }
                        string sourcePath = MangaUtility.GetPath(MangaUtility.Root, "Manga", manga.Nom, MangaUtility.GetName(chapter), Path.GetFileName(page));
                        string targetPath = MangaUtility.GetPath(MangaUtility.Root, "Backup", manga.Nom, MangaUtility.GetName(chapter), Path.GetFileName(page));
                        File.Copy(sourcePath, targetPath);
                        
                    }
                    Worker.ReportProgress(0);
                    Thread.Sleep(100);
                }
            }
        }

        protected override void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarManga.Value = Directory.GetDirectories(MangaUtility.GetPath(MangaUtility.Root, "Backup")).Length;
            ProgressBarChapter.Maximum = Directory.GetDirectories(MangaUtility.GetPath(MangaUtility.Root, "Manga", nameManga)).Length;
            ProgressBarChapter.Value = Directory.GetDirectories(MangaUtility.GetPath(MangaUtility.Root, "Backup", nameManga)).Length;

            LabelChapter.Text = "Backup de " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum;
            LabelManga.Text = "Backup de " + ProgressBarManga.Value + "/" + ProgressBarManga.Maximum;
        }
    }
}
