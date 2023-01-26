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
        private string source;
        [DataMember]
        private string toRemove;
        [DataMember]
        private List<Chapter> chapters;


        public string Source { get => source; set => source = value; }
        public string Nom { get => nom; set => nom = value; }
        public string ToRemove { get => toRemove; set => toRemove = value; }
        public List<Chapter> Chapters { get => chapters; set => chapters = value; }

        public Manga(string nom, string source, string toRemove, List<Chapter> chapters)
        {
            this.nom = nom;
            this.source = source;
            this.toRemove = toRemove;
            if (chapters != null)
            {
                this.chapters = chapters;
            }
            else
            {
                this.chapters = new List<Chapter>();
            }


        }

        public Manga()
        {
            chapters = new List<Chapter>();
        }
    }
}
