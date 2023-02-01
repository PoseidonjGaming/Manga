using scan_manga.Models;
using System.Runtime.Serialization;

namespace scan_manga
{
    [Serializable]
    [DataContract]
    public class Chapter : ChapterBase
    {
        [DataMember]
        private string NameChapter { get ; set ; }
        [DataMember]
        private List<string> ListScan { get ; set  ; }
        [DataMember]
        private string FirstScan { get; set; }

        public List<Page> Pages { get; set; }

        public Chapter(string nameChapter, List<string> listScan)
        {
            NameChapter = nameChapter;
            ListScan = listScan;
            FirstScan = listScan[0];
        }

        public Chapter()
        {
            ListScan = new List<string>();
            Pages= new List<Page>();
        }
    }
}
