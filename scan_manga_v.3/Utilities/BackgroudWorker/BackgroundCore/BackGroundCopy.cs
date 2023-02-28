using scan_manga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundCore
{
    public class BackGroundCopy : BackGroundCore
    {
        public BackGroundCopy(string name, List<Chapter> chapters) : base(name, chapters)
        {
            NameWindow = "Copy";
        }
        public override void Load()
        {
            if (!isCancelled)
            {
                ProgressBarManga.Maximum = 1;
                ProgressBarManga.Value = 1;

                ProgressBarChapter.Maximum = chaptersToDownload.Count;
                ProgressBarPage.Maximum = chaptersToDownload[0].ListScan.Count;

                ProgressBarChapter.Value = 0;
                ProgressBarPage.Value = 0;


                LabelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum;
                LabelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum;

                base.Load();

            }
        }

        protected override void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            foreach (string chapter in MangaUtility.Get(temp))
            {
                nameChapter = MangaUtility.GetName(chapter);
                MangaUtility.CreateDirectory(root, "Manga", nameManga,
                    MangaUtility.GetName(chapter));
                MangaUtility.CreateDirectory(pathTemp, nameManga,
                    MangaUtility.GetName(chapter));
                tempChapter = MangaUtility.GetChapter(nameChapter, chaptersToDownload);
                foreach (string page in MangaUtility.Get(chapter))
                {
                    Copy(nameManga, nameChapter, page, "Manga");
                    Copy(nameManga, nameChapter, page, "Temp");
                    Worker.ReportProgress(0);
                    Thread.Sleep(100);
                }
            }
        }

        protected override void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            string dirTempManga = MangaUtility.GetPath(pathTemp, nameManga);
            string dirTemp = MangaUtility.GetPath(temp, nameChapter);
            string dirManga = MangaUtility.GetPath(pathTemp, nameManga, nameChapter);

            ProgressBarChapter.Maximum = Directory.GetDirectories(temp).Length;
            ProgressBarChapter.Value = Directory.GetDirectories(dirTempManga).Length - oldNbPage;

            ProgressBarPage.Value = Directory.GetFiles(dirManga).Length;
            ProgressBarPage.Maximum = Directory.GetFiles(dirTemp).Length;

            LabelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum + " copiées";
            LabelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum + " copiés";
        }

        private void Copy(string nameManga, string nameChapter, string page, string dir)
        {
            File.Copy(page,
            MangaUtility.GetPath(root, dir, nameManga, nameChapter,
            "page_" + MangaUtility.GetNum(page,
            MangaUtility.GetChapter(nameChapter, chaptersToDownload).ListScan,
            p => Path.GetFileNameWithoutExtension(p.Source) == Path.GetFileNameWithoutExtension(page)))
            + Path.GetExtension(page));
        }
    }
}
