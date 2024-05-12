using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Computer_Shop_Menegement_System.PAL
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
     

           MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.ShowDialog();
            
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlUsers controlUsers = new ControlUsers();
            dataGridView1.DataSource = controlUsers.getDataXodimlar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();





            // textBoxlarni bo'sh bo'lmasligini tekshiramiz
            if (name != "" && email != "" && password != "" )
            {
               // User xodimObj = new User(name, email, password);
               User xodimObj = new User(name, email, password);
                ControlUsers controlXodim = new ControlUsers();
                if (controlXodim.InserUser(xodimObj))
                {
                    MessageBox.Show("Ma'lumot kiritildi.");
                    clearBoxs();
                }
                else
                {
                    MessageBox.Show("Ma'lumot kiritilmadi.");
                }
            }
            else
            {
                MessageBox.Show("Barcha maydonlar to'ldirilishi shart.");
            }
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void clearBoxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            uploadDataToGridView();

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
           int id = int.Parse(textBox4.Text); // Siz tanlangan foydalanuvchi ID sini olishingiz kerak
            ControlUsers controlUsers = new ControlUsers();
            


            // Foydalanuvchi ID sini bazadan o'chirish uchun deleteData metodini chaqirish
            bool deleted = controlUsers.deleteData(id);
            

            if (deleted)
            {
                MessageBox.Show("Ma'lumot o'chirildi!");
                // Qolgan kodlar, masalan, ro'yxatni yangilash uchun yana metod chaqirish mumkin
            }
            else
            {
                MessageBox.Show("Ma'lumot o'chirishda xatolik yuz berdi!");
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();

            User user = new User(userName, email, password);
            


            // Call the updateXodim method
            ControlUsers controlUsers = new ControlUsers();

            bool updated = controlUsers.updateXodim(user);

            if (updated)
            {
                MessageBox.Show("User updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update user.");
            }
        }
    }
}
