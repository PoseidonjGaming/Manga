using scan_manga.Utilities.BackgroudWorker;

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

            background.LabelPage = labelPage;
            background.LabelManga = labelManga;
            background.LabelChapter = labelChapter;

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
