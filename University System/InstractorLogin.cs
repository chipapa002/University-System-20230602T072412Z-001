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
    public partial class InstractorLogin : UserControl
    {
        HashCode hc = new HashCode();
        public static string instructorId;
        public InstractorLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string usern = username.Text;
            string passw = password.Text;

            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);

            try
            {
                string querry = "SELECT INSTRUCTOR_ID, PASSWORD FROM INSTRUCTOR_ACCOUNT_INFO WHERE INSTRUCTOR_ID = '" + username.Text + "' AND PASSWORD = '" + hc.PassHash(password.Text) + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    usern = username.Text;
                    passw = password.Text;
                    instructorId = username.Text;


                    //page to be loaded next
                    InstractorProfile profile = new InstractorProfile();
                    profile.Show();
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
    }
}
