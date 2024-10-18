using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace University_System
{
    public partial class StudentRegistration : Form
    {
        HashCode hc = new HashCode();
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (useTxt.Text == "")
            {
                MessageBox.Show("Please enter username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (fnameTxt.Text == "")
            {
                MessageBox.Show("Please enter First Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (lnameTxt.Text == "")
            {
                MessageBox.Show("Please enter Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (DateOfBirth.Text == "")
            {
                MessageBox.Show("Please enter date of birth!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (phoneTxt.Text == "")
            {
                MessageBox.Show("Please enter Phone number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (address.Text == "")
            {
                MessageBox.Show("Please enter address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(useTxt.Text.Length < 9)
            {
                MessageBox.Show("Username should be 9 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(useTxt.Text.Length > 9) 
            {
                MessageBox.Show("Username should be 9 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (pass.Text == "")
            {
                MessageBox.Show("Please enter password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (repass.Text == "")
            {
                MessageBox.Show("Please enter matching password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gender = "M";
            if (femaleTxt.Checked)
            {
                gender = "F";
            }
            
            string email = useTxt.Text + "@student.uj.ac.za";

            string cons = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cons);
            string querry1 = "SELECT * FROM STUDENTS WHERE STUDENT_ID = '" + useTxt.Text + "'";


            SqlDataAdapter sda = new SqlDataAdapter(querry1, cons);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {

                submit.Visible = false;
                label3.Text = "You have already applied!";
            }
            else
            {
                string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
                SqlConnection connn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into STUDENTS (STUDENT_ID, NAME, SURNAME, Date_of_Birth, GENDER, ADDRESS, PHONE, EMAIL ) values ('" + int.Parse(useTxt.Text) + "', '" + fnameTxt.Text + "', '" + lnameTxt.Text + "', '" + DateOfBirth.Value.ToString() + "', '" + gender + "', '" + address.Text + "', '" + int.Parse(phoneTxt.Text) + "', '" + email + "'  )", connn);

                connn.Open();
                cmd.ExecuteNonQuery();

                connn.Close();

                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand("insert into STUDENT_ACCOUNT_INFO (STUDENT_ID, PASSWORD ) values ('" + int.Parse(useTxt.Text) + "', '" + hc.PassHash(pass.Text) + "'  )", conn);

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Application Submitted");
                useTxt.Clear();
                fnameTxt.Clear();
                lnameTxt.Clear();
                phoneTxt.Clear();
                address.Clear();
                DateOfBirth = null;
                maleTxt.Checked = false;
                pass.Clear();
                repass.Clear();


                Login form1 = new Login();
                form1.Show();
                this.Hide();

            }







        }

        private void address_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void useTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
             
        }

        private void useTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }
    }
}
