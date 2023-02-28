using scan_manga.Models;
using scan_manga.Properties;
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
        private List<Manga> mangas;
        public FormScan()
        {
            InitializeComponent();
            if(Settings.Default.Manga != null)
            {
                mangas = Settings.Default.Manga;
            }
            
        }

        private void FormScan_Load(object sender, EventArgs e)
        {
            foreach(Manga manga in mangas)
            {
                cmbManga.Items.Add(manga.Nom);
            }
        }
    }
}
