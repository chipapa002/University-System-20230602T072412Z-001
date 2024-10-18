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
    public partial class InstractorProfile : Form
    {
        public InstractorProfile()
        {
            InitializeComponent();
            Insructor_Profile profile = new Insructor_Profile();
            addUserControl1(profile);
        }
        private void addUserControl1(UserControl userControl)
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
            Insructor_Profile profile = new Insructor_Profile();
            addUserControl1(profile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Classes classes = new Classes();
            addUserControl1(classes);
        }

        private void students_Click(object sender, EventArgs e)
        {
            Insructor_Profile profile = new Insructor_Profile();
            addUserControl1(profile);
        }

        private void course_Click(object sender, EventArgs e)
        {
            Classes classes = new Classes();
            addUserControl1(classes);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.ShowDialog();
        }
    }
}
