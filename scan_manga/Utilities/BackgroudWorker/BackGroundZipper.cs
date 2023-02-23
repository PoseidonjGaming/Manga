using scan_manga.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundZipper : BaseBackGroundWorker
    {
        private string SelectedPath;
        private string Manga;
        public BackGroundZipper(string manga) : base()
        {
            Manga = manga;
            NameWindow = "Uploads";
        }

        protected override void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            MangaUtility.CreateDirectory(SelectedPath, "Manga Scan", Manga);
            foreach (string chapter in Directory.GetDirectories(MangaUtility.GetPath(Settings.Default.Root, "Manga", Manga)))
            {
                if (!File.Exists(MangaUtility.GetPath(SelectedPath, "Manga Scan", Manga, Path.GetFileName(chapter) + ".zip")))
                {
                    MangaUtility.CreateDirectory(SelectedPath, "Manga Scan", Manga);
                    ZipFile.CreateFromDirectory(MangaUtility.GetPath(Settings.Default.Root, "Manga", Manga, Path.GetFileName(chapter)), MangaUtility.GetPath(SelectedPath, "Manga Scan", Manga, Path.GetFileName(chapter) + ".zip"));
                }
                Worker.ReportProgress(Directory.GetFiles(chapter).Length);
            }
        }

        protected override void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            ProgressBarPage.Maximum = e.ProgressPercentage;
            ProgressBarPage.Value = e.ProgressPercentage;

            ProgressBarChapter.Maximum = MangaUtility.GetSortedChapters(Settings.Default.Root, "Manga", Manga).Length;
            ProgressBarChapter.Value = MangaUtility.GetSortedChapters(SelectedPath, "Manga Scan", Manga).Length;

        }

        public override void Load()
        {
            FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = folderBrowserDialog.SelectedPath;
                ProgressBarManga.Maximum = 1;
                ProgressBarManga.Value = 1;
                base.Load();
            }
        }
    }
}
