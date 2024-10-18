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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace University_System
{
    public partial class Courses : UserControl
    {
        public Courses()
        {
            InitializeComponent();
        }

        private void Courses_Load(object sender, EventArgs e)
        {
            BindData();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            desc.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            credits.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            level.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            duration.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            deptId.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cons);
            string querry1 = "SELECT * FROM COURSES WHERE NAME = '" + name.Text + "' ";


            SqlDataAdapter sda = new SqlDataAdapter(querry1, cons);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {

                label3.Text = "Course already exists or Incorrect input";
            }
            else
            {
                string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
                SqlConnection connn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into COURSES (NAME, DESCRIPTION, NQF_CREDITS, NQF_LEVEL, DURATION, DEPARTMENT_ID ) values ('" + name.Text + "', '" + desc.Text + "', '" + credits.Text + "', '" + level.Text + "', '" + (duration.Text) + "', '" + deptId.Text + "' )", connn);

                connn.Open();
                cmd.ExecuteNonQuery();

                connn.Close();

                MessageBox.Show("Success");
                name.Clear();
                desc.Clear();
                level.Clear();
                deptId.Clear();
                duration.Clear();
                credits.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("UPDATE COURSES SET NAME = '" + name.Text + "', DESCRIPTION = '" + desc.Text + "', NQF_CREDITS = '" + credits.Text + "', NQF_LEVEL = '" + level.Text + "', DURATION = '" + duration.Text + "', DEPARTMENT_ID = '" + deptId.Text + "' WHERE NAME = '" + name.Text + "' ", connn);
            connn.Open();
            cmd.ExecuteNonQuery();
            connn.Close();
            MessageBox.Show("Updated Successfuly");
            name.Clear();
            desc.Clear();
            level.Clear();
            deptId.Clear();
            duration.Clear();
            credits.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("DELETE FROM COURSES WHERE NAME = '" + name.Text + "' ", connn);
            connn.Open();
            cmd.ExecuteNonQuery();
            connn.Close();
            MessageBox.Show("Deleted Successfuly");
            name.Clear();
            desc.Clear();
            level.Clear();
            deptId.Clear();
            duration.Clear();
            credits.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection connn = new SqlConnection(cs);
            connn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM COURSES WHERE COURSE_ID = '" + search.Text + "'", connn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            connn.Close();
        }
        private void BindData()
        {
            string cs = @"Data Source=LAPTOP-HA5U3ATN\SQLEXPRESS;Initial Catalog=UNIVERSITY_P_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM COURSES", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
