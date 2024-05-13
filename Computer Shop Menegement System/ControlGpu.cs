using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Shop_Menegement_System
{
    internal class ControlGpu: ConnectDb
    {


        public DataTable getDataGpu()
        {
            DataTable dt = new DataTable();
            sqlText = "select *from gpu";
            try
            {
                adapter = new Npgsql.NpgsqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }


        public bool InsertGpu(Gpu gpu)
        {
            int e = 0;
            sqlText = "INSERT INTO GPU(gpu_name, memory_size, manufacturer, price, year_released, rasm) Values ('" + gpu.name + "', '" + gpu.memory_size + "',  '" + gpu.manufacturer+ "', '" + gpu.price + "', '" + gpu.year_released + "',  '" + gpu.rasm + "');";
            try
            {
                cmd = new NpgsqlCommand(sqlText, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool updateGpu(Gpu gpu)
        {
            int e = 0;
            // update uchun sql kod.
            // bu metodga id ham keladi,
            sqlText = "UPDATE gpu SET gpu_name='" + gpu.name + "', memory_size='" + gpu.memory_size + "', manufacturer='" + gpu.manufacturer+ "', price=" + gpu.price + ", rasm='" + gpu.rasm + "' WHERE gpu_id= " + gpu.id + "";
            try
            {
                cmd = new NpgsqlCommand(sqlText, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }






    public class Gpu
    {

        public int id;
        public string name;
        public int memory_size;
        public string manufacturer;
        public double price;
        public int year_released;
        public string rasm;

        public Gpu(int id, string name, int memory_size, string manufacturer, double price, int year_released, string rasm)
        {
            this.id = id;
            this.name = name;
            this.memory_size = memory_size;
            this.manufacturer = manufacturer;
            this.price = price;
            this.year_released = year_released;
            this.rasm = rasm;
        }

        public Gpu(string name, int memory_size, string manufacturer, double price, int year_released, string newPhotoName)
        {
            this.name = name;
            this.memory_size = memory_size;
            this.manufacturer = manufacturer;
            this.price = price;
            this.year_released = year_released;
        }

       /* public Gpu(int id, string name, int memory_size, string manufacturer, double price, int year_released, string rasm)
        {
            this.id = id;
            this.name = name;
            this.memory_size = memory_size;
            this.manufacturer = manufacturer;
            this.price = price;
            this.year_released = year_released;
            this.rasm = rasm;
        }*/
    }
}
