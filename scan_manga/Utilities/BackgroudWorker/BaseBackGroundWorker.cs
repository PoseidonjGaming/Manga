using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities.BackgroudWorker
{
    public abstract class BaseBackGroundWorker
    {
        public Label labelChapter { get; set; }
        public Label labelManga { get; set; }
        public Label labelPage { get; set; }

        public BackgroundWorker Worker { get; set; }
        public ProgressBar progressBarManga { get; set; }
        public ProgressBar progressBarChapter { get; set; }
        public ProgressBar progressBarPage { get; set; }

        protected readonly MangaUtility utility;

        public BaseBackGroundWorker()
        {
            Worker = new();
            Worker.DoWork += backgroundWorker_DoWork;
            Worker.ProgressChanged += backgroundWorker_ProgressChanged;
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;

            utility = new();
        }

        protected virtual void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            
        }

        protected virtual void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            
        }

        public virtual void Load()
        {

        }

        public void backgroundWorker_RunWorker()
        {
            Worker.RunWorkerAsync();
        }

        public void Cancel()
        {
            Worker.CancelAsync();
        }

    }
}
