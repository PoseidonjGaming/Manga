using HtmlAgilityPack;
using scan_manga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundScan : BaseBackGroundWorker
    {
        private int numChapitre;
        private string chapitre;
        private readonly Manga manga;
        private readonly string root;
        private readonly string tempdir;
        private readonly List<Chapter> chapters;

        public BackGroundScan(string tempDir, string root, Manga manga) : base()
        {
            NameWindow = "Scan";
            this.tempdir = tempDir;
            this.root = root;
            this.manga = manga;
            chapters = new();
            numChapitre = 1;
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
            string source = manga.Source;
            bool isChapterExist;

            try
            {
                HttpClient client = new();
                var result = client.GetAsync(source.Replace("[num_chapitre]", "1")).Result;
                if (result.IsSuccessStatusCode)
                {
                    isChapterExist = true;
                }
                else
                {
                    isChapterExist = false;
                }
            }
            catch
            {
                isChapterExist = false;
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
                    string pathChapter = MangaUtility.GetPath(root, "Manga", manga.Nom, manga.Nom + " Chapitre " + numChapitre.ToString());
                    string url = source.Replace("[num_chapitre]", numChapitre.ToString());

                    if (!Directory.Exists(pathChapter))
                    {

                        List<Page> listScanTemp = new();
                        try
                        {
                            HttpClient client = new();
                            var result = client.GetAsync(source.Replace("[num_chapitre]", numChapitre.ToString())).Result;
                            if (result.IsSuccessStatusCode)
                            {
                                isChapterExist = true;
                                try
                                {
                                    HtmlWeb web = new();

                                    var doc = web.Load(url);
                                    var nodes = doc.DocumentNode.Descendants("img");

                                    foreach (HtmlNode node in nodes)
                                    {

                                        if (node.Attributes["data-src"] != null)
                                        {
                                            listScanTemp.Add(new(node.Attributes["data-src"].Value,
                                                MangaUtility.GetPath(tempdir, "Manga", manga.Nom,
                                                manga.Nom + " Chapitre " + numChapitre)));
                                        }
                                        else
                                        {
                                            listScanTemp.Add(new(node.Attributes["src"].Value,
                                                MangaUtility.GetPath(tempdir, "Manga", manga.Nom,
                                                manga.Nom + " Chapitre " + numChapitre)));
                                        }
                                    }
                                    chapters.Add(new Chapter(manga.Nom + " Chapitre " + numChapitre,
                                        listScanTemp));
                                    isChapterExist = true;


                                }
                                catch
                                {

                                    isChapterExist = false;


                                }
                            }
                            else
                            {
                                isChapterExist = false;
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }

                    Worker.ReportProgress(chapters.Count);

                    Thread.Sleep(100);
                    numChapitre++;
                } while (isChapterExist && numChapitre<=3);
                numChapitre = 0;
            }
        }

        protected override void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if (Directory.Exists(MangaUtility.GetPath(root, "Manga", manga.Nom, manga.Nom + " Chapitre " + numChapitre)))
            {
                labelChapter.Text = "Le Chapitre " + numChapitre.ToString() + " de " + manga.Nom + " est déjà possédé";
            }
            else if (e.ProgressPercentage > 0)
            {
                if (chapters.Last().NameChapter == manga.Nom + " Chapitre " + numChapitre.ToString())
                {
                    labelChapter.Text = "Le Chapitre " + numChapitre.ToString() + " de " + manga.Nom + " a été trouvé";
                }
            }
        }

        private void Clear()
        {
            foreach (string chapter in Directory.GetDirectories(tempdir))
            {
                Directory.Delete(chapter, true);
            }
        }

        public List<Chapter> GetChapters()
        {
            return chapters;
        }
    }
}
