using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Models
{
    [Serializable]
    [DataContract]
    public class Manga
    {
        [DataMember]
        private string nom;
        [DataMember]
        private List<string> source;
        [DataMember]
        private List<Chapter> chapters;


        public List<string> Source { get => source; set => source = value; }
        public string Nom { get => nom; set => nom = value; }
        public List<Chapter> Chapters { get => chapters; set => chapters = value; }

        public Manga(string nom, List<string> source, List<Chapter> chapters)
        {
            this.nom = nom;
            this.source = source;
            this.chapters = chapters;
        }

        public Manga()
        {
            chapters = new ();
            source = new();
        }
    }
}
