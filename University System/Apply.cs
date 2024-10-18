using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace University_System
{
    public partial class Apply : UserControl
    {
        public Apply()
        {
            InitializeComponent();
        }

        private void Apply_Load(object sender, EventArgs e)
        {
            id.Text = Login.setvalue;

            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            string querry1 = "SELECT * FROM ENROLLMENTS WHERE STUDENT_ID = '" + int.Parse(id.Text) + "'";
            

            SqlDataAdapter sda = new SqlDataAdapter(querry1, conn);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {

                submit.Visible = false;
                label3.Text = "You have already applied!";
            }
            else
            {
                submit.Visible= true;
            }



        }

        private void submit_Click(object sender, EventArgs e)
        {
            
            try
            {
            // Check to make sure that the user has entered all of the required information.
            if(coursebox.Text == "")
            {
            MessageBox.Show("Please select a Course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }

            //Registration date
            DateTime dateTime = DateTime.Now;

            string registerDate = dateTime.ToString();

            // Connect to the database.
            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);

            // Get the course ID.
            string querry1 = "SELECT COURSE_ID FROM COURSES WHERE NAME = '" + coursebox.Text + "'";
            SqlCommand cmd = new SqlCommand(querry1, con);
            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
            if (reader.Read())
            {
                string courseId = reader["COURSE_ID"].ToString();
                

                        // Add the registration to the database.
                string querry2 = "INSERT INTO ENROLLMENTS(STUDENT_ID, COURSE_ID, REGISTRATION_DATE) VALUES ('" + id.Text + "','" + courseId + "','" + registerDate + "')";
                SqlCommand cmd2 = new SqlCommand(querry2, con);

                        // Close the data reader before executing the next command.
                reader.Close();

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Application Submitted");
                        submit.Visible = false;
            }
            }

            // Close the connection to the database.
            con.Close();

            // Display a message to confirm that the registration was successful.
            MessageBox.Show("Application Submitted");
            }
            catch (Exception ex)
            {
            // Display a message to the user if an error occurs.
            MessageBox.Show("An error occurred while submitting your application. Please try again later.");
            }
           

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
