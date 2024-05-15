using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Shop_Menegement_System
{
    internal class ControlCpu : ConnectDb
    {

        public DataTable getDataGpu()
        {
            DataTable dt = new DataTable();
            sqlText = "select *from cpu";
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


        public bool InsertGpu(Cpu cpu)
        {
            int e = 0;
            sqlText = "INSERT INTO cpu (model_name, manufacturer, core_count, thread_count, speed, release_date, price) VALUES ('" + cpu.model_name + "', '" + cpu.manufacturer + "', " + cpu.core_count + ", " + cpu.thread_count + ", " + cpu.speed + ", " + cpu.release_date + ", " + cpu.price + ");";

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



        public bool updateCpu(Cpu cpu)
        {
            int e = 0;
            // update uchun sql kod.
            // bu metodga id ham keladi,
            sqlText = "UPDATE cpu SET model_name='" + cpu.model_name + "',  manufacturer='" + cpu.manufacturer + "', core_count ='" + cpu.core_count + "',  thread_count=" + cpu.core_count + ", speed = '"+ cpu.speed + "',  release_date = '"+ cpu.release_date + "', price='" + cpu.price  + "' WHERE cpu_id= " + cpu.id + "";
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



        public class Cpu
        {
            public int id;
            public string model_name;
            public string manufacturer;
            public int core_count;
            public int thread_count;
            public double speed;
            public int release_date;
            public double price;

            public Cpu()
            {
            }

            public Cpu(int id, string model_name, string manufacturer, int core_count, int thread_count, double speed, int release_date, double price)
            {
                this.id = id;
                this.model_name = model_name;
                this.manufacturer = manufacturer;
                this.core_count = core_count;
                this.thread_count = thread_count;
                this.speed = speed;
                this.release_date = release_date;
                this.price = price;
            }
            public Cpu(string model_name, string manufacturer, int core_count, int thread_count, double speed, int release_date, double price)
            {
                
                this.model_name = model_name;
                this.manufacturer = manufacturer;
                this.core_count = core_count;
                this.thread_count = thread_count;
                this.speed = speed;
                this.release_date = release_date;
                this.price = price;
            }
        }

    }
}
