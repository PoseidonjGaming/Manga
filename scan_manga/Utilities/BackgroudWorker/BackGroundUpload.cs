using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundUpload: BaseBackGroundWorker
    {
        string pathTemp;
        string pathManga;
        string manga;
        public BackGroundUpload(string manga): base()
        {
            NameWindow = "Upload";
            pathTemp = MangaUtility.GetPath(MangaUtility.Root, "Temp");
            pathManga = MangaUtility.GetPath(MangaUtility.Root, "Manga", manga);
            this.manga = manga;
        }

        public override void Load()
        {
            if(Directory.Exists(MangaUtility.GetPath(pathTemp, manga))){

            }
            base.Load();
        }

        protected override void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            foreach(string chapter in MangaUtility.Get(pathManga))
            {
                MessageBox.Show(chapter);
            }
        }

        protected override void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            base.backgroundWorker_ProgressChanged(sender, e);
        }
    }
}
