using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBcommand
    {
        /// <summary>
        /// Opent connectie
        /// </summary>
        /// <returns>een open connectie met database</returns>
        public SqlConnection OpenSqlConnection()
        {
            SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi468954_webshop;User Id=dbi468954_webshop;Password=W3elk0m;");

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// Maakt een command aan
        /// </summary>
        /// <param name="query">querry string</param>
        /// <param name="conn">connectie met database</param>
        /// <returns>geeft een database command uit</returns>
        public SqlCommand CreateCommand(string query, SqlConnection conn)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            return cmd;
        }
    }
}
