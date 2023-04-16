using scan_manga.Models;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker.BackgroundCore;
using System.Diagnostics;

namespace scan_manga
{
    public partial class FormDownload : Form
    {
        private readonly List<Chapter> chapters;
        private readonly List<Chapter> chaptersToDownload;
        private readonly string nameManga;



        public FormDownload(List<Chapter> list, string name)
        {
            InitializeComponent();
            chaptersToDownload = new();
            chapters = list;
            nameManga = name;

        }

        private void FormDownload_Load(object sender, EventArgs e)
        {
            foreach (Chapter chapter in chapters)
            {
                listBoxChapter.Items.Add(chapter.NameChapter);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listBoxChapter.SelectedIndex != -1)
            {
                foreach (int index in listBoxChapter.SelectedIndices)
                {
                    chaptersToDownload.Add(chapters[index]);
                }
                Populate();
            }
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            if (listBoxChapterDownload.SelectedIndex != -1)
            {
                foreach (int index in listBoxChapterDownload.SelectedIndices)
                {
                    chaptersToDownload.RemoveAt(index);
                }
                Populate();
            }
        }

        private void listBoxTempChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxChapter.SelectedIndex != -1 && listBoxChapter.SelectedItems.Count == 1)
            {
                listBoxChapterDownload.SelectedItems.Clear();
                pictureBoxScan.ImageLocation = chapters[listBoxChapter.SelectedIndex].FirstScan;
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            BackGroundDownload backGroundDownload = new(nameManga, chaptersToDownload);
            MangaUtility.Progress(backGroundDownload, this);

            if (!backGroundDownload.isCancelled)
            {
                MangaUtility.Progress(new BackGroundCopy(nameManga, chaptersToDownload), this);
                Close();
            }



        }

        private void buttonSelectAllTemp_Click(object sender, EventArgs e)
        {
            Select(listBoxChapter, true);
        }

        private void buttonUnSelectAllTemp_Click(object sender, EventArgs e)
        {
            Select(listBoxChapter, false);
        }
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            Select(listBoxChapterDownload, true);
        }

        private void buttonUnSelectAll_Click(object sender, EventArgs e)
        {
            Select(listBoxChapterDownload, true);
        }

        private void listBoxChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxChapterDownload.SelectedIndex != -1 && listBoxChapterDownload.SelectedItems.Count == 1)
            {
                listBoxChapter.SelectedItems.Clear();
                pictureBoxScan.ImageLocation = chaptersToDownload[listBoxChapterDownload.SelectedIndex].FirstScan;
            }
        }

        private void FormDownload_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void buttonOpenTemp_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", MangaUtility.Temp);
        }





        private void Select(ListBox listBox, bool selectType)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetSelected(i, selectType);
            }
        }

        private void Populate()
        {
            listBoxChapterDownload.Items.Clear();
            foreach (Chapter chapter in chaptersToDownload)
            {
                listBoxChapterDownload.Items.Add(chapter.NameChapter);
            }
        }

        private void btnDLAll_Click(object sender, EventArgs e)
        {
            Select(listBoxChapter, true);
            buttonAdd_Click(sender, e);
            buttonDownload_Click(sender, e);
        }
    }
}
