using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga
{
    
    internal class Manga
    {
        private string nom;
        private string source;
        private string xPath;
        private string toRemove;
        private List<Chapter> chapters;

        public string XPath { get => xPath; set => xPath = value; }
        public string Source { get => source; set => source = value; }
        public string Nom { get => nom; set => nom = value; }
        public string ToRemove { get => toRemove; set => toRemove = value; }
        public List<Chapter> Chapters { get => chapters; set => chapters = value; }

        public Manga(string nom, string source, string xPath, string toRemove, List<Chapter> chapters)
        {
            this.nom = nom;
            this.source = source;
            this.xPath = xPath;
            this.toRemove = toRemove;
            this.chapters = chapters;
            
        }

        public Manga()
        {

        }
    }
}
