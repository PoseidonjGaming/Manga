﻿using System;
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
                ProgressBarManga.Maximum = 1;
                ProgressBarManga.Value = 1;
                ProgressBarChapter.Value = 1;
                ProgressBarChapter.Maximum = chaptersToDownload.Count;

                ProgressBarPage.Value = 1;
                chaptersToDownload[0].ListScan = Verif(chaptersToDownload[0].ListScan);
                ProgressBarPage.Maximum = chaptersToDownload[0].ListScan.Count;

                LabelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum;
                LabelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum;
                Worker.RunWorkerAsync();
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
                foreach (string page in chapter.ListScan)
                {
                    try
                    {
                        client.DownloadFile(page, MangaUtility.GetPath(temp, chapter.NameChapter, Path.GetFileName(page)));
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
                    || !Path.GetFileNameWithoutExtension(item).Contains("google")
                    || !Path.GetFileNameWithoutExtension(item).Contains("go"))
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
        }
    }
}