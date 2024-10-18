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
    public partial class Students : UserControl
    {
        public Students()
        {
            InitializeComponent();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENTS", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            stdId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            surname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            DoB.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            gender.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            address.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            phone.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            email.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cons);
            string querry1 = "SELECT * FROM STUDENTS WHERE STUDENT_ID = '" + stdId.Text + "'";


            SqlDataAdapter sda = new SqlDataAdapter(querry1, cons);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {

                label3.Text = "Student already exists or Incorrect input";
            }
            else
            {
                string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
                SqlConnection connn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into STUDENTS (STUDENT_ID, NAME, SURNAME, Date_of_Birth, GENDER, ADDRESS, PHONE, EMAIL ) values ('" + int.Parse(stdId.Text) + "', '" + name.Text + "', '" + surname.Text + "', '" + DoB.Text + "', '" + gender.Text + "', '" + address.Text + "', '" + int.Parse(phone.Text) + "', '" + email.Text + "'  )", connn);

                connn.Open();
                cmd.ExecuteNonQuery();

                connn.Close();

                MessageBox.Show("Success");
                name.Clear();
                surname.Clear();
                DoB.Clear();
                gender.Clear();
                address.Clear();
                phone.Clear();
                email.Clear();
                BindData();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("UPDATE STUDENTS SET STUDENT_ID =  '" + stdId.Text + "' ,NAME = '" + name.Text + "', SURNAME = '" + surname.Text + "', Date_of_Birth = '" + DoB.Text + "',ADDRESS = '" + address.Text + "', PHONE = '" + phone.Text + "', EMAIL = '" + email.Text + "' WHERE STUDENT_ID = '" + stdId.Text + "' ", connn);
            connn.Open();
            cmd.ExecuteNonQuery();
            connn.Close();

            MessageBox.Show("Updated Successfuly");
            name.Clear();
            surname.Clear();
            DoB.Clear();
            gender.Clear();
            address.Clear();
            phone.Clear();
            email.Clear();
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("DELETE FROM STUDENTS WHERE STUDENT_ID = '" + int.Parse(stdId.Text) + "'", connn);
            connn.Open();
            cmd.ExecuteNonQuery();
            connn.Close() ;
            MessageBox.Show("Deleted Successfuly");
            stdId.Clear();
            name.Clear();
            surname.Clear();
            DoB.Clear();
            gender.Clear();
            address.Clear();
            phone.Clear();
            email.Clear();
            BindData();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENTS", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BindData()
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENTS", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            connn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENTS WHERE STUDENT_ID = '" + search.Text + "'", connn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            connn.Close();
        }
    }
}
