using scan_manga.Models;
using scan_manga.Utilities;

namespace scan_manga
{
    public partial class FormSetting : Form
    {
        private string root;
        private readonly List<Manga> mangas = new();
        public FormSetting()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Manga != null)
            {
                mangas = Properties.Settings.Default.Manga;
            }
            if (Properties.Settings.Default.Root != null)
            {
                root = Properties.Settings.Default.Root;
                textBoxRoot.Text = root;
            }

            PopulateManga();
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogRoot.ShowDialog() == DialogResult.OK)
            {
                root = folderBrowserDialogRoot.SelectedPath;
                textBoxRoot.Text = root;
                Save();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCh1.Text != string.Empty && textBoxCh2.Text != string.Empty
                && textBoxNameManga.Text != string.Empty)
            {
                Manga manga = new()
                {
                    //Source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]"),
                    Nom = textBoxNameManga.Text,
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
                    comboBox1.Items.AddRange(manga.Source.ToArray());
                }
                textBoxNameManga.Text = manga.Nom;



            }

        }

        private void buttonModif_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                Manga manga = new()
                {
                    //manga.Source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]");
                    Nom = textBoxNameManga.Text
                };
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

            for (int i = 0; i < ch1.Length; i++)
            {
                char char1 = ch1[i];
                char char2 = ch2[i];
                if (char1 != char2)
                {
                    diff += char2;
                }
            }

            return diff;
        }



        private void PopulateManga()
        {
            listBoxManga.Items.Clear();
            foreach (Manga manga in mangas)
            {
                listBoxManga.Items.Add(manga.Nom);
            }
        }

        private void Save()
        {
            Properties.Settings.Default.Root = root;
            Properties.Settings.Default.Manga = mangas;
            Properties.Settings.Default.Save();
        }

        private void Clear()
        {
            textBoxCh1.Clear();
            textBoxCh2.Clear();
            textBoxNameManga.Clear();
        }


    }
}
