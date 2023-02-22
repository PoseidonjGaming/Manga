using scan_manga.Models;

namespace scan_manga.Utilities.BackgroudWorker
{
    public class BackGroundCore: BaseBackGroundWorker
    {
        public List<Chapter> chaptersToDownload;
        protected Chapter tempChapter;
        protected readonly string pathTemp;
        public readonly string temp;
        public string nameManga;
        protected int maxPage;
        protected string nameChapter;
        protected int oldNbPage;
        public bool isCancelled;

        public BackGroundCore():base()
        {
            pathTemp = MangaUtility.GetPath(Properties.Settings.Default.Root, "Temp");
            temp = MangaUtility.GetPath(Directory.GetCurrentDirectory(), "Temp");
        }

        
    }
}