using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundDownload: BackGroundCore
    {
        public BackGroundDownload():base()
        {
            
        }

        public override void Load()
        {
            MessageBox.Show(chaptersToDownload.Count.ToString());
            if (chaptersToDownload.Count > 0)
            {
                progressBarManga.Maximum = 1;
                progressBarManga.Value = 1;
                progressBarChapter.Value = 1;
                progressBarChapter.Maximum = chaptersToDownload.Count;

                progressBarPage.Value = 1;
                chaptersToDownload[0].ListScan = Verif(chaptersToDownload[0].ListScan);
                progressBarPage.Maximum = chaptersToDownload[0].ListScan.Count;

                labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum;
                labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum;
                Worker.RunWorkerAsync();
            }
        }

        protected override void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Chapter chapter in chaptersToDownload)
            {
                tempChapter = chapter;
                chapter.ListScan = Verif(chapter.ListScan);
                maxPage = chapter.ListScan.Count;
                WebClient client = new();
                utility.CreateDirectory(temp, chapter.NameChapter);
                foreach (string page in chapter.ListScan)
                {
                    try
                    {
                        client.DownloadFile(page, utility.GetPath(temp, chapter.NameChapter, Path.GetFileName(page)));
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
                Worker.ReportProgress(0);
            }
        }

        private List<string> Verif(List<string> listIn)
        {
            List<string> list = new();
            foreach (string item in listIn)
            {

                if (!Path.GetFileNameWithoutExtension(item).Contains("captcha")
                    && !Path.GetFileNameWithoutExtension(item).Contains("google")
                    && !Path.GetFileNameWithoutExtension(item).Contains("go")
                    && list.Where(e => Path.GetFileNameWithoutExtension(e) == Path.GetFileNameWithoutExtension(item)).FirstOrDefault() == null)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        protected override void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarChapter.Value = Directory.GetDirectories(temp).Length;
            progressBarPage.Maximum = maxPage;

            if (Directory.Exists(temp + "\\" + tempChapter.NameChapter))
            {
                progressBarPage.Value = Directory.GetFiles(temp + "\\" + tempChapter.NameChapter).Length;
            }
            else
            {
                progressBarPage.Value = 0;
            }

            labelChapter.Text = "Chapitre: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum + " téléchargées";
            labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum + " téléchargés";
        }
    }
}
