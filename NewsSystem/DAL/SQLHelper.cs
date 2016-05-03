using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLHelper
    {
        /// <summary>
        /// 该方法执行传入的SQL增删改语句
        /// </summary>
        /// <param name="sql">要执行的SQL增删改语句</param>
        /// <returns>返回更新的记录数</returns>
        public int ExecuteNonQuery(string sql)
        {
            string connStr = @"server=.\sqlexpress; database=newssystem;uid=sa;pwd=123456";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            return res;
        }

        /// <summary>
        /// 该方法执行传入的SQL查询语句
        /// </summary>
        /// <param name="sql">传入的SQL查询</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            string connStr = @"server=.\sqlexpress; database=newssystem;uid=sa;pwd=123456";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            conn.Close();
            return dt;
        }
    }
}
