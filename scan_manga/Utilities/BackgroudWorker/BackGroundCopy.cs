using scan_manga.Models;
using scan_manga.Properties;
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


                labelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum;
                labelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum;

                base.Load();

            }
        }

        protected override void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            foreach (string chapter in MangaUtility.Get(temp))
            {
                nameChapter=MangaUtility.GetName(chapter);
                MangaUtility.CreateDirectory(root, "Manga", nameManga,
                    MangaUtility.GetName(chapter));
                MangaUtility.CreateDirectory(pathTemp, nameManga,
                    MangaUtility.GetName(chapter));
                tempChapter =  MangaUtility.GetChapter(nameChapter, chaptersToDownload);
                foreach (string page in MangaUtility.Get(chapter))
                {
                    File.Copy(page,
                        MangaUtility.GetPath(root, "Manga", nameManga, nameChapter, 
                        "page_"+MangaUtility.GetNum(page, MangaUtility.GetChapter(nameChapter, chaptersToDownload).ListScan, 
                        p=>Path.GetFileNameWithoutExtension(p.Source)==Path.GetFileNameWithoutExtension(page)))); ;
                    Worker.ReportProgress(0);
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

            labelChapter.Text = "Chapitre: " + ProgressBarChapter.Value + "/" + ProgressBarChapter.Maximum + " copiées";
            labelPage.Text = "Page: " + ProgressBarPage.Value + "/" + ProgressBarPage.Maximum + " copiés";
        }
    }
}
