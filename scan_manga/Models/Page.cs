using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Models
{
    public class Page
    {
        public string OldPage { get; set; }
        public string NewPage { get; set; }



        public Page(string oldPage, string newPage)
        {
            OldPage = oldPage;
            NewPage = newPage;
        }

        public Page()
        {

        }
    }
}
