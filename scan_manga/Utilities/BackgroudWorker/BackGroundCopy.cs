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
                progressBarManga.Maximum = 1;
                progressBarManga.Value = 1;

                progressBarChapter.Maximum = chaptersToDownload.Count;
                progressBarPage.Maximum = chaptersToDownload[0].ListScan.Count;

                progressBarChapter.Value = 0;
                progressBarPage.Value = 0;


                labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum;
                labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum;

                Worker.RunWorkerAsync();

            }
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            utility.CreateDirectory(pathTemp, nameManga);
            oldNbPage = Directory.GetDirectories(pathTemp + "\\" + nameManga).Length;
            foreach (string strChapter in Directory.GetDirectories(temp))
            {
                nameChapter = Path.GetFileName(strChapter);
                utility.CreateDirectory(Properties.Settings.Default.Root, "Temp", nameManga, nameChapter);
                utility.CreateDirectory(Properties.Settings.Default.Root, "Manga", nameManga, nameChapter);
                Chapter chapter = chaptersToDownload.Where(e => e.NameChapter == nameChapter).First();
                foreach (string page in Directory.GetFiles(strChapter))
                {
                    int numPage = chapter.ListScan.IndexOf(chapter.ListScan.Where(e => Path.GetFileNameWithoutExtension(e) == Path.GetFileNameWithoutExtension(page)).First()) + 1;
                    string dirManga = utility.GetPath(Properties.Settings.Default.Root, "Manga", nameManga, Path.GetFileName(strChapter));
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
            string dirTempManga = utility.GetPath(pathTemp, nameManga);
            string dirTemp = utility.GetPath(temp, nameChapter);
            string dirManga = utility.GetPath(pathTemp, nameManga, nameChapter);

            progressBarChapter.Maximum = Directory.GetDirectories(temp).Length;
            progressBarChapter.Value = Directory.GetDirectories(dirTempManga).Length - oldNbPage;

            progressBarPage.Value = Directory.GetFiles(dirManga).Length;
            progressBarPage.Maximum = Directory.GetFiles(dirTemp).Length;

            labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum + " copiées";
            labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum + " copiés";
        }
    }
}
