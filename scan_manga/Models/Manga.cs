using System.Runtime.Serialization;

namespace scan_manga.Models
{
    [Serializable]
    [DataContract]
    public class Manga
    {
        [DataMember]
        private string nom;
        [DataMember]
        private string source;
        [DataMember]
        private List<Chapter> chapters;


        public string Source { get => source; set => source = value; }
        public string Nom { get => nom; set => nom = value; }
        public List<Chapter> Chapters { get => chapters; set => chapters = value; }

        public Manga(string nom, string source, string toRemove, List<Chapter> chapters)
        {
            Nom = nom;
            Source = source;
            Chapters = chapters;


        }

        public Manga()
        {
            chapters = new List<Chapter>();
        }

        public Manga(string nom, string source)
        {
            Source = source;
            Nom = nom;
        }
    }
}
