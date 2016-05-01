using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLHelper
    {
        public int test()
        {
            string connStr = @"server=.\sqlexpress; database=newssystem;uid=sa;pwd=123456";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "insert into category (name) values('篮球')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            return res;
        }

    }
}
