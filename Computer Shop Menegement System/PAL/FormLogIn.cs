using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Shop_Menegement_System.PAL
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string l = textBox1.Text;
            string p  = textBox2.Text;

            UserLogin userLogin = new UserLogin(l,p);

            if (UserLogin.isLogin) {
            
            
                MainForm form2 = new MainForm();
                Main1 main1 = new Main1();
               
                this.Hide();
                form2.ShowDialog();
                main1.ShowDialog();
                
            
            }

            else
            {
                MessageBox.Show("Login yoki parol xato");
                textBox1.Text = "";
                textBox2.Text = "";

            }


        }
    }
}
