using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Computer_Shop_Menegement_System.PAL
{
    public partial class MainForm : Form
    {

        public string oldPhotoName = "";
        public string oldPhotoPath = "";
        public string newPhotoName = "";



        public void uploadPoto()
        {
           /* if (oldPhotoPath != "")
            {
                newPhotoName = "user_";
                string photoType = oldPhotoName.Substring(oldPhotoName.LastIndexOf('.'));
                newPhotoName += (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                newPhotoName = newPhotoName.Remove(newPhotoName.IndexOf('.'), 1);
                newPhotoName += photoType;

                File.Copy(oldPhotoPath, @"..\..\Resources\users\" + newPhotoName);
            }*/

        }


        public void clearBoxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            newPhotoName = "";
            oldPhotoName = "";
            oldPhotoPath = "";
            pictureBox7.Image = null;
          

        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }

        public void uploadDataToGridView()
        {
            ControlGpu controlGpu = new ControlGpu();
            dataGridView1.DataSource = controlGpu.getDataGpu();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (pictureBox7 != null)
            {
                openFileDialog.Filter = "(*.jpg;*.jpeg;*.png;*.bmp;)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    oldPhotoName = openFileDialog.SafeFileName;
                    oldPhotoPath = openFileDialog.FileName;
                    pictureBox7.Image = Image.FromFile(oldPhotoPath);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                string name = textBox2.Text.Trim();
                int memory_size = int.Parse( textBox3.Text.Trim());
                string manufacturer = textBox4.Text.Trim();
                double price = double.Parse(textBox5.Text.Trim());
                int year_released = int.Parse(textBox6.Text.Trim());  
                string rasm = "rasm";

                
                uploadPoto();
                // textBoxlarni bo'sh bo'lmasligini tekshiramiz
                if (name != "" &&  memory_size != 0 && manufacturer != ""  && price!= 0 && year_released != 0 )
                {
                    Gpu xodimObj = new Gpu(name, memory_size, manufacturer, price, year_released, rasm);
                    ControlGpu controlXodim = new ControlGpu();
                    if (controlXodim.InsertGpu(xodimObj))
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {   
                int id = int.Parse(textBox1.Text.Trim()); 
                string name = textBox2.Text.Trim();
                int memory_size = int.Parse(textBox3.Text.Trim());
                string manufacturer = textBox4.Text.Trim();
                double price = double.Parse(textBox5.Text.Trim());
                int year_released = int.Parse(textBox6.Text.Trim());
                string rasm = "rasm";

               /* string rasm = pictureBox2.Tag.ToString();
                //boshqa rasm tanlanganda undan avvalgisini o'chiramiz
                if (oldPhotoName != "")
                {
                    try
                    {
                        if (File.Exists(@"..\..\Resources\users\" + rasm))
                        {
                            File.Delete(@"..\..\Resources\users\" + rasm);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    uploadPoto();
                    rasm = newPhotoName;
                }
*/
               
               

                ControlGpu controlgpu = new ControlGpu();
                if (controlgpu.updateGpu(new Gpu(id, name, memory_size, manufacturer, price, year_released , rasm)))
                {
                    MessageBox.Show("Ma'lumot o'zgardi.");
                    clearBoxs();
                }
                else
                {
                    MessageBox.Show("Ma'lumot o'zgarmadi.");
                }



            }
            else
            {
                MessageBox.Show("Element tanlanmagan.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["gpu_id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["gpu_name"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["memory_size"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["manufacturer"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["year_released"].FormattedValue.ToString();

                //pictureBox2.Image = Image.FromFile(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["rasm"].FormattedValue.ToString());
                /* if (UserLogin.Username == dataGridView1.Rows[e.RowIndex].Cells["fLogin"].FormattedValue.ToString())
                 {
                     pictureBox7.Image = pictureBox1.Image;
                 }
                 else
                 {
                     using (FileStream fs = new FileStream(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["rasm"].FormattedValue.ToString(), FileMode.Open))
                     {
                         Image image = Image.FromStream(fs);
                         pictureBox2.Image = image;
                     }
                 }*/


                pictureBox7.Tag = dataGridView1.Rows[e.RowIndex].Cells["rasm"].FormattedValue.ToString();

            
            }
        }
    }
}

