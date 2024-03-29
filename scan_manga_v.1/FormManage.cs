﻿using scan_manga_v._1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga
{
    public partial class FormManage : Form
    {
        public FormManage()
        {
            InitializeComponent();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            if(Settings.Default.Root != string.Empty)
            {
                var dirs= Directory.GetDirectories(Settings.Default.Root);
                foreach(var dir in dirs)
                {
                    string nom= Path.GetFileName(dir);
                    if(nom != "Temp")
                    {
                        comboBoxManga.Items.Add(nom);
                    }
                    
                }
            }
        }

        private void comboBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxManga.SelectedIndex != -1)
            {
                if (Settings.Default.Root != string.Empty)
                {
                    comboBoxChapter.Items.Clear();
                    var chapters = sort(Directory.GetDirectories(Settings.Default.Root + "\\" + comboBoxManga.SelectedItem).ToList()," ", comboBoxManga.Text + " Chapitre ");
                    foreach (string chapter in chapters)
                    {
                        if(chapter != null)
                        {
                            comboBoxChapter.Items.Add(Path.GetFileName(chapter));
                        }
                        
                    }
                    if(chapters != null)
                    {
                        comboBoxChapter.SelectedItem = comboBoxChapter.Items[0];
                    }
                    
                }
            }
        }

        private void comboBoxChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxChapter.SelectedIndex != -1)
            {
                listBoxPage.Items.Clear();
                var pages = sort(Directory.GetFiles(Settings.Default.Root + "\\" +
                    comboBoxManga.Text + "\\" + comboBoxChapter.Text).ToList(),"_", "page_");
                
                foreach (string page in pages)
                {
                    
                    if(page != null)
                    {
                        listBoxPage.Items.Add(Path.GetFileNameWithoutExtension(page).Replace('_', ' '));
                    }
                    
                }
            }
        }

        private void listBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxPage.SelectedIndex != -1)
            {
                pictureBoxPage.ImageLocation = Settings.Default.Root +
                    "\\" + comboBoxManga.Text +
                    "\\" + comboBoxChapter.Text +
                    "\\" + listBoxPage.SelectedItem.ToString().Replace(' ', '_') + ".jpg";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(listBoxPage.SelectedIndex != -1)
            {
                listBoxNew.Items.Add(listBoxPage.SelectedItem);
                listBoxPage.Items.Remove(listBoxPage.SelectedItem);
            }
        }

        

        private void buttonNew_Click(object sender, EventArgs e)
        {

        }

        public List<string> sort(List<string> listIn, string split, string toSearch)
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

                
                listIndex.Add(float.Parse(strNum));
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
    }
}
