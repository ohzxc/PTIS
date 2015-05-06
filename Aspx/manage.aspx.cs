using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["flag"] == null))
        {
            Response.Redirect("admin.aspx");
        }        
        //			 在此处放置用户代码以初始化页面
    }
}