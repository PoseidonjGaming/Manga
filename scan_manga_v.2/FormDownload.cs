using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga
{
    public partial class FormDownload : Form
    {
        
        public List<Chapter> listChapters = new List<Chapter>();
        private string pathTemp = Properties.Settings.Default.Root + "\\Temp";
        private string temp = Directory.GetCurrentDirectory() + "\\Temp";
        public string nameManga;
        private int maxPage;
        private string nameChapter;
        private int oldNbChapter;

        public FormDownload()
        {
            
            InitializeComponent();
        }

        private void FormDownload_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach(Chapter chapter in listChapters)
            {
                list.Add(chapter.NameChapter);
            }
            

            listBoxTempChapter.Items.AddRange(sort(list).ToArray());
            
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            transfer(listBoxTempChapter, listBoxChapter);
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            transfer(listBoxChapter, listBoxTempChapter);
        }

        

        

        private void listBoxTempChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxTempChapter.SelectedIndex != -1)
            {

                
                pictureBoxScan.ImageLocation = listChapters.Find(e => e.NameChapter == listBoxTempChapter.SelectedItem).FirstScan;
            }
            
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerDownload.IsBusy && listBoxChapter.Items.Count >0)
            {
                progressBarChapter.Maximum = listBoxChapter.Items.Count;
                progressBarChapter.Value = 0;
                maxPage = listChapters.Find(e => e.NameChapter == listBoxChapter.Items[0].ToString()).ListScan.Count;
                progressBarPage.Maximum=maxPage;
                progressBarPage.Value = 1;

                createDirectory(pathTemp + "\\" + nameManga);
                labelChapter.Text = "Chapitre: 1/" + listBoxChapter.Items.Count;
                labelPage.Text= "Page: 1/" + listBoxChapter;

                oldNbChapter = Directory.GetDirectories(pathTemp + "\\" + nameManga).Length;

                backgroundWorkerDownload.RunWorkerAsync();
            }
            else
            {
                labelChapter.Text = "Chapitre: ";
                foreach (string chapter in Directory.GetDirectories(temp))
                {
                    Directory.Delete(chapter, true);
                }
                this.Close();
            }
        }

        private void backgroundWorkerDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            int numScan=0;
            
            foreach (string strChapter in listBoxChapter.Items)
            {

                Chapter chapter = listChapters.Find(e => e.NameChapter == strChapter);
                nameChapter = strChapter;
                createDirectory(pathTemp + "\\" + nameManga + "\\" + chapter.NameChapter);
                maxPage = chapter.ListScan.Count;
                foreach (string scan in chapter.ListScan)
                {
                    string nameFile = chapter.ListScan.IndexOf(scan) + 1 + ".jpg";
                    
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(scan, pathTemp + "\\" + nameManga + "\\" + chapter.NameChapter + "\\page_" + nameFile);

                    }
                    catch
                    {

                    }
                   
                    backgroundWorkerDownload.ReportProgress(0);
                    Thread.Sleep(1000);
                }

                backgroundWorkerDownload.ReportProgress(0);
            }
            
            
        }

        private void backgroundWorkerDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            if(progressBarPage.Value == maxPage)
            {
                progressBarChapter.Value = Directory.GetDirectories(pathTemp + "\\" + nameManga).Length - oldNbChapter;
                progressBarPage.Value = 0;
                
            }
            else
            {
                progressBarPage.Value = Directory.GetFiles(pathTemp + "\\" + nameManga + "\\" + nameChapter).Length;
            }
            progressBarPage.Maximum = maxPage;
            labelChapter.Text= "Chapitre: " +progressBarChapter.Value + "/" + progressBarChapter.Maximum;
            labelPage.Text = "Page: " + progressBarPage.Value + "/" + maxPage;
        }

        private void backgroundWorkerDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarChapter.Value = progressBarChapter.Maximum;
            progressBarPage.Value = progressBarPage.Maximum;
            labelPage.Text = "Page: " + progressBarPage.Value + "/" + progressBarPage.Maximum;

            if(Directory.Exists(pathTemp + "\\" + nameManga))
            {
                if (Directory.GetDirectories(pathTemp + "\\" + nameManga).Length == oldNbChapter + listBoxChapter.Items.Count)
                {
                    createDirectory(Properties.Settings.Default.Root + "\\" + nameManga);
                    foreach (var chapter in Directory.GetDirectories(pathTemp + "\\" + nameManga))
                    {
                        string nameChapter = Path.GetFileName(chapter);
                        createDirectory(Properties.Settings.Default.Root + "\\" + nameManga + "\\" + nameChapter);
                        foreach (var page in Directory.GetFiles(pathTemp + "\\" + nameManga + "\\" + nameChapter))
                        {
                            string namePage = Path.GetFileName(page);
                            File.Copy(page, Properties.Settings.Default.Root + "\\" + nameManga + "\\" + nameChapter + "\\" + namePage, true);
                        }
                    }


                }
            }
            
            foreach (string chapter in Directory.GetDirectories(temp))
            {
                Directory.Delete(chapter, true);
            }


        }

        

        private void buttonSelectAllTemp_Click(object sender, EventArgs e)
        {
            select(listBoxTempChapter, true);
        }

        private void buttonUnSelectAllTemp_Click(object sender, EventArgs e)
        {
            select(listBoxTempChapter, false);
        }
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            select(listBoxChapter, true);
        }

        private void buttonUnSelectAll_Click(object sender, EventArgs e)
        {
            select(listBoxChapter, false);
        }

        private void select(ListBox listBox, bool selectType)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetSelected(i, selectType);
            }
        }

        private List<string> sort(List<string> chapters)
        {
            string strNum = string.Empty;
            List<int> numChapter = new List<int>();
            List<string> list = new List<string>();
            foreach (string chapter in chapters)
            {
                
                strNum = chapter.Split(" ")[^1];
                numChapter.Add(int.Parse(strNum));

            }
            numChapter.Sort();
            foreach (int num in numChapter)
            {
                foreach (string chapter in chapters)
                {
                    strNum = num.ToString();
                    
                    if (strNum == chapter.Split(" ")[^1])
                    {
                        
                        list.Add(chapter);
                    }

                }
            }

            return list;
        }

        private void transfer(ListBox listBoxSource, ListBox listBoxTarget)
        {
            List<string> listSource = new List<string>();
            List<string> listTarget = new List<string>();
            for (int i = 0; i < listBoxSource.SelectedItems.Count; i++)
            {

                listTarget.Add(listBoxSource.SelectedItems[i].ToString());
                

            }
            foreach(string chapter in listBoxSource.Items)
            {
                if (!listBoxSource.SelectedItems.Contains(chapter))
                {
                    listSource.Add(chapter);
                }
            }

            listBoxSource.Items.Clear();
            listBoxSource.Items.AddRange(listSource.ToArray());


            listBoxTarget.Items.AddRange(sort(listTarget).ToArray());
            

        }

        private void createDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void backgroundWorkerCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorkerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            

            
        }

        private void backgroundWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Tous les chapitre ont été archivé");
        }
    }
}
