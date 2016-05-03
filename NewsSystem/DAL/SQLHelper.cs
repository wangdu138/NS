using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class SQLHelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader sdr = null;

        public SQLHelper()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        private SqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// 该方法执行传入的SQL增删改语句
        /// </summary>
        /// <param name="sql">要执行的SQL增删改语句</param>
        /// <returns>返回更新的记录数</returns>
        public int ExecuteNonQuery(string sql)
        {
            int res;
            try
            {
                cmd = new SqlCommand(sql, GetConn());
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


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
            cmd = new SqlCommand(sql, GetConn());
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
    }
}
