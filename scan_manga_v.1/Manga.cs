using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga
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
        private string xPath;
        [DataMember]
        private string toRemove;

        public string XPath { get => xPath; set => xPath = value; }
        public string Source { get => source; set => source = value; }
        public string Nom { get => nom; set => nom = value; }
        public string ToRemove { get => toRemove; set => toRemove = value; }

        public Manga(string nom, string source, string xPath, string toRemove)
        {
            this.nom = nom;
            this.source = source;
            this.xPath = xPath;
            this.toRemove = toRemove;
        }

        public Manga()
        {

        }
    }
}
