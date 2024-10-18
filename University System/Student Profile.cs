using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_System
{
    public partial class Student_Profile : Form
    {
        public Student_Profile()
        {
            InitializeComponent();
            Student_Dashboard student_Dashboard = new Student_Dashboard();
            addUserControl2(student_Dashboard);
        }
        private void addUserControl2(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student_Dashboard student_Dashboard = new Student_Dashboard();
            addUserControl2(student_Dashboard);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Apply apply = new Apply();
            addUserControl2(apply);
        }

        private void students_Click(object sender, EventArgs e)
        {
            Student_Dashboard student_Dashboard = new Student_Dashboard();
            addUserControl2(student_Dashboard);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Apply apply = new Apply();
            addUserControl2(apply);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
