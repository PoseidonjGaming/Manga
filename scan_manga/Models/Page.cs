using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Models
{
    public class Page
    {
        public string Source { get; set; }
        public string Target { get; set; }



        public Page(string source, string target)
        {
            Source = source;
            Target = target;
        }

        public Page()
        {

        }
    }
}
