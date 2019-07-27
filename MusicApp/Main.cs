using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

     

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 admMusic = new Form1();
          
            admMusic.ShowDialog();
        }

        private void MusicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MusicShow ms = new MusicShow();

            ms.ShowDialog();
        }
    }
}
