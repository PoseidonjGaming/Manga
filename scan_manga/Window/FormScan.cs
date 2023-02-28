using scan_manga.Models;
using scan_manga.Properties;
using scan_manga.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan_manga.Window
{
    public partial class FormScan : Form
    {
        private string source;
        private Manga Manga;
        public FormScan(Manga manga)
        {
            InitializeComponent();
            Manga = manga;

        }

        private void FormScan_Load(object sender, EventArgs e)
        {
            cmbSource.Items.AddRange(Manga.Source.ToArray());
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            source = cmbSource.Text;
            Close();
        }

        public string GetSource() { return source; }

    }
}
