using scan_manga.Models;
using scan_manga.Properties;

namespace scan_manga.Utilities.BackgroudWorker.BackgroundCore
{
    public class BackGroundCore : BaseBackGroundWorker
    {
        protected List<Chapter> chaptersToDownload;
        protected Chapter tempChapter;
        protected readonly string pathTemp;
        public readonly string temp;
        public readonly string root;
        public string nameManga;
        protected int maxPage;
        protected string nameChapter;
        protected int oldNbPage;


        public BackGroundCore(string name, List<Chapter> chapters) : base()
        {
            nameManga = name;
            chaptersToDownload = chapters;
            root = Settings.Default.Root;
            pathTemp = MangaUtility.GetPath(root, "Temp");
            temp = MangaUtility.Temp;
        }


    }
}