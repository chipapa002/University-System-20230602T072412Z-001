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
    public partial class Admin_Instrac_Login : Form
    {
        public Admin_Instrac_Login()
        {
            InitializeComponent();
            AdminLogin adminLogin = new AdminLogin();
            addUserControl1(adminLogin);
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
            AdminLogin adminLogin = new AdminLogin();
            addUserControl1(adminLogin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstractorLogin instractorLogin = new InstractorLogin();
            addUserControl1(instractorLogin);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void CreatePass_Click(object sender, EventArgs e)
        {
            PasswordCreat passwordCreat = new PasswordCreat();
            addUserControl1(passwordCreat);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.ShowDialog();
        }
    }
}
