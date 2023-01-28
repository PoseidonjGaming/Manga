using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities
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

        public BaseBackGroundWorker()
        {
            this.labelChapter = new();
            this.labelManga = new();
            this.labelPage = new();
            Worker = new();
            Worker.WorkerReportsProgress = true;
            this.progressBarManga = new();
            this.progressBarChapter = new();
            this.progressBarPage = new();
        }

        public abstract void Load();
    }
}
