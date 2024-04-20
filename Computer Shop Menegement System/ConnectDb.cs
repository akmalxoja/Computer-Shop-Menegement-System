using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Shop_Menegement_System
{

    
    internal class ConnectDb
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected string sqlText;

        public ConnectDb()
        {

            string connectionstring = "Host=localhost;Username=postgres;Password=root;Database=CMSdb";
            this.conn = new SqlConnection(connectionstring);
            this.conn.Open();
        }

        ~ConnectDb()
        {
            this.conn = null;
        }

    }
}
