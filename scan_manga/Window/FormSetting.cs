using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Properties;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace scan_manga
{
    public partial class FormSetting : Form
    {
        private List<Manga> mangas;

        public FormSetting()
        {
            InitializeComponent();
            mangas = MangaUtility.Mangas;
            textBoxRoot.Text = MangaUtility.Root;
            PopulateManga();
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogRoot.ShowDialog() == DialogResult.OK)
            {
                textBoxRoot.Text = folderBrowserDialogRoot.SelectedPath;
                MangaUtility.Save(textBoxRoot.Text, mangas);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCh1.Text != string.Empty && textBoxCh2.Text != string.Empty
                && textBoxNameManga.Text != string.Empty)
            {
                HtmlWeb web = new();
                Manga manga = new(textBoxNameManga.Text, textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]"));
                mangas.Add(manga);
                MangaUtility.Save(textBoxRoot.Text, mangas);
                PopulateManga();
                MangaUtility.StartPack();
                Clear();
            }
        }

        private void buttonSup_Click(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                mangas.RemoveAt(listBoxManga.SelectedIndex);
                MangaUtility.Save(textBoxRoot.Text, mangas);
                PopulateManga();
                Clear();

            }
        }

        private void listBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxManga.SelectedIndex != -1)
            {
                Manga manga = MangaUtility.GetManga(listBoxManga.Text, mangas);
                if (manga.Source is not null)
                {
                    textBoxCh1.Text = manga.Source.Replace("[num_chapitre]", "1");
                    textBoxCh2.Text = manga.Source.Replace("[num_chapitre]", "2");
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
                    Source = textBoxCh2.Text.Replace(FindDiff(), "[num_chapitre]"),
                    Nom = textBoxNameManga.Text
                };
                mangas[listBoxManga.SelectedIndex] = manga;

                MangaUtility.Save(textBoxRoot.Text, mangas);
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

        private void Clear()
        {
            textBoxCh1.Clear();
            textBoxCh2.Clear();
            textBoxNameManga.Clear();
        }


    }
}
