using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Shop_Menegement_System
{
    internal class UserLogin : ConnectDb
    {
        public static string Username = String.Empty;
        public static string Password = String.Empty;
        public static bool isLogin = false;
        public UserLogin(string userN, string userP)
        {
            
            userN.Trim(); 
            userP.Trim();

            if (!isLogin) 
            {
                sqlText = "SELECT * FROM users WHERE user_name='" + userN + "' AND user_password='" + userP + "'";
                try
                {
                    cmd = new NpgsqlCommand(sqlText, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Username = userN;
                        Password = userP;
                        isLogin = true;
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
    }
}
