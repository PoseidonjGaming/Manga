namespace scan_manga
{
    public class Chapter
    {
        private string nameChapter;
        private List<string> listScan;
        private string firstScan;

        public List<string> ListScan { get => listScan; set => listScan = value; }
        public string NameChapter { get => nameChapter; set => nameChapter = value; }
        public string FirstScan { get => firstScan; set => firstScan = value; }

        public Chapter(string nameChapter, List<string> listScan)
        {
            this.nameChapter = nameChapter;
            this.listScan = listScan;
            this.firstScan = listScan[0];
            
        }

        public Chapter()
        {
            this.listScan = new List<string>();
        }

        public void setFirstScan()
        {
            if (listScan[0] != null)
            {
                firstScan = listScan[0];
            }
        }
    }
}
