using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundCopy : BackGroundCore
    {
        public BackGroundCopy() : base()
        {

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


                labelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum;
                labelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum;

                Worker.RunWorkerAsync();

            }
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            MangaUtility.CreateDirectory(pathTemp, nameManga);
            oldNbPage = Directory.GetDirectories(pathTemp + "\\" + nameManga).Length;
            foreach (string strChapter in Directory.GetDirectories(temp))
            {
                nameChapter = Path.GetFileName(strChapter);
                MangaUtility.CreateDirectory(Properties.Settings.Default.Root, "Temp", nameManga, nameChapter);
                MangaUtility.CreateDirectory(Properties.Settings.Default.Root, "Manga", nameManga, nameChapter);
                Chapter chapter = chaptersToDownload.Where(e => e.NameChapter == nameChapter).First();
                foreach (string page in Directory.GetFiles(strChapter))
                {
                    int numPage = chapter.ListScan.IndexOf(chapter.ListScan.Where(e => Path.GetFileNameWithoutExtension(e) == Path.GetFileNameWithoutExtension(page)).First()) + 1;
                    string dirManga = MangaUtility.GetPath(Properties.Settings.Default.Root, "Manga", nameManga, Path.GetFileName(strChapter));
                    if (numPage < 10)
                    {
                        File.Copy(page, Properties.Settings.Default.Root + "\\Manga\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_0" + numPage + Path.GetExtension(page), true);
                        File.Copy(page, Properties.Settings.Default.Root + "\\Temp\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_0" + numPage + Path.GetExtension(page), true);
                    }
                    else
                    {
                        File.Copy(page, Properties.Settings.Default.Root + "\\Manga\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_" + numPage + Path.GetExtension(page), true);
                        File.Copy(page, Properties.Settings.Default.Root + "\\Temp\\" + nameManga + "\\" + Path.GetFileName(strChapter) + "\\page_" + numPage + Path.GetExtension(page), true);
                    }
                    if (Worker.CancellationPending)
                    {
                        Worker.Dispose();
                        e.Cancel = true;
                        isCancelled = true;
                        break;
                    }

                    Worker.ReportProgress(0);
                    Thread.Sleep(500);
                }
            }
        }

        protected override void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string dirTempManga = MangaUtility.GetPath(pathTemp, nameManga);
            string dirTemp = MangaUtility.GetPath(temp, nameChapter);
            string dirManga = MangaUtility.GetPath(pathTemp, nameManga, nameChapter);

            ProgressBarChapter.Maximum = Directory.GetDirectories(temp).Length;
            ProgressBarChapter.Value = Directory.GetDirectories(dirTempManga).Length - oldNbPage;

            ProgressBarPage.Value = Directory.GetFiles(dirManga).Length;
            ProgressBarPage.Maximum = Directory.GetFiles(dirTemp).Length;

            labelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum + " copiées";
            labelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum + " copiés";
        }
    }
}
