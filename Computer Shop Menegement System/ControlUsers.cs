using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Computer_Shop_Menegement_System
{
    internal class ControlUsers : ConnectDb
    {
        public bool InserUser(User user)
        {
            int e = 0;
            sqlText = "INSERT INTO users(user_name, email, user_password) VALUES ('" + user.user_name + "', '" + user.email + "', '" + user.user_password + "');";

            try
            {
                cmd = new NpgsqlCommand(sqlText,conn);
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
       


        public DataTable getDataXodimlar()
        {
            DataTable dt = new DataTable();
            sqlText = "select *from users";
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


        public bool updateXodim(User user)
        {
            int e = 0;
            // update uchun sql kod.
            // bu metodga id ham keladi,
            sqlText = "UPDATE users SET user_name='" + user.user_name + "', email='" + user.email + "', user_passwoed='" + user.user_password + "'  WHERE id=" + user.id + "";
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


        public bool deleteData(int id)
        {
            int e = 0;
            // delete uchun sql kod
            // bu metodga id ham keladi,
            sqlText = "DELETE from users WHERE id = " + id;
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

    public class User
    {
        public int id;
        public string user_name;
        public string email;
        public string user_password;

        public User(string user_name, string email, string user_password)
        {
           
            this.user_name = user_name;
            this.email = email;
            this.user_password = user_password;


        }
    }



}
