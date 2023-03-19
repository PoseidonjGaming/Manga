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

        public Manga(string nom, string source)
        {
            Source = source;
            Nom = nom;
            Chapters = new List<Chapter>();
        }
    }
}
