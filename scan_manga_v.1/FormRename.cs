using scan_manga_v._1.Properties;
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
        private List<Chapter> files = new List<Chapter>();
        private int oldNbChapter;
        private string path;

        public FormRename()
        {
            InitializeComponent();
            if (Settings.Default.Root != null)
            {
                root = Settings.Default.Root;
            }
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
            var listManga = Directory.GetDirectories(root);
            foreach (string manga in listManga)
            {
                string nomManga = Path.GetFileNameWithoutExtension(manga);
                if (nomManga != "Temp")
                {
                    comboBoxManga.Items.Add(nomManga);
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
            foreach (int index in listIndex)
            {
                string strNum = index.ToString();
                if (strNum.Contains(','))
                {
                    strNum = strNum.Replace(",", ".");

                }

                listOut.Add(listIn.Find(e => Path.GetFileNameWithoutExtension(e) == toSearch + strNum));
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
                Chapter chapter =files.Find(e=> e.NameChapter == comboBoxManga.Text + "_" + comboBoxChapter.Text);
                listBoxRename.Items.Clear();
                if (chapter != null)
                {
                    
                    foreach(string page in chapter.ListScan)
                    {
                        listBoxRename.Items.Add(page);
                    }
                }
                
            }
        }

        private void listBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPage.SelectedIndex != -1)
            {
                pictureBoxScan.ImageLocation = path + listBoxPage.SelectedItem;
                textBoxRename.Text = Path.GetFileNameWithoutExtension(root + "\\" + comboBoxManga.Text + "\\" + comboBoxChapter.Text + "\\" + listBoxPage.SelectedItem);
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (listBoxPage.SelectedIndex != -1)
            {
                Chapter chapter = files.Find(e => e.NameChapter == comboBoxManga.Text + "_" + comboBoxChapter.Text);
                
                if (chapter is null)
                {
                    chapter = new Chapter();
                    chapter.NameChapter = comboBoxManga.Text + "_" + comboBoxChapter.Text;
                    chapter.ListScan.Add(listBoxPage.SelectedItem + " -> " + textBoxRename.Text + Path.GetExtension(path + listBoxPage.SelectedItem));
                    chapter.setFirstScan();
                    files.Add(chapter);
                }
                else
                {
                    files.Remove(files.Find(e=> e.NameChapter == chapter.NameChapter));
                    chapter.ListScan.Add(listBoxPage.SelectedItem + " -> " + textBoxRename.Text + Path.GetExtension(path + listBoxPage.SelectedItem));
                    files.Add(chapter);
                }
                
                
                listBoxRename.Items.Add(listBoxPage.SelectedItem + " -> " + textBoxRename.Text + Path.GetExtension(path + listBoxPage.SelectedItem));

            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerRename.IsBusy && files.Count>0)
            {
                progressBarChapter.Maximum=files.Count;
                progressBarChapter.Value = 1;
                progressBarPage.Maximum = files[0].ListScan.Count;
                progressBarPage.Value = 1;

                if (Directory.Exists(root + "\\Temp\\" + comboBoxManga.Text))
                {
                    oldNbChapter = Directory.GetDirectories(root + "\\Temp\\" + comboBoxManga.Text).Length;
                }
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
                Chapter chapter = files.Find(e=> e.NameChapter == comboBoxManga.Text + "_" + comboBoxChapter.Text);
                chapter.ListScan.RemoveAt(listBoxRename.SelectedIndex);
                listBoxRename.Items.RemoveAt(listBoxRename.SelectedIndex);
                
            }
        }

        private void backgroundWorkerRename_DoWork(object sender, DoWorkEventArgs e)
        {
            

            foreach (Chapter chapter in files)
            {
                string nameManga = chapter.NameChapter.Split('_').First();
                string nameChapter = chapter.NameChapter.Split('_').Last();

                foreach (string page in chapter.ListScan)
                {
                    //File.Move(page.Split(" -> ").First(), page.Split(" -> ").Last(), true);
                    Thread.Sleep(1000);
                }

                //createDirectory(root + "\\Temp\\" + nameManga);
                //createDirectory(root + "\\Temp\\" + nameManga + "\\" + nameChapter);
                var pages = Directory.GetFiles(root + "\\" + nameManga + "\\" + nameChapter);
                foreach (string page in pages)
                {
                    //File.Copy(page, root + "\\Temp\\" + nameManga + "\\" + nameChapter + "\\" + Path.GetFileName(page));
                    backgroundWorkerRename.ReportProgress(0);
                }
            }
        }

        private void backgroundWorkerRename_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
