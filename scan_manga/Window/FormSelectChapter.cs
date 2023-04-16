using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Properties;
using System.Security.Policy;

namespace scan_manga
{
    public partial class FormSelectChapter : Form
    {
        public List<Chapter> chapter = new();
        public FormSelectChapter(int index = 0, string url = "", string chapter = "")
        {
            InitializeComponent();
            if (MangaUtility.Mangas != null)
            {
                foreach (Manga manga in Settings.Default.Manga)
                {
                    comboBoxManga.Items.Add(manga.Nom);
                }
            }
            comboBoxManga.SelectedIndex = index;
            textBoxUrl.Text = url;
            textBoxNameChapter.Text = chapter;
            
        }

        private void FormDownloadOneChapter_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            Manga manga = MangaUtility.GetManga(comboBoxManga.Text, Settings.Default.Manga);
            manga.Source = textBoxUrl.Text;
            MangaUtility.Scan(manga, false, this,
                int.Parse(textBoxNameChapter.Text.Split(" ").Last()));
            Close();

        }



        private void FormDownloadOneChapter_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (chapter.Count != 0)
            {
                FormDownload formDownload = new(chapter, comboBoxManga.Text);
                formDownload.ShowDialog(this.Parent);
            }


        }

        private void comboBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxNameChapter.Text = comboBoxManga.Text + " Chapitre ";
        }
    }
}
