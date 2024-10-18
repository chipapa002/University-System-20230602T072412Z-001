using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace University_System
{
    public partial class PasswordCreat : UserControl
    {
        HashCode hc = new HashCode();
        public PasswordCreat()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand("insert into INSTRUCTOR_ACCOUNT_INFO (INSTRUCTOR_ID, PASSWORD ) values ('" + int.Parse(username.Text) + "', '" + hc.PassHash(password.Text) + "'  )", conn);

            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Success");

            Admin_Instrac_Login admin_Instrac_Login = new Admin_Instrac_Login();
            admin_Instrac_Login.Show();
            this.Hide();

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
