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
            String musicName = txtMusicName.Text;
            DateTime createDate = dtgCreateDate.Value;
            string musicLength = txtLength.Text;
            int msLength;
            if (musicName!= string.Empty && createDate!= null && musicLength!= string.Empty)
            {
              if(int.TryParse(musicLength, out msLength))
                {
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.musicConn)) 
                    {
                        string comCommand = string.Format("Insert Into Music Values('{0}','{1}','{2}','{3}')", musicName, createDate, msLength, 3);
                        SqlCommand com = new SqlCommand(comCommand, conn);
                        conn.Open();
                        int result = com.ExecuteNonQuery();
                        if(result >=1)
                        {
                            MessageBox.Show("Music Add Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Sql Error");
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
      
    }
}
