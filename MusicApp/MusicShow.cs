using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MusicApp
{
    public partial class MusicShow : Form
    {
        public MusicShow()
        {
            InitializeComponent();
        }

        private void MusicShow_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OSF0P27\ELXANQULIYEV;Initial Catalog=C200MusicDB;Integrated Security=True");
            string comCommand = "Select mc.Name[Music Name],mc.MusicLength[Music Length],gs.Name[Genres Name] "+
                "from Music mc "+
                "Join Genres gs "+
                "on gs.Id=mc.GenresId";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(comCommand, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Music");
            dtgView.DataSource = ds.Tables["Music"];
        }
    }
}
