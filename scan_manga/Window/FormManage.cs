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
    public partial class FormManage : Form
    {
        private readonly MangaUtility utility;
        private readonly string root;
        public FormManage()
        {
            InitializeComponent();
            utility = new();
            root = Settings.Default.Root;
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            foreach (Manga manga in Settings.Default.Manga)
            {
                cmbBoxManga.Items.Add(manga.Nom);
            }
            if (cmbBoxManga.Items.Count > 0)
            {
                cmbBoxManga.SelectedIndex = 0;
            }
        }

        private void cmbBoxManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxManga.SelectedIndex != -1)
            {
                foreach(string chapter in utility.GetChapter(" Chapitre ", cmbBoxManga.Text + " Chapitre ",root, "Manga", cmbBoxManga.Text))
                {
                    
                }
            }
        }
    }
}
