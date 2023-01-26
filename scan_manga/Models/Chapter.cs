using System.Runtime.Serialization;

namespace scan_manga
{
    [Serializable]
    [DataContract]
    public class Chapter
    {
        [DataMember]
        private string nameChapter;
        [DataMember]
        private List<string> listScan;
        [DataMember]
        private string firstScan;

        public List<string> ListScan { get => listScan; set => listScan = value; }
        public string NameChapter { get => nameChapter; set => nameChapter = value; }
        public string FirstScan { get => firstScan; set => firstScan = value; }

        public Chapter(string nameChapter, List<string> listScan)
        {
            this.nameChapter = nameChapter;
            this.listScan = listScan;
            this.FirstScan = listScan[0];
        }

        public Chapter()
        {
            listScan = new List<string>();
        }
    }
}
