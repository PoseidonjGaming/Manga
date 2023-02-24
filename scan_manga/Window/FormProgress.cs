using Newtonsoft.Json;
using scan_manga.Models;
using scan_manga.Utilities.BackgroudWorker;
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
    public partial class FormProgress : Form
    {
        private readonly BaseBackGroundWorker Worker;

        public FormProgress(BaseBackGroundWorker background)
        {
            InitializeComponent();
            Worker = background;
            background.ProgressBarPage = progressBarPage;
            background.ProgressBarChapter = progressBarChapter;
            background.ProgressBarManga = progressBarManga;

            background.labelPage = labelPage;
            background.labelManga = labelManga;
            background.labelChapter = labelChapter;

            Text = background.NameWindow;

            background.Worker.RunWorkerCompleted += backgroundWorker_RunCompleted;
        }
        private void FormArchive_Load(object sender, EventArgs e)
        {
            Worker.Load();
        }

        private void backgroundWorker_RunCompleted(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Worker.Cancel();
        }
    }


}
