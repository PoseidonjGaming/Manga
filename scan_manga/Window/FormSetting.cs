using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Properties;

namespace scan_manga
{
    public partial class FormSetting : Form
    {
        private string root;
        private readonly List<Manga> mangas = new();
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
                && textBoxNameManga.Text != string.Empty)
            {
                Manga manga = new()
                {
                    Source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]"),
                    Nom = textBoxNameManga.Text,
                    ToRemove = textBoxToRemove.Text
                };

                mangas.Add(manga);
                
                
                Save();
                PopulateManga();
                MangaUtility.StartPack(root);
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
                Manga manga = mangas[listBoxManga.SelectedIndex];
                if (manga.Source is not null)
                {
                    textBoxCh1.Text = manga.Source.Replace("[num_chapitre]", "1");
                    textBoxCh2.Text = manga.Source.Replace("[num_chapitre]", "2");
                }
                textBoxNameManga.Text = manga.Nom;
                if(manga.ToRemove is not null)
                {
                    textBoxToRemove.Text = manga.ToRemove;
                }
                

            }
            
        }

        private void buttonModif_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                Manga manga = new Manga();
                manga.Source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]");
                manga.Nom = textBoxNameManga.Text;
                manga.ToRemove = textBoxToRemove.Text;
                mangas[listBoxManga.SelectedIndex] = manga;

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
            foreach(Manga manga in mangas)
            {
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
        }

        
    }
}
