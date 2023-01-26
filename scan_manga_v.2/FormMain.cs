using HtmlAgilityPack;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace scan_manga
{
    public partial class FormMain : Form
    {
        private List<string> mangaList = new List<string>();
        private List<Chapter> chapters = new List<Chapter>();
        private string root;
        private Manga manga;
        private string tempdir= Directory.GetCurrentDirectory() + "\\Temp";
        public FormMain()
        {
            InitializeComponent();
            labelChpater.Text = string.Empty;
            if(!(Properties.Settings.Default.Manga is null))
            {
                mangaList=Properties.Settings.Default.Manga;
                comboBoxManga.Items.AddRange(populate().ToArray());
            }
            if(Properties.Settings.Default.Root != string.Empty)
            {
                root=Properties.Settings.Default.Root;
                listBoxManga.Items.AddRange(populate().ToArray());
            }

            
        }

        private void buttonOption_Click(object sender, EventArgs e)
        {
            FormSetting settingsForm = new FormSetting();
            settingsForm.FormClosed+=Settings_FormClosed;
            settingsForm.ShowDialog();
        }
        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxManga.Items.Clear();
            comboBoxManga.Items.AddRange(populate().ToArray());

            listBoxManga.Items.Clear();
            listBoxManga.Items.AddRange(populate().ToArray());
        }

        private List<string> populate()
        {
            List<string> list = new List<string>();
            foreach (string strManga in mangaList)
            {
                Manga manga = JsonConvert.DeserializeObject<Manga>(strManga);
                list.Add(manga.Nom);
            }
            return list;
        }

       

        private void listBoxManga_SelectedValueChanged(object sender, EventArgs e)
        {
            if(listBoxManga.SelectedItem != null)
            {
                listBoxChapter.Items.Clear();
                string dirManga = root + "\\" + listBoxManga.SelectedItem;
                List<float> numChapter = new List<float>();
                string strNum = string.Empty;
                foreach (string chapter in Directory.GetDirectories(dirManga))
                {
                    strNum = Path.GetFileName(chapter).Split(" ")[^1];

                    if (strNum.Contains('.'))
                    {
                        strNum = strNum.Replace('.', ',');
                    }
                    numChapter.Add(float.Parse(strNum));
                }
                numChapter.Sort();
                foreach (float num in numChapter)
                {
                    foreach (string chapter in Directory.GetDirectories(dirManga))
                    {
                        strNum = num.ToString();

                        if (strNum.Contains(','))
                        {
                            strNum = strNum.Replace(',', '.');
                        }

                        if (strNum == chapter.Split(" ")[^1])
                        {
                            listBoxChapter.Items.Add(Path.GetFileName(chapter));
                        }
                    }
                }
            }
            

        }

        private void backgroundWorkerScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int numChapitre = 1;
            string source = manga.Source;
            bool isChapterExist=false;
            try
            {
                HttpClient client = new HttpClient();
                var result = client.GetAsync(source.Replace("[num_chapitre]", numChapitre.ToString())).Result;
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
                isChapterExist=false;
            }

            if (isChapterExist)
            {
                
                do
                {
                    string pathChapter = root + "\\" + manga.Nom + "\\" + manga.Nom + " Chapitre " + numChapitre.ToString();
                    string pathTempChapter = tempdir + "\\" + manga.Nom + " Chapitre " + numChapitre.ToString();
                    string url = source.Replace("[num_chapitre]", numChapitre.ToString());
                    
                    if (!Directory.Exists(pathChapter))
                    {
                        Directory.CreateDirectory(pathTempChapter);
                        List<string> listScanTemp = new List<string>();
                        try
                        {
                            HtmlWeb web = new HtmlWeb();
                            
                            var doc = web.Load(url);
                            var nodes = doc.DocumentNode.SelectSingleNode(manga.XPath);
                            
                            if(nodes != null)
                            {
                                foreach (HtmlNode node in nodes.ChildNodes)
                                {
                                    if (node.Name == "img")
                                    {
                                        
                                        listScanTemp.Add(node.Attributes["data-src"].Value.Replace(manga.ToRemove, string.Empty).Replace("https", "http"));
                                    }
                                }

                                WebClient webClient = new WebClient();
                                
                                webClient.DownloadFile(listScanTemp.First(), pathTempChapter + "\\page_01.jpg");
                                
                                chapters.Add(new Chapter(manga.Nom + " Chapitre " + numChapitre.ToString(), 
                                    listScanTemp));
                                isChapterExist = true;
                            }
                            else
                            {
                                isChapterExist=false;
                                Directory.Delete(pathTempChapter, true);
                            }
                           

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            isChapterExist = false;
                            Directory.Delete(pathTempChapter, true);
                            
                        }
                    }
                    
                   
                    

                    backgroundWorkerScan.ReportProgress(numChapitre);
                    numChapitre++;
                    Thread.Sleep(500);
                } while (isChapterExist);

            }
            
        }

        private void backgroundWorkerScan_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (Directory.Exists(tempdir + "\\" + manga.Nom + " Chapitre " + e.ProgressPercentage.ToString()))
            {
                labelChpater.Text = "Le Chapitre " + e.ProgressPercentage.ToString() + " de " + manga.Nom + " trouvé";
            }
            else if(Directory.Exists(root + "\\" + manga.Nom + "\\" + manga.Nom + " Chapitre " + e.ProgressPercentage.ToString()))
            {
                labelChpater.Text = "Le Chapitre " + e.ProgressPercentage.ToString() + " de " + manga.Nom + " déjà possédé";
            }
        }

        private void backgroundWorkerScan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FormDownload formDownload = new FormDownload();
            formDownload.listChapters=chapters;
            formDownload.nameManga = manga.Nom;
            if(chapters.Count != 0)
            {
                formDownload.ShowDialog();
            }
            
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            
            if(comboBoxManga.SelectedIndex != -1)
            {
                manga = JsonConvert.DeserializeObject<Manga>(mangaList.Find(e => e.Contains(comboBoxManga.SelectedItem.ToString())));
                
                if (!backgroundWorkerScan.IsBusy)
                {
                    backgroundWorkerScan.RunWorkerAsync();
                }
            }
            
            
        }

        private void buttonManage_Click(object sender, EventArgs e)
        {
            FormManage formManage = new FormManage();
            formManage.ShowDialog();
        }

        

        private void buttonRename_Click(object sender, EventArgs e)
        {
            FormRename formRename = new FormRename();
            formRename.ShowDialog();
            
            /*var pages = Directory.GetFiles("E:\\Manga Scan\\Dr Stone\\Dr Stone Chapitre 17");
            foreach(var page in pages)
            {
                MessageBox.Show(page);
            }*/

        }
    }
}