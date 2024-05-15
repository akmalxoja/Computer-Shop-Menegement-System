using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Computer_Shop_Menegement_System.ControlCpu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Computer_Shop_Menegement_System.PAL
{
    public partial class FormCpu : Form
    {
        public FormCpu()
        {
            InitializeComponent();
        }


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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            uploadDataToGridView();


        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCpu_Load(object sender, EventArgs e)
        {
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlCpu controlCpu = new ControlCpu();
            dataGridView1.DataSource = controlCpu.getDataGpu();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["cpu_id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["model_name"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["manufacturer"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["core_count"].FormattedValue.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["thread_count"].FormattedValue.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["speed"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["release_date"].FormattedValue.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();






                /* int id = int.Parse(textBox1.Text.Trim());
                 string model_name = textBox2.Text.Trim();
                 string manufacturer = textBox4.Text.Trim();
                 int year_released = int.Parse(textBox6.Text.Trim());
                 int core_count = int.Parse(textBox5.Text.Trim());
                 int thread_count = int.Parse(textBox8.Text.Trim());
                 double speed = double.Parse(textBox9.Text.Trim());
                 double price = double.Parse(textBox10.Text.Trim());*/

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




            }

        }

        private void button2_Click(object sender, EventArgs e)

        {
            string model_name = textBox2.Text.Trim();
            string manufacturer = textBox4.Text.Trim();
            int year_released = int.Parse(textBox6.Text.Trim());
            int core_count = int.Parse(textBox5.Text.Trim());
            int thered_count = int.Parse(textBox8.Text.Trim());
            int speed = int.Parse(textBox9.Text.Trim());
            double price = double.Parse(textBox10.Text.Trim());



            uploadPoto();
            // textBoxlarni bo'sh bo'lmasligini tekshiramiz
            if (model_name != "" && manufacturer != "" && core_count != 0 && year_released != 0)
            {
                Cpu cpu = new Cpu(model_name, manufacturer, year_released, core_count, thered_count, speed, price);
                ControlCpu controlCpu = new ControlCpu();

                if (controlCpu.InsertGpu(cpu))
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    // Parse and retrieve values from text boxes
                    int id = int.Parse(textBox1.Text.Trim());
                    string model_name = textBox2.Text.Trim();
                    string manufacturer = textBox4.Text.Trim();
                    int year_released = int.Parse(textBox6.Text.Trim());
                    int core_count = int.Parse(textBox5.Text.Trim());
                    int thread_count = int.Parse(textBox8.Text.Trim());
                    double speed = double.Parse(textBox9.Text.Trim());
                    double price = double.Parse(textBox10.Text.Trim());

                    // Instantiate ControlCpu and call updateCpu method
                    ControlCpu controlcpu = new ControlCpu();
                    bool isUpdated = controlcpu.updateCpu(new Cpu(id, model_name, manufacturer, core_count, thread_count, speed, year_released, price));

                    if (isUpdated)
                    {
                        MessageBox.Show("Ma'lumot o'zgardi.");
                        clearBoxs();
                    }
                    else
                    {
                        MessageBox.Show("Ma'lumot o'zgarmadi.");
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please ensure all inputs are in the correct format. " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Element tanlanmagan.");
            }
        }

    }
}
