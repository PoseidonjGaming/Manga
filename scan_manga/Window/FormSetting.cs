using scan_manga.Models;
using scan_manga.Utilities;
using System.Drawing.Imaging;

namespace scan_manga
{
    public partial class FormSetting : Form
    {
        private string root;
        private readonly List<Manga> mangas = new();
        private List<string> sources = new();
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
                    Source = sources,
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
                textBoxNameManga.Text = manga.Nom;
                lstBoxSources.Items.Clear();
                lstBoxSources.Items.AddRange(manga.Source.ToArray());
            }

        }

        private void buttonModif_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {

                mangas[listBoxManga.SelectedIndex].Nom = textBoxNameManga.Text;

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

        private void btnAddSource_Click(object sender, EventArgs e)
        {
            if (textBoxCh1.Text != string.Empty && textBoxCh2.Text != string.Empty)
            {
                string source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]");
                if (listBoxManga.SelectedIndex != -1)
                {
                    mangas[listBoxManga.SelectedIndex].Source.Add(source);
                    Save();
                }
                else
                {
                    sources.Add(source);
                }
                lstBoxSources.Items.Add(source);
                Clear();
            }
        }

        private void lstBoxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxSources.SelectedIndex != -1)
            {
                textBoxCh1.Text = lstBoxSources.Text.Replace("[num_chapitre]", "1");
                textBoxCh2.Text = lstBoxSources.Text.Replace("[num_chapitre]", "2");
            }
        }
    }
}
