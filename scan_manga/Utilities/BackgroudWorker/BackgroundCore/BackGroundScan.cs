using HtmlAgilityPack;
using scan_manga.Models;
using System.ComponentModel;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundCore
{
    public class BackGroundScan : BaseBackGroundWorker
    {
        private int numChapitre;
        private readonly Manga manga;
        private readonly string root;
        private readonly string tempdir;
        private List<Chapter> chapters;
        private bool scanAll;

        public BackGroundScan(string tempDir, string root, Manga manga,
            bool scanAll, int num = 1) : base()
        {
            NameWindow = "Scan";
            tempdir = tempDir;
            this.root = root;
            this.manga = manga;
            chapters = new();
            numChapitre = num;
            this.scanAll = scanAll;
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
            bool isChapterExist;
            HttpClient client = new();
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

                    string pathChapter = MangaUtility.GetPath(root, "Manga", manga.Nom,
                        manga.Nom + " Chapitre " + numChapitre.ToString());
                    string url = ReplaceNum(numChapitre);

                    if (!Directory.Exists(pathChapter))
                    {
                        List<Page> pages = new();
                        string nameChapter = GetNameChapter(manga.Nom, " Chapitre ", numChapitre.ToString());
                        HttpResponseMessage result = client.GetAsync(url).Result;
                        if (result.IsSuccessStatusCode)
                        {
                            try
                            {
                                HtmlWeb web = new();
                                HtmlDocument doc = web.Load(url);
                                IEnumerable<HtmlNode> nodes = doc.DocumentNode.Descendants("img");
                                if(doc.ParsedText.Equals(manga.HomePage))
                                {
                                    foreach (HtmlNode node in nodes)
                                    {
                                        if (node.Attributes["data-src"] != null)
                                        {
                                            pages.Add(new(node.Attributes["data-src"].Value,
                                                MangaUtility.GetPath(tempdir, "Manga", manga.Nom,
                                                nameChapter)));
                                        }
                                        else if (node.Attributes["src"] != null)
                                        {
                                            pages.Add(new(node.Attributes["src"].Value,
                                                MangaUtility.GetPath(tempdir, "Manga", manga.Nom,
                                                nameChapter)));
                                        }
                                    }
                                    chapters.Add(new(nameChapter, pages));
                                }
                                else
                                {
                                    throw new ArgumentNullException("la page n'a pas été trouvée et/ou redi");
                                }
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
                    
                    Worker.ReportProgress(chapters.Count);
                    Thread.Sleep(100);
                    numChapitre++;
                } while (scanAll && isChapterExist);
            }

        }

        protected override void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if (Directory.Exists(MangaUtility.GetPath(root, "Manga", manga.Nom, manga.Nom + " Chapitre " + numChapitre)))
            {
                LabelChapter.Text = "Le Chapitre " + numChapitre.ToString() + " de " + manga.Nom + " est déjà possédé";
            }
            else if (e.ProgressPercentage > 0)
            {
                if (chapters.Last().NameChapter == manga.Nom + " Chapitre " + numChapitre.ToString())
                {
                    LabelChapter.Text = "Le Chapitre " + numChapitre.ToString() + " de " + manga.Nom + " a été trouvé";
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

        private string ReplaceNum(int num)
        {
            return manga.Source.Replace("[num_chapitre]", num.ToString());
        }

        private string GetNameChapter(params string[] parts)
        {
            return String.Concat(parts);
        }
    }
}
