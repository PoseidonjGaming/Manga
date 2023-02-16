using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using static System.Net.WebRequestMethods;

namespace scan_manga
{
    public partial class FormSetting : Form
    {
        private string root;
        private readonly List<string> mangas = new();
        public FormSetting()
        {
            InitializeComponent();

            if(Settings.Default.Manga != null)
            {
                mangas = Settings.Default.Manga;
            }
            if(Settings.Default.Root != null)
            {
                root = Settings.Default.Root;
                textBoxRoot.Text=root;
            }

            PopulateManga();
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogRoot.ShowDialog() == DialogResult.OK)
            {
                root=folderBrowserDialogRoot.SelectedPath;
                textBoxRoot.Text = root;
                Save();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxCh1.Text != string.Empty && textBoxCh2.Text != string.Empty
                && textBoxNameManga.Text != string.Empty && textBoxXPath.Text != string.Empty)
            {
                Manga manga = new()
                {
                    Source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]"),
                    Nom = textBoxNameManga.Text,
                    XPath = textBoxXPath.Text,
                    ToRemove = textBoxToRemove.Text
                };

                mangas.Add(JsonConvert.SerializeObject(manga));
                
                
                Save();
                PopulateManga();
                Clear();
            }
        }

        private void buttonSup_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                mangas.RemoveAt(listBoxManga.SelectedIndex);
                Save();
                PopulateManga();
                Clear();
               
            }
        }

        private void listBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                Manga manga = JsonConvert.DeserializeObject<Manga>(mangas[listBoxManga.SelectedIndex]);
                textBoxCh1.Text = manga.Source.Replace("[num_chapitre]", "1");
                textBoxCh2.Text = manga.Source.Replace("[num_chapitre]", "2");
                textBoxNameManga.Text = manga.Nom;
                textBoxXPath.Text = manga.XPath;
                textBoxToRemove.Text = manga.ToRemove;

            }
            
        }

        private void buttonModif_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                Manga manga = new()
                {
                    Source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]"),
                    Nom = textBoxNameManga.Text,
                    XPath = textBoxXPath.Text,
                    ToRemove = textBoxToRemove.Text
                };
                mangas[listBoxManga.SelectedIndex] = JsonConvert.SerializeObject(manga);

                Save();
                PopulateManga();
                Clear();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
            listBoxManga.SelectedIndex = -1;
        }
        private string FindDiff()
        {
            string diff = string.Empty;
            string ch1 = textBoxCh1.Text;
            string ch2 = textBoxCh2.Text;

            for(int i = 0; i < ch1.Length; i++)
            {
                char char1 = ch1[i];
                char char2 = ch2[i];
                if(char1 != char2)
                {
                    diff += char2;
                }
            }

            return diff;
        }

       

        private void PopulateManga()
        {
            listBoxManga.Items.Clear();
            foreach(string strManga in mangas)
            {
                Manga manga = JsonConvert.DeserializeObject<Manga>(strManga);
                listBoxManga.Items.Add(manga.Nom);
            }
        }

        private void Save()
        {
            Settings.Default.Root = root;
            Settings.Default.Manga = mangas;
            Settings.Default.Save();
        }

        private void Clear()
        {
            textBoxCh1.Clear();
            textBoxCh2.Clear();
            textBoxNameManga.Clear();
            textBoxXPath.Clear();
        }

        
    }
}
