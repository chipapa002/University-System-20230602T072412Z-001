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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            Students students = new Students();
            addUserControl1(students);
        }
        private void addUserControl1(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Students students = new Students();
            addUserControl1(students);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Courses course = new Courses();
            addUserControl1(course);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Enrollments enrollments = new Enrollments();
            addUserControl1(enrollments);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sections section = new Sections();
            addUserControl1(section);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Instructors instractors = new Instructors();
            addUserControl1(instractors);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Admin_Instrac_Login admin_Instrac_Login = new Admin_Instrac_Login();
            this.Close();
            admin_Instrac_Login.ShowDialog();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
