using Npgsql;
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
        protected NpgsqlConnection conn;
        protected NpgsqlCommand cmd;
        protected NpgsqlDataReader reader;
        protected string sqlText;

        public ConnectDb()
        {

            string connectionstring = "Server=localhost;Port=5432;Database=CMSdb;User Id=postgres;Password=root";
            conn = new NpgsqlConnection(connectionstring);
            this.conn.Open();
        }

        ~ConnectDb()
        {
            this.conn = null;
        }

    }
}
