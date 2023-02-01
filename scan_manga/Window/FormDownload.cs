using HtmlAgilityPack;
using scan_manga.Utilities;
using scan_manga.Utilities.BackgroudWorker;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace scan_manga
{
    public partial class FormDownload : Form
    {
        public List<Chapter> chapters;
        private List<Chapter> chaptersToDownload;
        private BackGroundDownload BackGroundDownload;
        private BackGroundCopy BackGroundCopy;
        public string nameManga;


        private readonly MangaUtility utility;

        public FormDownload()
        {
            InitializeComponent();
            utility = new();
            BackGroundDownload = new();
            BackGroundCopy = new();
            chaptersToDownload = new();

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
            BackGroundDownload.chaptersToDownload = chaptersToDownload;
            BackGroundDownload.nameManga = nameManga;
            FormProgress formProgressDownload = new(BackGroundDownload);
            formProgressDownload.ShowDialog();
            if (!BackGroundDownload.isCancelled)
            {
                BackGroundCopy.nameManga = nameManga;
                BackGroundCopy.chaptersToDownload = chaptersToDownload;
                FormProgress formProgressCopy = new(BackGroundCopy);
                formProgressCopy.ShowDialog();
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
            Process.Start("explorer.exe", BackGroundCopy.temp);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {

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


    }
}
