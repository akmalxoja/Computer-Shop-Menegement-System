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
    public partial class Main1 : Form
    {
        public Main1()
        {
            InitializeComponent();
        }
        private void Main1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            startpos += 1;
            progressBar1.Value = startpos;
            label2.Text = startpos + "%";
            if (progressBar1.Value == 100)
            {
               progressBar1.Value = 0;
                timer1.Stop();
                FormLogIn log = new FormLogIn();
                log.Show();
                this.Hide();
            }

        }
    }
}
