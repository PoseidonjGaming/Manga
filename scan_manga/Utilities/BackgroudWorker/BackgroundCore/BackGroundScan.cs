using HtmlAgilityPack;
using scan_manga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundCore
{
    public class BackGroundScan : BaseBackGroundWorker
    {
        private int NumChapitre;
        private readonly Manga Manga;
        private readonly List<Chapter> Chapters;
        private readonly bool ScanAll;
        private string Source;

        public BackGroundScan(Manga manga, string source, bool scanAll, int num = 1) : base()
        {
            NameWindow = "Scan";
            Manga = manga;
            Chapters = new();
            NumChapitre = num;
            ScanAll = scanAll;
            Source = source;
        }

        public override void Load()
        {
            Clear();
            ProgressBarChapter.Value = ProgressBarChapter.Maximum;
            ProgressBarManga.Value = ProgressBarManga.Maximum;
            ProgressBarPage.Value = ProgressBarPage.Maximum;
            base.Load();
        }

        protected override void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            HttpClient client = new();
            bool isChapterExist;
            try
            {

                HttpResponseMessage result = client.GetAsync(ReplaceNum(1)).Result;
                if (result.IsSuccessStatusCode)
                {
                    isChapterExist = true;
                }
                else
                {
                    isChapterExist = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (isChapterExist)
            {
                do
                {
                    if (Worker.CancellationPending)
                    {
                        Worker.Dispose();
                        e.Cancel = true;
                        isCancelled = true;
                        break;
                    }

                    string pathChapter = MangaUtility.GetPath(MangaUtility.Root, "Manga", Manga.Nom,
                        Manga.Nom + " Chapitre " + NumChapitre.ToString());
                    string url = ReplaceNum(NumChapitre);

                    if (!Directory.Exists(pathChapter))
                    {
                        List<Page> pages = new();
                        string nameChapter = GetNameChapter(Manga.Nom, " Chapitre ", NumChapitre.ToString());
                        HttpResponseMessage result = client.GetAsync(url).Result;
                        if (result.IsSuccessStatusCode)
                        {


                            try
                            {
                                HtmlWeb web = new();
                                HtmlDocument doc = web.Load(url);
                                IEnumerable<HtmlNode> nodes = doc.DocumentNode.Descendants("img");

                                foreach (HtmlNode node in nodes)
                                {
                                    if (node.Attributes["data-src"] != null)
                                    {
                                        pages.Add(new(node.Attributes["data-src"].Value,
                                            MangaUtility.GetPath(MangaUtility.Temp, "Manga", Manga.Nom,
                                            nameChapter)));
                                    }
                                    else if (node.Attributes["src"] != null)
                                    {
                                        pages.Add(new(node.Attributes["src"].Value,
                                            MangaUtility.GetPath(MangaUtility.Temp, "Manga", Manga.Nom,
                                            nameChapter)));
                                    }
                                }
                                Chapters.Add(new(nameChapter, pages));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                isChapterExist = false;
                            }
                        }
                        else
                        {
                            isChapterExist = false;
                        }
                    }

                    Worker.ReportProgress(Chapters.Count);
                    Thread.Sleep(100);
                    NumChapitre++;
                } while (ScanAll && isChapterExist && NumChapitre<=3);
            }

        }

        protected override void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if (Directory.Exists(MangaUtility.GetPath(MangaUtility.Root, "Manga", Manga.Nom, Manga.Nom + " Chapitre " + NumChapitre)))
            {
                LabelChapter.Text = "Le Chapitre " + NumChapitre.ToString() + " de " + Manga.Nom + " est déjà possédé";
            }
            else if (e.ProgressPercentage > 0)
            {
                if (Chapters.Last().NameChapter == Manga.Nom + " Chapitre " + NumChapitre.ToString())
                {
                    LabelChapter.Text = "Le Chapitre " + NumChapitre.ToString() + " de " + Manga.Nom + " a été trouvé";
                }
            }
        }

        private void Clear()
        {
            foreach (string chapter in Directory.GetDirectories(MangaUtility.Temp))
            {
                Directory.Delete(chapter, true);
            }
        }

        public List<Chapter> GetChapters()
        {
            return Chapters;
        }

        private string ReplaceNum(int num)
        {
            return Source.Replace("[num_chapitre]", num.ToString());
        }

        private string GetNameChapter(params string[] parts)
        {
            return String.Concat(parts);
        }
    }
}
