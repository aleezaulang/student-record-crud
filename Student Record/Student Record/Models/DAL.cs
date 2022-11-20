using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;  //Allows use of DataTable

namespace Intepro.DataAccess
{
    class DAL
    {
        private string cs =
            "SERVER=LAPTOP-DLA6O7LL\\SQLEXPRESS;" +
            "DATABASE=INTEPRO;" +
            "UID=admin;PWD=leez";
        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        public void Open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = cs;
                con.Open();
            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void SetSql(string sql)
        {
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.Parameters.Clear();
        }
        public void AddParam(string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value);
        }
        public void Execute()
        {
            cmd.ExecuteNonQuery();
        }

        //GetRecords not ideal for use
        public DataTable GetRecords()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public SqlDataReader GetReader()
        {
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
