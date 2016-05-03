using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string caName = TextBox1.Text;
        bool b = new CategoryDAO().IsExists(caName);
        if (!b)
        {
            Response.Write(new CategoryDAO().Insert(caName));
        }
        else
        {
            Response.Write("该类别名已经存在，请重新添加！");
        }
        
    }
}