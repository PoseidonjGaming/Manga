using System.Runtime.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace scan_manga
{
    [DataContract, Serializable]
    public class ChapterBase
    {

        public List<Page> Pages { get; set; }
    }
}