using System.Runtime.Serialization;

namespace scan_manga.Models
{
    [Serializable]
    [DataContract]
    public class Manga
    {

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public List<Chapter> Chapters { get; set; }

        public string HomePage { get; set; }


        public Manga(string nom, string source, string toRemove, List<Chapter> chapters)
        {
            Nom = nom;
            Source = source;
            Chapters = chapters;


        }

        public Manga()
        {
            Chapters = new List<Chapter>();
        }

        public Manga(string nom, string source, string home)
        {
            Source = source;
            Nom = nom;
            HomePage = home;
        }
    }
}
