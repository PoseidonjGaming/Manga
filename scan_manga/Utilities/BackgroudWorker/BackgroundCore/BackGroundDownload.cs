using scan_manga.Models;
using System.ComponentModel;
using System.Net;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundCore
{
    public class BackGroundDownload : BackGroundCore
    {
        public BackGroundDownload(string name, List<Chapter> chapters) : base(name, chapters)
        {
            NameWindow = "Download";
        }

        public override void Load()
        {
            if (chaptersToDownload.Count > 0)
            {
                ProgressBarManga.Maximum = 1;
                ProgressBarManga.Value = 1;
                ProgressBarChapter.Value = 1;
                ProgressBarChapter.Maximum = chaptersToDownload.Count;

                ProgressBarPage.Value = 1;
                chaptersToDownload[0].ListScan = Verif(chaptersToDownload[0].ListScan);
                ProgressBarPage.Maximum = chaptersToDownload[0].ListScan.Count;

                LabelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum;
                LabelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum;
                base.Load();
            }
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient client = new();
            foreach (Chapter chapter in chaptersToDownload)
            {
                tempChapter = chapter;
                chapter.ListScan = Verif(chapter.ListScan);
                maxPage = chapter.ListScan.Count;

                MangaUtility.CreateDirectory(temp, chapter.NameChapter);
                foreach (Page page in chapter.ListScan)
                {
                    try
                    {
                        client.DownloadFile(page.Source,
                            MangaUtility.GetTempPath(temp, chapter.NameChapter, page.Source));
                        if (Worker.CancellationPending)
                        {
                            Worker.Dispose();
                            client.Dispose();
                            e.Cancel = true;
                            isCancelled = true;
                            break;
                        }
                    }
                    catch
                    {

                    }

                    Worker.ReportProgress(0);
                    Thread.Sleep(100);
                }
            }
        }

        private static List<Page> Verif(List<Page> listIn)
        {
            List<Page> list = new();
            foreach (Page item in listIn)
            {
                if (!Path.GetFileNameWithoutExtension(item.Source).Contains("captcha")
                    && !Path.GetFileNameWithoutExtension(item.Source).Contains("google")
                    && !Path.GetFileNameWithoutExtension(item.Source).Contains("go")
                    && list.Where(e => Path.GetFileNameWithoutExtension(e.Source) == Path.GetFileNameWithoutExtension(item.Source)).FirstOrDefault() == null)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        protected override void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarChapter.Value = Directory.GetDirectories(temp).Length;
            ProgressBarPage.Maximum = maxPage;

            if (Directory.Exists(temp + "\\" + tempChapter.NameChapter))
            {
                ProgressBarPage.Value = Directory.GetFiles(temp + "\\" + tempChapter.NameChapter).Length;
            }
            else
            {
                ProgressBarPage.Value = 0;
            }

            LabelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum + " téléchargées";
            LabelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum + " téléchargés";
            LabelManga.Text = "Manga: 1/1 téléchargés";
        }
    }
}
