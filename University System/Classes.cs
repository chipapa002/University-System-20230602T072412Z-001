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

namespace University_System
{
    public partial class Classes : UserControl
    {
        public Classes()
        {
            InitializeComponent();
        }

        private void Classes_Load(object sender, EventArgs e)
        {
            string instructor = InstractorLogin.instructorId;
            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            string querry1 = "SELECT INSTRUCTOR_ID FROM INSTRUCTORS WHERE INSTRUCTOR_ID = '" + instructor + "'";
            SqlCommand cmd2 = new SqlCommand(querry1, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(querry1, conn);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string instId = reader["INSTRUCTOR_ID"].ToString();
                        reader.Close();

                        SqlCommand cmd3 = new SqlCommand("SELECT * FROM SECTION WHERE INSTRUCTOR_ID = '" + instId + "'", con);
                        SqlDataAdapter ad = new SqlDataAdapter(cmd3);
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;

                    }
                }


            }
            else
            {
                MessageBox.Show("Welcome back!!");

            }






            // Close the connection to the database.
            con.Close();
        }
    }
}
