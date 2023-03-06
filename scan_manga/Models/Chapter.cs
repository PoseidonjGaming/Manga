using System.Runtime.Serialization;

namespace scan_manga.Models
{
    public class Chapter
    {
        public string NameChapter { get; set; } = string.Empty;
        public List<Page> ListScan { get; set; } = new();
        public string FirstScan { get; set; } = string.Empty;

        public Chapter(string nameChapter, List<Page> listScan)
        {
            NameChapter = nameChapter;
            ListScan = listScan;
            FirstScan = listScan[0].Source;
        }

        public Chapter()
        {
            ListScan = new();
        }
    }
}
