﻿using System;
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
        public static string userPhoto = String.Empty;
        public static bool isLogin = false;
        public UserLogin(string userN, string userP)
        {
            //Konstruktrga username va password keladi.
            userN.Trim(); // boshi va oxiridagi probellarni olib tashlash
            userP.Trim();

            if (!isLogin) // Agar user login bo'lmagan bo'lsa.
            {
                sqlText = "SELECT * FROM users WHERE user_name='" + userN + "' AND user_password='" + userP + "'";
                try
                {
                    cmd = new SqlCommand(sqlText, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Username = userN;
                        Password = userP;
                        isLogin = true;
                        userPhoto = reader.GetString(5);
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
