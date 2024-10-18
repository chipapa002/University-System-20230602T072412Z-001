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
    public partial class AdminLogin : UserControl
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usern = username.Text;
            string passw = password.Text;

            string conn = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);

            try
            {
                string querry = "SELECT ADMIN_ID, PASSWORD FROM ADMINISTRATION WHERE ADMIN_ID = '" + username.Text + "' AND PASSWORD = '" + (password.Text) + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    usern = username.Text;
                    passw = password.Text;

                    //page to be loaded next
                    AdminDashboard adminDashboard = new AdminDashboard();
                    Admin_Instrac_Login admin_Instrac_Login = new Admin_Instrac_Login();
                    admin_Instrac_Login.Close();
                    adminDashboard.ShowDialog();
                    
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

        private void AdminLogin_Load(object sender, EventArgs e)
        {
          
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
