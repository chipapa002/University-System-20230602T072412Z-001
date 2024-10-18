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

namespace University_System
{
    public partial class Instructors : UserControl
    {
        public Instructors()
        {
            InitializeComponent();
        }

        private void Intractors_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM INSTRUCTORS", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            surname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            DoB.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            gender.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            phone.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            email.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            office.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            office_no.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            depId.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            rate.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cons);
            string querry1 = "SELECT * FROM INSTRUCTORS WHERE NAME = '" + name.Text + "', AND SURNAME = '"+surname.Text+"'";


            SqlDataAdapter sda = new SqlDataAdapter(querry1, cons);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {

                label3.Text = "Instructor already exists or Incorrect input";
            }
            else
            {
                string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
                SqlConnection connn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into INSTRUCTORS (NAME, SURNAME, Date_of_Birth, GENDER, PHONE, EMAIL, OFFICE, OFFICE_No, DEPARTMENTS_CODE, HOURLY_RATE ) values ('" + name.Text + "', '" + surname.Text + "', '" + DoB.Text + "', '" + gender.Text + "', '" + int.Parse(phone.Text) + "', '" + email.Text + "', '"+office.Text+"', '"+office_no.Text+"', '"+depId.Text+"', '"+rate.Text+"'  )", connn);

                connn.Open();
                cmd.ExecuteNonQuery();

                connn.Close();

                MessageBox.Show("Success");
                name.Clear();
                surname.Clear();
                DoB.Clear();
                gender.Clear();
                office.Clear();
                phone.Clear();
                email.Clear();
                office_no.Clear();
                depId.Clear();
                BindData();
            }
            

        }
        private void BindData()
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM INSTRUCTORS", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("UPDATE INSTRUCTORS SET NAME = '" + name.Text + "', SURNAME = '" + surname.Text + "', Date_of_Birth = '" + DoB.Text + "', PHONE = '" + phone.Text + "', EMAIL = '" + email.Text + "', OFFICE = '"+office.Text+"', OFFICE_No = '"+office_no.Text+"', DEPARTMENT_CODE = '"+depId.Text+ "', HOURLY_RATE = '"+rate.Text+"'  WHERE NAME = '" + name.Text + "' AND SURNAME = '"+surname.Text+"' ", connn);
            connn.Open();
            cmd.ExecuteNonQuery();
            connn.Close();

            MessageBox.Show("Updated Successfuly");
            name.Clear();
            surname.Clear();
            DoB.Clear();
            gender.Clear();
            office.Clear();
            phone.Clear();
            email.Clear();
            office_no.Clear();
            depId.Clear();
            rate.Clear();
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("DELETE FROM INSTRUCTORS WHERE NAME = '" + name.Text + "', AND SURNAME = '"+surname.Text+"'", connn);
            connn.Open();
            cmd.ExecuteNonQuery();
            connn.Close();
            MessageBox.Show("Deleted Successfuly");
            name.Clear();
            surname.Clear();
            DoB.Clear();
            gender.Clear();
            office.Clear();
            phone.Clear();
            email.Clear();
            office_no.Clear();
            depId.Clear();
            BindData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            connn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM INSTRUCTORS WHERE INSTRUCTOR_ID = '" + search.Text + "'", connn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            connn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
