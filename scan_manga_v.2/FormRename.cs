using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga
{

    public partial class FormRename : Form
    {
        private string root;
        private List<Manga> files = new List<Manga>();
        private string path;
        private int maxManga;
        private int maxChapter;
        private int maxPage;

        public FormRename()
        {
            InitializeComponent();
        }

        private void comboBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxManga.SelectedIndex != -1)
            {
                comboBoxChapter.Items.Clear();
                var listChapitre = Directory.GetDirectories(root + "\\" + comboBoxManga.Text);
                List<string> tempList = new List<string>();
                foreach (string chapitre in listChapitre)
                {
                    string nameChapitre = Path.GetFileNameWithoutExtension(chapitre);
                    tempList.Add(nameChapitre);
                }
                comboBoxChapter.Items.AddRange(sort(tempList, " ", comboBoxManga.Text + " Chapitre ").ToArray());
                comboBoxChapter.SelectedIndex = 0;

            }
        }

        private void FormRename_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Root != null)
            {
                root = Properties.Settings.Default.Root;
            }
            if (Properties.Settings.Default.Manga != null)
            {
                foreach (string manga in Properties.Settings.Default.Manga)
                {
                    files.Add(JsonConvert.DeserializeObject<Manga>(manga));
                }
                foreach(Manga manga in files)
                {
                    comboBoxManga.Items.Add(manga.Nom);
                }
            }
            
            
        }

        private List<string> sort(List<string> listIn, string split, string toSearch)
        {
            List<string> listOut = new List<string>();
            List<float> listIndex = new List<float>();
            foreach (string item in listIn)
            {
                string strNum = Path.GetFileNameWithoutExtension(item).Split(split).Last();
                if (strNum.Contains('.'))
                {
                    strNum = strNum.Replace(".", ",");

                }

                float num = float.Parse(strNum);
                listIndex.Add(num);
            }
            listIndex.Sort();
            foreach (float index in listIndex)
            {
                string strNum = index.ToString();
                if (strNum.Contains(','))
                {
                    strNum = strNum.Replace(",", ".");

                }

                listOut.Add(listIn.Find(e => float.Parse(Path.GetFileNameWithoutExtension(e).Split(split).Last()) == index));
            }

            return listOut;
        }

        private void comboBoxChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChapter.SelectedIndex != -1)
            {
                var listPages = Directory.GetFiles(root + "\\" + comboBoxManga.Text + "\\" + comboBoxChapter.Text);
                listBoxPage.Items.Clear();
                foreach (string page in listPages)
                {
                    string namePage = Path.GetFileName(page);
                    listBoxPage.Items.Add(namePage);
                }
                path= root + "\\" + comboBoxManga.Text + "\\" + comboBoxChapter.Text;
                Manga manga =files.Find(e=> e.Nom == comboBoxManga.Text);
                listBoxRename.Items.Clear();
                if (manga.Chapters != null)
                {
                    if(manga.Chapters.Count > 0)
                    {
                        Chapter chapter = manga.Chapters.Find(e => e.NameChapter == comboBoxManga.Text + "_" + comboBoxChapter.Text);

                        if (chapter != null)
                        {
                            
                            foreach (string page in chapter.ListScan)
                            {
                                listBoxRename.Items.Add(page);
                            }
                        }
                    }
                    


                }
                
            }
        }

        private void listBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPage.SelectedIndex != -1)
            {
                path = root + "\\" + comboBoxManga.Text + "\\" + comboBoxChapter.Text + "\\";
                
                pictureBoxScan.ImageLocation = path + listBoxPage.SelectedItem;
                textBoxRename.Text = Path.GetFileNameWithoutExtension(root + "\\" + comboBoxManga.Text + "\\" + comboBoxChapter.Text + "\\" + listBoxPage.SelectedItem);
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (listBoxPage.SelectedIndex != -1)
            {
                Manga manga = files.Find(e => e.Nom == comboBoxManga.Text);
                if(manga.Chapters == null)
                {
                    manga.Chapters = new List<Chapter>();
                }
                Chapter chapter = manga.Chapters.Find(e => e.NameChapter ==  comboBoxManga.Text + "_" + comboBoxChapter.Text);
                
                if (chapter is null)
                {
                    chapter = new Chapter();
                    chapter.NameChapter = comboBoxManga.Text + "_" + comboBoxChapter.Text;
                    chapter.ListScan.Add(listBoxPage.SelectedItem + " -> " + textBoxRename.Text + Path.GetExtension(path + listBoxPage.SelectedItem));
                    chapter.setFirstScan();
                    manga.Chapters.Add(chapter);
                    
                }
                else
                {
                    manga.Chapters.Remove(manga.Chapters.Find(e => e.NameChapter == comboBoxManga.Text + "_" + comboBoxChapter.Text));
                    chapter.ListScan.Add(listBoxPage.SelectedItem + " -> " + textBoxRename.Text + Path.GetExtension(path + listBoxPage.SelectedItem));
                    manga.Chapters.Add(chapter);
                }
                
                files.RemoveAt(files.IndexOf(files.Find(e=> e.Nom == comboBoxManga.Text)));
                files.Add(manga);
                listBoxRename.Items.Add(listBoxPage.SelectedItem + " -> " + textBoxRename.Text + Path.GetExtension(path + listBoxPage.SelectedItem));

            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerRename.IsBusy && files.Count>0)
            {
               
                List<Manga> list= new List<Manga>();
                foreach(Manga manga in files)
                {
                    if(manga.Chapters != null)
                    {
                        if(manga.Chapters.Count > 0)
                        {
                            
                            list.Add(manga);
                        }
                       
                    }
                }
                files = list;
                progressBarManga.Maximum= list.Count;
                progressBarManga.Value = 1;
                progressBarChapter.Value = 1;
                progressBarChapter.Maximum = files[0].Chapters.Count;
                progressBarPage.Value = 1;
                progressBarPage.Maximum = files[0].Chapters[0].ListScan.Count;

                labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum + " copiées";
                labelChapter.Text = "Chapter: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum + " traités";
                labelManga.Text = "Manga: " + progressBarManga.Value + "/" + progressBarManga.Maximum + " traités";

                backgroundWorkerRename.RunWorkerAsync();
            }
        }

        private void createDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void buttonSup_Click(object sender, EventArgs e)
        {
            if(listBoxRename.SelectedIndex != -1)
            {
                Manga manga = files.Find(e => e.Nom == comboBoxManga.Text);
                Chapter chapter = manga.Chapters.Find(e=> e.NameChapter == comboBoxManga.Text + "_" + comboBoxChapter.Text);
                chapter.ListScan.RemoveAt(listBoxRename.SelectedIndex);
                listBoxRename.Items.RemoveAt(listBoxRename.SelectedIndex);
                
            }
        }

        private void backgroundWorkerRename_DoWork(object sender, DoWorkEventArgs e)
        {

            foreach(Manga manga in files)
            {
                if(manga.Chapters.Count >0)
                {
                    maxChapter = manga.Chapters.Count;
                    foreach (Chapter chapter in manga.Chapters)
                    {
                        string nameManga = chapter.NameChapter.Split('_').First();
                        string nameChapter = chapter.NameChapter.Split('_').Last();
                        path = root + "\\" + nameManga + "\\" + nameChapter;
                        maxPage = chapter.ListScan.Count;
                        foreach (string page in chapter.ListScan)
                        {
                            
                            File.Move(path + "\\" +  page.Split(" -> ").First(), path + "\\" + page.Split(" -> ").Last(), true);
                            
                            backgroundWorkerRename.ReportProgress(0);
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
            

           

        }

        private void backgroundWorkerRename_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            update();
            labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum + " copiées";
            labelChapter.Text = "Chapter: " + progressBarChapter.Value + "/" + progressBarChapter.Maximum + " traités";
            labelManga.Text = "Manga: " + progressBarManga.Value + "/" + progressBarManga.Maximum + " traités";
        }

        private void update()
        {
            if (progressBarPage.Value == progressBarPage.Maximum)
            {
                progressBarPage.Value = 1;
                int numChapter = progressBarPage.Value;
                if (numChapter++ >= progressBarPage.Minimum)
                {
                    progressBarChapter.Value = progressBarChapter.Maximum;
                }
                else
                {
                    progressBarChapter.Value++;
                    progressBarPage.Maximum = maxPage;
                }

            }
            else
            {
                progressBarPage.Value++;
            }

            if (progressBarChapter.Value == progressBarChapter.Maximum)
            {
                progressBarChapter.Value = 1;
                int numManga = progressBarManga.Value;
                if (numManga++ >= progressBarManga.Maximum)
                {
                    progressBarManga.Value = progressBarManga.Maximum;
                }
                else
                {
                    progressBarManga.Value++;
                    progressBarChapter.Maximum = maxChapter;
                }

            }
        }

       

        private void backgroundWorkerRename_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarChapter.Value = progressBarChapter.Maximum;
            progressBarManga.Value = progressBarManga.Maximum;
            progressBarPage.Value = progressBarPage.Maximum;

            foreach (Manga manga in files)
            {
                foreach (Chapter chapter in manga.Chapters)
                {
                    string nameManga = chapter.NameChapter.Split('_').First();
                    string nameChapter = chapter.NameChapter.Split('_').Last();
                    createDirectory(root + "\\Temp\\" + nameManga);
                    createDirectory(root + "\\Temp\\" + nameManga + "\\" + nameChapter);

                    var pages = Directory.GetFiles(root + "\\" + nameManga + "\\" + nameChapter);

                    foreach (string currentPage in pages)
                    {
                        string newPage = currentPage;

                        File.Copy(newPage, root + "\\Temp\\" + nameManga + "\\" + nameChapter + "\\" + Path.GetFileName(newPage), true);
                        
                        Thread.Sleep(1000);
                    }
                }
                MessageBox.Show("Toutes les pages ont été copiées");
            }
        }

        
    }
}
