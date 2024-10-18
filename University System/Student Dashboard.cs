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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace University_System
{
    public partial class Student_Dashboard : UserControl
    {
        public Student_Dashboard()
        {
            InitializeComponent();
        }

        private void Student_Dashboard_Load(object sender, EventArgs e)
        {
            string studentId = Login.setvalue;
            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            string querry = "SELECT NAME, SURNAME FROM STUDENTS WHERE STUDENT_ID = '" + studentId + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    welcome.Text = " " + reader["NAME"].ToString();
                    welcome.Text = welcome.Text + " " + reader["SURNAME"].ToString();
                }
            }
            con.Close();

            string querry1 = "SELECT COURSE_ID FROM ENROLLMENTS WHERE STUDENT_ID = '" + studentId + "'";
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
                        string courseId = reader["COURSE_ID"].ToString();
                        reader.Close();

                        SqlCommand cmd3 = new SqlCommand("SELECT * FROM SECTION WHERE COURSE_ID = '"+courseId+"'", con);
                        SqlDataAdapter ad = new SqlDataAdapter(cmd3);
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;




                    }
                }


            }
            else
            {
                MessageBox.Show("You have not yet applied");
                
            }
            



            

            // Close the connection to the database.
            con.Close();


            // Get the course ID.

        }
    }
}
