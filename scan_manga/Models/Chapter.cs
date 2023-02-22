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
        public List<string> ListScan { get; set; } = new();
        [DataMember]
        public string FirstScan { get; set; } = string.Empty;

        public Chapter(string nameChapter, List<string> listScan)
        {
            NameChapter = nameChapter;
            ListScan = listScan;
            FirstScan = listScan[0];
        }

        public Chapter()
        {
            ListScan = new List<string>();
        }
    }
}
