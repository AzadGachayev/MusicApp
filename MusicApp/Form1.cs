using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string musicName = txtMusicName.Text;
            DateTime createDate = dtgCreateDate.Value;
            string musicLength = txtLength.Text;
            int msLength;
            if (musicName != string.Empty && createDate != null && musicLength != string.Empty)
            {
                if (int.TryParse(musicLength, out msLength))
                {
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.musicConn))
                    {
                        string comCommand = String.Format("Insert Into Music Values('{0}','{1}','{2}','{3}')", musicName, createDate, msLength, 3);
                        SqlCommand com = new SqlCommand(comCommand, conn);
                        conn.Open();
                        int result = com.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Music add Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Sql Error");

                        }
                    }
                }
                else
                {
                    lblError.Text = "Music Length reqem daxil edin!";
                    lblError.Visible = true;
                }
            
            }
            else
            {
                lblError.Text = "Bos gondermeyin!";
                lblError.Visible = true;
            }
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillComboGenre();
        }
        private void FillComboGenre()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.musicConn))
            {
                string comCommand = "Select Name from Genres ";
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(comCommand, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Genres");
                MessageBox.Show(ds.Tables["Genres"].ToString());
                //cmbGenres.Items.AddRange( ds.Tables["Music"]);

            }
        }
    }
}
