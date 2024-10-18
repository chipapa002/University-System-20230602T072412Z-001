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
    public partial class Login : Form
    {
        public static string setvalue;
        HashCode hc = new HashCode();
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentRegistration studentRegistration = new StudentRegistration();
            studentRegistration.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Instrac_Login admin_Instrac_Login = new Admin_Instrac_Login();
            admin_Instrac_Login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Instrac_Login admin_Instrac_Login = new Admin_Instrac_Login();
            admin_Instrac_Login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Verifying the login details

            string usern = username.Text;
            string passw = password.Text;

            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);

            try
            {
                string querry = "SELECT STUDENT_ID, PASSWORD FROM STUDENT_ACCOUNT_INFO WHERE STUDENT_ID = '" + username.Text + "' AND PASSWORD = '" + hc.PassHash(password.Text) + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    usern = username.Text;
                    passw = password.Text;
                    setvalue = (username.Text);


                    //page to be loaded next
                    Student_Profile studentProfile = new Student_Profile();
                    studentProfile.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    username.Clear();
                    password.Clear();

                    username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }

            
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Maximizing the form
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Minimizing the form
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
