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
    public partial class Insructor_Profile : UserControl
    {
        public Insructor_Profile()
        {
            InitializeComponent();
        }

        private void Insructor_Profile_Load(object sender, EventArgs e)
        {
            string instructor = InstractorLogin.instructorId;
            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            string querry = "SELECT NAME, SURNAME FROM INSTRUCTORS WHERE INSTRUCTOR_ID = '" + instructor + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    label1.Text = "It's great to have you back, " + reader["NAME"].ToString();
                    label1.Text = label1.Text + " " + reader["SURNAME"].ToString();
                }
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void welcome_Click(object sender, EventArgs e)
        {

        }
    }
}
