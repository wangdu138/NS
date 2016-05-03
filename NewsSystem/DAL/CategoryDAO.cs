using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 新闻类别表操作类
    /// </summary>
    public class CategoryDAO
    {
        private SQLHelper sqlhelper = null;
        public CategoryDAO()
        {
            sqlhelper = new SQLHelper();
        }


        /// <summary>
        /// 增加分类
        /// </summary>
        /// <param name="caName">类别名称</param>
        /// <returns></returns>
        public bool Insert(string caName)
        {
            bool flag = false;
            string sql = "Insert into category (name) values('" + caName + "')";
            int res = sqlhelper.ExecuteNonQuery(sql);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断类别名称是否已存在
        /// </summary>
        /// <param name="caName">类别名称</param>
        /// <returns></returns>
        public bool IsExists(string caName)
        {
            bool flag = false;
            string sql = "select * from category where [name]='" + caName + "'";
            DataTable dt = sqlhelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
