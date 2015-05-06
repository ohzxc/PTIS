using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["flag"] != null))
        {
            Response.Redirect("manage.aspx");
        }
        //			 在此处放置用户代码以初始化页面
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (this.txtUserName.Text == "")
        {
            Response.Write("<script>alert('请输入用户名！')</script>");
            return;
        }
        if (this.textPswd.Text == "")
        {
            Response.Write("<script>alert('请输入密码！')</script>");
            return;
        }
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Admin WHERE qmadmin_user='" + this.txtUserName.Text.Trim() + "'AND qmadmin_pass='" + this.textPswd.Text.Trim() + "'", con);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count > 0)
        {
            Session["flag"] = txtUserName.Text.Trim();
            Session.Timeout = 20;
            Response.Redirect("manage.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误！')</script>");
        }
    }
}