using System.Drawing.Imaging;
using System.Runtime.Serialization;

namespace scan_manga.Models
{
    [Serializable]
    [DataContract]
    public class Chapter
    {
        [DataMember]
        public string NameChapter { get; set; } = string.Empty;
        [DataMember]
        public List<Page> ListScan { get; set; } = new();
        [DataMember]
        public string FirstScan { get; set; } = string.Empty;

        public Chapter(string nameChapter, List<Page> listScan)
        {
            NameChapter = nameChapter;
            ListScan = listScan;
            FirstScan = listScan[0].Target;
        }

        public Chapter()
        {
            ListScan = new();
        }
    }
}
